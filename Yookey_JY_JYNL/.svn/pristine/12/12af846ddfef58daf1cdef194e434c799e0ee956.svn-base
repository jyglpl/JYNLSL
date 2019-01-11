(function ($) {
    $.nemoLayout = {
        loadAjaxUpload: function (_ButtonID, _ImageID, _HiddenId, _action, _fileurl) {
            /*
            *_ButtonID---上次按钮的ID
            *_ImageID----为图片上层的a标签ID
            *_HiddenId---隐藏域，为传递到后台的图片路径
            *_action----传递方式（add：会把图片隐藏、update：会把图片显示）
            *_fileurl----图片路径（update使用的时候才需要此值）
            */
            if (_action == 'add') {
                $('#' + _ImageID).hide().attr('href', 'javascript:;');
                $('#' + _ImageID + '>img').attr('src', '');
            } else if (_action == 'update') {
                $('#' + _ImageID).show().attr('href', _fileurl);
                $('#' + _ImageID + '>img').attr('src', _fileurl);
            }
            new AjaxUpload("#" + _ButtonID, {
                action: '/Cms/Upload/UploadHandler.ashx',
                responseType: 'json',
                onSubmit: function(file, ext) {
                    if (!(ext && /^(jpg|png|jpeg|gif)$/.test(ext))) {
                        // 扩展名不允许
                        alert('错误：无效的文件扩展名！');
                        // 取消上传
                        return false;
                    } else {
                        $('#' + _ButtonID).removeClass('.icon-upload-img').html("<img border=0 src='' /><font color='gray'>正在上传，请稍候……</font>");
                    }
                },
                onComplete: function(file, response) {
                    if (response.result != '上传失败') {
                        $('#' + _HiddenId).val(response.result);
                        $('#' + _ImageID).show().attr('href', response.result);
                        $('#' + _ImageID + '>img').attr('src', response.result);
                        $('#' + _ButtonID).removeClass('.icon-upload-img').html("<font color='green'>上传成功</font>");
                    } else {
                        $('#' + _ButtonID).removeClass('.icon-upload-img').html("<font color='red'>上传失败</font>");
                    }
                    $('#' + _ButtonID).html('').addClass('.icon-upload-img');
                }
            });
        },
        FireDefaultButton: function(event, target) {
            if (event.keyCode == 13 && !(event.srcElement && (event.srcElement.tagName.toLowerCase() == "textarea"))) {
                var defaultButton = document.getElementById(target);
                if (defaultButton && typeof(defaultButton.click) != "undefined") {
                    defaultButton.click();
                    event.cancelBubble = true;
                    if (event.stopPropagation) event.stopPropagation();
                    return false;
                }
            }
            return true;
        },
        logout:function(_title) {
            $.messager.confirm('系统提示', '确定要退出' + _title + '吗？', function (r) {
                if (r) {
                    $.ajax({
                        cache: false,
                        type: "POST",
                        url: 'LoginHandler.ashx?action=Logout',
                        success: function (result) {
                            if (result == "OK") {
                                window.location = 'Login.aspx';
                            }
                        }
                    });
                }
            });
        },
        pagerFilter: function (data) {
            if (typeof data.length == 'number' && typeof data.splice == 'function') {
                data = {
                    total: data.length,
                    rows: data
                };
            }
            var dg = $(this);
            var opts = dg.datagrid('options');
            var pager = dg.datagrid('getPager');
            pager.pagination({
                onSelectPage: function (pageNum, pageSize) {
                    opts.pageNumber = pageNum;
                    opts.pageSize = pageSize;
                    pager.pagination('refresh', {
                        pageNumber: pageNum,
                        pageSize: pageSize
                    });
                    dg.datagrid('loadData', data);
                },
                onRefresh: function () {
                    $.gridView.initDataGridSource();
                }
            });
            if (!data.originalRows) {
                data.originalRows = (data.rows);
            }
            var start = (opts.pageNumber - 1) * parseInt(opts.pageSize);
            var end = start + parseInt(opts.pageSize);
            data.rows = (data.originalRows.slice(start, end));
            return data;
        },
        showUpdatePwd:function() {
            $('#win').dialog('open').dialog('setTitle', '修改密码');
            $('#fm').form('clear');
            $('#oldpass').focus();
        },
        updatePwd:function() {
            $('#fm').form('submit', {
                url: '/Cms/Basic/BasicHandler.ashx?action=UpdatePwd',
                onSubmit: function () {
                    return $(this).form('validate');
                },
                success: function (result) {
                    if (result === "OK") {
                        $.messager.alert('提示', '修改成功', 'info');
                        $('#win').window('close');
                    }
                    else {
                        $.messager.alert('提示', '错误：' + result, 'warning');
                    }
                }
            });
        }
    };
})(jQuery);