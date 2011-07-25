<%@ Page Title="Manage Students" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManageSchool.aspx.cs" Inherits="ManageSchool" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" Runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#settings").tabs();
            $("#btncreateStudent").button();
            $("#studentstitle").corner();
            $("#adduser").hide();
            $("#searchresultcontainer").hide();
            $("#btnAddUserToSchool").click(function () {
                $("#adduser").show();
            });
            $("#btnFindUser").button();
            $("#btnAddUserToSchool").button();
            $("#btnRemoveUsers").button();
            $.ajax(
            {
                type: "POST",
                url: "Record.aspx/GetStudents",
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    PopulateStudents(json);
                }
            });
            $.ajax(
            {
                type: "POST",
                url: "ManageSchool.aspx/GetUsersForSchool",
                dataType: "json",
                data: {},
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var s = json.d[0];
                    DisplaySchoolUsers(s);
                }
            });
        });

        function PopulateStudents(json) {
            var s = json.d[0];

            for (var i = 0; i < s.length; i++) {
                $('#studentslist').append("<input id='student_" + s[i].Id +
                        "' type='checkbox' value='" + s[i].Id + "' name='students' /><label id='lstu_" + s[i].Id + "' for='student_" + s[i].Id + "'>" +
                        s[i].NameFirst + " " + s[i].NameLast + "</label>");

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
                            if ($('#rbTest').is(':checked')) {
                                createTestResultControls();
                            }
                        })
                        .filter(":checked").button({ icons: { primary: "ui-icon-circle-check"} });
                $('[id^="lstu_"]').addClass('studentselectorcb');
            }
        }
        function CreateStudent() {
            $('#main').validate({
                rules: {
                    studentfname: { required: true, },
                    studentlname: { required: true },
                    studentdob: { required: true, date: true }
                }
            });

            if (!$('#main').valid()) {
                return false;
            }

            var fname = $('#studentfname').val();
            var lname = $('#studentlname').val();
            var dob = $('#studentdob').val();

            var DTO = {
            "Fname" : fname,
            "Lname" : lname,
            "DOB" : dob
            }

            $.ajax({
                type: "POST",
                url: "ManageSchool.aspx/SaveStudent",
                dataType: "json",
                data: JSON.stringify(DTO),
                contentType: "application/json; charset=utf-8",
                success: submitActivityResponse

            });

        }

        function submitActivityResponse(msg) {
//            if (msg.hasOwnProperty("d")) { msg = msg.d; }
//            alert(msg);
        }

        function FindUser() {
            $('#main').validate({
                rules: {
                    emailsearch: { required: true,
                    email: true }
                }
            });

            if (!$('#main').valid()) {
                return false;
            }

            var emailsearchstring = $("#txtuseremail").val();
            var dto = {
            "email" : emailsearchstring
            }

            $.ajax(
            {
                type: "POST",
                url: "ManageSchool.aspx/GetUsersByEmail",
                dataType: "json",
                data: JSON.stringify(dto),
                contentType: "application/json; charset=utf-8",
                success: function (json) {
                    var s = json.d[0];

                    DisplayEmailSearchResults(s);
                    }
            });

        }

        function DisplayEmailSearchResults(json)
        {
            $('#searchresultcontainer').show();
            $(json).each(function (index, value) {
                $('#srfname').append("<div id='userfname_" + value.Id + "' class='griditem'>" + value.FirstName + "</div>");
                $('#srlname').append("<div id='userlname_" + value.Id + "' class='griditem'>" + value.LastName + "</div>");
                $('#sremail').append("<div id='useremail_" + value.Id + "' class='griditem'>" + value.Email + "</div>");
                $('#srcmd').append("<div class='griditem'><input id='btnadduser_" + value.Id + "' onclick='AddUserToSchool(" + value.Id + ")' type='submit' value='Add User' /></div>");
                $("#btnadduser_" + value.Id).button();
                return true;
            });
        }

        function DisplaySchoolUsers(json)
        {
            $(json).each(function (index, value) {
               $('#userfname').append("<div id='userfname_" + value.Id + "' class='griditem'>" + value.FirstName + "</div>");
               $('#userlname').append("<div id='userlname_" + value.Id + "' class='griditem'>" + value.LastName + "</div>");
               $('#useremail').append("<div id='useremail_" + value.Id + "' class='griditem'>" + value.Email + "</div>");
               $('#userteacher').append("<div id='userteacher_" + value.Id + "' class='griditem'><input id='cbuserteacher_" + value.Id + "' type='checkbox'><label for='cbuserteacher_" + value.Id + "'>IsTeacher</label></div>");
               if (value.IsTeacher) {
                    $('#cbuserteacher_' + value.Id).attr("checked", "checked");
               }
               
               $('#usercmd').append("<div id='usercmd_" + value.Id + "' class='griditem'></div>");
               $('#usercmd_' + value.Id).append("<input type='submit' id='btnremoveuser_" + value.Id + "' value='Remove' />");
               $('#btnremoveuser_' + value.Id)
                    .button()
                    .click(function () {
                        // Check if this is a teacher - must remove teacher flag first
                        var isTeacher = $('#cbuserteacher_' + value.Id).attr("checked");
                        if (!isTeacher) {
                            RemoveUserFromSchool(value.Id);
                        }
                        else {
                            $('#userworking').append("Cannot remove a teacher.");
                            return false;
                        }
                        
                    });
               $('#userworking').append("<div id='userworking_" + value.Id + "' class='griditem'></div>");
               $('#userworking_' + value.Id).append("<img src='Icons/16x16/record.png' id='userworkingimg_" + value.Id + "'/>");
               $('#userworking_' + value.Id).append("<img src='Icons/16x16/accept.png' id='userdoneimg_" + value.Id + "'>");
               $('#userworkingimg_' + value.Id).hide();      
               $('#userdoneimg_' + value.Id).hide();      

               $('#cbuserteacher_' + value.Id)
                .button()
                .click(function () {
                    $('#userdoneimg_' + value.Id).hide();
                    $('#userworkingimg_' + value.Id).show();
                    ToggleTeacherPermission(value.Id);
                });

               
               return true;         
            });
        }

        function RemoveUserFromSchool(userid) {
            var dto = {
                "id" : userid
            }

            $.ajax(
            {
                type: "POST",
                url: "ManageSchool.aspx/RemoveUser",
                dataType: "json",
                data: JSON.stringify(dto),
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $('#userworkingimg_' + userid).hide();
                    $('#userdoneimg_' + userid).show();
                }
            });
        }

        function ToggleTeacherPermission(userid) {
            var dto = {
                "id" : userid
            }

            $.ajax(
            {
                type: "POST",
                url: "ManageSchool.aspx/ToggleTeacher",
                dataType: "json",
                data: JSON.stringify(dto),
                contentType: "application/json; charset=utf-8",
                success: function () {
                    $('#userworkingimg_' + userid).hide();
                    $('#userdoneimg_' + userid).show();
                }
            });
        }

        function AddUserToSchool(id)
        {
            var dto = {
                "id" : id
            }

            $.ajax(
            {
                type: "POST",
                url: "ManageSchool.aspx/AddUserToSchool",
                dataType: "json",
                data: JSON.stringify(dto),
                contentType: "application/json; charset=utf-8",
                success: submitActivityResponse
            });

        }

    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
        
    <div id="settings">
        <ul>
            <li><a href="#students">Student Management</a></li>
            <li><a href="#school">School Management</a></li>
            <!--<li><a href="#subjects">Subject Management</a></li>
            <li><a href="#chores">Chore Management</a></li>-->
        </ul>
        <div id="students">
            <fieldset class="register">
                <legend>Current Students</legend>
                <div id="studentslist"></div>
            </fieldset>
            <div id="addstudents">
                <div>
                <fieldset class="register">
                    <legend>Add Student</legend>
                    <p>
                        <label for="studentfname">First Name</label>
                        <input type="text" id="studentfname" name="studentname" />
                        <label for="studentfname">Last Name</label>
                        <input type="text" id="studentlname" name="studentname" />
                        <label for="studentdob">Date of Birth</label>
                        <input type="text" id="studentdob" name="studentdob" />
                    </p>
                    <p class="submitButton">
                        <input type="button" onclick="CreateStudent()" id="btncreateStudent" value="Save"/>
                    </p>
                </fieldset>
                
                </div>
            </div>
        </div>
        <div id="school">
            <fieldset class="register">
                <legend>School Users</legend>
                <div id="users" class="srcontainer">
                    <div id="userfname" class="srname"><div class="srtitle">First Name</div></div>
                    <div id="userlname" class="srname"><div class="srtitle">Last Name</div></div>
                    <div id="useremail" class="sremail"><div class="srtitle">Email</div></div>
                    <div id="userteacher" class="srcmd"><div class="srtitle">Teacher</div></div>
                    <div id="usercmd" class="srcmd"><div class="srtitle">Options</div></div>
                    <div id="userworking" class="srworking"><div class="srtitle"></div></div>
                </div>  
                <div class="srcontainer">
                <p>
                    <input type="button" id="btnAddUserToSchool" value="Add User" />
                    
                </p>
                </div>              
                <div id="adduser" style="width: 100%;">
                    <div class="srcontainer">
                        <label for="txtuseremail">User Email</label>
                        <input type="text" id="txtuseremail" name="emailsearch" /><input type="button" id="btnFindUser" onclick="FindUser()" value="Find User" />
                    </div>
                    <div id="searchresultcontainer" class="srcontainer">
                        <div id="searchresulttitle" class="srmaintitle">Search Results</div>
                        <div id="searchresults">
                            <div id="srfname" class="srname"><div class="srtitle">First Name</div></div>
                            <div id="srlname" class="srname"><div class="srtitle">Last Name</div></div>
                            <div id="sremail" class="sremail"><div class="srtitle">Email</div></div>
                            <div id="srcmd" class="srcmd"><div class="srtitle">Options</div></div>
                        </div>
                    </div>
                </div>
            </fieldset>
        </div>
        <div id="subjects">
        
        </div>
        <div id="chores">
        
        </div>

    </div>
</asp:Content>

