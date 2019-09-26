<%@ Page Title="" Language="C#" MasterPageFile="~/src/ProductosMP.Master" AutoEventWireup="true" CodeBehind="ListaCompra.aspx.cs" Inherits="Catalogo.GUI.ListaCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section center">
        <h4>Lista de compra</h4>
    </div>
    <div class="section">
        <div class="row">
            <asp:Button ID="btnSeguirC" runat="server" Text="Agregar más" CssClass="btn btn-large blue waves-effect waves-light" OnClick="btnSeguirC_Click" />
        </div>
    </div>
    <div class="section">
        <asp:GridView ID="gvListaCompra" runat="server" CellPadding="4" CssClass="responsive-table" GridLines="None" DataKeyNames="Código,PrecioUnitario" AutoGenerateColumns="false" ForeColor="#333333" OnRowCommand="gvListaCompra_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Producto" />

                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%#Eval("Cantidad")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText="Precio Unitario" DataField="PrecioUnitario" DataFormatString="{0:C}" />
                <asp:BoundField HeaderText="Sub-Total" DataField="Total" DataFormatString="{0:C}" />

                <asp:ButtonField Text="Calcular" HeaderText="Calcular Subtotal" CommandName="Subtotal" />
                <asp:ButtonField Text="Eliminar" HeaderText="Quitar" CommandName="Eliminar" />
            </Columns>

            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="true" ForeColor="#333333" />
        </asp:GridView>
    </div>

    <div class="section">
        <div class="row">
            <div class="input-field">
                <label>Total:</label>
                <asp:TextBox ID="txtTotalC" runat="server" Enabled="false"></asp:TextBox>
            </div>
        </div>
    </div>
</asp:Content>
