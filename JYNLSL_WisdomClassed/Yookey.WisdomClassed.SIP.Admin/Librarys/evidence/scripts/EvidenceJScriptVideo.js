(function ($) {
    $.Evidence = {
        haspermanentper: "0", //永久删除数据权限
        /**加载部门**/
        loaddept: function () {
            $("#deptid").html("");
            $.ajax({
                type: "POST",
                url: "Services/User.ashx",
                data: { action: "2", type: "1", rnd: Math.random() },
                success: function (data) {
                    var json = eval(data);
                    $.each(json,
                        function (i) {
                            $("#deptid").append($("<option></option>").val(json[i].Id).html(json[i].DeptName));
                        });
                    $.Evidence.getdetachment();
                }
            });
        },
        /**根据选择的大队编号加载中队编号**/
        getdetachment: function () {
            $("#detachment").html("");
            var deptid = $("#deptid").val();
            $.ajax({
                type: "POST",
                url: "Services/User.ashx",
                data: { action: "2", type: "2", _deptid: deptid, rnd: Math.random() },
                success: function (data) {
                    var deptjson = eval(data);
                    $.each(deptjson,
                        function (i) {
                            $("#detachment").append($("<option></option>").val(deptjson[i].Id).html(deptjson[i].DeptName));
                        });
                }
            });
        },
        bindDetpTree: function () {
            $.ajax({
                type: "POST",
                url: "/Evidence/QueryTreeviewDept",
                data: {},
                success: function (data) {
                    $("#smoothmenu2").html(data);

                    $('.teamName').click(function () {
                        if ($(this).hasClass('active')) {
                            $(this).removeClass('active').next('ul').hide();
                        } else {
                            $(this).addClass('active').next('ul').show();
                        }
                    });
                    /* 竖直导航 */
                    //ddsmoothmenu.init({
                    //    mainmenuid: "smoothmenu2", //Menu DIV id
                    //    orientation: 'v', //Horizontal or vertical menu: Set to "h" or "v"
                    //    classname: 'ddsmoothmenu-v', //class added to menu's outer DIV
                    //    //customtheme: ["#804000", "#482400"],
                    //    contentsource: "markup" //"markup" or ["container_id", "path_to_menu_file"]
                    //});
                }
            });
        },
        leftTree: function (ty, id) {
            if (ty == '1') {
                $("#txtDetp").val(id);
                $("#txtDetachment").val("");
                $("#uid").val("");
            }
            else if (ty == '2') {
                $("#txtDetachment").val(id);
                $("#uid").val("");
                $("#txtDetp").val("");
            }
            else if (ty == '3') {
                $("#uid").val(id);
                $("#txtDetp").val("");
                $("#txtDetachment").val("");
            }
            else if (ty == '4') {
                $("#cuid").val(id);
                $("#txtDetp").val("");
                $("#txtDetachment").val("");
            }
            $.Evidence.pageload();
        },


        /**初始加载电子证据数据**/
        pageload: function () {
            var keyvalue = $("#headq").val();
            var filename = $("#filename").val();
            var uname = $("#uname").val();
            var uid = $("#uid").val();
            var cuid = $("#cuid").val();   //采集人ID
            var deceiveno = $("#deceiveno").val();
            var deptid = $("#deptid").val();
            var detachment = $("#detachment").val();

            //左侧树选择的部门
            var txtDeptId = $("#txtDetp").val();
            var txtDetachment = $("#txtDetachment").val();

            var filetype = $("#filetype").val();
            var classno = $("#classno").val();
            var starttime = $("#starttime").val();
            var endtime = $("#endtime").val();
            var pageindex = $("#page").val();
            var pagetype = $("#pagetype").val();
            var pagesize = 2;
            $.ajax({
                type: "POST",
                url: "/Evidence/QueryEvidence",
                data: {
                    keyvalue: keyvalue, filename: filename, uname: uname, uid: uid, deceiveno: deceiveno, deptid: deptid,
                    detachment: detachment, deptidsecond: txtDeptId, detachmentsecond: txtDetachment, filetype: filetype, classno: classno, starttime: starttime,
                    endtime: endtime, cuid: cuid, pagetype: pagetype, pageindex: pageindex, pagesize: pagesize,
                },
                beforeSend: function () {
                    $("#pageloading").html("数据加载中，请稍等...").show();
                },
                success: function (data) {
                    $("#pageloading").hide();
                    var json = eval('(' + data + ')');
                    $(".yk-row").html("");
                    //拼接证据展示列表
                    for (var i = 0; i < json.rows.length; i++) {

                        //解析json
                        var datasource = json.rows[i]["datasource"] == "1" ? "Android" : "管理平台";
                        var jFilename = json.rows[i]["filename"];
                        var update = json.rows[i]["update"];  //上传时间
                        var jFiletype = json.rows[i]["filetype"];
                        var haddress = json.rows[i]["haddress"];
                        var filethumbnail = json.rows[i]["filethumbnail"];
                        var sysid = json.rows[i]["sysid"];
                        var jUname = json.rows[i]["uname"];   //上传人
                        var isnew = json.rows[i]["isnew"];
                        var ctime = json.rows[i]["CTime"];    //采集时间
                        var cuname = json.rows[i]["CUname"];  //采集人
                        var cremark = json.rows[i]["CRemark"];
                        var caddress = json.rows[i]["CAddress"];

                        var imgsrc = "";      //缩略图路径
                        var callmethod = "";  //查看明细所要调用的方法

                        var types = jFiletype;

                        if (jFiletype == "1" || jFiletype == "3")
                            imgsrc = haddress + "/" + filethumbnail;
                        else
                            imgsrc = "/Librarys/evidence/image/voice.png";

                        if (jFiletype == "1") { //文件类型
                            jFiletype = "视频";
                            callmethod = "$.Evidence.playVideo('" + jUname + "','" + update + "','" + datasource + "','" + sysid + "')";
                        }
                        else if (jFiletype == "2") {
                            jFiletype = "音频";
                            callmethod = "$.Evidence.playMusic('" + jFilename + "','" + sysid + "')";
                        }
                        else {
                            jFiletype = "图片";
                            callmethod = "$.Evidence.ShowPic('" + sysid + "')";
                        }

                        var appendhtml = "<div class='col-lg-2 col-md-3 videoItem'><div class=\"posRel\">";
                        //判断是否是新上传的数据（24小时内的）
                        if (isnew == "1") {
                            appendhtml += "<div class=\"new\"><div class=\"newText\">新</div></div>";
                        }
                        if (jFiletype == "视频") {
                            appendhtml += "<img src='../Librarys/evidence/image/shipin.png' alt='' class='iconVideo'>";
                        }
                        if (jFiletype == "音频") {
                            appendhtml += "<img src='../Librarys/evidence/image/music.png' alt='' class='iconVideo'>";
                        }
                        appendhtml += "<a href='#'>" +
                            "<img src='" + imgsrc + "' alt='' class='pic' onclick=\"" + callmethod + "\">" +
                        "</a>" +
                        "<div class='videoBottom'>" +
                            "<ul class='clearfixed'>" +
                                "<li>" +
                                    "<img src='../Librarys/evidence/image/dianping.png' alt='' onclick=\"OpenEdit('" + sysid + "')\">" +
                                "</li>" +
                                "<li>" +
                                    "<img src='../Librarys/evidence/image/xiazai.png' alt='' onclick=\"$.Evidence.DownUrl('" + sysid + "');\">" +
                                "</li>";
                        if (haspermanentper == "1") {
                            appendhtml += "<li><img src='../Librarys/evidence/image/shanchu.png' alt='' onclick=\"$.Evidence.TemporaryDel('" + sysid + "','2')\"></li>";
                        }
                        appendhtml += "<li class=\"chooseIcon\">" +
                            "<input type=\"checkbox\" name=\"chkFiles\" filetype=\"" + types + "\" value=\"" + sysid + "\"><label for=\"man\"></label>" +
                        "</li>" +
                    "</ul>" +
                    "<div class=\"daily\">" + cremark + "</div>" +
                    "<div class=\"adress\">" + caddress + "</div>";
                        if (cuname != undefined && cuname != '') {
                            appendhtml += "<div>" + cuname + "&nbsp;&nbsp;" + ctime + "</div>" +
                                "<div>" + jUname + "&nbsp;&nbsp;" + update + "</div>";
                        }
                        else {
                            appendhtml += "<div>" + jUname + "&nbsp;&nbsp;" + update + "</div>";
                        }
                        appendhtml += "</div>" +
                    "</div>" +
                "</div>";

                        //var appendhtml = "<div class=\"yk-col4\"><div class=\"v\"><div class=\"v-thumb\">" +
                        //    "<img src=\"" + imgsrc + "\"/></div>" +
                        //    "<div class=\"v-link\"><a href=\"javascript:void(0)\" onclick=\"" + callmethod + "\" title=\"" + jFilename + "\"></a>";
                        ////判断是否是新上传的数据（24小时内的）
                        //if (isnew == "1")
                        //    appendhtml += "<span class=\"v-new\"><img src=\"/Librarys/evidence/image/new_icon.gif\"/></span>";
                        //appendhtml += "</div>" +
                        //    "<div class=\"v-isdrama\"></div><div class=\"v-meta va\"><div class=\"v-meta-neck\">" +
                        //    "<div id=\"hs1\"><span class=\"v-status\">" + jFiletype + "</span></div>" +
                        //    "<div id=\"hs2\"><span class=\"v-operate\">";

                        //if (pagetype == "0")
                        //    appendhtml += "<img src=\"/Librarys/evidence/image/recycle.png\" alt=\"放入回收站\" onclick=\"$.Evidence.TemporaryDel('" + sysid + "','1')\" />";
                        //else if (pagetype == "1")
                        //    appendhtml += "<img src=\"/Librarys/evidence/image/back.png\" alt=\"撤销删除\" onclick=\"$.Evidence.TemporaryDel('" + sysid + "','3')\" />";

                        //if (haspermanentper == "1") {
                        //    appendhtml += "<img src=\"/Librarys/evidence/image/delete.png\" alt=\"永久删除\" onclick=\"$.Evidence.TemporaryDel('" + sysid + "','2')\"/>";
                        //}

                        //if (cuname != undefined && cuname != '') {
                        //    appendhtml += "</span></div>" +
                        //        "</div><div class=\"v-meta-title\">" +
                        //        "<a href=\"javascript:void(0)\" onclick=\"" + callmethod + ";\">" + cremark + "</a>" +
                        //        "<br/>" +
                        //        "<a href=\"javascript:void(0)\" onclick=\"" + callmethod + ";\">" + caddress + "" +
                        //        "</div>" +
                        //        "<div class=\"v-meta-entry\"><span>" +
                        //        "" + cuname + "&nbsp;|&nbsp;" + ctime + "<br/>" +
                        //        "" + jUname + "&nbsp;|&nbsp;" + update + "&nbsp;</span></div>" +
                        //        "<div class=\"v-meta-overlay\"></div></div></div></div>";
                        //} else {
                        //    appendhtml += "</span></div>" +
                        //        "</div><div class=\"v-meta-title\">" +
                        //        "<a href=\"javascript:void(0)\" onclick=\"" + callmethod + ";\">" + cremark + "</a>" +
                        //        "<br/>" +
                        //        "<a href=\"javascript:void(0)\" onclick=\"" + callmethod + ";\">" + caddress + "" +
                        //        "</div>" +
                        //        "<div class=\"v-meta-entry\"><span>" +
                        //        "" + jUname + "&nbsp;|&nbsp;" + update + "&nbsp;</span></div>" +
                        //        "<div class=\"v-meta-overlay\"></div></div></div></div>";
                        //}

                        $(".yk-row").append(appendhtml);
                    }
                    $.Evidence.querypage(pageindex, json.rowscount, pagesize);
                }
            });
        },
        /**请求加载分页控件**/
        querypage: function (pageindex, rowscount, pagesize) {
            $.ajax({
                type: "POST",
                url: "/Evidence/EvidenceQuery",
                data: { totalRecords: rowscount, pageIndex: pageindex, pageSize: pagesize },
                dataType: "html",
                success: function (data) {
                    $(".applay-select").html(data);
                }
            });
        },
        /**显示、隐藏跳转层**/
        shownextpagego: function () {
            $(".nextpagego-box").toggle();
        }, /**分页_跳转指定页面1**/
        gotopage: function (pageindex) {
            $("#page").val(pageindex);
            $.Evidence.pageload();
        },
        /**分页_跳转指定页面2**/
        gotopageN: function (pagecount) {

            var pageindex = $("input[name='goto']").val();

            if (pagecount >= pageindex) {
                $("#page").val(pageindex);
                $.Evidence.pageload();
            } else {
                $("#page").val(pagecount);
                $.Evidence.pageload();
            }
        },
        /**切换头部菜单**/
        changeheard: function (obj) {
            $('.menuUl li').click(function () {
                $(this).addClass('active').siblings().removeClass('active');
            })
            //$(".nav_content li").removeClass("current");
            //$(obj).parent().addClass("current");
            var clotext = $(obj)[0].innerText;

            $("#pagetype").val("0");    //页面类型
            if (clotext == "全部") {
                $("#filetype").val(""); //文件类型
                $("#txtDetachment").val("");
                $("#uid").val("");
                $("#txtDetp").val("");
            }
            else if (clotext == "视频") {
                $("#filetype").val("1");
            }
            else if (clotext == "音频")
                $("#filetype").val("2");
            else if (clotext == "图片")
                $("#filetype").val("3");
            else if (clotext == "回收站") {
                $("#filetype").val(""); //切换回收站时查询所有类型
                $("#pagetype").val("1");
            }
            $("#page").val(1);  //初始化页数
            $.Evidence.pageload();  //执行查询加载数据
        },
        /**播放视频**/
        playVideo: function (uname, update, datasource, sid) {

            var width = $(window).width();
            width = width - (width * 0.1);
            var height = $(window).height();
            //Dialog(("VideoPlay?sid=" + sid + '&rnd=' + Math.random()), "Evidence", "视频信息", width, height);
            Dialog('/Evidence/VideoPlay?sid=' + sid + "&height=680&width=" + width, "", "", width, 650);


            //$.layer({
            //    type: 2,
            //    title: '' + uname + '&nbsp;|&nbsp;' + update + '&nbsp;|&nbsp;' + datasource + '',
            //    iframe: { src: '/Evidence/VideoPlay?sid=' + sid },
            //    area: ['750px', '550px'],
            //    offset: ['50%', '50%']
            //});
        },
        /**播放音频**/
        playMusic: function (title, sid) {
            $.layer({
                type: 2,
                title: title,
                iframe: { src: '/Evidence/VoicePlay?sid=' + sid },
                area: ['460px', '185px'],
                offset: ['', '']
            });
        },
        /* *显示图片**/
        ShowPic: function (sid) {
            $.layer({
                type: 2,
                title: '图片',
                iframe: { src: '/Evidence/ShowPic?sid=' + sid },
                area: ['700px', '585px'],
                offset: ['50%', '50%']
            });
        },
        /**删除电子证据**/
        TemporaryDel: function (sid, type) {
            var tiptext = "系统提示：你确定将该证据执行临时删除操作吗？";
            if (type == "2") tiptext = "系统提示：你确定将该证据执行永久删除操作吗？此操作需谨慎！";
            else if (type == "3") tiptext = "系统提示：你确定将该证据执行撤销删除操作吗？";
            if (confirm(tiptext)) {
                $.ajax({
                    type: "POST",
                    url: "/Evidence/DeleteEvidence",
                    data: { type: type, sid: sid },
                    dataType: "html",
                    beforeSend: function () {
                        $("#pageloading").html("正在执行删除，请稍等...").show();
                    },
                    success: function (data) {
                        $("#pageloading").hide();
                        if (type == "1" || type == "2") {
                            if (data == "true") {
                                $.Evidence.pageload(); //删除成功执行刷新  
                            } else {
                                alert("系统提示：删除电子证据出现异常,请联系管理员！");
                            }
                        } else if (type == "3") {
                            if (data == "true") {
                                $.Evidence.pageload(); //成功执行刷新  
                            } else {
                                alert("系统提示：撤销删除电子证据出现异常,请联系管理员！");
                            }
                        }
                    }
                });
            }
        },
        /**批量删除**/
        DeleteAll: function () {
            var str = "";
            $("input[name='chkFiles']").each(function () {
                if ($(this).is(":checked")) {
                    $.ajax({
                        type: "POST",
                        url: "/Evidence/DeleteEvidence",
                        data: { type: $(this).attr("filetype"), sid: $(this).val() },
                        dataType: "html",
                        beforeSend: function () {
                            $("#pageloading").html("正在执行删除，请稍等...").show();
                        },
                        success: function (data) {
                            $("#pageloading").hide();
                            if (type == "1" || type == "2") {
                                if (data == "true") {
                                    $.Evidence.pageload(); //删除成功执行刷新  
                                } else {
                                    alert("系统提示：删除电子证据出现异常,请联系管理员！");
                                }
                            } else if (type == "3") {
                                if (data == "true") {
                                    $.Evidence.pageload(); //成功执行刷新  
                                } else {
                                    alert("系统提示：撤销删除电子证据出现异常,请联系管理员！");
                                }
                            }
                        }
                    });
                }

            });
        },
        /**下载地址**/
        DownUrl: function (sid) {
            var url = "";
            $.ajax({
                type: "POST",
                url: "/Evidence/VideoInfo",
                data: { sid: sid, type: 1 },
                async: false,
                success: function (data) {
                    json = eval('(' + data + ')');
                    url = json.playurl;
                    if (url != "") {
                        window.open(url);
                    }
                    else {
                        alert("下载地址无效！");
                    }
                }
            });
        }
    };






    $(function () {
        $.Evidence.bindDetpTree();

        //获取当前用户是否有永久删除权限
        haspermanentper = 1;

        //计算panel的位置
        var wiwidth = document.documentElement.clientWidth;
        var panright = 0;
        if (wiwidth > 1090) {
            panright = (wiwidth - 1080) / 2;
        }
        $(".panel").css('right', panright);

        $(".yk-menu-so #advacetso").mousemove(function () {
            $(".panel").show(
                    function () {
                        $(".panel").mouseleave(function (e) {
                            var o = e.relatedTarget || e.toElement;
                            if (!o) return; //增加移动到的对象判断，为option时退出
                            $(this).hide();
                        });
                    });
        });
        $.Evidence.loaddept();  //加载部门
        $.Evidence.pageload();  //加载证据列表

        /**高级搜索**/
        $(".btnSearch").click(function () {
            $.Evidence.pageload();
        });

        /**搜库**/
        $("#btnSearchKU").click(function () {
            $.Evidence.pageload();
        });

        /**清空**/
        $(".btnClear").click(function () {
            $("#headq").val("");
            $("#filename").val("");
            $("#uname").val("");
            $("#uid").val("");
            $("#deceiveno").val("");
            $("#classno").val("");
            $("#starttime").val("");
            $("#endtime").val("");
            $("#deptid").val(0);
            $("#detachment").val(0);
            $("#classno").val(0);
            $("#filetype").val(0);
        });
    });

    /**
    *窗体大小改后,重新计算查询面版的位置
    */
    window.onresize = function () {
        //计算panel的位置
        var wiwidth = document.documentElement.clientWidth;
        var panright = 0;
        if (wiwidth > 1090) {
            panright = (wiwidth - 1080) / 2;
        }
        $(".panel").css('right', panright);
    };
})(jQuery);