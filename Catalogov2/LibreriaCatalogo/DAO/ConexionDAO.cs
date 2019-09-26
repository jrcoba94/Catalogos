using System.Data.SqlClient;

namespace LibreriaCatalogo.DAO
{
    public class ConexionDAO
    {
        public SqlConnection EstablecerConexion()
        {
            return new SqlConnection("Data Source = .; Initial Catalog = Productos; Integrated Security = True");
        }
    }
}
