using Microsoft.Data.SqlClient;

namespace Infrastructure.Data
{
    public static class BadDb
    {
        // Propiedad estática para la cadena de conexión
        public static string ConnectionString { get; set; } =
            "Server=localhost;Database=master;User Id=demo;Password=Demo123!;TrustServerCertificate=True";

        public static int ExecuteNonQuery(string sql, SqlParameter[] parameters)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            conn.Open();
            return cmd.ExecuteNonQuery();
        }
    }
}