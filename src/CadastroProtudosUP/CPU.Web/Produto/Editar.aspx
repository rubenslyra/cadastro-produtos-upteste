<%@ Page Title="Editar Produto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CPU.Web.Views.Produto.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Produto</h2>
    <!-- Formulário para editar produto -->
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" AssociatedControlID="txtNome" /><br />
        <asp:TextBox ID="txtNome" runat="server" /><br />
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" /><br />
        <asp:TextBox ID="txtDescricao" runat="server" /><br />
        <asp:Label ID="lblPreco" runat="server" Text="Preço:" AssociatedControlID="txtPreco" /><br />
        <asp:TextBox ID="txtPreco" runat="server" /><br />
        <asp:Label ID="lblQuantidade" runat="server" Text="Quantidade:" AssociatedControlID="txtQuantidade" /><br />
        <asp:TextBox ID="txtQuantidade" runat="server" /><br />
    </div>
    <br />
    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
    <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Views/Produto/Listagem.aspx" Text="Cancelar" />
</asp:Content>
