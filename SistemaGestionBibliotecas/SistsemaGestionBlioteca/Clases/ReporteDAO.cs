using Npgsql;
using System.Data;
using SistemaDeGestionDeBiblioteca.Conexion;

namespace SistemaDeGestionDeBiblioteca.Clases
{
    // Solo lecturas: los reportes no modifican la base de datos.
    public class ReporteDAO
    {
        public const string TipoGeneral = "General";
        public const string TipoDevoluciones = "Devoluciones";
        public const string TipoReservas = "Reservas";

        // Máximo de meses que muestra el gráfico.
        private const int MaxMesesGrafico = 24;


        public record Indicadores(
            int LibrosPrestados,
            int UsuariosActivos,
            int Reservas,
            int Morosidad);


        // desde y hasta incluyen ambos días.
        public Indicadores ObtenerIndicadores(DateOnly desde, DateOnly hasta)
        {
            Permisos.RequerirGestion();
            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                // Morosidad: préstamos del período que siguen vencidos
                // o que se devolvieron con retraso.
                string sql = @"
                    SELECT
                        (SELECT COUNT(*) FROM prestamos
                         WHERE fecha_prestamo::date BETWEEN @desde AND @hasta),
                        (SELECT COUNT(*) FROM (
                             SELECT id_usuario FROM prestamos
                             WHERE fecha_prestamo::date BETWEEN @desde AND @hasta
                             UNION
                             SELECT id_usuario FROM reservas
                             WHERE fecha_reserva::date BETWEEN @desde AND @hasta
                         ) t),
                        (SELECT COUNT(*) FROM reservas
                         WHERE fecha_reserva::date BETWEEN @desde AND @hasta),
                        (SELECT COUNT(*) FROM prestamos p
                         LEFT JOIN devoluciones d ON d.id_prestamo = p.id_prestamo
                         WHERE p.fecha_prestamo::date BETWEEN @desde AND @hasta
                           AND ((p.estado = 'Activo' AND p.fecha_vencimiento < CURRENT_DATE)
                                OR d.dias_retraso > 0))";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@desde", desde);
                    comando.Parameters.AddWithValue("@hasta", hasta);

                    using (NpgsqlDataReader lector = comando.ExecuteReader())
                    {
                        lector.Read();

                        return new Indicadores(
                            Convert.ToInt32(lector[0]),
                            Convert.ToInt32(lector[1]),
                            Convert.ToInt32(lector[2]),
                            Convert.ToInt32(lector[3])
                        );
                    }
                }
            }
        }


        // Cantidad por mes. Muestra desde enero del año de "hasta"
        // (o desde el mes de "desde" si es anterior), hasta el mes de "hasta".
        public DataTable ObtenerSerieMensual(
            string tipo,
            DateOnly desde,
            DateOnly hasta)
        {
            Permisos.RequerirGestion();
            DateOnly inicio = new DateOnly(hasta.Year, 1, 1);

            if (desde < inicio)
                inicio = new DateOnly(desde.Year, desde.Month, 1);

            DateOnly limite = new DateOnly(hasta.Year, hasta.Month, 1)
                .AddMonths(-(MaxMesesGrafico - 1));

            if (inicio < limite)
                inicio = limite;


            (string origen, string fecha, string libro) = Origen(tipo);

            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    WITH meses AS (
                        SELECT generate_series(
                                   date_trunc('month', @inicio::date),
                                   date_trunc('month', @hasta::date),
                                   interval '1 month')::date AS mes)
                    SELECT m.mes, COUNT(x.fecha) AS cantidad
                    FROM meses m
                    LEFT JOIN (SELECT " + fecha + @" AS fecha FROM " + origen + @") x
                           ON date_trunc('month', x.fecha)::date = m.mes
                    GROUP BY m.mes
                    ORDER BY m.mes";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@inicio", inicio);
                    comando.Parameters.AddWithValue("@hasta", hasta);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        public DataTable ObtenerTopLibros(
            string tipo,
            DateOnly desde,
            DateOnly hasta,
            int cantidad)
        {
            Permisos.RequerirGestion();
            (string origen, string fecha, string libro) = Origen(tipo);

            DataTable tabla = new DataTable();

            using (NpgsqlConnection conexion = ConexionBD.ObtenerConexion())
            {
                conexion.Open();

                string sql = @"
                    SELECT
                        l.titulo,
                        COUNT(*) AS veces,
                        c.nombre AS categoria
                    FROM " + origen + @"
                    INNER JOIN libros l ON l.id_libro = " + libro + @"
                    INNER JOIN categorias c ON c.id_categoria = l.id_categoria
                    WHERE " + fecha + @"::date BETWEEN @desde AND @hasta
                    GROUP BY l.id_libro, l.titulo, c.nombre
                    ORDER BY veces DESC, l.titulo
                    LIMIT @cantidad";

                using (NpgsqlCommand comando = new NpgsqlCommand(sql, conexion))
                {
                    comando.Parameters.AddWithValue("@desde", desde);
                    comando.Parameters.AddWithValue("@hasta", hasta);
                    comando.Parameters.AddWithValue("@cantidad", cantidad);

                    NpgsqlDataAdapter adaptador = new NpgsqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
            }

            return tabla;
        }


        // Fragmentos fijos de SQL (no vienen del usuario) según el tipo de reporte.
        private static (string origen, string fecha, string libro) Origen(string tipo)
        {
            switch (tipo)
            {
                case TipoDevoluciones:
                    return (
                        "devoluciones d INNER JOIN prestamos p ON p.id_prestamo = d.id_prestamo",
                        "d.fecha_devolucion",
                        "p.id_libro"
                    );

                case TipoReservas:
                    return (
                        "reservas r",
                        "r.fecha_reserva",
                        "r.id_libro"
                    );

                default:
                    return (
                        "prestamos p",
                        "p.fecha_prestamo",
                        "p.id_libro"
                    );
            }
        }
    }
}
