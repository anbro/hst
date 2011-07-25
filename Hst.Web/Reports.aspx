<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Default2" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script>
    $(document).ready(function () {
        
    }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="reportsheader">
        <div class="reportsheader-childrenselector"></div>
        <div class="reportsheader-reportselector"></div>
        <div class="reportsheader-date"></div>
        <div class="reportsheader-date"></div>
    </div>
    <div id="reportscontainer">
        <div id="reports-activities">
            <div id="reports-activities-title" class="recordtypetitle">Activities</div>
            <div id="reports-activities-grid">
                <div class="recordtitle">title</div>
                <div class="recorddate">5/10/2011</div>
                <div class="recordsubjects">
                    <div>Mathematics</div>
                    <div>Reading</div>
                </div>
                <div class="recordcontent">The content goes here</div>
            </>
        </div>
        <div id="reports-lessons"></div>
        <div id="reports-tests"></div>
    
    </div>
</asp:Content>

