$(function () {
    $(window).load(function () {
        window.setTimeout(function () {
            $('#ajax-loader').fadeOut();
        }, 200);
    });
});
//样式
function readyIndex() {
    $(".main_menu li div").click(function () {
        $(".main_menu li div").removeClass('main_menu leftselected');
        $(this).addClass('main_menu leftselected');
    }).hover(function () {
        $(this).addClass("hoverleftselected");
    }, function () {
        $(this).removeClass("hoverleftselected");
    });
    //点击TOP按钮显示标签
    $("#topnav .droppopup a").hover(function () {
        $("#topnav .droppopup a").removeClass('onnav');
        $(this).addClass('onnav');
        var Y = $(this).attr("offsetLeft");
        $(this).find('.popup').show().css('top', ($(this).offset().top + 71)).css('left', $(this).offset().left - ($(this).find('.popup').width() / 2 - 36));
    }, function () {
        $("#topnav .droppopup a").removeClass('onnav');
        $(this).find('.popup').hide();
    });
    $(".popup li").click(function () {
        $('.popup').hide();
    });
}
/**安全退出**/
function IndexOut() {
    var msg = "<div class='ui_alert'>确认要退出系统？</div>";
    top.$.dialog({
        id: "confirmDialog",
        lock: true,
        icon: "hits.png",
        content: msg,
        title: "系统提示",
        button: [
            {
                name: '退出',
                callback: function() {
                    Loading(true, "正在退出系统...");
                    window.setTimeout(function() {
                        getAjax(RootPath() + "/Account/LogOff", "", function(data) {
                            window.opener = null;
                            var wind = window.open('', '_self');
                            wind.close();
                        });
                    }, 200);
                }
            },
            {
                name: '切换账号',
                callback: function() {
                    Loading(true, "正在注销系统...");
                    window.setTimeout(function() {
                        getAjax(RootPath() + "/Account/LogOff", "", function(data) {
                            window.location.href = RootPath() + '/Account/LoginOn';
                        });
                    }, 200);
                }
            },
            {
                name: '取消'
            }
        ]
    });
}

//个人中心
function PersonCenter() {
    var url = RootPath() + "/Account/ChangePassword";
    Dialog(url, "ResetPassword", "个人中心", 350, 220);
}
//快捷方式列表
function ShortcutsList() {
    $("#Shortcuts").html('');
    //AjaxJson("/Home/ShortcutsListJson", {}, function (DataJson) {
    //    $.each(DataJson, function (i) {
    //        $("#Shortcuts").append("<li onclick=\"AddTabMenu('" + DataJson[i].ModuleId + "', '" + DataJson[i].Location + "', '" + DataJson[i].FullName + "',  '" + DataJson[i].Icon + "','true');\"><img src=\"/Content/Images/Icon16/" + DataJson[i].Icon + "\" />" + DataJson[i].FullName + "</li>");
    //    });
    //});
    $(".popup li").click(function () {
        $('.popup').hide();
    });
}
//快捷方式设置
function Shortcuts() {
    var url = "/Home/Shortcuts";
    openDialog(url, "Shortcut", "快捷方式设置", 500, 300, function (iframe) {
        top.frames[iframe].AcceptClick();
    });
}
//页面关闭事件
function PageClose() {
    var n = window.event.screenX - window.screenLeft;
    var b = n > document.documentElement.scrollWidth - 20;
    if (b && window.event.clientY < 0 || window.event.altKey) {
        window.location.href = "/Login/OutLogin";
    }
}
//技术支持
function Support() {
    Dialog("/Home/SupportPage", "Support", "7 × 24 技术支持服务", 600, 275);
}
//关于我们
function About() {
    alertDialog("姑苏区综合行政执法平台<br>版本1.0.1<br>江苏中越科技发展有限公司<br>保留所有权利", 0);
}
//个性化皮肤设置
function SkinIndex() {
    Dialog("/Home/SkinIndex", "SkinIndex", "个性化设置", 580, 350);
}

//操作手册
function Operation() {
    window.open(RootPath() + '/Home/Assist');
}

//通讯录
function Contacts() {
    //window.open(RootPath() + '/Home/Contacts');
    AddTabMenu('MailList', RootPath() + '/Home/Contacts', '通讯录', 'world_go.png', 'true');
    parent.linkAddTabMenu();
}