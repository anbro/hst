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
        <asp:TextBox ID="txtTimeSpent" runat="server"></asp:TextBox></div>
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
