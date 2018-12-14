
$(function () {
    var para = location.search.substr(1).split("=");

    //添加接收对象
    $("#btnAddRows").click(function () {
        $('#ttt').datagrid('appendRow', {
            index: 0,
            row: {
                columns: [[
                    { field: 'ActionIstanceID', title: '对象Id', width: 80, editor: 'text', hidden: 'true' },
                    { field: 'CommunityID', title: '部门ID', width: 80, editor: 'text' },
                    { field: 'CommunityName', title: '部门名称', width: 80, editor: 'text' },
                    { field: 'UserID', title: '人员ID', width: 80, editor: 'text' },
                    { field: 'UserName', title: '人员名称', width: 80, editor: 'text' },
                    { field: 'IsUnlock', title: '是否启用', width: 80, checkbox: 'true' }
                ]]
            }
        });
    });

    BindGridView(); //绑定接收对象
    BindRuleDg();   //绑定规则

    //下拉框默认选中
    $("#drpSendORWithdrawalActivity").val($("#inputSendORWithdrawalActivity").val());

});


//修改人：周庆
//修改日期：2015年4月28日
//修改原因：换成虚拟目录是rootpath获取不正确
//注意：当前rootpath兼容网站和虚拟目录
function RootPath() {
    var strFullPath = window.document.location.href;//格式：http://www.baidu.com/
    var strPath = window.document.location.pathname;// /XX/XXX
    strFullPath = strFullPath.substring(7, strFullPath.length);//去除http://
    var pos = strFullPath.indexOf(strPath);
    var prePath = "http://" + strFullPath.substring(0, pos);//添加http://
    var postPath = strPath.substring(0, strPath.substr(1).indexOf('/') + 1);

    //本项目特殊处理
    var urlPartArray = strPath.split("/");
    if (urlPartArray.length > 3)//带有虚拟目录
        return (prePath + postPath);
    else if (urlPartArray.length == 3 && urlPartArray[2] == "")//虚拟目录首页
        return (prePath + postPath);
    else
        return (prePath);//不带虚拟目录
}

function BindGridView() {
    var activityId = $("#txtActivityID").val();
    $('#ttt').datagrid({
        url: RootPath() + '/FlowEditor/ReadFeActionInstance?activityId=' + activityId + "&isUnlock=-1",
        width: 'auto',
        height: 'auto',
        fitColumns: true,
        rownumbers: true,
        singleSelect: false,
        onClickCell: onClickCell,
        checkOnSelect: false,
        selectOnCheck: true,
        columns: [[
             { field: 'ck', width: 80, checkbox: 'true' },
             { field: 'Id', title: '对象Id', width: 80, editor: 'text', hidden: 'true' },
             { field: 'ActionIstanceID', title: '对象Id', width: 80, editor: 'text', hidden: 'true' },
             { field: 'CommunityID', title: '部门ID', width: 80, editor: 'text' },
             { field: 'CommunityName', title: '部门名称', width: 80, editor: 'text' },
             { field: 'UserID', title: '人员ID', width: 80, editor: 'text' },
             { field: 'UserName', title: '人员名称', width: 80, editor: 'text' }
        ]]
    });
}

$.extend($.fn.datagrid.methods, {
    editCell: function (jq, param) {
        return jq.each(function () {
            var opts = $(this).datagrid('options');
            var fields = $(this).datagrid('getColumnFields', true).concat($(this).datagrid('getColumnFields'));
            var i;
            var col;
            for (i = 0; i < fields.length; i++) {
                col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor1 = col.editor;
                if (fields[i] != param.field) {
                    col.editor = null;
                }
            }
            $(this).datagrid('beginEdit', param.index);
            for (i = 0; i < fields.length; i++) {
                col = $(this).datagrid('getColumnOption', fields[i]);
                col.editor = col.editor1;
            }
        });
    }
});

