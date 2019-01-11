/////////////////////////////
//
//编辑器核心

//
/////////////////////////////
 var PaintStat="add";
 function SetState(x)
 {
    PaintStat=x;
    ClearErrorLine();
    HideContextMenu();
 }
 
 function ClearErrorLine()
 {
            var elen=document.all.length;   
                      for (var i=0;i<elen;i++)   
                      {   
                           if(document.all[i] != null && document.all[i].className !=null && document.all[i].className=="Line")
                           {
                                  var lineobj=document.all[i];
                                  if(lineobj!=null & lineobj.frompoint!=null && lineobj.topoint!=null)
                                  {
                                       if(lineobj.frompoint==lineobj.topoint || lineobj.frompoint=="EEnd" || lineobj.topoint=="EStart")
                                       {lineobj.parentNode.removeChild(lineobj);}
                                       
                                       var fpoint=document.getElementById(lineobj.frompoint);
                                       var tpoint=document.getElementById(lineobj.topoint);
                                       
                                       if(fpoint==null || tpoint==null || fpoint=="undefinned" || tpoint=="undefinned")
                                        {lineobj.parentNode.removeChild(lineobj);}
                                       
                                  }
                                  else 
                                  {
                                        if(lineobj!=null)
                                        {lineobj.parentNode.removeChild(lineobj);}
                                  }
                           }
                      }  
                        document.onmousedown=initDrag; 
                        document.onmouseup=mouserup;
                        LineFrom ="";
                        aLine=""; 
 }
 ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var NodeNumber=1;
        var NewID=1;
        function CreateA()
        {
            var str='<v:RoundRect class="dragAble" onclick="eClick(this);"  style="position:absolute;top:5px;left:5px;width:100px;height:50px"></v:RoundRect>';
            var a=document.createElement(str);
            a.strokecolor = 'black';
            a.fillcolor='white';
            a.innerHTML='<v:shadow on="T" type="single" color="#b3b3b3" offset="4px,4px"/>';
            a.innerHTML+='<v:TextBox class="PointText" inset="5pt,5pt,5pt,5pt" style="font-size:10pt;">结点'+(NodeNumber) + '_' + NewID +'</v:TextBox>';
            NodeNumber++;
            return a;
        }
        
        //var ControlList=new Hash();
        function AddControl(o,zindex,x,y)
        {
            if(o.className=="dragAble" )
            {
                o.style.left=x;
                o.style.top=y; 
            }            
            o.id="\"C"+NewID + "\""; 
            o.style.zIndex=zindex;
            group1.insertBefore(o);
            // 
            NewID++;
        }
        function eClick(x)
        {
            if(PaintStat!="drwaline")
            {
                      var maxtop=0;
                      var elen=document.all.length;   
                      for (var i=0;i<elen;i++)   
                      {   
                           if(document.all[i].className=="dragAble")
                           {
                           document.all[i].style.zIndex=100;
                           }
                      }   
                    x.style.zIndex=101;
              }
              else
              {
                    if(LineFrom !="")
                    {
                        
                        LineFrom ="";
                    }
              }
        }
        function CreateLine(from,to)
        {
            var str='<v:line class="Line" style="position:absolute;" from="'+from+'" to="'+to+'" strokeweight="1.2pt" ></v:line>';
            var a=document.createElement(str);
            a.innerHTML='<v:stroke EndArrow="Classic"/>';
            return a;
        }   
        
        var LineFrom="";
        var NewLineID=1;
        var aLine="";
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        var ie=document.all; 
        var nn6=document.getElementById&&!document.all; 
        var isdrag=false;
        var isDraw=false; 
        var y,x; 
        var oDragObj;
        var DrawFrameX,DrawFrameY; 

        function moveMouse(e) 
        { 
            if(PaintStat !="drawline")
            {
                 if (isdrag)
                 { 
                        var ty=(nn6 ? nTY + e.clientY - y : nTY + event.clientY - y);
                        if(ty>0)
                        oDragObj.style.top  =  ty+"px";
                        //
                        var tx= (nn6 ? nTX + e.clientX - x : nTX + event.clientX - x);
                        if(tx>0)
                        oDragObj.style.left  = tx+"px";
                        //
                        UpdateLine(); 
                        //
                        return false; 
                 }
            } 
            else
            {
                if(LineFrom!="")
                {
                    ////////////////////////////////////////////////////////////////////////////
                     var ty = nn6 ? e.clientY : event.clientY; 
                     var tx = nn6 ? e.clientX : event.clientX; 
                     
                     if(tx<5)tx=5;if(ty<5)ty=5;
                     
                     var fy=0;fx=0;
                     if(ty<LineFrom.style.pixelTop)
                     { fy = parseInt(LineFrom.style.pixelTop);}
                     else if(ty> LineFrom.style.pixelTop+LineFrom.style.pixelHeight)
                     { fy = parseInt(LineFrom.style.pixelTop+LineFrom.style.pixelHeight);}
                     else 
                     {fy=parseInt(LineFrom.style.pixelTop+LineFrom.style.pixelHeight/2);}
                     //
                     if(tx<LineFrom.style.pixelLeft-10)
                     {  fx=LineFrom.style.pixelLeft;}
                     else if(tx>LineFrom.style.pixelLeft+LineFrom.style.pixelWidth+10)                  
                     {fx =parseInt(LineFrom.style.pixelLeft+LineFrom.style.pixelWidth);}
                     else
                     {
                        {fx =parseInt(LineFrom.style.pixelLeft+LineFrom.style.pixelWidth/2);}
                     }
                     ////////////////////////////////////////////////////////////////////////////
                     
                     if(fy>ty)
                        ty+=2;
                     else
                        ty-=2;
                     
                     if(fx>tx)
                        tx+=2;
                     else
                        tx-=2;
                                          
                     var LineFromXY =fx+","+fy;
                     var t=(tx)+","+(ty);
                    if(aLine=="")
                    {
                        aLine=CreateLine(LineFromXY,t);
                        aLine.id="line"+NewLineID ;
                        AddControl(aLine,99999,0,0);
                        NewLineID++;
                    }
                    else
                    {
                        aLine.from=LineFromXY;
                        aLine.to=t;
                    }
                }
            }
        } 

        var DElement;
        function initDrag(e) 
        { 
            self.focus();
            //
            var oDragHandle = nn6 ? e.target : event.srcElement;
            /////////////////////////////////
             if(DElement!=null && (oDragHandle.className=="dragAble" || oDragHandle.className=="Line" || oDragHandle.className=="PointText"))
             { 
                 DElement.strokecolor="black" ;
                 DElement.strokeweight="1pt";
                 if(DElement.className=="Line") DElement.strokeweight="1.2pt";
             }  
            /////////////////////////////////
            if(event.button!=2 && oDragHandle.className!="MenuItem" && oDragHandle.className!="MenuItemIco" && oDragHandle.className!="aContextMenu" && oDragHandle.className!="MenuItemSplit"  )
            {   
                HideContextMenu();
            }
            // 
            //
            if(oDragHandle.className=="dragAble" || oDragHandle.className=="Line" || oDragHandle.className=="PointText")
            {
                DElement=oDragHandle;
                if(DElement.className=="PointText")DElement=DElement.parentNode;
                //////////////////
                if( PaintStat !="drawline")
                {
                   DElement.strokecolor="#0066ff" ;
                   DElement.strokeweight="1.2pt";
                   if(DElement.className=="Line") DElement.strokeweight="1.6pt";
                }
                /////////////////
                FocusChange();//触发控件焦点改变事件
            }
            //
            if(PaintStat !="drawline")
            {
                 var topElement = "HTML"; 
                 while (oDragHandle.tagName != topElement && oDragHandle.className != "dragAble") 
                 { 
                    oDragHandle = nn6 ? oDragHandle.parentNode : oDragHandle.parentElement; 
                 } 
                 if (oDragHandle.className=="dragAble") 
                 { 
                     isdrag = true; 
                     oDragObj = oDragHandle; 
                     nTY = parseInt(oDragObj.style.top+0); 
                     y = nn6 ? e.clientY : event.clientY; 
                     nTX = parseInt(oDragObj.style.left+0); 
                     x = nn6 ? e.clientX : event.clientX; 
                     document.onmousemove=moveMouse; 
                     return false; 
                 } 
                 else
                 {
                    return false; 
                 }
             }
             else
             { 
                  if(oDragHandle.className=="PointText")oDragHandle=oDragHandle.parentNode;
                  if(oDragHandle.className=="dragAble" )
                  {
                        if( LineFrom =="" )
                        {
                            LineFrom =oDragHandle;
                        }
                        else
                        {
                            if(!ChkIsLinked(LineFrom.id,oDragHandle.id))
                            {
                                 aLine.frompoint=LineFrom.id;
                                 aLine.topoint=oDragHandle.id;
                                 UpdateLine();
                                 LineFrom ="";
                                 aLine="";
                            }
                            else 
                            {
                                 ClearErrorLine();
                                 PaintStat =="drawline";
                                 LineFrom ="";
                                 aLine="";
                            }
                        }
                   }
                   else
                   {
                         ClearErrorLine();
                         PaintStat =="drawline";
                         LineFrom ="";
                         aLine="";
                   }
             }
        } 
        function mouserup()
        {
            isdrag=false;isDraw=false;
             self.focus();
        }
        document.onmousedown=initDrag; 
        document.onmouseup=mouserup; 
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        	function getElementsByClassName(clsName,htmltag)
			{    
				var arr = new Array();    
				var elems = document.getElementsByTagName(htmltag);   
				for ( var cls, i = 0; ( elem = elems[i] ); i++ ){   
				if ( elem.className == clsName ){ 
				arr[arr.length] = elem;   
				}   
				}   
				return arr;   
			} 
			
			///////////////////////////////////////////////////////////////
			function UpdateLine()
			{
			    ClearErrorLine();
			     var elen=document.all.length;   
                      for (var i=0;i<elen;i++)   
                      {   
                           if(document.all[i] != null && document.all[i].className !=null && document.all[i].className=="Line")
                           {
                                  var lineobj=document.all[i];
                                  if(lineobj!=null & lineobj.frompoint!=null && lineobj.topoint!=null && ( lineobj.frompoint==DElement.id || lineobj.topoint==DElement.id))
                                  {
                                      var fpoint=document.getElementById(lineobj.frompoint);
                                      var tpoint=document.getElementById(lineobj.topoint);
                                      //
                                      if(fpoint !=null && tpoint !=null )
                                      {
                                          var fpx=fpoint.style.pixelLeft;
                                          var fpy=fpoint.style.pixelTop;
                                          var fpw=fpoint.style.pixelWidth;
                                          var fph=fpoint.style.pixelHeight;
                                          //
                                          var tpx=tpoint.style.pixelLeft;
                                          var tpy=tpoint.style.pixelTop;
                                          var tpw=tpoint.style.pixelWidth;
                                          var tph=tpoint.style.pixelHeight;
                                          //
                                          //
                                          var fx=0;fy=0;
                                          var tx=0;ty=0;
                                          //
                                          if(fpx+fpw<tpx)////
                                          {fx=fpx+fpw ;tx=tpx;}
                                          else if(fpx>tpx+tpw)///
                                          {fx=fpx;tx=tpx+tpw;}
                                          else//
                                          {fx=fpx+fpw/2;tx=tpx+tpw/2;}
                                          if(fpy+fph<tpy )///
                                          {fy=fpy+fph;ty=tpy;}
                                          else if(fpy>tpy+tph)///
                                          {fy=fpy;ty=tpy+tph;}
                                          else 
                                          {fy=fpy+fph/2;ty=tpy+tph/2;}
                                          //
                                          //
                                          lineobj.from=fx+","+fy;
                                          lineobj.to=tx+","+ty;
                                      }
                                  }
                                  else 
                                  {
                                        //if(lineobj!=null)
                                        //{lineobj.parentNode.removeChild(lineobj);}
                                  }
                           }
                      }   
			}

///////////////////////////////////////
function ChkIsLinked(fromid,toid)//检查两结点间是不是已存在链接

{
     var elen=document.all.length; 
     var re=false ;  
                      for (var i=0;i<elen;i++)   
                      {   
                           if(document.all[i] != null && document.all[i].className !=null && document.all[i].className=="Line")
                           {
                                var lineobj=document.all[i];
                                if((lineobj.frompoint==fromid && lineobj.topoint==toid ) || (lineobj.topoint==fromid && lineobj.frompoint==toid))
                                {
                                    re =true ;
                                }
                           }
                      }
                      return re;
}