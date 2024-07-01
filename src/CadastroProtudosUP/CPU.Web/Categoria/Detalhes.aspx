<%@ Page Title="Detalhes da Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="CPU.Web.Views.Categoria.Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalhes da Categoria</h2>
    <!-- Exibir detalhes da categoria -->
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" AssociatedControlID="txtNome" /><br />
        <asp:TextBox ID="txtNome" runat="server" ReadOnly="true" /><br />
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" /><br />
        <asp:TextBox ID="txtDescricao" runat="server" ReadOnly="true" /><br />
    </div>
    <br />
    <asp:HyperLink ID="lnkVoltar" runat="server" NavigateUrl="~/Views/Categoria/Listagem.aspx" Text="Voltar à Listagem" />
</asp:Content>
