<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="Million.WebForm.Start" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Label ID="lblName" runat="server" Text="Ваше ім'я"></asp:Label>
    <asp:TextBox ID="tbxName" runat="server"></asp:TextBox>
    <asp:Button ID="btnStart" runat="server" Text="Почати гру !" EnableTheming="false" OnClick="btnStart_Click" />
    <asp:RequiredFieldValidator ID="vld_nameValidate" runat="server" ErrorMessage="Вкажіть ім'я!" ControlToValidate="tbxName" ForeColor="White"></asp:RequiredFieldValidator>
</asp:Content>
