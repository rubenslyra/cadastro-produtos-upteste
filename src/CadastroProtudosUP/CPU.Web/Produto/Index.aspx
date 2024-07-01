<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="CPU.Web.Produto.Listagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Listagem de Produtos</h2>
    <!-- Exibir tabela com listagem de produtos -->
    <asp:GridView ID="gvProdutos" runat="server" AutoGenerateColumns="False" GridLines="None">
        <Columns>
            <asp:BoundField DataField="ProdutoId" HeaderText="ID" />
            <asp:BoundField DataField="Nome" HeaderText="Nome" />
            <asp:BoundField DataField="Descricao" HeaderText="Descrição" />
            <asp:BoundField DataField="Preco" HeaderText="Preço" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Quantidade" HeaderText="Quantidade" />
            <asp:HyperLinkField DataNavigateUrlFields="ProdutoId" HeaderText="Detalhes" Text="Detalhes" DataNavigateUrlFormatString="Detalhes.aspx?ProdutoId={0}" />
            <asp:HyperLinkField DataNavigateUrlFields="ProdutoId" HeaderText="Editar" Text="Editar" DataNavigateUrlFormatString="Editar.aspx?ProdutoId={0}" />
        </Columns>
    </asp:GridView>

    <!-- Paginação -->
    <%--<uc:Paginacao ID="ucPaginacao" runat="server" />--%>
</asp:Content>