var editIndex = undefined;
function endEditing() {
    if (editIndex == undefined) { return true }
    if ($('#ttt').datagrid('validateRow', editIndex)) {
        $('#ttt').datagrid('endEdit', editIndex);
        editIndex = undefined;
        return true;
    } else {
        return false;
    }
}

function onClickCell(index, field) {
    if (endEditing()) {
        $('#ttt').datagrid('selectRow', index).datagrid('editCell', { index: index, field: field });
        editIndex = index;
    }
}

/*
*  保存
*/
function Save() {
    var oldNoneName = $("#txtOldNoneName").val();
    //保存节点基本属性
    var activityId = $("#txtActivityID").val();
    var processId = $("#txtProcessID").val();
    var noteEntity = "";
    var noneId = $("#txtNoneID").val();
    var noneName = $("#txtNoneName").val();
    var sendOrWithdrawalActivity = $("#drpSendORWithdrawalActivity").val();
    var formAddress = $("#txtFormAddress").val();
    var isContrastCommunity = "0";
    if ($("#cbIsContrastCommunity")[0].checked) {
        isContrastCommunity = "1";
    }
    var isContrastRule = "0";
    if ($("#cbIsContrastRule")[0].checked) {
        isContrastRule = "1";
    }
    var isSendOnOpener = "0";
    if ($("#cbIsSendOnOpener")[0].checked) {
        isSendOnOpener = "1";
    }
    var noneDisposeManner = "0";
    if ($("#serHandel")[0].checked) {
        noneDisposeManner = "1";
    }
    var fulfillAssemblyName = $("#txtFulfillAssemblyName").val();
    var fulfillClassFullName = $("#txtFulfillClassFullName").val();
    var assemblyName = $("#txtOverdueAssemblyName").val();
    var classFullName = $("#txtOverdueClassFullName").val();
    var overdueHour = $("#txtOverdueHour").val();
    var remark = $("#txtRemark").val();
    noteEntity = noneId + "|" + noneName + "|" + sendOrWithdrawalActivity + "|" + formAddress + "|" + isContrastCommunity + "|" + isContrastRule + "|" + isSendOnOpener + "|";
    noteEntity += noneDisposeManner + "|" + fulfillAssemblyName + "|" + fulfillClassFullName + "|" + assemblyName + "|" + classFullName + "|" + overdueHour + remark + "|";

    //接收对象
    var rowActivity = $('#ttt').datagrid('getRows');
    var arryActivity = JSON.stringify(rowActivity);

    //规则设置
    var rowRule = $('#rule').datagrid('getRows');
    var tabRule = JSON.stringify(rowRule);

    var radom = Math.random();
    $.ajax({
        type: "POST",
        url: RootPath() + '/FlowEditor/SaveActivity',
        data: { activity: noteEntity, note: arryActivity, rules: tabRule, activityID: activityId, processId: processId, OldNoneName: oldNoneName, rnd: radom },
        success: function (data) {
            if (data.rtState == 1) {
                //Returnvalue("true", noneName, activityId);
                var api = frameElement.api, w = api.opener;
                //调父窗体加载流程方法
                w.handleReturn("true", noneName, activityId);
                api.close();
            } else
                alert(data.rtMsrg);
        }
    });
}

