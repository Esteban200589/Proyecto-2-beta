<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="noticia.aspx.cs" Inherits="Presentacion.noticia" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Datos Noticia</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="noticia">
        <div class="modal-dialog modal-md">       
            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Fecha</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" ReadOnly="True"></asp:TextBox>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Codigo</div>
                <div class ="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Titulo</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtTitulo" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Cuerpo</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtCuerpo" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Importancia</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtImportancia" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Periodistas</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:GridView ID="gvPeriodistas" runat="server"></asp:GridView>
                </div>
            </div> 

            <div class="row detail-view-row">
                <div class="col-xs-12 col-sm-4 label col-1-label">Usuario</div>
                <div class="col-xs-12 col-sm-4 edit-view-field">
                    <asp:TextBox ID="txtUsuario" runat="server" ReadOnly="True"></asp:TextBox>
                </div>
            </div>

        </div>
    </div>

    <div>                   
        <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
    </div><br/>

    <br/>
    <a href="default.aspx">Volver</a>

    </form>
</body>
</html>
