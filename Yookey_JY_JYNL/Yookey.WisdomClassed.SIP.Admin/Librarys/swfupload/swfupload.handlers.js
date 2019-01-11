/* ******************************************
*	初始化SWFUpload上传控件
* ****************************************** */
function InitSWFUpload(upurl, uppath, upsize, flashurl, iswater, isthumbnail, ptype, UploadCount) {
    var sendUrl = upurl + "?action=MultipleFile&UpFilePath=" + uppath + "&folderName=" + ptype;
    if (arguments.length == 5) {
        sendUrl = upurl + "?action=MultipleFile&UpFilePath=" + uppath + "&IsWater=" + iswater + "&folderName=" + ptype;
    }
    if (arguments.length == 6) {
        sendUrl = upurl + "?action=MultipleFile&UpFilePath=" + uppath + "&IsWater=" + iswater + "&IsThumbnail=" + isthumbnail + "&folderName=" + ptype;
    }
    var swfu = new SWFUpload({
        // Backend Settings
        upload_url: sendUrl,
        file_post_name: uppath,
        post_params: { "ASPSESSID": "NONE" },

        file_size_limit: upsize, // 2MB
        file_types: "*.jpg;*.jpge;*.png;*.gif",
        file_types_description: "JPG Images",
        file_upload_limit: UploadCount, //限定用户一次性最多上传多少个文件，在上传过程中，该数字会累加，如果设置为“0”，则表示没有限制
        file_queue_error_handler: fileQueueError,
        file_dialog_complete_handler: fileDialogComplete,
        upload_progress_handler: uploadProgress,
        upload_error_handler: uploadError,
        upload_success_handler: uploadSuccess,
        // upload_complete_handler: uploadComplete,

        // Button Settings
        button_placeholder_id: "upload",
        button_width: 56,
        button_height: 22,
        button_text: '添加证据',
        button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,
        button_cursor: SWFUpload.CURSOR.HAND,

        // Flash Settings
        flash_url: flashurl,

        custom_settings: {
            upload_target: "show"
        },
        // Debug Settings
        debug: false
    });
}

/* ******************************************
*	返回上传的状态
* ****************************************** */
function uploadSuccess(file, serverData) {
    try {
        //var progress = new FileProgress(file, this.customSettings.upload_target);
        //var jsonstr = eval('(' + serverData + ')');
        //if (jsonstr.msg == '0') {
        //    progress.setComplete();
        //    progress.setStatus(jsonstr.msbox);
        //    progress.toggleCancel(false);
        //}
        //else if (jsonstr.msg == '2') {
        //    progress.setComplete();
        //    progress.setStatus("对不起！您所报送的违章超出大规定的大小。");
        //    progress.toggleCancel(false, this);
        //}
        //else if (jsonstr.msg == '1') {
        //    var imgArr = jsonstr.msbox.split(",");
        //    var type = $("#DrpFileType").val();   //得到照片的类别

        //    if (typeof (type) == "undefined")  //如果照片的类别为空的话，默认给“现场照片”
        //        type = "00850010";

        //    if (imgArr.length == 2) {
        //        addImage(imgArr[0], imgArr[1], type, imgArr[3]);
        //    } else {
        //        addImage(jsonstr.msbox, jsonstr.msbox, type, jsonstr.wmsbox);
        //    }
        //    progress.setStatus("缩略图创建成功.");
        //    progress.toggleCancel(false, this);
        //}
        var jsonstr = eval('(' + serverData + ')');
        addImage(jsonstr.LinkUrl, jsonstr.LinkUrl, "1", jsonstr.NewFileName, jsonstr.OldFileName, jsonstr.SaveUrl);
    } catch (ex) {
        this.debug(ex);
    }
}


/********************************************
*裁剪图片
********************************************/
function DrawImage(ImgD, width, height) {
    var image = new Image();
    var iwidth = width;
    var iheight = height;
    image.src = ImgD.src;
    if (image.width > 0 && image.height > 0) {
        if (image.width / image.height >= iwidth / iheight) {
            if (image.width > iwidth) {
                ImgD.width = iwidth;
                ImgD.height = (image.height * iwidth) / image.width;
            }
            else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = image.width + "×" + image.height;
        }
        else {
            if (image.height > iheight) {
                ImgD.height = iheight;
                ImgD.width = (image.width * iheight) / image.height;
            }
            else {
                ImgD.width = image.width;
                ImgD.height = image.height;
            }
            ImgD.alt = image.width + "×" + image.height;
        }
    }
}

