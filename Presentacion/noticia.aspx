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
            <div id="op" class="row detail-view-row">
                <div id="lb" class="col-xs-12 col-sm-4 edit-view-field">
                    <%--<input type="radio" class="form-check-input" name="Fecha" id="Fecha"  value="Fecha">--%>
                    <asp:TextBox ID="txtFecha" runat="server" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 label col-1-label">Fecha</div>
            </div> 

            <div id="op" class="row detail-view-row">
                <div id="lb" class="col-xs-12 col-sm-4 edit-view-field">
                    <%--<input type="radio" class="form-check-input" name="Codigo" id="Codigo"  value="Codigo">--%>
                    <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 label col-1-label">Codigo</div>
            </div> 

            <div id="op" class="row detail-view-row">
                <div id="lb" class="col-xs-12 col-sm-4 edit-view-field">
                    <%-- <input type="radio" class="form-check-input" name="Titulo" id="Titulo"  value="Titulo">--%>
                    <asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 label col-1-label">Titulo</div>
            </div> 

            <div id="op" class="row detail-view-row">
                <div id="lb" class="col-xs-12 col-sm-4 edit-view-field">
                    <%--<input type="radio" class="form-check-input" name="Importancia" id="Importancia"  value="Importancia">--%>
                    <asp:TextBox ID="txtImportancia" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 label col-1-label">Importancia</div>
            </div> 

            <div id="op" class="row detail-view-row">
                <div id="lb" class="col-xs-12 col-sm-4 edit-view-field">
                    <%--<input type="radio" class="form-check-input" name="Cuerpo" id="Cuerpo"  value="Cuerpo">--%>
                    <asp:TextBox ID="txtCuerpo" runat="server"></asp:TextBox>
                </div>
                <div class="col-xs-12 col-sm-4 label col-1-label">Cuerpo</div>
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
