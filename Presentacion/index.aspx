<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Presentacion.index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html xmlns="http://www.w3.org/1999/xhtml">
    <body>
        <div align="center">
            <h1 id="titulo_inicio">BIENVENDIDO</h1>
        </div><br />

        <%--<div id="grilla">
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
        </div><br/>--%>

    </body>
</html>
</asp:Content>
