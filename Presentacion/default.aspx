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

        <div id="grilla">
            <asp:GridView ID="gvNoticias" runat="server" Width="400px" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
                          BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
        </div>

        <%--<div id="lista">
            <asp:ListBox ID="lbNoticias" runat="server" Width="200"></asp:ListBox>
        </div>--%>

        
    </form>
</body>
</html>
