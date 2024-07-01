<%@ Page Title="Detalhes do Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalhes.aspx.cs" Inherits="CPU.Web.Views.Produto.Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalhes do Produto</h2>
    <!-- Exibir detalhes do produto -->
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" AssociatedControlID="txtNome" /><br />
        <asp:TextBox ID="txtNome" runat="server" ReadOnly="true" /><br />
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" /><br />
        <asp:TextBox ID="txtDescricao" runat="server" ReadOnly="true" /><br />
        <asp:Label ID="lblPreco" runat="server" Text="Preço:" AssociatedControlID="txtPreco" /><br />
        <asp:TextBox ID="txtPreco" runat="server" ReadOnly="true" /><br />
        <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade:" AssociatedControlID="txtQuantidade" /><br />
        <asp:TextBox ID="txtQuantidade" runat="server" ReadOnly="true" /><br />
    </div>
    <br />
    <asp:HyperLink ID="lnkVoltar" runat="server" NavigateUrl="~/Views/Produto/Listagem.aspx" Text="Voltar à Listagem" />
</asp:Content>
