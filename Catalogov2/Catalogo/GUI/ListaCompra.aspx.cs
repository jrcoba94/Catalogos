using System;
using System.Web.UI.WebControls;
using System.Data;

namespace Catalogo.GUI
{
    public partial class ListaCompra : System.Web.UI.Page
    {
        DataTable dsCarritoDt = new DataTable();
        double Total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Carrito();
                CalcularTotal();

            }
        }

        private void Carrito()
        {
            try
            {
                if (Session["Carrito"] != null)
                {
                    this.dsCarritoDt = (dsProductos.dtCarritoDataTable)Session["Carrito"];
                }

                this.gvListaCompra.DataSource = this.dsCarritoDt;
                this.gvListaCompra.DataBind();
            }
            catch(Exception ex){ }
        }

        protected void gvListaCompra_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int Codigo = int.Parse(gvListaCompra.DataKeys[index]["Código"].ToString());
                this.dsCarritoDt = (dsProductos.dtCarritoDataTable)Session["Carrito"];
                dsCarritoDt.Rows.Remove(dsCarritoDt.Select("Código =" + Codigo)[0]);
                Session["Carrito"] = dsCarritoDt;
                gvListaCompra.DataSource = dsCarritoDt;
                gvListaCompra.DataBind();
            }

            if (e.CommandName == "Subtotal")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                TextBox txt = gvListaCompra.Rows[index].FindControl("txtCantidad") as TextBox;
                int Codigo = int.Parse(gvListaCompra.DataKeys[index]["Código"].ToString());
                int Cantidad = int.Parse(txt.Text);
                this.dsCarritoDt = (dsProductos.dtCarritoDataTable)Session["Carrito"];
                dsCarritoDt.Rows[index]["Cantidad"] = Cantidad;
                dsCarritoDt.Rows[index]["Total"] = Cantidad * Convert.ToDouble(gvListaCompra.DataKeys[index]["PrecioUnitario"]);
                Session["Carrito"] = dsCarritoDt;
                gvListaCompra.DataSource = dsCarritoDt;
                gvListaCompra.DataBind();
                
                txtTotalC.Text = CalcularTotal().ToString();
            }
        }

        public double CalcularTotal()
        {
            foreach (GridViewRow row in gvListaCompra.Rows)
            {
                Total += double.Parse(row.Cells[3].Text);
            }
            return Total;
        }

        protected void btnSeguirC_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx");
        }
    }
}
