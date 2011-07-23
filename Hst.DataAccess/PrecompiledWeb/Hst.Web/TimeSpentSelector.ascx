<%@ control language="C#" autoeventwireup="true" inherits="TimeSpentSelector, App_Web_25gyrecf" %>
<asp:UpdatePanel ID="updTimeSpent" runat="server" UpdateMode="Always">
    <ContentTemplate>
        <asp:HiddenField ID="hidTimeSpent" runat="server" />
        <div class="">
            <div class="timeSelectButton" id="fifteen">
                <div class="timeSelectButton-rb">
                    <a class="checkbox-select" id="cb-select_<%= rbFifteen.ClientID %>" href="#"><img src="Icons/24x24/clock.png" /></a>
                    <a class="checkbox-deselect" id="cb-deselect_<%= rbFifteen.ClientID %>" href="#"><img src="Icons/24x24/accept.png" /></a>
                    <asp:RadioButton ID="rbFifteen" runat="server" GroupName="Time" />
                </div>
                <div class="timeSelectButton-txt">
                    15m
                </div>
                
            </div>
            <div class="timeSelectButton" id="thirty">
                <div class="timeSelectButton-rb">
                    <a class="checkbox-select" id="cb-select_<%= rbThirty.ClientID %>" href="#"><img src="Icons/24x24/clock.png" /></a>
                    <a class="checkbox-deselect" id="cb-deselect_<%= rbThirty.ClientID %>" href="#"><img src="Icons/24x24/accept.png" /></a>
                    <asp:RadioButton ID="rbThirty" runat="server" GroupName="Time" />
                </div>
                <div class="timeSelectButton-txt">
                    30m
                </div>
                
            </div>
            <div class="timeSelectButton" id="sixty">
                <div class="timeSelectButton-rb">
                    <a class="checkbox-select" id="cb-select_<%= rbSixty.ClientID %>" href="#"><img src="Icons/24x24/clock.png" /></a>
                    <a class="checkbox-deselect" id="cb-deselect_<%= rbSixty.ClientID %>" href="#"><img src="Icons/24x24/accept.png" /></a>
                    <asp:RadioButton ID="rbSixty" runat="server" GroupName="Time" />
                </div>
                <div class="timeSelectButton-txt">
                    60m
                </div>
                
            </div>
            <div class="timeSelectButton" id="customtime">
                <div class="timeSelectButton-rb">
                    <a class="checkbox-select" id="cb-select_<%= rbCustom.ClientID %>" href="#"><img src="Icons/24x24/clock.png" /></a>
                    <a class="checkbox-deselect" id="cb-deselect_<%= rbCustom.ClientID %>" href="#"><img src="Icons/24x24/accept.png" /></a>
                    <asp:RadioButton ID="rbCustom" runat="server" GroupName="Time" />
                </div>
                <div class="timeSelectButton-txt">
                    <asp:TextBox ID="txtCustomTime" runat="server"></asp:TextBox> minutes
                </div>
                
            </div>
        </div>
        <div></div>
    </ContentTemplate>
