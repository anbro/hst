<%@ control language="C#" autoeventwireup="true" inherits="SelectedStudent, App_Web_25gyrecf" %>
<div class="summarySelectedStudentContainer">
    <div class="summarySelectedStudentIcon"><img src="Icons/32x32/users_accept.png" /></div>
    <div class="summarySelectedStudentName"><asp:Label ID="lblStudentName" runat="server"></asp:Label></div>
    <div class="summarySelectedStudentAge"><asp:Label ID="lblStudentAge" runat="server"></asp:Label></div>
</div>
<script type="text/javascript">
    $("document").ready(function () {
        $(".summarySelectedStudentContainer").corner();
    });
</script>