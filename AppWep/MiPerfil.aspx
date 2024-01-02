<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="AppWep.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Validator{
            color:red;
            font-size: 15px;
            font-family:inherit;
        }
    </style>

     <script>
         function validar() {

             //capturar el control. 
             const txtApellido = document.getElementById("txtApellido");
             const txtNombre = document.getElementById("txtNombre");
             if (txtApellido.value == "") {
                 txtApellido.classList.add("is-invalid");
                 txtApellido.classList.remove("is-valid");
                 txtNombre.classList.add("is-valid");
                 return false;
             }
             txtApellido.classList.remove("is-invalid");
             txtApellido.classList.add("is-valid");
             return true;
         }
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Mi Perfil</h2>
    <div class="row">
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
                <asp:RequiredFieldValidator ErrorMessage="El Mail es requerido" CssClass="Validator" ControlToValidate="txtEmail" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" CssClass="form-control" ClientIDMode="Static" ID="txtNombre" />
                <%--<asp:RequiredFieldValidator ErrorMessage="El nombre es requerido" CssClass="Validator" ControlToValidate="txtNombre" runat="server" />--%>
                <%--<asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="El nombre es requerido" ControlToValidate="txtNombre" runat="server" />--%>
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox ID="txtApellido" ClientIDMode="Static" runat="server" CssClass="form-control" MaxLength="8">
                </asp:TextBox>
                <%--<asp:RegularExpressionValidator ErrorMessage="Solo numeros" CssClass="Validator" ControlToValidate="txtApellido" ValidationExpression="^[0-9]+$" runat="server" />--%>
                <%--<asp:RangeValidator ErrorMessage="Fuera de rango.." CssClass="Validator" ControlToValidate="txtApellido" Type="Integer" MinimumValue="1" MaximumValue="20" runat="server" />--%>
                <%--<asp:RegularExpressionValidator ErrorMessage="Formato email por favor" CssClass="Validator" ControlToValidate="txtApellido" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />--%>
                 
            </div>
            <div class="mb-3">
                <label class="form-label">Fecha de Nacimiento</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtFechaNacimiento" TextMode="Date" />
            </div>

        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen Perfil</label>
                <input type="file" id="txtImagen" runat="server" class="form-control" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                runat="server" CssClass="img-fluid mb-3" />

        </div>

    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" OnClientClick="return validar()"   ID="btnGuardar" runat="server" />
            <a href="/">Regresar</a>
        </div>
    </div>

</asp:Content>
