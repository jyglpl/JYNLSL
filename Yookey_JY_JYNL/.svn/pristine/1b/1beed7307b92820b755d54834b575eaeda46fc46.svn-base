(function ($) {
    $.PersonelCenter = {


        /*
        * 用户登出
        * 添加人：周 鹏
        * 添加时间：2014-11-13
        * 修改描述：时间+作者+描述
        */
        UserLoginOut: function () {
            $.ajax({
                cache: false,
                type: "POST",
                url: '/Account/LogOff',
                success: function (result) {
                    if (result == "OK") {
                        location.href = "/Account/LogOn";
                    } else {
                        alert("登录过程出现异常,请联系管理员");
                    }
                },
                error: function (data) {
                    alert("登录过程出现异常,请联系管理员");
                }
            });
        }
    };
    $(function () {

        //登出
        $("#btnLogout").click($.PersonelCenter.UserLoginOut);
    });
})(jQuery);