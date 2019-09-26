<%@ Page Title="" Language="C#" MasterPageFile="~/src/ProductosMP.Master" AutoEventWireup="true" CodeBehind="ModProducto.aspx.cs" Inherits="Catalogo.GUI.ModProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="section">
        <div class="row col s12">
            <div class="input-field">
                <asp:hiddenfield id="txtId" runat="server" />
            </div>
            <div class="input-field">
                <asp:textbox id="txtNombreP" runat="server" cssclass="validate" autocompletetype="Disabled" autopostback="false"></asp:textbox>
                <label for="first_name">Nombre</label>
            </div>
            <div class="input-field">
                <asp:textbox id="txtColor" runat="server" cssclass="validate" autocompletetype="Disabled" autopostback="false"></asp:textbox>
                <label for="first_name">Color</label>
            </div>
            <div class="input-field">
                <asp:textbox id="txtContenido" runat="server" cssclass="validate" autocompletetype="Disabled" autopostback="false"></asp:textbox>
                <label for="first_name">Cantidad</label>
            </div>
            <div class="input-field">
                <asp:textbox id="txtPrecio" runat="server" cssclass="validate" autocompletetype="Disabled" autopostback="false"></asp:textbox>
                <label for="first_name">$ 000,00</label>
            </div>
            <div class="input-field">
                <asp:textbox id="txtDescripcionP" runat="server" cssclass="validate " autocompletetype="Disabled" autopostback="false"></asp:textbox>
                <label for="last_name">Descripción</label>
            </div>
        </div>
        <div class="row">
            <div class="col s3"></div>
            <div class="col s6 row">
                <asp:Button ID="btnModificar" runat="server" Text="Guardar" CssClass="btn btn-large blue waves-effect waves-light" OnClick="btnModificar_Click"/>
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-large blue waves-effect waves-light" OnClick="btnCancelar_Click"/>
            </div>
            <div class="col s3"></div>
        </div>
    </div>

    <script>
        $(document).ready(function () {
            $("#ContentPlaceHolder1_txtContenido").mask('0000');
            $("#ContentPlaceHolder1_txtPrecio").mask("##.##0,00", { reverse: true });
        });
    </script>
</asp:Content>