/* ******************************************
*	添加图片列表
* ****************************************** */
//缩略图地址，大图地址，选中的案件类别
//function addImage(bigSrc, smallSrc, type, NewFileName, OldFileName, SaveUrl) {
//    var focus_photo = $('#focus_photo').val();
//    var newLi = $('<li></li>');
//    var claname = '';
//    if (focus_photo == '') {
//        $('#focus_photo').val(smallSrc);
//        claname = 'current';
//    }
//    var hidValue = $('<input type="hidden" name="hide_photo_name" value="' + bigSrc +  '|' + NewFileName + '|' + OldFileName + '|' + SaveUrl + '" />').appendTo(newLi);
//    var newImg = $('<img id="previewImage" src="' + smallSrc + '" bigsrc="' + bigSrc + '" onmousemove=\"imagePreview();\" onclick="focus_img(this);" onload="DrawImage(this,120,120);"  class="' + claname + '"/>').appendTo(newLi);
//    var br = $('<br />').appendTo(newLi);
//    var forea = $('<a href="javascript:;" onclick="show_link(this);">链接</a>').appendTo(newLi);
//    var downa = $('<a href="javascript:;" onclick="del_img(this);">删除</a>').appendTo(newLi);
//    newLi.appendTo("#show_list ul");
//}


/* ******************************************
*	添加图片列表
* ****************************************** */
//bigSrc　显示上传到服务端图片的地址
//bigwSrc 调用WebService写入的路径地址
function addImage(bigSrc, smallSrc, type, NewFileName, OldFileName, SaveUrl) {
    var focus_photo = $('#focus_photo').val();
    var newLi = $('<li></li>');
    var claname = '';
    if (focus_photo == '') {
        $('#focus_photo').val(smallSrc);
        claname = 'current';
    }
    var hidValue = $('<input type="hidden" name="hide_photo_name" value="' + NewFileName + '|' + OldFileName + '|' + SaveUrl + '" />').appendTo(newLi);
    var newImg = $('<img id="previewImage" src="' + smallSrc + '" bigsrc="' + bigSrc + '" onmousemove=\"imagePreview();\" onclick="focus_img(this);" onload="DrawImage(this,120,120);"  class="' + claname + '"/>').appendTo(newLi);
    var br = $('<br />').appendTo(newLi);
    var forea = $('<a href="javascript:;" onclick="show_link(this);">链接</a>').appendTo(newLi);
    var downa = $('<a href="javascript:;" onclick="del_img(this);">删除</a>').appendTo(newLi);
    newLi.appendTo("#show_list ul");
}



/* ******************************************
*	删除LI元素
* ****************************************** */
function del_img(obj) {
    var focusphoto = $("#focus_photo");
    var smallimg = $(obj).prevAll("img").eq(0).attr("src");
    var node = $(obj).parent(); //要删除的LI节点
    node.remove(); //删除DOM元素
    //检查是否为封面
    if (focusphoto.val() == smallimg) {
        focusphoto.val("");
        var firtimg = $("#show_list ul li img").eq(0);
        firtimg.addClass("current"); //取第一张做为封面
        focusphoto.val(firtimg.attr("src")); //重新给封面的隐藏域赋值
    }
}


//通过js删除已上传的本地图片
function del_File(FileAddr) {
    $.ajax({
        type: "POST",
        url: "../../Services/upload_ajax.ashx?fileaddr=" + FileAddr + "&rnd=" + Math.random(),
        timeout: 20000,
        beforeSend: function (XMLHttpRequest) {
            $("#").html("");
        },
        success: function (data, textStatus) {
            $("").html(data);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            $("").html("");
        }
    });
}

/* ******************************************
*	设置相册封面
* ****************************************** */
function focus_img(obj) {
    $("#focus_photo").val($(obj).attr("src"));

    $(obj).addClass("current");
}

/* ******************************************
*	显示图片链接
* ****************************************** */
function show_link(obj) {
    var bigimg = $(obj).prevAll("img").eq(0).attr("bigsrc");
    alert(bigimg);
}

function fileQueueError(file, errorCode, message) {
    try {
        var progress = new FileProgress(file, this.customSettings.progressTarget);
        progress.setError();
        progress.toggleCancel(false);
        if (errorCode === SWFUpload.errorCode_QUEUE_LIMIT_EXCEEDED) {
            errorName = "您选择的文件太多.";
        }
        if (errorName !== "") {
            alert(errorName);
            return;
        }

        switch (errorCode) {
            case SWFUpload.QUEUE_ERROR.ZERO_BYTE_FILE:
                progress.setStatus(file.name + "文件太小");
                progress.toggleCancel(false, this);
                break;
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                progress.setStatus(file.name + "文件太大");
                progress.toggleCancel(false, this);
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                progress.setStatus(file.name + "文件类型出错");
                progress.toggleCancel(false, this);
                break;
            default:
                if (file !== null) {
                    progress.setStatus("未知错误");
                    progress.toggleCancel(false, this);
                }
                break;
        }

    } catch (ex) {
        this.debug(ex);
    }

}

