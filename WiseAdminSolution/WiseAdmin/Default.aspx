<%@ Page Title="Wise Admin - Logon" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WiseAdmin.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="scripts/ajax/ScriptMaster.js" ></script>
    <script src="scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="scripts/jqueryui/js/jquery-ui-1.8.23.custom.min.js" type="text/javascript"></script>
    <link href="scripts/jqueryui/css/cupertino/jquery-ui-1.8.23.custom.css" rel="stylesheet"
        type="text/css" />
    <script  type="text/javascript">

        $.fx.speeds._default = 1000;
        $(document).ready(function () {
            $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                show: "blind",
                hide: "explode",
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager  runat="server" ID="ScriptManager1" EnablePageMethods="true" ></asp:ScriptManager>
<asp:UpdatePanel runat="server" ID="updata"  UpdateMode="Always">
<ContentTemplate>
    <div class="login boxAzul">
        <h1 class="fonteH1">Bem Vindo</h1>
        <div class="dvCampos">        
            <label>Login:</label>
            <asp:TextBox runat="server" ID="txtLogin" MaxLength="100"></asp:TextBox>
        </div>
        <div class="dvCampos">        
            <label>Senha:</label>
            <asp:TextBox runat="server" ID="txtSenha"  TextMode="Password" MaxLength="100"></asp:TextBox>
        </div>
        <div class="btnEnviar">
            
            <asp:Button runat="server" ID="btnLogar"  CssClass="btnPadraoAzul" Width="100" 
                Text="Logar!!" OnClientClick="return validaLogon();" onclick="btnLogar_Click"/>
        </div>
        <div>
            <asp:UpdateProgress DisplayAfter="0" AssociatedUpdatePanelID="updata" runat="server">
            
                <ProgressTemplate>
                
                    <img src="images/ajax-loader.gif"  alt="loading"/>
                
                </ProgressTemplate>
            
            </asp:UpdateProgress>
        
        </div>

    </div>
    
</ContentTemplate>

</asp:UpdatePanel>
<div id="dialog-message" title="Error Message" >
	<p>
		<span class="ui-icon ui-icon-alert" style="float:left; margin:0 7px 50px 0;"></span>
		

	</p>
	<div id="textoMsg">Favor Preencher usuário e senha para efetuar logon!!</div>
</div>
<script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
        $("#dialog-message").dialog({
                modal: true,
                autoOpen: false,
                show: "blind",
                hide: "explode",
                buttons: {
                    Ok: function () {
                        $(this).dialog("close");
                    }
                }
            });

        }
       


</script>
</asp:Content>
