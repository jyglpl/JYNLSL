function gridProperty(){
	this.currPage=1;
    this.currentPage = 1;
    this.totlePage = 0;
    this.pageSize = 10;
    this.totalRecordNumber = 0;
    this.selectValue = [];
    this.selectAllValue = [];
    this.build = this.build;
    this.refresh = this.refresh;
    this.selectAll = this.selectAll;
    this.model = null;
};


gridProperty.prototype.selectAll = function(event) {
    $_event = $(event.target);
    var childCheckBox = $_event.parent().parent().parent().next("tbody").find(".grid-checkbox");
    if($_event.is(":checked")){
        childCheckBox.each(function(){
            if(!$(this).is(":checked")){
                $(this).click();
            }
        });
    }else{
        childCheckBox.each(function(){
            if($(this).is(":checked")){
                $(this).click();
            }
        });
    }
};

gridProperty.prototype.build = function(model,callback) {
    var getDataFunction = this;
    this.getData(model,1,model.grid.pageSize,function(){
        if(model.grid.totlePage != 1 && model.grid.totlePage != 0){
            var pageButton = '<a class="first_page">首页</a>' +
                '<a class="prev_page">上一页</a>' +
                '<a class="next_page">下一页</a>' +
                '<a class="end_page">尾页</a>';
            $("#"+model.pageId).html("").append(pageButton);
            getDataFunction.firstPage(model);
            $("#"+model.pageId).find(".prev_page").on("click",function(){
                getDataFunction.changePage(-1,model);
            });
            $("#"+model.pageId).find(".next_page").on("click",function(){
                getDataFunction.changePage(1,model);
            });
            $("#"+model.pageId).find(".first_page").on("click",function(){
                getDataFunction.changeFirstPage(model);
            });
            $("#"+model.pageId).find(".end_page").on("click",function(){
                getDataFunction.changeEndPage(model);
            })
        }
        if(!!callback && typeof callback == "function"){
            callback();
        }
    });
};

gridProperty.prototype.refresh = function(model,callback){
    var refreshData = this;
    this.build(model,function(){
        refreshData.selectValue = [];
        refreshData.selectAllValue = [];
        if(!!callback && typeof callback == "function"){
            callback();
        }
    });
};

gridProperty.prototype.changeFirstPage = function(model){
    var getDataFunction = this;
    this.getData(model,1,model.grid.pageSize,function(){
        getDataFunction.firstPage(model);
        model.grid.currentPage = 1;
    });
};

gridProperty.prototype.changeEndPage = function(model){
    var getDataFunction = this;
    this.getData(model,model.grid.totlePage,model.grid.pageSize,function(){
        getDataFunction.endPage(model);
        model.grid.currentPage = model.grid.totlePage;
    });
};

gridProperty.prototype.changePage = function(pageNum,model){
    if((model.grid.currentPage == 1 && pageNum == -1) || (model.grid.currentPage == model.grid.totlePage && pageNum == 1)){
        return false;
    }
    var getDataFunction = this;
    getDataFunction.getData(model,model.grid.currentPage + pageNum,model.grid.pageSize,function(){
        if(model.grid.currentPage + pageNum == 1){
            getDataFunction.firstPage(model);
        }else if(model.grid.currentPage + pageNum == model.grid.totlePage){
            getDataFunction.endPage(model);
        }else{
            getDataFunction.otherPage(model);
        }
        model.grid.currentPage = model.grid.currentPage + pageNum;
    });
};

gridProperty.prototype.firstPage = function(model){
    $("#"+model.pageId).find(".first_page").hide();
    $("#"+model.pageId).find(".prev_page").hide();
    $("#"+model.pageId).find(".next_page").show();
    $("#"+model.pageId).find(".end_page").show();
};

gridProperty.prototype.endPage = function(model){
    $("#"+model.pageId).find(".first_page").show();
    $("#"+model.pageId).find(".prev_page").show();
    $("#"+model.pageId).find(".next_page").hide();
    $("#"+model.pageId).find(".end_page").hide();
};

gridProperty.prototype.otherPage = function(model){
    $("#"+model.pageId).find(".first_page").show();
    $("#"+model.pageId).find(".prev_page").show();
    $("#"+model.pageId).find(".next_page").show();
    $("#"+model.pageId).find(".end_page").show();
};

gridProperty.prototype.getData = function(model,pageNum,pageSize,callback) {
    //todo ajax
    var ajaxData = {
        page:pageNum - 1,
        size:pageSize
    };

    if(typeof token != "undefined" && !!token
        && typeof appId != "undefined" && !!appId
        && typeof userId != "undefined" && !!userId){
        ajaxData = $.extend({},ajaxData,{token:token,userId:userId,appId:appId})
    }

    $.ajax({
        type:"POST",
        url:root + model.url,
        data:!!model.param ? $.extend({},ajaxData,model.param) :ajaxData,
        success:function(data){
            if(!!data.success){
                if(data.data){
                    model.data = !!data.data.data?data.data.data:data.data;
                    model.grid.totlePage = data.data.totalPageNumber;
                    model.grid.totalRecordNumber = data.data.totalRecordNumber;
                    if(data.data.pageable!=null){	//原来没有的，
                    	model.grid.currPage=data.data.pageable.pageNumber+1;
                    }
                    if(typeof callback == "function" ){
                        callback(model);
                    }
                }else{
                    model.data = [];
                    model.grid.currPage = 1;
                    model.grid.currentPage = 0;
                    model.grid.totlePage = 0;
                    model.grid.totalRecordNumber = 0;
                }
            }else{
                //Tool.errorMessage(data.errorMessage)
            }
        },
        error:function(err){
            //Tool.errorMessage(err);
        }
    });

};