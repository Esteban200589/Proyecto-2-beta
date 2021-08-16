<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="estadisticas.aspx.cs" Inherits="Presentacion.estadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id="principal" align="center">
        <h2 style="margin:1px;">ESTADISTICAS DE NOTICIAS</h2><br/>

        <div id="grilla">
            <asp:GridView ID="gvNoticias" runat="server" Width="85%" HorizontalAlign="Center" BackColor="White" BorderColor="#CCCCCC"
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
        </div><br/>
        
        <div>                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
        </div><br/>

        <br/>
        <a href="default.aspx">Volver</a>
    </div>

</body>
</html>
</asp:Content>
