<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Presentacion.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="text-align:center; width:720px;max-width:720px; opacity:75%; padding:1%;">
        <div class="row">
            <div class="col-md-6 mx-auto">

                <div class="card">
                     <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h3>Login</h3>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <asp:TextBox runat="server" id="txtUser" class="form-control" 
                                placeholder="Username" ToolTip="Username"></asp:TextBox>
                        </div><br />
                        <div class="row">
                            <asp:TextBox runat="server" id="txtPass" class="form-control" 
                                placeholder="Password" TextMode="Password" ToolTip="Password"></asp:TextBox>
                        </div><br /><br />
                        <div class="row">
                            <div style="text-align:center; margin:auto;">
                                <asp:Button runat="server" id="btnLogin" type="submit" class="btn btn-secondary" text="Login" 
                                    style="margin-left:auto; margin-right:auto;" OnClick="btnLogin_Click"/>
                                <asp:Button runat="server" id="btnVolver" type="submit" class="btn btn-secondary" text="Volver" 
                                    style="margin-left:auto; margin-right:auto;" OnClick="btnVolver_Click"/>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>

        <div>                   
            <asp:Label id="lblMsj" for="exampleFormControlInput1" runat="server"></asp:Label>                  
        </div><br/>
    </div>
    </form>
</body>
</html>
