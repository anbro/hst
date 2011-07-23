<%@ control language="C#" autoeventwireup="true" inherits="SelectedSubject, App_Web_25gyrecf" %>
<div class="summarySelectedStudentContainer">
    <div class="summarySelectedStudentIcon"><img src="Icons/32x32/notebook.png" /></div>
    <div class="summarySelectedSubjectName"><asp:Label ID="lblSubjectName" runat="server"></asp:Label></div>
</div>
<script type="text/javascript">
    $("document").ready(function () {
        $(".summarySelectedStudentContainer").corner();
    });
</script>