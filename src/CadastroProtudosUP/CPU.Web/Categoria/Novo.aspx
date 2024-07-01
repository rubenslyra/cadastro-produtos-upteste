<%@ Page Title="Nova Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Novo.aspx.cs" Inherits="CPU.Web.Views.Categoria.Novo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Nova Categoria</h2>
    <!-- Formulário para nova categoria -->
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" AssociatedControlID="txtNome" /><br />
        <asp:TextBox ID="txtNome" runat="server" /><br />
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" /><br />
        <asp:TextBox ID="txtDescricao" runat="server" /><br />
    </div>
    <br />
    <asp:Button ID="btnSalvar" runat="server" Text="Salvar" OnClick="btnSalvar_Click" />
    <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Views/Categoria/Listagem.aspx" Text="Cancelar" />
</asp:Content>
