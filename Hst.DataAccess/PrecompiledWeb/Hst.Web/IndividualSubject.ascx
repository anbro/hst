<%@ control language="C#" autoeventwireup="true" inherits="IndividualSubject, App_Web_25gyrecf" %>
<div class="subjectselector" id="subjectsel_<%= cbSubjectSelected.ClientID %>">
    <div class="subjectcheckbox">
        <asp:CheckBox ID="cbSubjectSelected" runat="server" OnCheckedChanged="cbSubjectSelected_OnCheckedChanged" />
        <a class="checkbox-select" id="cb-select_<%= cbSubjectSelected.ClientID %>" href="#"><img src="Icons/24x24/notebook_add.png" /></a>
        <a class="checkbox-deselect" id="cb-deselect_<%= cbSubjectSelected.ClientID %>" href="#"><img src="Icons/24x24/notebook_accept.png" /></a>
    </div>
    <div class="subjectname"><asp:Label ID="lblSubjectName" Text="" runat="server"></asp:Label></div>
</div>


<script>
    $(document).ready(function () {
        $("#cb-deselect_<%= cbSubjectSelected.ClientID %>").hide();
        $("#<%= cbSubjectSelected.ClientID %>").hide();
        if ($('#<%= cbSubjectSelected.ClientID %>').is(":checked")) {
            $('#<%= cbSubjectSelected.ClientID %>').parent().parent().removeClass("subjectselector");
            $('#<%= cbSubjectSelected.ClientID %>').parent().parent().addClass("subjectselector-selected");
            $("#cb-deselect_<%= cbSubjectSelected.ClientID %>").show();
            $("#cb-select_<%= cbSubjectSelected.ClientID %>").hide();
        }

    });

    $("#subjectsel_<%= cbSubjectSelected.ClientID %>").click(
    function (event) {
        toggleSubjectSelected("<%= cbSubjectSelected.ClientID %>");
    });

//    /* handle the user selections */
//    $("#cb-select_<%= cbSubjectSelected.ClientID %>").click(
//    function (event) {
//        toggleSubjectSelected("<%= cbSubjectSelected.ClientID %>");
////        event.preventDefault();
////        $(this).parent().parent().removeClass("subjectselector");
////        $(this).parent().parent().addClass("subjectselector-selected");
////        $(this).hide();
////        $("#cb-deselect_<%= cbSubjectSelected.ClientID %>").show();
////        $('#<%= cbSubjectSelected.ClientID %>').attr('checked', true);
////        $('#<%= cbSubjectSelected.ClientID %>').change();


//    }
//    );

//    $("#cb-deselect_<%= cbSubjectSelected.ClientID %>").click(
//    function (event) {
//        toggleSubjectSelected("<%= cbSubjectSelected.ClientID %>");
////        event.preventDefault();
////        $(this).parent().parent().removeClass("subjectselector-selected");
////        $(this).parent().parent().addClass("subjectselector");
////        $(this).hide();
////        $("#cb-select_<%= cbSubjectSelected.ClientID %>").show();
////        $('#<%= cbSubjectSelected.ClientID %>').removeAttr('checked');

//    }
//    );
    $(".subjectselector").corner();
    $(".subjectselector-selected").corner();

</script>