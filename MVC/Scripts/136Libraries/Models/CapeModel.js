function CapeModel(asyncIndicator) {
    if (asyncIndicator == undefined) {
        asyncIndicator = true;
    }

    this.Create = function (Cape, callback) {
        $.ajax({
            async: asyncIndicator,
            method: "POST",
            url: "http://localhost:9393/Api/Cape/InsertCapeRating/id=" + id,
            data: cape,
            dataType: "json",
            success: function (result) {
                callback(result);
            },
            error: function () {
                alert('Error while adding cape.  Is your service layer running?');
            }
        });
    };

    this.GetCapeRating = function (id, callback) {
        alert("baba");
        var url = "http://localhost:9393/Api/Cape/GetCapeRating?stud_id" + id;
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
                alert('Error while loading cape detail.  Is your service layer running?');
            }
        });
    };
}
