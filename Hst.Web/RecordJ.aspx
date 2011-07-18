<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="RecordJ.aspx.cs" Inherits="RecordJ" ValidateRequest="false" %>

<asp:Content ID="header" ContentPlaceHolderID="HeadContent" Runat="Server">
<script type="text/javascript" src="tinymce/jscripts/tiny_mce/tiny_mce.js"></script>
<script type="text/javascript">
    var validator;
    $(document).ready(function () {
        tinyMCE.init({
            mode: "textareas",
            theme: "advanced",   //(n.b. no trailing comma, this will be critical as you experiment later)
            theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "",
            theme_advanced_buttons3: "",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            height: "300px",
        });

        $('#record').corner();
        // Hide all the irrelevant screens

        $('#details-activity').hide();
        $('#details-lesson').hide();
        $('#details-test').hide();
        $('#recordtypelist').buttonset();
        $('#recordtypelist').addClass('recordtypeselectorrb');
        $('#activitytimespentlist').buttonset();
        $('#activitytimespentlist').addClass('recordtypeselectorrb');
        $('#txtActivityCustomTime').hide();
        $('#ltxtActivityCustomTime').hide();
        $('#rbActivityCustom').click(function () {
            $('#txtActivityCustomTime').show();
            $('#ltxtActivityCustomTime').show();
        });
        $('#rbActivity15m').click(function () {
            $('#txtActivityCustomTime').hide();
            $('#ltxtActivityCustomTime').hide();
        });
        $('#rbActivity30m').click(function () {
            $('#txtActivityCustomTime').hide();
            $('#ltxtActivityCustomTime').hide();
        });
        $('#rbActivity60m').click(function () {
            $('#txtActivityCustomTime').hide();
            $('#ltxtActivityCustomTime').hide();
        });

        $('#selecteddate').datepicker();
        $('#selecteddate').val(function () {
            var now = new Date();
            return now.format("M/dd/yyyy");
        });

        $('#rbActivity').click(function () {
            $('#details-activity').show();
            $('#details-lesson').hide();
            $('#details-test').hide();
        });

        $('#rbLesson').click(function () {
            $('#details-activity').hide();
            $('#details-lesson').show();
            $('#details-test').hide();
        });

        $('#rbTest').click(function () {
            $('#details-activity').hide();
            $('#details-lesson').hide();
            $('#details-test').show();
        });

        $('#btnResetActivity').button({
            icons: { primary: "ui-icon-alert" }
        });
        $('#btnSaveActivity').button({
            icons: { primary: "ui-icon-circle-check" }
        });

        $.ajax(
        {
            type: "POST",
            url: "RecordJ.aspx/GetSubjects",
            dataType: "json",
            data: {},
            contentType: "application/json; charset=utf-8",
            success: function (json) {
                var s = json.d;

                for (var i = 0; i < s.length; i++) {
                    $('#subjectslist').append("<input id='subject_" + s[i].Id + "' type='checkbox' value='" + s[i].Id + "' /><label id='lsubject_" + s[i].Id + "' for='subject_" + s[i].Id + "'>" + s[i].Name + "</label>");
                }

                $('input[id^="subject_"]')
                        .button({
                            icons: { primary: "ui-icon-circle-check" }
                        })
                        .click(function () {
                            if (this.checked) {
                                $(this).button("option", "icons", { primary: "ui-icon-circle-close" })
                            }
                            else {
                                $(this).button("option", "icons", { primary: "ui-icon-circle-check" })
                            }
                        })
                        .filter(":checked").button({ icons: { primary: "ui-icon-circle-check"} });
                $('[id^="lsubject_"]').addClass('subjectselectorcb');
            }
        });

        // Load students
        $.ajax(
            {
                type: "POST",
                url: "RecordJ.aspx/GetStudents",
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var s = json.d[0];

                    for (var i = 0; i < s.length; i++) {
                        $('#involvedstudentslist').append("<input id='student_" + s[i].Id +
                        "' type='checkbox' value='" + s[i].Id + "' name='students' /><label id='lstu_" + s[i].Id + "' for='student_" + s[i].Id + "'>" +
                        s[i].NameFirst + " " + s[i].NameLast + "</label>");
                    }
                    //$('input[id^="student_"]').button({ icons: { primary: 'ui-icon-circle-close'} });
                    $('input[id^="student_"]')
                        .button({
                            icons: { primary: "ui-icon-circle-check" }
                        })
                        .click(function () {
                            if (this.checked) {
                                $(this).button("option", "icons", { primary: "ui-icon-circle-close" })
                            }
                            else {
                                $(this).button("option", "icons", { primary: "ui-icon-circle-check" })
                            }
                        })
                        .filter(":checked").button({ icons: { primary: "ui-icon-circle-check"} });
                    $('[id^="lstu_"]').addClass('studentselectorcb');
                    //$('#involvedstudentslist').append("<label name='students' for='students' class='error'></label>");
                }

            });


    });

    function submitActivityData()
    {
        $('#main').validate({
            rules: {
                selecteddate: {
                    required: true,
                    date: true
                },
                students: {
                    required: true,
                    minlength: 1
                }

            },
            messages: {
                selecteddate: {
                    required: "You must enter a date.",
                    date: "Please enter a date."
                },
                students: {
                    required: "You must select at least one student.",
                    minlength: "You must select at least one student."
                }
            }
//            },
//            errorPlacement: function (error, element) {
//                $(element).closest('[name=students]').after(error)
//            }
        });


        if (!$('#main').valid()) {
            return false;
        }
        var subjectids = [];
        var subjectcounter = 0;
        $('input[id^="subject_"]:checked').each(function(index, value) {
            subjectids[subjectcounter] = Number($(value).val());
            subjectcounter++;
        });

        var studentids = [];
        var studentcounter = 0;
        $('input[id^="student_"]:checked').each(function(index, value) {
            studentids[studentcounter] = Number($(value).val());
            studentcounter++;
        });

        var recorddate = String($('#selecteddate').val());

        var activityname = $('#txtActivityName').val();

        var timespent = $('input[name=TimeSpent-Activity]:checked').val();
        if (timespent == "custom") {
            timespent = $('#txtActivityCustomTime').val();
        }
        tinyMCE.get("txtActivityDescription").save();
        var activitydescription = $('#txtActivityDescription').val();

        var DTO = {
            "studentids" : studentids,
            "subjectids" : subjectids,
            "date" : recorddate,
            "activityName" : activityname,
            "activityDescription" : activitydescription,
            "timeSpent" : timespent
        }

        // ok, now let's make the ajax call
        $.ajax({
                type: "POST",
                url: "RecordJ.aspx/SaveActivity",
                dataType: "json",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                success: submitActivityResponse
        
        });
    }
    function submitActivityResponse(msg) {
        if (msg.hasOwnProperty("d")) { msg = msg.d; }
            alert(msg);           
    }

