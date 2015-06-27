<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="End.aspx.cs" Inherits="Million.WebForm.End" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1><asp:Label ID="lbl_Name" runat="server"></asp:Label> Гра закінчена! Ваш виграш <asp:Label ID="lbl_result" runat="server">$</asp:Label></h1>
    <asp:Button ID="btnGotostart" runat="server" onclick="btnGotostart_Click" Text="На головну"/> 
</asp:Content>
