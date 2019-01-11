var Drag = {
    "obj": null,
    "init": function (handle, dragBody, e) {
        if (e == null) {
            handle.onmousedown = Drag.start;
        }
        handle.root = dragBody;

        if (isNaN(parseInt(handle.root.style.left))) handle.root.style.left = "0px";
        if (isNaN(parseInt(handle.root.style.top))) handle.root.style.top = "0px";//确保后来能够取得top值
        handle.root.onDragStart = new Function();
        handle.root.onDragEnd = new Function();
        handle.root.onDrag = new Function();
        if (e != null) {
            var handle = Drag.obj = handle;
            e = Drag.fixe(e);
            var top = parseInt(handle.root.style.top);
            var left = parseInt(handle.root.style.left);
            handle.root.onDragStart(left, top, e.pageX, e.pageY);
            handle.lastMouseX = e.pageX;
            handle.lastMouseY = e.pageY;
            document.onmousemove = Drag.drag;
            document.onmouseup = Drag.end;

            //window.document.getElementById("txtTop").value = top;
            //window.document.getElementById("txtLeft").value = left; 
        }
    },
    "start": function (e) {
        var handle = Drag.obj = this;
        e = Drag.fixEvent(e);
        var top = parseInt(handle.root.style.top);
        var left = parseInt(handle.root.style.left);
        //alert(left)
        //一般情况下 left top 在初始的时候都为0
        handle.root.onDragStart(left, top, e.pageX, e.pageY);
        handle.lastMouseX = e.pageX;
        handle.lastMouseY = e.pageY;
        document.onmousemove = Drag.drag;
        document.onmouseup = Drag.end;

        //window.document.getElementById("txtTop").value = top;
        //window.document.getElementById("txtLeft").value = left;
        return false;
    },
    "drag": function (e) {//这里的this为document 所以拖动对象只能保存在Drag.obj里
        e = Drag.fixEvent(e);
        var handle = Drag.obj;
        var mouseY = e.pageY;
        var mouseX = e.pageX;
        var top = parseInt(handle.root.style.top);
        var left = parseInt(handle.root.style.left);//这里的top和left是handle.root距离浏览器边框的上边距和左边距

        var currentLeft, currentTop;
        currentLeft = left + mouseX - handle.lastMouseX;
        currentTop = top + (mouseY - handle.lastMouseY);

        //上一瞬间的上边距加上鼠标在两个瞬间移动的距离 得到现在的上边距


        //if (currentTop > 0 && (mouseY + 700) < document.documentElement.scrollHeight) {
            handle.root.style.left = currentLeft + "px";
            handle.root.style.top = currentTop + "px";
            
            //更新当前的位置

            handle.lastMouseX = mouseX;
            handle.lastMouseY = mouseY;

            //保存这一瞬间的鼠标值 用于下一次计算位移

            handle.root.onDrag(currentLeft, currentTop, e.pageX, e.pageY);//调用外面对应的函数

        //}
        //window.document.getElementById("txtTop").value = top;
        //window.document.getElementById("txtLeft").value = left;
        return false;
    },
    "end": function () {
        document.onmousemove = null;
        document.onmouseup = null;
        Drag.obj.root.onDragEnd(parseInt(Drag.obj.root.style.left), parseInt(Drag.obj.root.style.top));
        Drag.obj = null;
    },
    "fixEvent": function (e) {//格式化事件参数对象
        if (typeof e == "undefined") e = window.event;
        if (typeof e.layerX == "undefined") e.layerX = e.offsetX;
        if (typeof e.layerY == "undefined") e.layerY = e.offsetY;
        if (typeof e.pageX == "undefined") e.pageX = e.clientX + document.body.scrollLeft - document.body.clientLeft;
        if (typeof e.pageY == "undefined") e.pageY = e.clientY + document.body.scrollTop - document.body.clientTop;
        return e;
    },
    "Show": function (obj, sh) {//用来显示一个窗口
        if (sh == 'show') {
            dlgobj = document.getElementById(obj);
            var h1 = document.documentElement.offsetHeight;
            var h2 = document.documentElement.scrollHeight;
            var w1 = document.documentElement.offsetWidth;
            var w2 = document.documentElement.scrollWidth;
            if (h2 < h1)
                h2 = h1;
            if (w2 < w1)
                w2 = w1;
            dlgobj.style.left = (w2 / 2 - dlgobj.clientWidth / 2) + 'px';
            dlgobj.style.top = (h2 / 2 - dlgobj.clientHeight / 2) + 'px';
            dlgobj.style.visibility = 'visible';
        }
        else {
            if (sh == 'hide') {
                dlgobj.style.visibility = 'hidden';
            }
        }
    }
};