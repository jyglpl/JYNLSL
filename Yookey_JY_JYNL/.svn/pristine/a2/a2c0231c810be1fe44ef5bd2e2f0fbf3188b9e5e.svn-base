
$(function () {
    var para = location.search.substr(1).split("=");

    //添加接收对象
    $("#btnAddRows").click(function () {
        //$('#ttt').jqGrid('addRowData', {
        //    index: 0,
        //    row: {
        //        columns: [
        //            { name: 'ActionIstanceID', label: '对象Id', width: 80, editor: 'text', hidden: true },
        //            { name: 'CommunityID', label: '部门ID', width: 80, editor: 'text' },
        //            { name: 'CommunityName', label: '部门名称', width: 80, editor: 'text' },
        //            { name: 'UserID', label: '人员ID', width: 80, editor: 'text' },
        //            { name: 'UserName', label: '人员名称', width: 80, editor: 'text' },
        //            { name: 'IsUnlock', label: '是否启用', width: 80, checkbox: 'true' }
        //        ]
        //    }
        //});

        var dataRow = { ActionIstanceID: "", CommunityID: "", CommunityName: "", UserID: "", IsUnlock: "" };
        $("#ttt").jqGrid("addRowData", 0, dataRow, "first");
    });

    BindGridView(); //绑定接收对象
    BindRuleDg();   //绑定规则

    $('#ttt').setGridParam({ cellEdit: true });


    //下拉框默认选中
    $("#drpSendORWithdrawalActivity").val($("#inputSendORWithdrawalActivity").val());

});

function BindGridView() {
    var activityId = $("#txtActivityID").val();
    $('#ttt').jqGrid({
        //url: '/FlowEditor/ReadFeActionInstance?activityId=' + activityId + "&isUnlock=-1",
        datatype: "json",
        treeGrid: false,
        treeGridModel: "nested",
        width: $(window).width() - 5,
        height: $(window).height() - 100,
        multiselect: true,
        colModel: [
             { name: 'Id', label: '对象Id', width: 80, editor: 'text', hidden: true },
             { name: 'ActionIstanceID', label: '对象Id', width: 80, editor: 'text', hidden: true },
             { name: 'CommunityID', label: '部门ID', width: 80, editor: 'text' },
             { name: 'CommunityName', label: '部门名称', width: 80, editor: 'text' },
             { name: 'UserID', label: '人员ID', width: 80, editor: 'text' },
             { name: 'UserName', label: '人员名称', width: 80, editor: 'text' }
        ]
    });
}

//$.extend($.fn.datagrid.methods, {
//    editCell: function (jq, param) {
//        return jq.each(function () {
//            var opts = $(this).datagrid('options');
//            var fields = $(this).datagrid('getColumnFields', true).concat($(this).datagrid('getColumnFields'));
//            var i;
//            var col;
//            for (i = 0; i < fields.length; i++) {
//                col = $(this).datagrid('getColumnOption', fields[i]);
//                col.editor1 = col.editor;
//                if (fields[i] != param.field) {
//                    col.editor = null;
//                }
//            }
//            $(this).datagrid('beginEdit', param.index);
//            for (i = 0; i < fields.length; i++) {
//                col = $(this).datagrid('getColumnOption', fields[i]);
//                col.editor = col.editor1;
//            }
//        });
//    }
//});

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
        url: '/FlowEditor/SaveActivity',
        data: { activity: noteEntity, note: arryActivity, rules: tabRule, activityID: activityId, processId: processId, OldNoneName: oldNoneName, rnd: radom },
        success: function (data) {
            if (data.rtState == 1) {
                Returnvalue("true", noneName, activityId);
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
    $('#rule').jqGrid({
        //url: '/FlowEditor/ReadRule?actityId=' + activityId,
        datatype: "json",
        treeGrid: false,
        treeGridModel: "nested",
        width: $(window).width() - 5,
        height: $(window).height() - 500,
        multiselect: true,
        colModel: [
            { name: 'RuleClauses', label: '规则表达式', width: 140 },
            { name: 'SendORWithdrawalActivityName', label: '成功规则接收对象', width: 120 },
            { name: 'IsUnlockName', label: '是否启用', width: 80, align: 'center' },
            { name: 'IsEventName', label: '是否有事件', width: 80, align: 'center' }
        ]
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

