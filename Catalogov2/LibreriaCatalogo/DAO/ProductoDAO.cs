using System;
using System.Data;
using System.Data.SqlClient;
using LibreriaCatalogo.BO;

namespace LibreriaCatalogo.DAO
{
    public class ProductoDAO
    {
        SqlConnection conn;
        ConexionDAO conexion = new ConexionDAO();

        public ProductoDAO()
        {
            conn = conexion.EstablecerConexion();
        }

        public int Ejecutarsql(SqlCommand cmd)
        {
            int resultado = 0;

            try
            {
                cmd.Connection.Open();
                resultado = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return resultado;
            }
            catch (Exception)
            {
                cmd.Connection.Close();
                return resultado;
            }
        }

        public int AgregarProducto(ProductoBO obj)
        {
            string sql = "INSERT INTO Producto(Nombre,Color,Contenido,Precio,Descripcion) values(@Nombre,@Color,@Contenido,@Precio,@Descripcion)";
            SqlCommand cmd1 = new SqlCommand(sql, conn);

            cmd1.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar));
            cmd1.Parameters.Add(new SqlParameter("@Color", SqlDbType.VarChar));
            cmd1.Parameters.Add(new SqlParameter("@Contenido", SqlDbType.VarChar));
            cmd1.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal));
            cmd1.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar));

            cmd1.Parameters["@Nombre"].Value = obj.Nombre;
            cmd1.Parameters["@Color"].Value = obj.Color;
            cmd1.Parameters["@Contenido"].Value = obj.Cantidad;
            cmd1.Parameters["@Precio"].Value = obj.Precio;
            cmd1.Parameters["@Descripcion"].Value = obj.Descripcion;

            return Ejecutarsql(cmd1);
        }

        public int ActualizarProducto(ProductoBO obj)
        {
            string sql = "UPDATE Producto SET Nombre = @Nombre,Color = @Color,Contenido = @Contenido,Precio = @Precio,Descripcion = @Descripcion where Id = @Id";
            SqlCommand cmd2 = new SqlCommand(sql, conn);

            cmd2.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = obj.Id;
            cmd2.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar)).Value = obj.Nombre;
            cmd2.Parameters.Add(new SqlParameter("@Color", SqlDbType.VarChar)).Value = obj.Color;
            cmd2.Parameters.Add(new SqlParameter("@Contenido", SqlDbType.VarChar)).Value = obj.Cantidad;
            cmd2.Parameters.Add(new SqlParameter("@Precio", SqlDbType.Decimal)).Value = obj.Precio;
            cmd2.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.VarChar)).Value = obj.Descripcion;
            
            return Ejecutarsql(cmd2);
        }

        public int EliminarProducto(ProductoBO obj)
        {
            string sql = "DELETE Producto WHERE Id = @Id";
            SqlCommand cmd3 = new SqlCommand(sql, conn);

            cmd3.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = obj.Id;

            return Ejecutarsql(cmd3);
        }

        public DataTable DevuelveProductos()
        {
            try
            {
                string sql = "select * from Producto";
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
            catch
            {
                DataTable dt = new DataTable();
                return dt;
            }
        }
    }
}