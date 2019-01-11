
function stratVideo(Id, viewName, controllers) {
    //var user = getUserId();
    

    //var user = getUserId();
    //alert(user);
    var idx = 0;
    hwcam.StartPreview(idx);
    hwcam.SetCamResIndex(idx, 0);
    var myDate = new Date();
    //var path = Configuration.WebConfigurationManager.AppSettings["VideoPath"];
   // alert(path);
    var filepath = "C:\\FileUploadTemp\\" + Id + "_" + viewName + "," + controllers + "_" + usersId + "_" + myDate.getFullYear() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getDate() + " " + myDate.getHours() +
                                 myDate.getMinutes() + myDate.getSeconds() + ".mp4";
    hwcam.StartRecord(idx, filepath, 1);
}

var usersId;

function getId() {
    $.ajax({
        type: "POST",
        url: '@Url.Action("GetUserLoginId", "PenaltyCaseAjax")',
        data: "",
        success: function (sesponseTest) {
            usersId = (sesponseTest);
        }
    });
}


function endVideo() {
    //$.ajax({
    //    type: "POST",
    //    url: '@Url.Action("GetUserHasDriver", "PenaltyCaseAjax")',
    //    data: "",
    //    success: function (sesponseTest) {
    //        alert(sesponseTest);
    //    }
    //});


    hwcam.StartPreview(0);
    hwcam.StopRecord(0);
    hwcam.StopPreview(0);
}
