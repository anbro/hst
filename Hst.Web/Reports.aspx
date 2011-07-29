<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Reports.aspx.cs" Inherits="Default2" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#reportselector').buttonset();
            $('#btnloadreport')
                .button()
                .click(function () {
                    if ($('#activityreport').is(':checked')) {
                        var startdate = $('#txtstartdate').val();
                        var enddate = $('#txtenddate').val();
                        var studentid = $('#childselector option:selected').val();
                        GetActivities(startdate, enddate, studentid);
                    }
                    if ($('#lessonreport').is(':checked')) {
                        var startdate = $('#txtstartdate').val();
                        var enddate = $('#txtenddate').val();
                        var studentid = $('#childselector option:selected').val();
                        GetLessons(startdate, enddate, studentid);
                    }
                    if ($('#testreport').is(':checked')) {
                        var startdate = $('#txtstartdate').val();
                        var enddate = $('#txtenddate').val();
                        var studentid = $('#childselector option:selected').val();
                        GetActivities(startdate, enddate, studentid);
                    }

                });
            $('#txtstartdate').datepicker();
            $('#txtenddate').datepicker();



            // Load students
            $.ajax(
            {
                type: "POST",
                url: "Record.aspx/GetStudents",
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var s = json.d[0];

                    for (var i = 0; i < s.length; i++) {
                        $('#childselector').append("<option value='" + s[i].Id + "'>" + s[i].NameFirst + " " + s[i].NameLast + "</option>");
                    }
                    // Set the selectbox to a selectmenu styling
                    $('#childselector').selectmenu({ menuWidth: "300px", width: "250px" });
                }

            });
        });

    function GetActivities(startdate, enddate, studentid)
    {
        var DTO = {
            "startdate" : startdate,
            "enddate" : enddate,
            "studentid" : studentid
            }

            $.ajax(
            {
                type: "POST",
                url: "Reports.aspx/GetActivities",
                dataType: "json",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    ClearActivities();

                    var data = json.d[0];
                    $(data).each(function (index, value) {
                        WriteActivity(value);
                        return true;
                    });
                }
            });
        }

        function GetLessons(startdate, enddate, studentid) {
            var DTO = {
                "startdate": startdate,
                "enddate": enddate,
                "studentid": studentid
            }

            $.ajax(
            {
                type: "POST",
                url: "Reports.aspx/GetLessons",
                dataType: "json",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    ClearActivities();

                    var data = json.d[0];
                    $(data).each(function (index, value) {
                        WriteLesson(value);
                        return true;
                    });
                }
            });
        }

        function DateDeserialize(dateStr) {
            return eval('new' + dateStr.replace(/\//g, ' '));
        }

    function WriteActivity(activity)
    {
        var activitytitleid = 'activitytitle_' + activity.Id;
        var activitysubjectid = 'activitysubjects_' + activity.Id;
        var activityid = 'activity_' + activity.Id;
        $('#reports-activities-grid').append("<div id='" + activityid + "'></div>");
        $('#' + activityid).append("<div class='recordtitle' id='" + activitytitleid + "'>" + activity.Title + "</div>");

        $('#' + activityid).append("<div class='recorddate'>" + DateDeserialize(activity.Date).format('M/d/yyyy') + "</div>");
        $('#' + activityid).append("<div class='recordsubjects' id='" + activitysubjectid + "'></div>");

        $(activity.Subjects).each(function (index, value) {
            $('#' + activitysubjectid).append("<div>" + value + "</div>");
            return true;
        });

        $('#' + activityid).append("<div class='recordcontent'>" + activity.Notes + "</div>");
    }

    function ClearActivities()
    {
        $('#reports-activities-grid').children().remove();
    }

    function WriteLesson(lesson) {
        var lessontitleid = 'lessontitle_' + lesson.Id;
        var lessonsubjectid = 'lessonsubjects_' + lesson.Id;
        var lessonid = 'lesson_' + lesson.Id;
        $('#reports-lessons-grid').append("<div id='" + lessonid + "'></div>");
        $('#' + lessonid).append("<div class='recordtitle' id='" + lessontitleid + "'>" + lesson.Title + "</div>");

        $('#' + lessonid).append("<div class='recorddate'>" + DateDeserialize(lesson.Date).format('M/d/yyyy') + "</div>");
        $('#' + lessonid).append("<div class='recordsubjects' id='" + lessonsubjectid + "'></div>");

        $(lesson.Subjects).each(function (index, value) {
            $('#' + lessonsubjectid).append("<div>" + value + "</div>");
            return true;
        });

        $('#' + lessonid).append("<div class='recordcontent'>" + lesson.Notes + "</div>");
    }

    function ClearActivities() {
        $('#reports-lessons-grid').children().remove();
    }
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="reportsheader">
        <div class="reportsheader-childrenselector">            
            <select id="childselector">
            </select>
        </div>
        <div class="reportsheader-reportselector" id="reportselector">
            <input type="checkbox" id="activityreport" name="reportselector" />
            <label for="activityreport">Activities</label>
            <input type="checkbox" id="lessonreport" name="reportselector" />
            <label for="lessonreport">Lessons</label>
            <input type="checkbox" id="testreport" name="reportselector" />
            <label for="testreport">Tests</label>
        </div>
        <div class="reportsheader-date">
            <input type="text" id="txtstartdate" />
            <label for="txtstartdate">Start Date</label>
        </div>
        <div class="reportsheader-date">
            <input type="text" id="txtenddate" />
            <label for="txtenddate">End Date</label>
        </div>
        <div class="reportsheader-cmd">
            <input type="button" id="btnloadreport" value="Load" />
        </div>
    </div>
    <div id="reportscontainer">
        <div>
            <div id="reports-activities" style="width: 100%; float: left;">
                <div id="reports-activities-title" class="recordtypetitle">Activities</div>
                <div id="reports-activities-grid">
                
                </div>
            </div>
        </div>
        <div>
            <div id="reports-lessons" style="width: 100%; float: left;">
                <div id="reports-lessons-title" class="recordtypetitle">Lessons</div>
                <div id="reports-lessons-grid">
                
                </div>
            </div>
        </div>
        <div>
            <div id="reports-tests" style="width: 100%; float: left;"></div>
        </div>
    </div>
</asp:Content>

