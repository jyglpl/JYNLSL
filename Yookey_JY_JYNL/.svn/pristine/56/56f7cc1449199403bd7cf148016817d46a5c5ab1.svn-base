 //
 //编辑器菜单部分。
 // 
 
 ////////////////////////////////屏掉IE默认右键/////////////////////////////////
  if (window.Event) 
    document.captureEvents(Event.MOUSEUP);
     
    function nocontextmenu(e)
    { 
     event.cancelBubble = true 
     event.returnValue = false; 
     ShowContextMeun(e);
     return false; 
    } 
    document.oncontextmenu = nocontextmenu; 
///////////////////////////////////////////////////////////////////////////////

var mx,my;//用来记录弹出右键菜单位置,以在相应位置显示结点.

function ShowContextMeun(e)
{
    var y = nn6 ? e.clientY : event.clientY; 
    var x = nn6 ? e.clientX : event.clientX; 
    var MenuBody=document.getElementById("aContextMenu");
    MenuBody.style.pixelLeft=x+2;
    MenuBody.style.pixelTop=y+2;
    MenuBody.style.display='';
    mx=x;my=y;
}
//隐藏右键菜单.
function HideContextMenu()
{
    var MenuBody=document.getElementById("aContextMenu");
    MenuBody.style.display='none';
}
//在单击菜单项时.
function MenuItemClick(x)
{
    HideContextMenu();
    //
    //////////////////////////////
    switch (x)
    {
        case "指针":
        point();
        break ;
        case "添加结点":
        ADD();
        break ;
        case "画连结线":
        dl();
        break ;
        case "删除":
            del(); 
        break ;
        case "属性":
        Properpies();
        break ;
        case "网格":
        ShowGrid();
        break ;
    }
}
//////////////////////////////////////////////////////////////////////////////
/////////////
        //添加一个新结点(这个方法为添加按钮事件,所以新结点的位置,是从左上角自动偏移的).
        var NewX=1,NewY=1;
        function New()
        {
            SetState("add");
            var a=CreateA();
            AddControl(a,102,NewX,NewY);
            
            NewX+=5;
            NewY+=5;
            if(NewX>50)NewX=1;
            if(NewY>50)NewY=1;
        }
/////////////
        function ADD()
        {
            SetState("add");
            var a=CreateA();
            AddControl(a,102,mx,my);//添加一新结点并显示在弹出右键菜单处.
        }
        function dl()
        {
             SetState("drawline");
        }
        function point()
        {
             SetState("add");
        }
        function del()
        {
             HideContextMenu();
            if(DElement!=null)
            {
                if(confirm("确认删除吗?"))
                {
                    if(DElement!="undefinned" && DElement!=null && DElement.className!=null && DElement.id!="EStart" && DElement.id!="EEnd"  && (DElement.className=="dragAble" || DElement.className=="Line"))
                    {
                       // if(DElement.className=="PointText")DElement=DElement.parentNode;
                        DElement.parentNode.removeChild(DElement);
                        ClearErrorLine();
                        ClearErrorLine();
                        ClearErrorLine();
                        UpdateLine();
                        //DElement=null ;
                    }
                    else
                    {
                        //alert("");
                         ClearErrorLine();
                    }
                    return true;
                }
            }
            return false;
        }
        /////////////////////////
        var IsShowGrid=false;
        function ShowGrid()
        {
            HideContextMenu();
            IsShowGrid=!IsShowGrid;
            if(IsShowGrid)
            {
                document.body.style.backgroundImage = "url(../../Content/Theme/Default/Images/FlowEditor/bg.jpg)";
                return true;
            }
            else
            {
                document.body.style.backgroundImage = "url(../../Content/Theme/Default/Images/FlowEditor/bg1.jpg)";
                return false;
            }
          
        }
        /////////////////////////
        function Properpies()
        {
            if(DElement!=null)
            {
                try
                {
                    self.parent.Properpies(DElement);
                }
                catch(e)
                {
                    alert("请实现Properpies()");
                }
            }
            else
            {
                alert("请选择对象");
            }
        }
        //双击时同样也将触发查看属性事件.
        document.body.ondblclick=Properpies;
        //触发焦点改变事件.
        function FocusChange()
        {
            if(DElement.className=="dragAble")
            {
                try
                {
                    self.parent.FocusChange(DElement);
                }
                catch(e)
                {
                    //alert("请实现FocusChange()");
                }
            }
        }
        
       /////////////////////////
//取得编辑内容值,以备保存
function GetEditorValue()
{
    if(DElement!=null )
    {
        DElement.strokecolor="black" ;
        DElement.strokeweight="1pt";
        if(DElement.className=="Line") DElement.strokeweight="1.2pt";
    }
    return document.getElementById("group1").innerHTML;
}
//设置编辑内容的值(必须是用GetEditorValue()取复的值)
function SetEditorValue(value)
{
    if(value!="")
    {
        document.getElementById("group1").innerHTML=value;
    }
    else 
    {
        Clear();
    }
}

//清空编辑内容
function Clear()
{
    document.getElementById("group1").innerHTML=InitEditorValue;
            
}
///////////////////////////////////////////////////////////////////////////////////
var InitEditorValue;
function Init()
{
   InitEditorValue=document.getElementById("group1").innerHTML;
}
Init();
///////////////////////////////////////////////////////////////////////////////////