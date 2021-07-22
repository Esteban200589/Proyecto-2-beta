<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="alta_empleado.aspx.cs" Inherits="Presentacion.alta_empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="principal" align="center">
        <h2 style="margin:1px;">ABM EMPLEADOS</h2><br/>

        <table id="tabla_usuarios" style="width:800px;margin:auto;" align="center">
            <tr>
                <td class="style3"> Username:</td>
                <td class="style1">
                     <asp:TextBox ID="txtUsername" class="form-control" runat="server" Width="210px" 
                         ToolTip="Nombre de Usuario" ></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="style3"> Password:</td>
                <td class="style1">
                    <asp:TextBox ID="txtPassword" class="form-control" runat="server" Width="210px" 
                        TextMode="Password" ToolTip="Introduzca su Password" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnGuardar" class="btn btn-secondary" runat="server" Text="Guardar" Width="102px" OnClick="btnGuardar_Click"/>
                </td>
            </tr>
            
            
            <tr>
                <td class="style3"></td>
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
        <a href="default.aspx">Volver</a>
    </div>

</body>
</html>
</asp:Content>
