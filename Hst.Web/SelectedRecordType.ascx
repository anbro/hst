﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SelectedRecordType.ascx.cs" Inherits="SelectedRecordType" %>
<div style="text-align: center; margin-top: -10px;"><h2>Record Type</h2></div>
<div class="summarySelectedRecordTypeContainer">
    <div class="summarySelectedRecordTypeIcon">
        <asp:Image ImageUrl="~/Icons/32x32/info.png" runat="server" ID="imgType" />
    </div>
    <div class="summarySelectedRecordTypeName">
        <asp:Label ID="lblRecordType" runat="server"></asp:Label>
    </div>    
</div>
