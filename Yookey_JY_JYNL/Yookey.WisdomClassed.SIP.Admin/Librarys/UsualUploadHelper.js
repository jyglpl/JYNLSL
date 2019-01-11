var iMaxUpdateFileSize = 1024 * 20000;

//初始化上传控件
//ConId:控件Id
//folderName：保存的文件夹名称
//type：是否是单文件上传
//callback: 上传后执行方法
function StartUploadify(conId, folderName, fileExt, type, callback) {
    var rootPath = RootPath();
    $("#" + conId).uploadify({
        'uploader': rootPath + '/Librarys/uploadify-v2.1.4/uploadify.swf?s' + Math.random(),
        'cancelImg': rootPath + '/Librarys/uploadify-v2.1.4/cancel.png',
        'buttonText': "Select File",
        'buttonImg': rootPath + '/Librarys/uploadify-v2.1.4/selectfiles.png',
        'width': 185,
        'height': 30,
        'script': rootPath + '/Upload/PicUpload?folderName=' + folderName + '&s=' + Math.random(),
        'folder': '/UploadFile',
        'fileDesc': 'Files',
        'fileExt': fileExt,
        'sizeLimit': iMaxUpdateFileSize,
        'simUploadLimit': 1,
        'multi': false,
        'auto': true,
        'onSelect': function (a, b, c) { /*选择文件上传时可以禁用某些按钮*/ },
        'onComplete': function (a, b, c, d, e) {
            callback(a, b, c, d, e);
        },
        'onAllComplete': function (a, b) {

        },
        'onCancel': function (a, b, c, d, e) { },
        'onError': function (a, b, c, d, e) {
            if (c.size > iMaxUpdateFileSize) {
                setTimeout("$('#" + conId + "').uploadifyCancel('" + b + "')", 2000);
            }
        }
    });
}