<%@ control language="C#" autoeventwireup="true" inherits="SelectedDate, App_Web_25gyrecf" %>
<div style="text-align: center; margin-top: -10px;"><h2>Selected Date</h2></div>
<div class="summarySelectedDateContainer">
    <div class="summarySelectedDateIcon">
        <asp:Image ImageUrl="~/Icons/32x32/calendar_date.png" runat="server" ID="imgType" />
    </div>
    <div class="summarySelectedDateName">
        <asp:Label ID="lblDate" runat="server"></asp:Label>
    </div>    
</div>