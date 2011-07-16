<%@ Control Language="C#" AutoEventWireup="true" CodeFile="IndividualChild.ascx.cs" Inherits="IndividualChild" %>
<div class="studentselector" id="studentsel_<%= cbStudentSelected.ClientID %>">
    <div class="studentcheckbox">
        <asp:CheckBox ID="cbStudentSelected" runat="server" OnCheckedChanged="cbStudentSelected_OnCheckedChanged" />
        <a class="checkbox-select" id="cb-select_<%= cbStudentSelected.ClientID %>" href="#"><img src="Icons/48x48/user_add.png" /></a>
        <a class="checkbox-deselect" id="cb-deselect_<%= cbStudentSelected.ClientID %>" href="#"><img src="Icons/48x48/user_accept.png" /></a>
    </div>
    <div class="studentname"><asp:Label ID="lblStudentName" Text="" runat="server"></asp:Label></div>
    <div class="studentage">Age: <asp:Label ID="lblStudentAge" Text="" runat="server"></asp:Label></div>
</div>


<script>
    $(document).ready(function () {
        $("#cb-deselect_<%= cbStudentSelected.ClientID %>").hide();
        $("#<%= cbStudentSelected.ClientID %>").hide();
        if ($('#<%= cbStudentSelected.ClientID %>').is(":checked")) {
            $('#<%= cbStudentSelected.ClientID %>').parent().parent().removeClass("studentselector");
            $('#<%= cbStudentSelected.ClientID %>').parent().parent().addClass("studentselector-selected");
            $("#cb-deselect_<%= cbStudentSelected.ClientID %>").show();
            $("#cb-select_<%= cbStudentSelected.ClientID %>").hide();
        }

    });

    /* handle the user selections */
    $("#cb-select_<%= cbStudentSelected.ClientID %>").click(
    function (event) {
        event.preventDefault();
        $(this).parent().parent().removeClass("studentselector");
        $(this).parent().parent().addClass("studentselector-selected");
        $(this).hide();
        $("#cb-deselect_<%= cbStudentSelected.ClientID %>").show();
        $('#<%= cbStudentSelected.ClientID %>').attr('checked', true);
        $('#<%= cbStudentSelected.ClientID %>').change();


    }
    );

    $("#cb-deselect_<%= cbStudentSelected.ClientID %>").click(
    function (event) {
        event.preventDefault();
        $(this).parent().parent().removeClass("studentselector-selected");
        $(this).parent().parent().addClass("studentselector");
        $(this).hide();
        $("#cb-select_<%= cbStudentSelected.ClientID %>").show();
        $('#<%= cbStudentSelected.ClientID %>').removeAttr('checked');

    }
    );
 
    
//    $("[id$=cbStudentSelected]").attr('checked') { function() { $("studentsel").toggleClass(".studentselector");
//    $("[id$=cbStudentSelected]").attr('checked') { function() { $("studentsel").toggleClass(".studentselector-selected");
    $(".studentselector").corner();
    $(".studentselector-selected").corner();

</script>