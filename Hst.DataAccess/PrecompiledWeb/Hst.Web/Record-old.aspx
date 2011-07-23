<%@ page title="Record" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Recordold, App_Web_teqmkjj5" validaterequest="false" %>
<%@ Register Src="~/ChildSelector.ascx" TagName="ChildSelector" TagPrefix="Hst" %>

<%@ Reference Control="~/IndividualChild.ascx" %>
<%@ Reference Control="~/SelectedStudents.ascx" %>
<%@ Reference Control="~/SelectedStudent.ascx" %>
<%@ Reference Control="~/SelectedRecordType.ascx" %>
<%@ Reference Control="~/SubjectSelector.ascx" %>
<%@ Reference Control="~/SelectedSubjects.ascx" %>
<%@ Reference Control="~/SelectedDate.ascx" %>
<%@ Reference Control="~/RecordActivity.ascx" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
 <script type="text/javascript">
	 $("document").ready(function () {
		 Sys.WebForms.PageRequestManager.getInstance().add_endRequest(roundCorners);
		 //Sys.WebForms.PageRequestManager.getInstance().add_endRequest(loadmce);

		 roundCorners();
		 //loadmce();
	 });

	 function roundCorners() {
		 $(".summarySelectedStudentContainer").corner();
		 $('#<%= btnRecordActivity.ClientID %>').corner();
		 $('#<%= btnRecordLesson.ClientID %>').corner();
		 $('#<%= btnRecordTest.ClientID %>').corner();
		 $('[id$=involved]').corner();
		 $('[id$=recorddate]').corner();
		 $('[id$=subjects]').corner();
		 $('.summary').corner();
		 $('.summarySelectedRecordTypeContainer').corner();
		 $('.summarySelectedDateContainer').corner();
		 $('#<%= btnStudentsSelected.ClientID %>').corner();
		 $('#<%= btnSubjectsSelected.ClientID %>').corner();
		 $('#<%= btnSelectDate.ClientID %>').corner();
		 $('#<%= btnSaveDetails.ClientID %>').corner();
		 $('#<%= txtRecordDate.ClientID %>').hide();
		 $('#recorddate').datepicker({
			onSelect: function(dateText, inst) {
				 $('#<%= txtRecordDate.ClientID %>').val(dateText);
				 }
		 });
	}

	$(function(){
		var activeIndex = parseInt($('#<%=hidAccordionIndex.ClientID %>').val());
		$("#accordion").accordion({
			autoHeight: false,
			navigation: true,
			event: "mousedown",
			active: activeIndex,
			change: function (event, ui) {
				var index = $(this).children('h3').index(ui.newHeader);
				$('#<%=hidAccordionIndex.ClientID %>').val(index);
			}
		});
	});
	function moveNextAccordion() {
		var index = $('#<%=hidAccordionIndex.ClientID %>').val();
		$('#<%=hidAccordionIndex.ClientID %>').val(index++);
		$("#accordion").accordion("activate", index++);
		$(".summarySelectedStudentContainer").corner();
	};
	function loadmce() {
		tinyMCE.init({
			// general options
			mode: "textareas",
			theme: "advanced",
			theme_advanced_toolbar_location: "top",
			theme_advanced_toolbar_align : "left",
			theme_advanced_buttons1 : "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,|,bullist",
			theme_advanced_buttons2 : "",
			theme_advanced_buttons3: "",
			height: "300px",

			// set the css class to use for textareas that are NOT to use the editor
			editor_deselector: "mceNoEditor",

			// the css stylesheet to use
			content_css: "~/Styles/Site.css",
//            onchange_callback: function(ed) {
//                ed.triggerSave();
//                },
			// allow the iframe and other tags
			extended_valid_elements: "iframe[src|width|height|name|align]"
		});
	};

	</script>
	<asp:UpdatePanel ID="updHiddenFields" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
	<ContentTemplate>
	<asp:HiddenField ID="hidAccordionIndex" runat="server" Value="0" />
	<asp:HiddenField ID="hidRecordType" runat="server" Value="" />
	<asp:HiddenField ID="hidActivityNotesClientID" runat="server" Value="" />
	<asp:TextBox ID="txtRecordDate" runat="server"></asp:TextBox>
	</ContentTemplate>
	<Triggers>
		<asp:AsyncPostBackTrigger ControlID="btnRecordActivity" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="btnRecordLesson" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="btnRecordTest" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="btnStudentsSelected" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="btnSubjectsSelected" EventName="Click" />
		<asp:AsyncPostBackTrigger ControlID="btnSelectDate" EventName="Click" />
	</Triggers>
	</asp:UpdatePanel>
	<div class="simpleLeftColumn">
		<div id="accordion">
			<h3>
				<a href="#">tell us about who was involved...</a></h3>
			<div>
				<asp:Panel ID="pnlStudents" runat="server">
				</asp:Panel>
				<div class="accordionCommandArea">
					<asp:UpdatePanel ID="updStudentsSelected" runat="server" UpdateMode="Always">
						<ContentTemplate>
							<asp:Button ID="btnStudentsSelected" runat="server" Text="next" CssClass="cmdButton" OnClientClick="moveNextAccordion()" OnClick="btnStudentsSelected_OnClick" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>
			</div>
			<h3>
				<a href="#">Select a record type...</a></h3>
			<div>
				<p>
					<asp:UpdatePanel ID="updSelectRecordType" runat="server" ViewStateMode="Enabled">
						<ContentTemplate>
							<asp:Button ID="btnRecordActivity" runat="server" Text="Activity" CssClass="recordButton"
								Font-Size="X-Large" OnClientClick="moveNextAccordion()" OnClick="btnRecordActivity_Click" />
							<asp:Button ID="btnRecordLesson" runat="server" Text="Lesson" CssClass="recordButton"
								Font-Size="X-Large" OnClientClick="moveNextAccordion()" OnClick="btnRecordLesson_Click" />
							<asp:Button ID="btnRecordTest" runat="server" Text="Test" CssClass="recordButton"
								Font-Size="X-Large" OnClientClick="moveNextAccordion()" OnClick="btnRecordTest_Click" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</p>
			</div>
			<h3>
				<a href="#">tell us about the subjects involved...</a></h3>
			<div>
				<asp:Panel ID="pnlSubjects" runat="server"></asp:Panel>
				<div class="accordionCommandArea">
					<asp:UpdatePanel ID="updSubjectsSelected" runat="server" UpdateMode="Always">
						<ContentTemplate>
							<asp:Button ID="btnSubjectsSelected" runat="server" Text="next" CssClass="cmdButton" OnClientClick="moveNextAccordion()" OnClick="btnSubjectsSelected_OnClick" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>
			</div>
			<h3>
				<a href="#">When was this?</a></h3>
			<div>
				
				<div id="recorddate"></div>
				<div class="accordionCommandArea">
					<asp:UpdatePanel ID="updRecordDate" runat="server" UpdateMode="Always">
						<ContentTemplate>
							<asp:Button ID="btnSelectDate" runat="server" Text="next" CssClass="cmdButton" OnClientClick="moveNextAccordion()" OnClick="btnDateSelected_OnClick" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>
			</div>
			<h3>
				<a href="#">tell us about the details!</a></h3>
			<div>
				<asp:UpdatePanel ID="updDetails" runat="server" UpdateMode="Conditional" ViewStateMode="Enabled">
					<ContentTemplate>
					<asp:Panel ID="pnlRecordDetails" runat="server"></asp:Panel>
					</ContentTemplate>
					<Triggers>
						<asp:AsyncPostBackTrigger ControlID="btnRecordActivity" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnRecordLesson" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnRecordTest" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnStudentsSelected" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnSubjectsSelected" EventName="Click" />
						<asp:AsyncPostBackTrigger ControlID="btnSelectDate" EventName="Click" />
					</Triggers>
				</asp:UpdatePanel>
				<div class="accordionCommandArea">
					<asp:UpdatePanel ID="updRecordDetails" runat="server" UpdateMode="Always">
						<ContentTemplate>
							<asp:Button ID="btnSaveDetails" runat="server" Text="save" CssClass="cmdButton" OnClientClick="tinyMCE.triggerSave()" OnClick="btnSaveDetails_OnClick" />
						</ContentTemplate>
					</asp:UpdatePanel>
				</div>

			</div>
		</div>
	</div>
	<div class="simpleRightColumn">
		<fieldset class="summary">
		<legend>Summary</legend>
		<asp:UpdatePanel ID="updSummary" runat="server"  ViewStateMode="Enabled" UpdateMode="Conditional">
			<ContentTemplate>
				<div class="summaryStudents">
					<asp:Panel ID="pnlSelectedStudents" runat="server">
					</asp:Panel>
				</div>
				<asp:Panel ID="pnlSelectedRecordType" runat="server">
					<div class="summaryItemType">
						<asp:Label ID="lblSelectedRecordType" runat="server"></asp:Label>
					</div>
				</asp:Panel>
				<div class="summarySubjects">
					<asp:Panel ID="pnlSelectedSubjects" runat="server">
					</asp:Panel>
				</div>
				<div class="summaryDate">
					<asp:Panel ID="pnlSelectedDate" runat="server"></asp:Panel>
				</div>
			</ContentTemplate>
			<Triggers>
				<asp:AsyncPostBackTrigger ControlID="btnStudentsSelected" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnRecordActivity" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnRecordLesson" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnRecordTest" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnSubjectsSelected" EventName="Click" />
				<asp:AsyncPostBackTrigger ControlID="btnSelectDate" EventName="Click" />
			</Triggers>
		</asp:UpdatePanel>
		</fieldset>
	</div>

</asp:Content>

