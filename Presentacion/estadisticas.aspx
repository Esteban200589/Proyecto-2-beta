<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="estadisticas.aspx.cs" Inherits="Presentacion.estadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div style="text-align:center;">
        <h2>ESTADISTICAS DE NOTICIAS</h2><br/>
        <div id="filtros">
            <asp:DropDownList ID="ddlTipo" runat="server" Width="150px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged">
                <asp:ListItem Value="0">Seleccionar</asp:ListItem>
                <asp:ListItem Value="1">Todas</asp:ListItem>
                <asp:ListItem Value="2">Nacionales</asp:ListItem>
                <asp:ListItem Value="3">Internacionales</asp:ListItem>
            </asp:DropDownList>
            <asp:Button ID="btnCantAnual" runat="server" Text="Cantidad Anual" OnClick="btnCantAnual_Click" />
            <asp:Button ID="btnLimpiarfiltros" runat="server" Text="Limpiar Filtros"  Width="150px"/>     
        </div></br>

        <div id="grilla">
            <%--<asp:Xml ID="XmlListar" runat="server" TransformSource="~/App_Code/estadisticas.xslt"></asp:Xml>--%>
            
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
        
        <div style="text-align:center;">                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label> 
            <br/><br/>
            <a href="index.aspx">Volver</a>
        </div><br/>
    </div>

</body>
</html>
</asp:Content>