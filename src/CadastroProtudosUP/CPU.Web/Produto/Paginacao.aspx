<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Paginacao.ascx.cs" Inherits="CPU.Web.Views.Shared.Paginacao" %>

<asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
    <asp:ListItem Text="15" Value="15"></asp:ListItem>
    <asp:ListItem Text="25" Value="25"></asp:ListItem>
    <asp:ListItem Text="50" Value="50"></asp:ListItem>
    <asp:ListItem Text="100" Value="100"></asp:ListItem>
</asp:DropDownList>

<asp:DataPager ID="dpPager" runat="server" PageSize="15">
    <Fields>
        <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
    </Fields>
</asp:DataPager>
