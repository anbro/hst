<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RecordActivity.ascx.cs"
    Inherits="RecordActivity" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<!-- Activity Name -->
<div class="detailsContainer">
    <div class="leftRecordDetailsColumn">
        Activity Name</div>
    <div class="rightRecordDetailsColumn">
        <asp:TextBox ID="txtActivityName" runat="server" CssClass="textboxwide"></asp:TextBox></div>
</div>
<!-- Activity Time Spent -->
<div class="detailsContainer">
    <div class="leftRecordDetailsColumn">
        Time Spent</div>
    <!-- Left column -->
    <div class="rightRecordDetailsColumn">
        <asp:RadioButtonList ID="rbTimeSpent" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Text="15m" Value="15"></asp:ListItem>
            <asp:ListItem Text="30m" Value="30"></asp:ListItem>
            <asp:ListItem Text="60m" Value="60"></asp:ListItem>
            <asp:ListItem Text="Custom" Value="15"></asp:ListItem>
        </asp:RadioButtonList>
        <asp:TextBox ID="txtTimeSpent" runat="server"></asp:TextBox></div>
        <script type="text/javascript">
            function rb () {
                $('#<%= rbTimeSpent.ClientID %>').buttonset();
            }
        </script>
    <!-- Right column -->
</div>
<!-- Activity Notes -->
<div class="detailsContainer">
    <div class="leftRecordDetailsColumn">
        Notes</div>
    <!-- Left column -->
    <div class="rightRecordDetailsColumn">
        <HTMLEditor:Editor ID="txtActivityNote" runat="server" Height="300px" Width="100%" />
    </div>
    <!-- Right column -->
</div>