//新增规则
function AddToList() {
    var ruleClauses = $("#txtRuleClauses").val();
    if (ruleClauses == "") {
        alert('【规则表达示】为必输项...');
        return;
    }
    var riolationRuleI = $("#drpRiolationRuleI").val();
    var riolationRuleText = $("#drpRiolationRuleI").find("option:selected").text();
    var isUnlock = $("#cbIsUnlock")[0].checked;
    var remark = $("#txtRemark_Rule").val();
    var fulfillAssemblyName = $("#txtFulfillAssemblyName_Rule").val();
    var fulfillClassFullName = $("#txtFulfillClassFullName_Rule").val();

    var ruledgSelectIndex = $("#ruledgSelectIndex").val();
    if (ruledgSelectIndex == '') {
        $("#rule").datagrid('appendRow', {
            RuleClauses: ruleClauses,
            RiolationRuleID: riolationRuleI,
            SendORWithdrawalActivityName: riolationRuleText,
            FulfillAssemblyName: fulfillAssemblyName,
            FulfillClassFullName: fulfillClassFullName,
            IsUnlock: isUnlock ? 1 : 0,
            Remark: remark,
            IsUnlockName: isUnlock ? '是' : '否',
            IsEventName: (fulfillAssemblyName != '' && fulfillClassFullName != '') ? '有' : '没有'
        });
    } else {
        $("#rule").datagrid('updateRow', {
            index: ruledgSelectIndex,
            row: {
                RuleClauses: ruleClauses,
                RiolationRuleID: riolationRuleI,
                SendORWithdrawalActivityName: riolationRuleText,
                FulfillAssemblyName: fulfillAssemblyName,
                FulfillClassFullName: fulfillClassFullName,
                IsUnlock: isUnlock ? 1 : 0,
                Remark: remark,
                IsUnlockName: isUnlock ? '是' : '否',
                IsEventName: (fulfillAssemblyName != '' && fulfillClassFullName != '') ? '有' : '没有'
            }
        });
    }
}

//加载规则列表
function BindRuleDg() {
    var activityId = $("#txtActivityID").val();
    $('#rule').datagrid({
        url: RootPath() + '/FlowEditor/ReadRule?actityId=' + activityId,
        width: 'auto',
        height: 'auto',
        rownumbers: true,
        singleSelect: true,
        selectOnCheck: false,
        checkOnSelect: false,
        onDblClickRow: EditRule,
        columns: [[
            { field: 'ck', width: 60, checkbox: 'true' },
            { field: 'RuleClauses', title: '规则表达式', width: 140 },
            { field: 'SendORWithdrawalActivityName', title: '成功规则接收对象', width: 120 },
            { field: 'IsUnlockName', title: '是否启用', width: 80, align: 'center' },
            { field: 'IsEventName', title: '是否有事件', width: 80, align: 'center' }
        ]]
    });
}

//删除规则
function DeleteRuleCode() {
    if (confirm("您确定要删除所选项吗？")) {
        var rows = $('#rule').datagrid('getChecked');
        for (var i = 0; i < rows.length; i++) {
            var rowIndex = $('#rule').datagrid('getRowIndex', rows[i]);
            $("#rule").datagrid('deleteRow', rowIndex);
        }
    }
}

//清空规则控件
function ClearRuleCon() {
    $("#ruledgSelectIndex").val("");
    $("#txtRuleClauses").val("");
    $("#txtRemark_Rule").val("");
    $("#txtFulfillAssemblyName_Rule").val("");
    $("#txtFulfillClassFullName_Rule").val("");
    $("#cbIsUnlock").attr('checked', true);
    $("#drpRiolationRuleI").get(0).selectedIndex = 0;
}

//删除接收对象
function DelActionInstance() {
    if (confirm("您确定要删除所选项吗？")) {
        var rows = $('#ttt').datagrid('getChecked');
        for (var i = 0; i < rows.length; i++) {
            var rowIndex = $('#ttt').datagrid('getRowIndex', rows[i]);
            $("#ttt").datagrid('deleteRow', rowIndex);
        }
    }
}

//编辑规则
function EditRule(rowIndex, data) {
    $("#ruledgSelectIndex").val(rowIndex);   //当前规则的索引行
    $("#txtRuleClauses").val(data.RuleClauses);
    $("#drpRiolationRuleI").val(data.RiolationRuleID);
    $("#cbIsUnlock").attr('checked', data.IsUnlock == 1 ? true : false);
    $("#txtRemark_Rule").val(data.Remark);
    $("#txtFulfillAssemblyName_Rule").val(data.FulfillAssemblyName);
    $("#txtFulfillClassFullName_Rule").val(data.FulfillClassFullName);
}


function Returnvalue(returnValue, noneName, activityId) {
    var array = new Array(returnValue, noneName, activityId);
    window.returnValue = array;
    window.close();
}

