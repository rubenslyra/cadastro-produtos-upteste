<%@ Page Title="Editar Categoria" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="CPU.Web.Views.Categoria.Editar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Editar Categoria</h2>
    <!-- Formulário para editar categoria -->
    <div>
        <asp:Label ID="lblNome" runat="server" Text="Nome:" AssociatedControlID="txtNome" /><br />
        <asp:TextBox ID="txtNome" runat="server" /><br />
        <asp:Label ID="lblDescricao" runat="server" Text="Descrição:" AssociatedControlID="txtDescricao" /><br />
        <asp:TextBox ID="txtDescricao" runat="server" /><br />
    </div>
    <br />
    <asp:Button ID="btnAtualizar" runat="server" Text="Atualizar" OnClick="btnAtualizar_Click" />
    <asp:HyperLink ID="lnkCancelar" runat="server" NavigateUrl="~/Views/Categoria/Listagem.aspx" Text="Cancelar" />
</asp:Content>
