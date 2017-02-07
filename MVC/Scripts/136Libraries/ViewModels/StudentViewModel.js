function StudentViewModel() {

    var StudentModelObj = new StudentModel();
    var self = this;
    var initialBind = true;
    var studentListViewModel = ko.observableArray();
    var selfId = -1;

    this.Initialize = function() {

        var viewModel = {
            id: ko.observable("A0000111"),
            ssn: ko.observable("555-55-3333"),
            first: ko.observable("Bruce"),
            last: ko.observable("Wayne"),
            email: ko.observable("bwayne@ucsd.edu"),
            password: ko.observable("password"),
            shoesize: ko.observable("10"),
            weight: ko.observable("160"),
            add: function (data) {
                self.CreateStudent(data);
            }
        };

        ko.applyBindings(viewModel, document.getElementById("divStudent"));
    };

    this.CreateStudent = function(data) {
        var model = {
            StudentId: data.id(),
            SSN: data.ssn(),
            FirstName: data.first(),
            LastName: data.last(),
            Email: data.email(),
            Password: data.password(),
            ShoeSize: data.shoesize(),
            Weight: data.weight()
        }

        StudentModelObj.Create(model, function(result) {
            if (result == "ok") {
                alert("Create student successful");
            } else {
                alert("Error occurred");
            }
        });

    };

    this.GetAll = function() {

        StudentModelObj.GetAll(function(studentList) {
            studentListViewModel.removeAll();

            for (var i = 0; i < studentList.length; i++) {
                studentListViewModel.push({
                    id: studentList[i].StudentId,
                    first: studentList[i].FirstName,
                    last: studentList[i].LastName,
                    email: studentList[i].Email
                });
            }

            if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divStudentListContent"));
                initialBind = false; // this is to prevent binding multiple time because "Delete" functio calls GetAll again
            }
        });
    };

    this.GetDetail = function (id) {

        StudentModelObj.GetDetail(id, function (result) {

            var student = {
                id: result.StudentId,
                first: result.FirstName,
                last: result.LastName,
                email: result.Email,
                shoesize: result.ShoeSize,
                weight: result.Weight,
                ssn: result.SSN
            };

            if (initialBind) {
                ko.applyBindings({ viewModel: student }, document.getElementById("divStudentContent"));
            }
        });
    };

    this.GetEnrollment = function (id) {
        StudentModelObj.GetEnrollment(id, function (result) {
            studentListViewModel.removeAll();
            for (var i = 0; i < result.length; i++) {
                studentListViewModel.push({
                    studentid: result[i].StudentId,
                    coursetitle: result[i].CourseTitle,
                    scheduleid: result[i].ScheduleId,
                    instruct: result[i].InstructName,
                    year: result[i].Year,
                    quarter: result[i].Quarter,
                    session: result[i].Session,
                    day: result[i].Day,
                    time: result[i].Time,
                    grade: result[i].Grade
                });
            }
            //if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divEnrollmentContent"));
            //}
        });
    };

    this.GetEnrollmentSchedule = function (id) {
        StudentModelObj.GetEnrollmentSchedule(id, function (result) {
            studentListViewModel.removeAll();
            for (var i = 0; i < result.length; i++) {
                studentListViewModel.push({
                    studentid: result[i].StudentId,
                    scheduleid: result[i].ScheduleId,
                    coursetitle: result[i].CourseTitle,
                    instruct: result[i].InstructName,
                    year: result[i].Year,
                    quarter: result[i].Quarter,
                    session: result[i].Session,
                    day: result[i].Day,
                    time: result[i].Time
                });
            }
            //if (initialBind) {
                ko.applyBindings({ viewModel: studentListViewModel }, document.getElementById("divStudentSchedule"));
            //}
        });
    };

    ko.bindingHandlers.DeleteStudent = {
        init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function() {
                var id = viewModel.id;

                StudentModelObj.Delete(id, function(result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        studentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    ko.bindingHandlers.AddCourse = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.studentid;
                var course = viewModel.scheduleid;
                StudentModelObj.AddEnrollment(id, course, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        studentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    ko.bindingHandlers.DropCourse = {
        init: function (element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function () {
                var id = viewModel.studentid;
                var course = viewModel.scheduleid;
                StudentModelObj.DropEnrollment(id, course, function (result) {
                    if (result != "ok") {
                        alert("Error occurred");
                    } else {
                        studentListViewModel.remove(viewModel);
                    }
                });
            });
        }
    };

    ko.bindingHandlers.DeleteStudentAsync = {
        init: function(element, valueAccessor, allBindings, viewModel, bindingContext) {
            $(element).click(function() {
                var id = viewModel.id;

                StudentModelObj.DeleteAsync(id, function(result) {
                    alert(result);
                    //studentListViewModel.remove(viewModel);
                });
            });
        }
    };

}
