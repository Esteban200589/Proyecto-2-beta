<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="Presentacion._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Pagina de Inicio</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>PAGINA INICIAL (CONSULTA DE NOTICIAS)<b> Default</b> <a href="login.aspx" 
                style="float:right;position:absolute;right:10%;">LOGIN</a></p>
        </div>
        <br />

        Filtros de Busqueda:
        <table style="width: 100%;">
            <tr>
                <td style="text-align:right;">
                    <div id="tipos" class="col-3">
                        <asp:DropDownList ID="ddlTipo" runat="server" Width="150px">
                            <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                            <asp:ListItem Value="1">Todas</asp:ListItem>
                            <asp:ListItem Value="2">Nacionales</asp:ListItem>
                            <asp:ListItem Value="3">Internacionales</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <%--<td style="text-align:center;">
                    <div id="select" class="col-3">
                        <asp:Button ID="btnSelect" runat="server" Text="Seleccionar" Width="100px" OnClick="btnSelect_Click" />
                    </div>
                </td>--%>
                <td style="text-align:center;">
                    <div id="seccion" class="col-3">
                        <asp:DropDownList ID="ddlSeccion" runat="server" Width="150px">
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </td>
                <td style="text-align:left;">
                    <%--<div id="limpiar" class="col-3">
                        <asp:Button ID="btnLimpiarfiltros" runat="server" Text="Limpiar Filtros"  Width="150px" OnClick="btnLimpiarfiltros_Click"/>
                    </div>--%>
                    <div id="buscar" class="col-3">
                        <asp:Button ID="btnBuscar" runat="server" Text="Filtrar" Width="150px" OnClick="btnBuscar_Click" />
                    </div>
                </td>
            </tr>
        </table>
        <br />

        <div id="grilla">
            <asp:GridView ID="gvNoticias" runat="server" Width="85%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                          BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" OnSelectedIndexChanged="gvNoticias_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" HeaderStyle-BackColor="Black" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" HeaderStyle-BackColor="Black" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center"/>
                    <asp:BoundField DataField="Titulo" HeaderText="Titulo" HeaderStyle-BackColor="Black" ItemStyle-BackColor="White" ItemStyle-HorizontalAlign="Center"/>
                    <asp:CommandField ShowSelectButton="True" 
                        AccessibleHeaderText="Ver" SelectText="Ver" >
                        <ControlStyle BackColor="Transparent" ForeColor="Red" />
                        <HeaderStyle BackColor="Black" />
                        <ItemStyle BackColor="White" HorizontalAlign="Center" />
                    </asp:CommandField>
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div><br/>
        
        

        <div style="text-align:center;">                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
        </div><br/>

        <%--<div id="lista">
            <asp:ListBox ID="lbNoticias" runat="server" Width="200"></asp:ListBox>
        </div>--%>

        
    </form>
</body>
</html>
