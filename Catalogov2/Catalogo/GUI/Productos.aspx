<%@ Page Title="" Language="C#" MasterPageFile="~/src/ProductosMP.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Catalogo.GUI.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="center">
            <h4>Productos</h4>
        </div>
    </div>

    <div class="section">
        <div class="row">
            <div class="col s4">
                <div class="input-field">
                    <a style="color: lightgray" class="material-icons prefix">search</a>
                    <asp:TextBox ID="txtBusqueda" runat="server" AutoCompleteType="Disabled"></asp:TextBox>
                    <label for="first_name">Busqueda por nombre</label>
                </div>
                <asp:Button ID="btnBusqueda" runat="server" Text="Buscar" CssClass="btn btn-block waves-effect waves-light" OnClick="btnBusqueda_Click"/>
            </div>
            <div class="col s4"></div>
            <div class="col s4"></div>
        </div>
    </div>
    <div class="section">
        <div class="row">
            <asp:Button ID="btnListaC" runat="server" Text="Lista de compra" CssClass="btn btn-large blue waves-effect waves-light" OnClick="btnListaC_Click"/>
        </div>
    </div>
    <div class="section">
        <div class=" card-panel">
            <h4>Lista Productos</h4>
            <br />
            <asp:GridView ID="gvProductos" runat="server" CellPadding="4" CssClass="responsive-table centered center-align" GridLines="None" DataKeyNames="Código,Nombre,Color,Contenido,Precio,Descripción" AutoGenerateColumns="False" OnRowCommand="gvProductos_RowCommand" OnSelectedIndexChanged="gvProductos_SelectedIndexChanged">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Código" HeaderText="Código" Visible="False">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Color" HeaderText="Color">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Contenido" HeaderText="Contenido">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:$ 0.0}">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Descripción" HeaderText="Descripción">
                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>

                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Editar">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" Text="Edit" OnClick="btnEdit_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agregar">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnAddToList" runat="server" Text="Agregar" OnClick="btnAddToList_Click"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <SelectedRowStyle BackColor="#A5DDFE" Font-Bold="True" ForeColor="#8080FF" />
            </asp:GridView>
            <asp:HiddenField ID="txtId" runat="server" />
        </div>
    </div>
</asp:Content>
