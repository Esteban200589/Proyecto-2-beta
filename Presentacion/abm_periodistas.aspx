<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="abm_periodistas.aspx.cs" Inherits="Presentacion.abm_periodistas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="principal" align="center">
        <h2 style="margin:1px;">ABM PERIODISTAS</h2><br/>

        <table id="tabla_periodistas" style="width:800px;margin:auto;" align="center">
            <tr>                <td class="style3">Cedula:</td>
                <td class="style1">
                     <asp:TextBox ID="txtCedula" class="form-control" runat="server" Width="210px" 
                         ToolTip="Cedula o documento del periodista" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" Width="102px" OnClick="btnBuscar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3">Nombre Completo:</td>
                <td class="style1">
                    <asp:TextBox ID="txtNombre" class="form-control" runat="server" Width="210px" 
                        ToolTip="Introduzca el nombre completo del periodista" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModificar" class="btn btn-secondary" runat="server" Text="Modificar" Width="102px" OnClick="btnModificar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3"> Email:</td>
                <td class="style1">
                    <asp:TextBox ID="txtEmail" class="form-control" runat="server" Width="210px" 
                        ToolTip="Introduzca el email del periodista" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGuardar" class="btn btn-secondary" runat="server" Text="Guardar" Width="102px" OnClick="btnGuardar_Click"/>
                </td>
            </tr>
            
            <tr>
                <td class="style3"></td>
                <td class="style3"></td>
                <td>
                    <asp:Button ID="btnEliminar" class="btn btn-secondary" runat="server" Text="Eliminar" Width="102px" OnClick="btnEliminar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style1">
                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="210px" OnClick="btnLimpiar_Click"/>
                </td>
                <td>
                </td>
            </tr>
        </table><br/>
        
        <div>                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
        </div><br/>

        <br/>
        <a href="index.aspx">Volver</a>
    </div>

</body>
</html>
</asp:Content>