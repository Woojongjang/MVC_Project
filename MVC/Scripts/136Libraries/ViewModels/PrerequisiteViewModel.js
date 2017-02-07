function PrerequisiteViewModel() {

    var PrerequisiteModelObj = new PrerequisiteModel();
    var self = this;
    var initialBind = true;
    var prerequisiteListViewModel = ko.observableArray();
    var selfId = -1;

    this.Initialize = function () {
        PrerequisiteModelObj.GetPrerequisite(function (result) {

            prerequisiteListViewModel.removeAll();

            for (var i = 0; i < result.length; i++) {
                prerequisiteListViewModel.push({
                    prereq_id: result[i].prereq_course,
                    prereq_title: result[i].prereq_title,
                    postreq_id: result[i].postreq_course,
                    postreq_title: result[i].postreq_title
                });
            }

            ko.applyBindings({ viewModel: prerequisiteListViewModel }, document.getElementById("divEditPrerequisite"));

        });
    };

    ko.bindingHandlers.DeletePrerequisite = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var postid = viewModel.postreq_id;
                var preid = viewModel.prereq_id;
                PrerequisiteModelObj.DeletePrerequisite(postid, preid, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        prerequisiteListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    ko.bindingHandlers.UpdatePrerequisite = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var preid = viewModel.prereq_id;
                var postid = viewModel.postreq_id;
                PrerequisiteModelObj.UpdatePrerequisite(postid, preid, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    }
                });
            });
        }
    };

    ko.bindingHandlers.InsertPrerequisite = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var postreq = viewModel.postreq_id;
                var prereq = viewModel.prereq_id;
                PrerequisiteModelObj.InsertPrerequisite(postreq, prereq, function (result) {
                    if (result == "ok") {
                        alert("Course add successful");
                    } else {
                        alert("Error occurred");
                    }
                });
            });
        }
    };

    this.InsertInitialize = function () {

        prerequisiteListViewModel.removeAll();
        prerequisiteListViewModel.push({
            prereq_id: "1",
            postreq_id: "1"
        });
        ko.applyBindings({ viewModel: prerequisiteListViewModel }, document.getElementById("divInsertPrerequisite"));

    };

    this.InsertPrereq = function (data) {
        alert("strat insert prereq");
        //var postid = data.postreq_id();
        //var preid = data.prereq_id();

        /*PrerequisiteModelObj.InsertPrerequisite(postid, preid, function (result) {
            if (result == "ok") {
                alert("Course add successful");
            } else {
                alert("Error occurred");
            }
        });*/

    };

    this.Load = function () {
        var courseListModelObj = new CourseListModel();

        // Because the Load() is a async call (asynchronous), we'll need to use
        // the callback approach to handle the data after data is loaded.
        courseListModelObj.Load(function (courseListData) {

            // courseList - presentation layer model retrieved from /Course/GetCourseList route.
            // courseListViewModel - view model for the html content
            var courseListViewModel = new Array();

            // DTO from the JSON model to the view model. In this case, courseListViewModel doesn't need the "id" attribute
            for (var i = 0; i < courseListData.length; i++) {
                courseListViewModel[i] = {
                    courseid: courseListData[i].CourseId,
                    title: courseListData[i].Title,
                    description: courseListData[i].Description
                };
            }

            // this is using knockoutjs to bind the viewModel and the view (Home/Index.cshtml)
            ko.applyBindings({ viewModel: courseListViewModel }, document.getElementById("divInsertPrereqList"));
        });
    };
}
