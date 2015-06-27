<%@ Page Title="" Language="C#" MasterPageFile="~/SiteTemplate.Master" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="Million.WebForm.Main" %>

<%@ Register Src="~/UserControls/ucWiningSum.ascx" TagPrefix="uc1" TagName="ucWiningSum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
     <div>
        <div>
            <%--<asp:Button ID="btnStart" runat="server" Text="Start Game" OnClick="btnStart_Click" />--%>
            <asp:Panel ID="QandAPanel" runat="server">

                <asp:Panel ID="QuestionPanel" runat="server">
                    <asp:Label ID="lblQuestion" runat="server" Text="Question"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="AnswersPanel" runat="server" CssClass="AnswersPanel">
                    <asp:Panel ID="Answer1Panel" runat="server">
                        <asp:Button ID="btnA1" runat="server" Text="" ForeColor="#0066FF" OnClick="btnA1_Click" Enabled="False" />
                    </asp:Panel>
                    <asp:Panel ID="Answer2Panel" runat="server">
                        <asp:Button ID="btnA2" runat="server" Text="" ForeColor="#0066FF" OnClick="btnA2_Click" Enabled="False" />
                    </asp:Panel>
                    <asp:Panel ID="Answer3Panel" runat="server">
                        <asp:Button ID="btnA3" runat="server" Text="" ForeColor="#0066FF" OnClick="btnA3_Click" Enabled="False" />
                    </asp:Panel>
                    <asp:Panel ID="Answer4Panel" runat="server">
                        <asp:Button ID="btnA4" runat="server" Text="" ForeColor="#0066FF" OnClick="btnA4_Click" Enabled="False" />
                    </asp:Panel>

                </asp:Panel>
            </asp:Panel>
        </div>

        <div>
            <asp:Panel ID="HelpPanel" runat="server">
                <asp:Panel ID="FiftyPanel" runat="server">
                    <asp:Button ID="btnFifty" runat="server" Text="Fifty-Fifty" OnClick="btnFifty_Click" Enabled="False" />
                </asp:Panel>

                <asp:Panel ID="AskFriendPanel" runat="server">
                    <asp:Button ID="btnAskFriend" runat="server" Text="Ask Friend" Enabled="False" OnClick="btnAskFriend_Click" />
                </asp:Panel>

                <asp:Panel ID="AskHallPanel" runat="server">
                    <asp:Button ID="btnAksHall" runat="server" Text="Ask Hall" Enabled="False" />
                </asp:Panel>

            </asp:Panel>
        </div>

        <asp:Label ID="lblMoney" Text="Грогші: 0" runat="server"></asp:Label>

        <asp:Label ID="lblCurrentMoney" Text="Неспалювана сума: 0" runat="server"></asp:Label>

         <uc1:ucWiningSum runat="server" ID="ucWiningSum" />

    </div>
</asp:Content>
