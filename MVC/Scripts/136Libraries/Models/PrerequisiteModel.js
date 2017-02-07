//// THe reason for asyncIndicator is to make sure Jasmine test cases can run without error
//// Due to async nature of ajax, the Jasmine's compare function would throw an error during
//// a callback. By allowing this optional paramter for StudentModel function, it forces the ajax
//// call to be synchronous when running the Jasmine tests.  However, the viewModel will not pass
//// this parameter so the asynncIndicator would be undefined which is set to "true". Ajax would
//// be async when called by viewModel.
function PrerequisiteModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.GetPrerequisite = function (callback) {
        var url = "http://localhost:9393/Api/Course/GetPrerequisite";

        $.ajax({
            async: asyncIndicator,
            method: "GET",
            url: url,
            data: "",
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while loading prerequisite detail.  Is your service layer running?');
            }
        });
    };

    this.DeletePrerequisite = function (postid, preid, callback) {
        alert("deleting");
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/DeletePrerequisite?course_id=" + postid + "&prereq_id=" + preid,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleting prerequisite.  Is your service layer running?');
            }
        });
    };

    this.UpdatePrerequisite = function (postid, preid, callback) {
        alert("wth bruh");
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/UpdatePrerequisite?course_id=" + postid + "&prereq_id=" + preid,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while updating prerequisite.  Is your service layer running?');
            }
        });
    };

    this.InsertPrerequisite = function (postid, preid, callback) {
        alert("Inserting");
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Course/InsertPrerequisite?course_id=" + postid + "&prereq_id=" + preid,
            data: '',
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while deleting prerequisite.  Is your service layer running?');
            }
        });
    };

    this.Load = function (callback) {
        $.ajax({
            url: "http://localhost:9393/Api/Course/GetCourseList",
            data: "",
            dataType: "json",
            success: function (courseListData) {
                callback(courseListData);
            },
            error: function () {
                alert('Error while loading course list.  Is your service layer running?');
            }
        });
    };
}
