///////////////////////////////////////////////
//
//处理键盘事件， 为编辑器添加快捷键。
//
///////////////////////////////////////////////
function hotkey() //键盘按下
{ 
    var a=window.event.keyCode; 
    //alert(a);
    if(DElement!=null )
    {
        if(a==46)//删除侯
        {
            del();
        }
        else if(a==37 && DElement.className!="Line")//向左
        {
            DElement.style.pixelLeft--;
        }
        else if(a==38 && DElement.className!="Line")//向上
        {
            DElement.style.pixelTop--;
        }
        else if(a==39 && DElement.className!="Line")//向右
        {
            DElement.style.pixelLeft++;
        }
        else if(a==40 && DElement.className!="Line")//向下
        {
            DElement.style.pixelTop++;
        }
        else if((a==78 && event.ctrlKey) || a==78 || a==51)//新建 Ctrl + N 或 N 或 3
        {
            self.New();
        }
        else if(a==80 || a==49 )//指针  P 或 1
        {
            point();
        }
        else if(a==76 || a==50 )//画线  L 或 2
        {
            dl();
        }
        UpdateLine();
    }
     return false ; //返回假,阻止页面滚动.
}
document.onkeydown = hotkey;
self.focus();//设置编辑器取得焦点
