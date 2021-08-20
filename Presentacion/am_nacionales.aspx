<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="am_nacionales.aspx.cs" Inherits="Presentacion.am_nacionales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<html>
<body>
    <div id="principal" style="text-align:center;">
        <h2 style="margin:1px;">ALTA Y MODIFICACION DE NOTICIA INTERNACIONAL</h2><br/>

        <table id="tabla_internacional" style="width:800px;margin:auto;text-align:center;">       
            <tr>
                <td class="style3">Fecha de Publicación: </td>
                <td class="style1">                
                    <asp:TextBox ID="txtfecha" class="form-control" runat="server" Width="200px" TextMode="Date"></asp:TextBox>
                </td>
                <td> </td>
            </tr>
            <tr>
                <td class="style3">Codigo: </td>
                <td class="style3">
                    <asp:TextBox  ID="txtCodigo" class="form-control" runat="server" Width="200px" ToolTip="Introduzca el código de la noticia" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" Width="102px" OnClick="btnBuscar_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3"> Titulo: </td>
                <td class="style1">
                     <asp:TextBox ID="txtTitulo" class="form-control" runat="server" Width="200px" ToolTip="Introduzca el titulo de la noticia" ></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnModificar" class="btn btn-secondary" runat="server" Text="Modificar" Width="102px" OnClick="btnModificar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
                <td class="style3"></td>
                <td>
                    <asp:Button ID="btnGuardar" class="btn btn-secondary" runat="server" Text="Guardar" Width="102px" OnClick="btnGuardar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3"> Cuerpo:</td>
                <td class="style1">
                    <asp:TextBox ID="txtCuerpo" class="form-control" runat="server" Width="400px" Height="100px" TextMode="MultiLine" ToolTip="Introduzca el cuerpo de la noticia"/>
                </td>
                <td style="text-align:center;"> Importancia: <br/>
                    <asp:DropDownList ID="ddlImportancia" class="btn btn-default" runat="server" Width="50px">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3">Sección:</td>
                <td id="td_seccion" style="text-align:left;">
                    <asp:DropDownList ID="ddlSecciones" class="btn btn-default" runat="server" Width="200px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Periodistas Disponibles: </td>
                <td style="text-align:left;">
                    <asp:DropDownList ID="ddlPeriodistasDisponibles" class="btn btn-default" runat="server" Width="200px" >
                    </asp:DropDownList>&nbsp;
                    <asp:Button ID="btnAgregar" class="btn btn-secondary" runat="server" Text="+" Width="30px" Height="30px" OnClick="btnAgregar_Click"/>&nbsp;
                    <asp:Button ID="btnQuitar" class="btn btn-secondary" runat="server" Text="-" Width="30px" Height="30px" OnClick="btnQuitar_Click"/>
                </td>
                
            </tr>
            <tr>
                <td>Periodistas Seleccionados: </td>
                <td style="text-align:left;">
                    <asp:ListBox ID="lbPeriodistasNoticia" class="form-control" runat="server"  Width="300px"></asp:ListBox>
                </td>
                <td>
                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="102px" OnClick="btnLimpiar_Click"/>
                </td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style1">
                </td>
                <td class="style1">
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
