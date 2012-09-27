<%@ Page Title="Wise Admin - Logon" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WiseAdmin.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login boxAzul">
        <h1 class="fonteH1">Bem Vindo</h1>
        <div class="dvCampos">        
            <label>Login:</label>
            <asp:TextBox runat="server" ID="txtLogin" MaxLength="100"></asp:TextBox>
        </div>
        <div class="dvCampos">        
            <label>Senha:</label>
            <asp:TextBox runat="server" ID="TextBox1"  TextMode="Password" MaxLength="100"></asp:TextBox>
        </div>
        <div class="btnEnviar">
            <input type="button"  class="btnPadraoAzul" style="width:100px;cursor:pointer"  value="Logar!!!"/>
        
        </div>
    </div>


</asp:Content>
