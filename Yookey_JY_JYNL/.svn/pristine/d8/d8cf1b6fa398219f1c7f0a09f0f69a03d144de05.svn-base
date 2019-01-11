function DialogShow(Url, Title, BtnName, Width, Height) {

    $.ajax({
        url: Url,
        type: "Post",
        success: function (data) {
            $("#userModal #userPreview").html(data);
        }
    });

    $("#userModal #userModalLabel").text(Title);
    $("#userModal #operateUser-btn").text(BtnName);
    $('.modal-content').css('width', Width);
    $('.modal-dialog').css('width', Width);
    $('.modal-content').css('height', Height);
    $('.modal-dialog').css('height', Height);
    $("#userModal").modal('show');
}

