<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SubjectSelector.ascx.cs" Inherits="SubjectSelector" %>
<%@ Reference Control="~/IndividualSubject.ascx" %>
<div>
    <script language="javascript">
        function toggleSubjectSelected(cbid) {
            var cbs = String(cbid);
            if ($("#subjectsel_" + cbs).hasClass("subjectselector")) {
                $("#subjectsel_" + cbs).removeClass("subjectselector");
                $("#subjectsel_" + cbs).addClass("subjectselector-selected");
                $('#' + cbs).attr('checked', true);
                $('#' + cbs).change();
                $("#cb-deselect_" + cbs).show();
                $("#cb-select_" + cbs).hide();
            }
            else {
                $("#subjectsel_" + cbs).removeClass("subjectselector-selected");
                $("#subjectsel_" + cbs).addClass("subjectselector");
                $("#cb-deselect_" + cbs).hide();
                $("#cb-select_" + cbs).show();
                $('#' + cbs).removeAttr('checked');
            }

            
        }
    </script>
    <asp:Panel ID="pnlSubjectsList" runat="server">
    </asp:Panel>

</div>