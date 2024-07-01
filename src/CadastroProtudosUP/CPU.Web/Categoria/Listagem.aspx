<%@ Page Title="Listagem de Categorias" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listagem.aspx.cs" Inherits="CPU.Web.Views.Categoria.Listagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listagem de Categorias</h2>
    <!-- Exibir tabela com listagem de categorias -->
    <asp:GridView ID="gvCategorias" runat="server" AutoGenerateColumns="False" GridLines="None">
        <Columns>
            <asp:BoundField DataField="CategoriaId" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:HyperLinkField DataNavigateUrlFields="CategoriaId" HeaderText="Detalhes" Text="Detalhes" DataNavigateUrlFormatString="Detalhes.aspx?CategoriaId={0}" />
            <asp:HyperLinkField DataNavigateUrlFields="CategoriaId" HeaderText="Editar" Text="Editar" DataNavigateUrlFormatString="Editar.aspx?CategoriaId={0}" />
        </Columns>
    </asp:GridView>

    <!-- Paginação -->
    <uc:Paginacao ID="ucPaginacao" runat="server" />
</asp:Content>
