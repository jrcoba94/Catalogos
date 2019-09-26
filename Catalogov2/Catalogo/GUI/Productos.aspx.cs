using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LibreriaCatalogo.BO;
using LibreriaCatalogo.DAO;

namespace Catalogo.GUI
{
    public partial class Productos : System.Web.UI.Page
    {
        ProductoBO oProductoBO;
        ProductoDAO oProductoDAO;

        protected void Page_Load(object sender, EventArgs e)
        {
            oProductoBO = new ProductoBO();
            oProductoDAO = new ProductoDAO();

            FacadeMth("Listar");
        }

        public ProductoBO InterfaceToData()
        {
            oProductoBO.Id = Convert.ToInt32(txtId.Value);

            return oProductoBO;
        }

        private void FacadeMth(string accion)
        {
            switch (accion)
            {
                case "Listar":
                    Listado();
                    break;
                case "Eliminar":
                    Elimina();
                    break;
                case "Limpia":
                    Limpiar();
                    break;
            }
        }

        public void Elimina()
        {
            ProductoBO oprod = InterfaceToData();
            if (oprod.Id > 0)
            {
                oProductoDAO.EliminarProducto(oprod);
            }

            FacadeMth("Listar");
        }

        public void Listado()
        {
            dsProductosTableAdapters.ProductoTableAdapter prod = new dsProductosTableAdapters.ProductoTableAdapter();
            gvProductos.DataSource = prod.GetData();
            gvProductos.DataBind();
        }

        public void Limpiar()
        {
            txtId.Value = "";
            txtBusqueda.Text = "";
        }

        protected void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dsProductosTableAdapters.ProductoTableAdapter prod = new dsProductosTableAdapters.ProductoTableAdapter();
            gvProductos.DataSource = prod.GetDataByName(txtBusqueda.Text);
            gvProductos.DataBind();
        }

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow gvrow = (GridViewRow)btn.NamingContainer;
            int index = gvrow.RowIndex;
            txtId.Value = gvProductos.DataKeys[index]["Id"].ToString();
            FacadeMth("Eliminar");
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton btnAdd = sender as LinkButton;
            GridViewRow gvr = (GridViewRow)btnAdd.NamingContainer;
            int index = gvr.RowIndex;
            int idProd = 0;
            string Nombre = "";
            string Color = "";
            string Desc = "";
            string Contenido = "";
            string Precio = "";
            try
            {
                int.TryParse(gvProductos.DataKeys[index]["Código"].ToString(), out idProd);
                Nombre = gvProductos.DataKeys[index]["Nombre"].ToString();
                Color = gvProductos.DataKeys[index]["Color"].ToString();
                Contenido = gvProductos.DataKeys[index]["Contenido"].ToString();
                Precio = gvProductos.DataKeys[index]["Precio"].ToString();
                Desc = gvProductos.DataKeys[index]["Descripción"].ToString();

                dsProductos.dtProductoDataTable dt = new dsProductos.dtProductoDataTable();
                dt.Rows.Add(idProd, Nombre, Color, Contenido, Precio, Desc);
                Session["dtProductosEdit"] = dt;
                Response.Redirect("ModProducto.aspx");
            }
            catch
            {

            }
        }

        protected void btnAddToList_Click(object sender, EventArgs e)
        {
            LinkButton btnAdd = sender as LinkButton;
            GridViewRow gvr = (GridViewRow)btnAdd.NamingContainer;
            int index = gvr.RowIndex;
            int Codigo = 0;
            double total = 0;
            string Nombre = "";
            try
            {
                Codigo = int.Parse(gvProductos.DataKeys[index]["Código"].ToString());
                total = double.Parse(gvProductos.DataKeys[index]["Precio"].ToString());
                Nombre = gvProductos.DataKeys[index]["Nombre"].ToString();

                if(Session["Carrito"] != null)
                {
                    dsProductos.dtCarritoDataTable dt = (dsProductos.dtCarritoDataTable)Session["Carrito"];
                    if (dt.Select("Código =" + Codigo).Length <= 0)
                    {
                        dt.Rows.Add(Codigo, Nombre, 1, total, total);
                        Session["Carrito"] = dt;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", string.Format("<script> alert('El producto ya se encuentra en la lista!'); </script>"));
                        //Session["Carrito"] = dt;
                    }
                }
                else
                {
                    dsProductos.dtCarritoDataTable dt = new dsProductos.dtCarritoDataTable();
                    if(dt.Select("Código = "+Codigo).Length <= 0)
                    {
                        dt.Rows.Add(Codigo, Nombre, 1, total, total);
                        Session["Carrito"] = dt;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(Page.GetType(), "Mensaje", string.Format("<script> alert('El producto ya se encuentra en la lista!');</script>"));
                        //Session["Carrito"] = dt;
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        protected void btnListaC_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaCompra.aspx");
        }

        protected void btnBusqueda_Click(object sender, EventArgs e)
        {
            dsProductosTableAdapters.ProductoTableAdapter prod = new dsProductosTableAdapters.ProductoTableAdapter();
            gvProductos.DataSource = prod.GetDataByName(txtBusqueda.Text);
            gvProductos.DataBind();
        }
    }
}