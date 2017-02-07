function CapeViewModel() {

    var CapeModeObj = new CapeModel();
    var self = this;
    var initialBind = true;
    var capeListViewModel = ko.observableArray();

    this.Initialize = function (id) {
        CapeModeObj.GetCapeRating(id, function (result) {
            capeListViewModel.removeAll();
            for (var i = 0; i < result.length; i++) {
                capeListViewModel.push({
                    studentid: result[i].studentID,
                    instructor: result[i].instructorID,
                    scheduleid: result[i].ScheduleId,
                    rating: result[i].CapeRating
                });
            }

            ko.applyBindings({ viewModel: capeListViewModel }, document.getElementById("divViewEditCapes"));

        });
    };


    this.InsertCapeRating = function (data) {
        var model = {
            stud_id: data.stud_id(),
            instr_id: data.instr_id(),
            sched_id: data.sched_id(),
            rating: data.rating()
        }

        CapeModelObj.Create(model, function (result) {
            if (result == "ok") {
                alert("Create Cape successful");
            } else {
                alert("Error occurred");
            }
        });

    };
}