</asp:UpdatePanel>

        <script>
            $(document).ready(function () {
                $("#cb-deselect_<%= rbFifteen.ClientID %>").hide();
                $("#<%= rbFifteen.ClientID %>").hide();
                $("#cb-deselect_<%= rbThirty.ClientID %>").hide();
                $("#<%= rbThirty.ClientID %>").hide();
                $("#cb-deselect_<%= rbSixty.ClientID %>").hide();
                $("#<%= rbSixty.ClientID %>").hide();
                $("#cb-deselect_<%= rbCustom.ClientID %>").hide();
                $("#<%= rbCustom.ClientID %>").hide();

                if ($('#<%= rbFifteen.ClientID %>').is(":checked")) {
                    $('#<%= rbFifteen.ClientID %>').parent().parent().removeClass("timeSelectButton");
                    $('#<%= rbFifteen.ClientID %>').parent().parent().addClass("timeSelectButton-selected");
                    $("#cb-deselect_<%= rbFifteen.ClientID %>").show();
                    $("#cb-select_<%= rbFifteen.ClientID %>").hide();
                }

                if ($('#<%= rbThirty.ClientID %>').is(":checked")) {
                    $('#<%= rbThirty.ClientID %>').parent().parent().removeClass("timeSelectButton");
                    $('#<%= rbThirty.ClientID %>').parent().parent().addClass("timeSelectButton-selected");
                    $("#cb-deselect_<%= rbThirty.ClientID %>").show();
                    $("#cb-select_<%= rbThirty.ClientID %>").hide();
                }

                if ($('#<%= rbSixty.ClientID %>').is(":checked")) {
                    $('#<%= rbSixty.ClientID %>').parent().parent().removeClass("timeSelectButton");
                    $('#<%= rbSixty.ClientID %>').parent().parent().addClass("timeSelectButton-selected");
                    $("#cb-deselect_<%= rbSixty.ClientID %>").show();
                    $("#cb-select_<%= rbSixty.ClientID %>").hide();
                }

                if ($('#<%= rbCustom.ClientID %>').is(":checked")) {
                    $('#<%= rbCustom.ClientID %>').parent().parent().removeClass("timeSelectButton");
                    $('#<%= rbCustom.ClientID %>').parent().parent().addClass("timeSelectButton-selected");
                    $("#cb-deselect_<%= rbCustom.ClientID %>").show();
                    $("#cb-select_<%= rbCustom.ClientID %>").hide();
                }
            });

            /* handle the user selections */

            //
            /* For 15 minutes */
            //
            $("#cb-select_<%= rbFifteen.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton");
                $(this).parent().parent().addClass("timeSelectButton-selected");
                $(this).hide();
                $("#cb-deselect_<%= rbFifteen.ClientID %>").show();
                $('#<%= rbFifteen.ClientID %>').attr('checked', true);
                $('#<%= rbFifteen.ClientID %>').change();

                // Set everything else to not selected.
                $('#<%= rbThirty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbThirty.ClientID %>').show();
                $('#cb-deselect_<%= rbThirty.ClientID %>').hide();

                $('#<%= rbSixty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbSixty.ClientID %>').show();
                $('#cb-deselect_<%= rbSixty.ClientID %>').hide();

                $('#<%= rbCustom.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbCustom.ClientID %>').show();
                $('#cb-deselect_<%= rbCustom.ClientID %>').hide();
            }
            );

            $("#cb-deselect_<%= rbFifteen.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton-selected");
                $(this).parent().parent().addClass("timeSelectButton");
                $(this).hide();
                $("#cb-select_<%= rbFifteen.ClientID %>").show();
                $('#<%= rbFifteen.ClientID %>').removeAttr('checked');

            }
            );

            //
            /* For 30 minutes */
            //
            $("#cb-select_<%= rbThirty.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton");
                $(this).parent().parent().addClass("timeSelectButton-selected");
                $(this).hide();
                $("#cb-deselect_<%= rbThirty.ClientID %>").show();
                $('#<%= rbThirty.ClientID %>').attr('checked', true);
                $('#<%= rbThirty.ClientID %>').change();

                // Set everything else to not selected.
                $('#<%= rbFifteen.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbFifteen.ClientID %>').show();
                $('#cb-deselect_<%= rbFifteen.ClientID %>').hide();

                $('#<%= rbSixty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbSixty.ClientID %>').show();
                $('#cb-deselect_<%= rbSixty.ClientID %>').hide();

                $('#<%= rbCustom.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbCustom.ClientID %>').show();
                $('#cb-deselect_<%= rbCustom.ClientID %>').hide();
            }
            );

            $("#cb-deselect_<%= rbThirty.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton-selected");
                $(this).parent().parent().addClass("timeSelectButton");
                $(this).hide();
                $("#cb-select_<%= rbThirty.ClientID %>").show();
                $('#<%= rbThirty.ClientID %>').removeAttr('checked');

            }
            );

            //
            /* For 60 minutes */
            //
            $("#cb-select_<%= rbSixty.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton");
                $(this).parent().parent().addClass("timeSelectButton-selected");
                $(this).hide();
                $("#cb-deselect_<%= rbSixty.ClientID %>").show();
                $('#<%= rbSixty.ClientID %>').attr('checked', true);
                $('#<%= rbSixty.ClientID %>').change();

                // Set everything else to not selected.
                $('#<%= rbFifteen.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbFifteen.ClientID %>').show();
                $('#cb-deselect_<%= rbFifteen.ClientID %>').hide();

                $('#<%= rbThirty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbThirty.ClientID %>').show();
                $('#cb-deselect_<%= rbThirty.ClientID %>').hide();

                $('#<%= rbCustom.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbCustom.ClientID %>').show();
                $('#cb-deselect_<%= rbCustom.ClientID %>').hide();
            }
            );

            $("#cb-deselect_<%= rbSixty.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton-selected");
                $(this).parent().parent().addClass("timeSelectButton");
                $(this).hide();
                $("#cb-select_<%= rbSixty.ClientID %>").show();
                $('#<%= rbSixty.ClientID %>').removeAttr('checked');

            }
            );

            //
            /* For custom */
            //
            $("#cb-select_<%= rbCustom.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton");
                $(this).parent().parent().addClass("timeSelectButton-selected");
                $(this).hide();
                $("#cb-deselect_<%= rbCustom.ClientID %>").show();
                $('#<%= rbCustom.ClientID %>').attr('checked', true);
                $('#<%= rbCustom.ClientID %>').change();

                // Set everything else to not selected.
                $('#<%= rbFifteen.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbFifteen.ClientID %>').show();
                $('#cb-deselect_<%= rbFifteen.ClientID %>').hide();

                $('#<%= rbThirty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbThirty.ClientID %>').show();
                $('#cb-deselect_<%= rbThirty.ClientID %>').hide();

                $('#<%= rbSixty.ClientID %>').removeAttr('checked');
                $('#cb-select_<%= rbSixty.ClientID %>').show();
                $('#cb-deselect_<%= rbSixty.ClientID %>').hide();
            }
            );

            $("#cb-deselect_<%= rbCustom.ClientID %>").click(
            function (event) {
                event.preventDefault();
                $(this).parent().parent().removeClass("timeSelectButton-selected");
                $(this).parent().parent().addClass("timeSelectButton");
                $(this).hide();
                $("#cb-select_<%= rbCustom.ClientID %>").show();
                $('#<%= rbCustom.ClientID %>').removeAttr('checked');

            }
            );

            $(".timeSelectButton").corner();
            $(".timeSelectButton-selected").corner();

        </script>