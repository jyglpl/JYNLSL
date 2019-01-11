$(function () {

    $.fn.scrollpic = function (options) {
        //var options = jQuery.extend({
        //    preLoadSrc: "http://wimg.mangocity.com/img/home/banner/loading.gif"
        //}, options || {});

        var defaults = {
            defaultSpeed: 1000,   //默认滚动时间  点击按钮滚动时间
            speed: 5000,   		  //自动播放滚动时间
            defaultPicId: ""      //默认显示图片ID
        };

        return this.each(function () {

            //默认
            var option = $.extend(defaults, options);
            var $this = $(this);
            var defaultSpeed = option.defaultSpeed;   //默认滚动时间  点击按钮滚动时间
            var defaultPicId = option.defaultPicId;   //默认显示图片ID 用于显示图片
            var speed = options.speed;   //自动播放滚动时间
            var number = 0;
            var oldStartTime = 0;
            var showRightPics;
            var showLeftPics;

            //获取 、 计算
            var bLen = $this.find('.picWrap li').length; 				  //获取图片li的个数
            var $picWrap = $this.find('.picWrap');  					 //获取到图片box
            var $picWrapLi = $this.find('.picWrap li');  				//获取到图片box
            var showIndex = $this.find('.picWrap li.show').index();    //获取图片li.show 当前的
            var $circle = $this.find('.sliderSign li'); 			  //获取滚动圆点的li
            var $btnLeft = $this.find('.slidePre');                  //获取左边的按
            var $btnRight = $this.find('.slideNext'); 				//获取右边的按钮
            var $thisWidth = $this.width(); 					   //获取整个box的width
            var $slideTxtMore = $this.find('.slideTxtMore');  	  //获取更多按钮
            var $sliderTextBox = $this.find('.sliderTextBox');	 //获取文字大的box
            var $sliderTextBg = $this.find('.sliderTextBg');	//获取文字背景
            var $sliderText = $this.find('.sliderTxtBot');	   //获取文本名称和介绍的box
            var $sliderTextAll = $this.find('.sliderTextAll');
            var $sliderShowText = $this.find('.sliderShowText');


            //设置文字下面的背景的width() 和 height()
            $sliderText.width(500);
            $sliderTextBox.height($sliderText.height() + 10).addClass('hidden');  //设置大的文本的box的高度			
            $sliderTextBg.width($sliderTextBox.width());
            $sliderTextBg.height($sliderTextBox.height() + 20);



            //设置div的width() 和 height()
            $picWrap.find('ul').width($thisWidth * bLen);	//设置ul的宽度
            $sliderShowText.width($sliderTextAll * bLen); //设置所有text外层的大box的width
            //$sliderTextAll.width($thisWidth);	//设置text外层的box的宽度

            var defaultIndex = 0;
            if (defaultPicId != '') {
                defaultIndex = $picWrapLi.index($("#" + defaultPicId));   //获取需要默认图片索引
            }

            //初始化
            $picWrapLi.eq(defaultIndex).addClass('show').css({ 'left': 0 }).siblings().removeClass('show').css({ 'left': -$thisWidth }); //初始化时给li添加class="show"
            GetFileDetails($picWrapLi.eq(defaultIndex).attr('Id'));

            //$sliderTextAll.eq(0).css({'left':0}).siblings().css({'left':-$thisWidth}); //文本外层的div初始化

            //右侧滚动公用方法
            function showRightPics() {
                $picWrapLi.eq(showIndex).addClass('show').css({ 'left': 0 }).siblings().removeClass('show').css({ 'left': -$thisWidth }); //初始化时给li添加class="show"					
                if (showIndex + 1 == bLen) {
                    showIndex = -1;
                }
                ++showIndex;
                var beforeIndex = showIndex; //设置当前li（索引）的 前一个li（索引）
                if (showIndex == 0) {
                    beforeIndex = bLen;
                }
                $picWrapLi.eq(showIndex).animate({ left: 0 }, defaultSpeed);  //当前li（索引）的滚动特效
                //当前li（索引） 和 当前li（索引）的前一个li（索引）的滚动特效
                $picWrapLi.slice(beforeIndex - 1, beforeIndex).stop().animate({ left: $thisWidth }, defaultSpeed,
	    		function () {
	    		    $picWrapLi.eq(showIndex).css({ 'left': '0' }).addClass('show').siblings().removeClass('show').css('left', -$thisWidth);
	    		});

                GetFileDetails($picWrapLi.eq(showIndex).attr('Id'));
            }

            //左侧滚动公用方法
            function showLeftPics() {
                var nextIndex = showIndex == 0 ? (bLen - 1) : (showIndex - 1); //设置当前li（索引）的 前一个li（索引）				
                $picWrapLi.eq(showIndex).addClass('show').css({ 'left': 0 }).siblings().removeClass('show').css({ 'left': $thisWidth }); //初始化时给li添加class="show"    			
                $picWrapLi.eq(nextIndex).animate({ left: 0 }, defaultSpeed);  //下一个 当前li（索引）的滚动特效
                $picWrapLi.eq(showIndex).stop().animate({ left: -$thisWidth }, defaultSpeed, function () {
                    $picWrapLi.eq(nextIndex).css({ 'left': '0' }).addClass('show').siblings().removeClass('show').css('left', $thisWidth);
                });

                GetFileDetails($picWrapLi.eq(showIndex).attr('Id'));

                showIndex = showIndex == 0 ? (bLen - 1) : (showIndex - 1);
            }

            $btnLeft.click(function () {
                showLeftPics();
            });

            $btnRight.click(function () {
                showRightPics();
            });

        });

    }

});