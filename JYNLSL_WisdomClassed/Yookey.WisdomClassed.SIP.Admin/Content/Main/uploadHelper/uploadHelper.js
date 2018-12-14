var iMaxUpdateFileSize = 1024 * 2000;
//初始化上传控件
//ConId:控件Id
//folderName：保存的文件夹名称
//type：是否是单文件上传（logo图），true：是，false：不是（多图，比如是：资源图片集合）
//callback: 上传后执行方法
function StartUploadify(ConId, folderName, type, callback) {
    var rootPath = RootPath();
    $("#" + ConId).uploadify({
        'uploader': rootPath + '/Librarys/uploadify-v2.1.4/uploadify.swf?s' + Math.random(),
        'cancelImg': rootPath + '/Librarys/uploadify-v2.1.4/cancel.png',
        'buttonText': "Select File",
        'buttonImg': rootPath + '/Librarys/uploadify-v2.1.4/selectfiles.png',
        'width': 185,
        'height': 30,
        'script': rootPath + '/Upload/PicUpload?folderName=' + folderName + '&s=' + Math.random(),
        'folder': '/UploadFile',
        'fileDesc': 'Files',
        'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
        'sizeLimit': iMaxUpdateFileSize,
        'simUploadLimit': 1,
        'multi': false,
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) {
            //if (type) {//单文件上传 调用SetLogoImg
            //    //SetLogoImg(d);
            //    callback(a, b, c, d, e);
            //}
            //if (!type) {//多文件上传 SetFlashImages
            //    //SetFlashImages(d);
            //}

            callback(a, b, c, d, e);
        },
        'onAllComplete': function (a, b) {
            //enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            if (c.size > iMaxUpdateFileSize) {
                //myCustomAlter("上传图片大小应为200kb以内，请修改后再上传");
                setTimeout("$('#" + ConId + "').uploadifyCancel('" + b + "')", 2000);
            }
        }
    });
}

//保存缩略图
//ConId:控件Id
//folderName：保存的文件夹名称
//type：是否是单文件上传（logo图），true：是，false：不是（多图，比如是：资源图片集合）
function StartUploadImage(ConId, folderName, type) {
    var rootPath = RootPath();
    $("#" + ConId).uploadify({
        'uploader': rootPath + '/Librarys/uploadify-v2.1.4/uploadify.swf?s' + Math.random(),
        'cancelImg': rootPath + '/Librarys/uploadify-v2.1.4/cancel.png',
        'buttonText': "Select File",
        'buttonImg': rootPath + '/Librarys/uploadify-v2.1.4/selectfiles.png',
        'width': 185,
        'height': 30,
        'script': rootPath + '/Upload/ThumbnailUpload?folderName=' + folderName + '&s=' + Math.random(),
        'folder': '/UploadFile',
        'fileDesc': 'Files',
        'fileExt': '*.jpg;*.jpeg;*.gif;*.png',
        'sizeLimit': 1024 * 1024,
        'simUploadLimit': 1,
        'multi': false,
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) {
            if (type) {//单文件上传 调用SetLogoImg
                SetLogoImg(d);
            }
            if (!type) {//多文件上传 SetFlashImages
                SetFlashImages(d);
            }
        },
        'onAllComplete': function (a, b) {
            enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            if (c.size > iMaxUpdateFileSize) {
                alert("上传图片大小应为1M以内，请修改后再上传");
                setTimeout("$('#" + ConId + "').uploadifyCancel('" + b + "')", 2000);
            }
        }
    });
}

//初始化上传控件
//ConId:控件Id
//folderName：保存的文件夹名称
//type：是否是单文件上传（logo图），true：是，false：不是（多图，比如是：资源图片集合）
//needzip:是否需要压缩文件,true:压缩,false:不压缩
function StartUploadifyFile(conId, folderName, type, needzip) {
    var rootPath = RootPath();
    $("#" + conId).uploadify({
        'uploader': rootPath + '/Librarys/uploadify-v2.1.4/uploadify.swf?s' + Math.random(),
        'cancelImg': rootPath + '/Librarys/uploadify-v2.1.4/cancel.png',
        'buttonText': "Select File",
        'buttonImg': rootPath + '/Librarys/uploadify-v2.1.4/selectfiles.png',
        'width': 185,
        'height': 30,
        'script': rootPath + '/Upload/FileUpload',
        'scriptData': { "folderName": folderName, "returntype": 1, "zip": needzip, "s": Math.random() },
        'folder': '/UploadFile',
        'fileDesc': 'Files',
        'fileExt': '*.doc;*.xls;*.xlsx;*.pdf;*.rar;*.zip',
        'sizeLimit': 1024 * 1024 * 1024,
        'simUploadLimit': 1,
        'multi': false,
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) {
            if (type) {//单文件上传 调用SetLogoImg
                //SetLogoImg(d);
                callback(a, b, c, d, e);
            }
            if (!type) {//多文件上传 SetFlashImages
                //SetFlashImages(d);
            }
        },
        'onAllComplete': function (a, b) {
            enabledSaveButton(true);
        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            if (c.size > iMaxUpdateFileSize) {
                alert("上传图片大小应为200kb以内，请修改后再上传");
                setTimeout("$('#" + conId + "').uploadifyCancel('" + b + "')", 2000);
            }
        }
    });
}

/*
*初始化上传控件（不自动上传）上传方法：StartUpload
*创建人：周庆
*创建日期：2015年5月13日
*@ConId 控件Id
*@上传文件夹
*@type 文件上传类型 true 多文件 false 单文件
*@callback 上传前回调函数
*/
function InitUploader(ConId, folderName, gmId, type, callback) {
    var rootPath = RootPath();
    $("#" + ConId).uploadify({
        'uploader': rootPath + '/Librarys/uploadify-v2.1.4/uploadify.swf?s' + Math.random(),
        'cancelImg': rootPath + '/Librarys/uploadify-v2.1.4/cancel.png',
        'buttonText': "Select File",
        'buttonImg': rootPath + '/Librarys/uploadify-v2.1.4/selectfiles1.png',
        'width': 185,
        'height': 30,
        'script': rootPath + '/Upload/LedgerFileUpload',
        'scriptData': { "folderName": folderName, "gmId": gmId },
        'folder': '/UploadFile',
        'fileDesc': 'Files',
        'fileExt': '*.png;*.jpg;*.jpeg;*.docx;*.doc;*.xls;*.xlsx;*.pdf;*.rar;*.zip',
        'sizeLimit': 1024 * 1024 * 1024,
        'simUploadLimit': 5,
        'queueSizeLimit': 5,
        'uploadLimit': 5,
        'multi': type,
        'auto': false,
        'onProgress': function () {
            
        },
        'onComplete': function (a, b, c, d, e) {
            callback(a, b, c, d, e);
        },
        'onError': function (event, queueId, fileObj, errorObj) {
            alert(errorObj.info);
        }
    });
}
/*
*开始上传
*创建人：周庆
*创建日期：2015年5月13日
*@ConId 控件Id
*/
function StartUpload(ConId) {
    $("#" + ConId).uploadifyUpload();
}



//js获取网站根路径(站点及虚拟目录)
function RootPath() {
    var strFullPath = window.document.location.href;
    var strPath = window.document.location.pathname;
    var pos = strFullPath.indexOf(strPath);
    var prePath = strFullPath.substring(0, pos);
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);
    //return (prePath + postPath);   //如果发布IIS，有虚假目录用用这句
    return (prePath);
}