</script>
</asp:Content>
<asp:Content ID="mainbody" ContentPlaceHolderID="MainContent" runat="Server">



<div id="record" class="container">
    <div id="recordtype" class="stepFloat">
        <div class="stepLeft">Record Type</div>
        <div class="stepContainer" id="recordtype-content">
            <div class="stepContentContainer">
                <div class="stepContent" id="recordtypelist">
                    <input type="radio" value="activity" name="RecordType" id="rbActivity" />
                    <label for="rbActivity" id="lrbActivity">Activity</label>
                    <input type="radio" value="lesson" name="RecordType" id="rbLesson" />
                    <label for="rbLesson" id="lrbLesson">Lesson</label>
                    <input type="radio" value="test" name="RecordType" id="rbTest"/>
                    <label for="rbTest" id="lrbTest">Test</label>

                </div>
            </div>
        </div>
    </div>
    <div id="dateofrecord" class="stepFloat">
        <div class="stepLeft">Date</div>
        <div class="stepContainer" id="dateofrecord-content">            
            <div class="stepContentContainer">
                <div class="stepContent recordtypeselectorrb">
                    <input type="text" id="selecteddate" name="selecteddate" class="required date" />
                </div>
            </div>
        </div>
    </div>
    <div id="involvedstudents" class="stepFloat">
        <div class="stepLeft">Students</div>
        <div class="stepContainer" id="involvedstudents-content">
            <div class="stepContentContainer">
                <div class="stepContent" id="involvedstudentslist">
                    
                </div>
            </div>
        </div>
    </div>


    <div id="subjects" class="stepFloat">
        <div class="stepLeft">Subjects</div>
        <div class="stepContainer" id="subjects-content">
            <div class="stepContentContainer">
                <div class="stepContent" id="subjectslist">
                    <div class="subjectselectortop"></div>
                </div>
            </div>
        </div>
    </div>
    <div id="details-activity" class="stepFloat">
        <div class="stepFloat">
            <div class="stepLeft">
                Activity Name</div>
            <div class="stepContainer" id="details-activity-name">
                <div class="stepContentContainer">
                    <div class="stepContent recordtypeselectorrb">
                        <input type="text" id="txtActivityName" class="recordname" />
                    </div>
                </div>
            </div>
        </div>
        <div class="stepFloat">
            <div class="stepLeft">
                Time Spent</div>
            <div class="stepContainer" id="details-activity-timespent">
                <div class="stepContentContainer">
                    <div class="stepContent" id="activitytimespentlist">
                        <input type="radio" value="15" name="TimeSpent-Activity" id="rbActivity15m" />
                        <label for="rbActivity15m" id="lrbActivity15m">
                            15 minutes</label>
                        <input type="radio" value="30" name="TimeSpent-Activity" id="rbActivity30m" />
                        <label for="rbActivity30m" id="lrbActivity30m">
                            30 minutes</label>
                        <input type="radio" value="60" name="TimeSpent-Activity" id="rbActivity60m" />
                        <label for="rbActivity60m" id="lrbActivity60m">
                            60 minutes</label>
                        <input type="radio" value="custom" name="TimeSpent-Activity" id="rbActivityCustom" />
                        <label for="rbActivityCustom" id="lrbActivityCustom">
                            Custom</label>
                        <input type="text" id="txtActivityCustomTime" class="minutebox" />
                        <label for="txtActivityCustomTime" id="ltxtActivityCustomTime">Minutes</label>
                    </div>

                </div>
            </div>
        </div>
        <div class="stepFloat">
            <div class="stepLeft">
                Description</div>
            <div class="stepContainer" id="details-activity-description">
                <div class="stepContentContainer">
                    <div class="stepContent recordtypeselectorrb">
                        <textarea id="txtActivityDescription" name="txtActivityDescription" class="tinymce" style="width: 726px;" rows="30"></textarea>
                    </div>
                </div>
            </div>
        </div>
        <div class="commandcontainer">
            <button id="btnResetActivity" title="Reset">Reset</button>
            <button id="btnSaveActivity" title="Save" type="submit" onclick="submitActivityData()">Save and reset</button>            
        </div>
    </div>
    <div id="details-lesson" class="stepFloat">
    <div class="stepLeft">Lesson</div>
        <div class="stepContainer" id="details-lesson-content">
            <div class="stepContentContainer">
                <div class="stepContent">
                    
                </div>
            </div>
        </div>
    </div>
    <div id="details-test" class="stepFloat">
    <div class="stepLeft">Test</div>
        <div class="stepContainer" id="details-test-content">
            <div class="stepContentContainer">
                <div class="stepContent recordtypeselectorrb">
                    
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>

