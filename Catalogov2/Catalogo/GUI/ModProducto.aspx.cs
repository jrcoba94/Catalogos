using System;
using System.Data;
using LibreriaCatalogo.BO;
using LibreriaCatalogo.DAO;

namespace Catalogo.GUI
{
    public partial class ModProducto : System.Web.UI.Page
    {
        ProductoBO oProductoBO;
        ProductoDAO oProductoDAO;

        protected void Page_Load(object sender, EventArgs e)
        {
            oProductoBO = new ProductoBO();
            oProductoDAO = new ProductoDAO();

            if (Session["dtProductosEdit"] != null && !IsPostBack)
            {
                dsProductos.dtProductoDataTable dt = (dsProductos.dtProductoDataTable)Session["dtProductosEdit"];
                foreach (DataRow dr in dt.Rows)
                {
                    txtId.Value = dr["Código"].ToString();
                    txtNombreP.Text = dr["Nombre"].ToString();
                    txtColor.Text = dr["Color"].ToString();
                    txtContenido.Text = dr["Contenido"].ToString();
                    txtPrecio.Text = dr["Precio"].ToString();
                    txtDescripcionP.Text = dr["Descripción"].ToString();
                }
            }
            
        }

        public ProductoBO InterfaceToData()
        {

            oProductoBO.Id = Convert.ToInt32(txtId.Value);
            oProductoBO.Nombre = txtNombreP.Text;
            oProductoBO.Color = txtColor.Text;
            oProductoBO.Cantidad = txtContenido.Text;
            oProductoBO.Precio = Convert.ToDecimal(txtPrecio.Text);
            oProductoBO.Descripcion = txtDescripcionP.Text;

            return oProductoBO;
        }

        private void FacadeMth(string accion)
        {
            switch (accion)
            {
                case "Guardar":
                    Agregar();
                    break;
                case "Eliminar":
                    Elimina();
                    break;
                case "Modifica":
                    Modificar();
                    break;
                case "Limpia":
                    Limpiar();
                    break;
            }
        }

        public void Agregar()
        {
            ProductoBO oProd = InterfaceToData();
            if (oProd.Id == 0)
            {
                oProductoDAO.AgregarProducto(oProd);
            }

            FacadeMth("Limpia");
        }

        public void Modificar()
        {
            ProductoBO oprod = InterfaceToData();
            if (oprod.Id > 0)
            {
                oProductoDAO.ActualizarProducto(oprod);
            }

            FacadeMth("Limpia");
        }

        public void Elimina()
        {
            ProductoBO oprod = InterfaceToData();
            if (oprod.Id > 0)
            {
                oProductoDAO.EliminarProducto(oprod);
            }

            FacadeMth("Limpia");
        }

        public void Limpiar()
        {
            txtId.Value = "";
            txtNombreP.Text = "";
            txtColor.Text = "";
            txtContenido.Text = "";
            txtPrecio.Text = "";
            txtDescripcionP.Text = "";
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            Response.Redirect("../GUI/Productos.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            FacadeMth("Modifica");
            FacadeMth("Limpia");
            Response.Redirect("../GUI/Productos.aspx");
        }
    }
}