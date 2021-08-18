<%@ Page Title="" Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="am_nacionales.aspx.cs" Inherits="Presentacion.am_nacionales" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<html>
<body>
    <div id="principal" align="center">
        <h2 style="margin:1px;">ALTA Y MODIFICACION DE NOTICIA INTERNACIONAL</h2><br/>

        <table id="tabla_internacional" style="width:800px;margin:auto;" align="center">
          
            <tr>
                <td class="style3">Fecha de Publicación: </td>
                <td class="style1">                
                    <asp:TextBox ID="txtfecha" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td> Codigo: </br>
                    <asp:TextBox  ID="txtCodigo" class="form-control" runat="server" Width="100px" 
                         ToolTip="Introduzca el código de la noticia" ></asp:TextBox>
                </td>
            </tr>
                <td class="style3"></td>
                <td class="style3"></td>
                <td>
                    <asp:Button ID="btnBuscar" class="btn btn-secondary" runat="server" Text="Buscar" Width="102px" OnClick="btnBuscar_Click" />
                </td>
            <tr>
                <td class="style3"> Titulo: </td>
                <td class="style1">
                     <asp:TextBox ID="txtTitulo" class="form-control" runat="server" Width="210px" 
                         ToolTip="Introduzca el titulo de la noticia" ></asp:TextBox>
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
                    <asp:TextBox ID="txtCuerpo" class="form-control" runat="server" Width="400px" Height="100px"
                        TextMode="MultiLine" ToolTip="Introduzca el cuerpo de la noticia"/>
                </td>
                <td> Importancia: <br/>
                    <asp:DropDownList ID="ddlImportancia" runat="server">
                        <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="2">2</asp:ListItem>
                        <asp:ListItem Value="3">3</asp:ListItem>
                        <asp:ListItem Value="4">4</asp:ListItem>
                        <asp:ListItem Value="5">5</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>

            <tr>
                <td class="style3"> Periodistas: </td>
                <td class="style1">
                    <div style="width:100%;display:flex;justify-content:space-between;">
                        <asp:GridView ID="gvPeriodistasSeleccion" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                      CellPadding="1" ForeColor="Black" GridLines="Vertical" Width="40%" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPeriodistasSeleccion_SelectedIndexChanged">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField HeaderText="Periodista" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                        
                    </div>
                </td>
                <td >
                    <div style="width:100%;display:flex;justify-content:space-between;">
                        <asp:GridView ID="gvPeriodistasElegidos" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                      CellPadding="1" ForeColor="Black" GridLines="Vertical" Width="40%" AutoGenerateColumns="False">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:BoundField HeaderText="Elegidos" />
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>
            <tr>
                <td class="style3">Sección:</td>
                <td id="td_seccion">
                    <asp:DropDownList ID="ddlSecciones" class="form-control" runat="server" Width="210px" >
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style3"></td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style1">
                    
                </td>
                <td>
                    <asp:Button ID="btnLimpiar" class="btn btn-secondary" runat="server" Text="Limpiar" Width="210px" OnClick="btnLimpiar_Click"/>
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