function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 0) {
            this.startUpload();
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadProgress(file, bytesLoaded) {

    try {
        var percent = Math.ceil((bytesLoaded / file.size) * 100);

        var progress = new FileProgress(file, this.customSettings.upload_target);
        progress.setProgress(percent);
        if (percent === 100) {
            progress.setStatus("创建缩略图...");
            progress.toggleCancel(false, this);
        } else {
            progress.setStatus("上传...");
            progress.toggleCancel(true, this);
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadComplete(file) {
    try {
        /*  I want the next upload to continue automatically so I'll call startUpload here */
        if (this.getStats().files_queued > 0) {
            this.startUpload();
        } else {
            var progress = new FileProgress(file, this.customSettings.upload_target);
            progress.setComplete();
            progress.setStatus("上传完成.");
            progress.toggleCancel(false);
        }
    } catch (ex) {
        this.debug(ex);
    }
}

function uploadError(file, errorCode, message) {
    var imageName = "error.gif";
    var progress;
    try {
        switch (errorCode) {
            case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                try {
                    progress = new FileProgress(file, this.customSettings.upload_target);
                    progress.setCancelled();
                    progress.setStatus("Cancelled");
                    progress.toggleCancel(false);
                }
                catch (ex1) {
                    this.debug(ex1);
                }
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                try {
                    progress = new FileProgress(file, this.customSettings.upload_target);
                    progress.setCancelled();
                    progress.setStatus("Stopped");
                    progress.toggleCancel(true);
                }
                catch (ex2) {
                    this.debug(ex2);
                }
            case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                imageName = "uploadlimit.gif";
                break;
            default:
                alert(message);
                break;
        }
        addImage("images/" + imageName);
    } catch (ex3) {
        this.debug(ex3);
    }
}

function fadeIn(element, opacity) {
    var reduceOpacityBy = 5;
    var rate = 30; // 15 fps


    if (opacity < 100) {
        opacity += reduceOpacityBy;
        if (opacity > 100) {
            opacity = 100;
        }

        if (element.filters) {
            try {
                element.filters.item("DXImageTransform.Microsoft.Alpha").opacity = opacity;
            } catch (e) {
                // If it is not set initially, the browser will throw an error.  This will set it if it is not set yet.
                element.style.filter = 'progid:DXImageTransform.Microsoft.Alpha(opacity=' + opacity + ')';
            }
        } else {
            element.style.opacity = opacity / 100;
        }
    }

    if (opacity < 100) {
        setTimeout(function () {
            fadeIn(element, opacity);
        }, rate);
    }
}

/* ******************************************
*	FileProgress Object
*	Control object for displaying file info
* ****************************************** */

function FileProgress(file, targetID) {
    this.fileProgressID = "divFileProgress";

    this.fileProgressWrapper = document.getElementById(this.fileProgressID);
    if (!this.fileProgressWrapper) {
        this.fileProgressWrapper = document.createElement("div");
        this.fileProgressWrapper.className = "progressWrapper";
        this.fileProgressWrapper.id = this.fileProgressID;

        this.fileProgressElement = document.createElement("div");
        this.fileProgressElement.className = "progressContainer";

        var progressCancel = document.createElement("a");
        progressCancel.className = "progressCancel";
        progressCancel.href = "#";
        progressCancel.style.visibility = "hidden";
        progressCancel.appendChild(document.createTextNode(" "));

        var progressText = document.createElement("div");
        progressText.className = "progressName";
        progressText.appendChild(document.createTextNode(file.name));

        var progressBar = document.createElement("div");
        progressBar.className = "progressBarInProgress";

        var progressStatus = document.createElement("div");
        progressStatus.className = "progressBarStatus";
        progressStatus.innerHTML = "&nbsp;";

        this.fileProgressElement.appendChild(progressCancel);
        this.fileProgressElement.appendChild(progressText);
        this.fileProgressElement.appendChild(progressStatus);
        this.fileProgressElement.appendChild(progressBar);

        this.fileProgressWrapper.appendChild(this.fileProgressElement);

        document.getElementById(targetID).appendChild(this.fileProgressWrapper);
        fadeIn(this.fileProgressWrapper, 0);

    } else {
        this.fileProgressElement = this.fileProgressWrapper.firstChild;
        this.fileProgressElement.childNodes[1].firstChild.nodeValue = file.name;
    }

    this.height = this.fileProgressWrapper.offsetHeight;

}
FileProgress.prototype.setProgress = function (percentage) {
    this.fileProgressElement.className = "progressContainer green";
    this.fileProgressElement.childNodes[3].className = "progressBarInProgress";
    this.fileProgressElement.childNodes[3].style.width = percentage + "%";
};
FileProgress.prototype.setComplete = function () {
    this.fileProgressElement.className = "progressContainer blue";
    this.fileProgressElement.childNodes[3].className = "progressBarComplete";
    this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setError = function () {
    this.fileProgressElement.className = "progressContainer red";
    this.fileProgressElement.childNodes[3].className = "progressBarError";
    this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setCancelled = function () {
    this.fileProgressElement.className = "progressContainer";
    this.fileProgressElement.childNodes[3].className = "progressBarError";
    this.fileProgressElement.childNodes[3].style.width = "";

};
FileProgress.prototype.setStatus = function (status) {
    this.fileProgressElement.childNodes[2].innerHTML = status;
};

FileProgress.prototype.toggleCancel = function (show, swfuploadInstance) {
    this.fileProgressElement.childNodes[0].style.visibility = show ? "visible" : "hidden";
    if (swfuploadInstance) {
        var fileID = this.fileProgressID;
        this.fileProgressElement.childNodes[0].onclick = function () {
            swfuploadInstance.cancelUpload(fileID);
            return false;
        };
    }
};