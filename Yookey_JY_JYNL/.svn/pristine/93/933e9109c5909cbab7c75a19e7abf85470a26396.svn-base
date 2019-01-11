using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Yookey.WisdomClassed.SIP.Business.Case;
using Yookey.WisdomClassed.SIP.Business.Com;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace SupplementPoliceData
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Thread _thread;

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_thread == null || _thread.ThreadState == ThreadState.Aborted ||
               _thread.ThreadState == ThreadState.Stopped)
            {
                _thread = new Thread(Start) { IsBackground = true };
                _thread.Start();
            }
        }


        private void Start()
        {

            var stime = dtpStart.Value.ToString("yyyy-MM-dd");
            var etime = dtpEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            var data = new InfCarChecksignBll().GetUnYJ(stime, etime);

            BeginInvoke(new MethodInvoker(delegate
                {
                    btnStart.Enabled = false;
                    btnStart.Text = @"执行中...";

                    pb.Maximum = data.Rows.Count;
                    pb.Value = 0;
                }));
            try
            {
                foreach (DataRow row in data.Rows)
                {
                    var checkSignId = row["Id"].ToString();
                    ConverInf(checkSignId);

                    BeginInvoke(new MethodInvoker(delegate
                        {
                            pb.Value += 1;
                        }));
                }
            }
            catch (Exception ex)
            {
                BeginInvoke(new MethodInvoker(delegate
                    {
                        MessageBox.Show(@"异常：" + ex.Message);
                    }));
            }
            BeginInvoke(new MethodInvoker(delegate
                {
                    btnStart.Enabled = true;
                    btnStart.Text = @"开始执行";
                }));
        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            if (_thread == null || _thread.ThreadState == ThreadState.Aborted ||
                _thread.ThreadState == ThreadState.Stopped)
            {
                this.Close();
            }
        }

        //重新执行照片合成
        public void ConverInf(string checksignId)
        {
            var search = new InfCarChecksignBll().Get(checksignId);

            var listWt = new InfCarAttachBll().Query(Yookey.WisdomClassed.SIP.Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.Id).
                    AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "2"));
            string picCompleteAddr = "";  //合成后的照片

            //如果该条案件没有合成照片，合成案件照片，有的话，则直接取
            if (listWt.Count <= 0)
            {
                #region 合成照片
                //设备编号
                var sbCode = AppConfig.SBCode;
                ////公路等级
                //违法行为
                var wfxw = AppConfig.WFXW;
                //发现机关
                var fxjg = AppConfig.FXJG;
                //执勤民警
                var zqmj = AppConfig.ZQMJ;
                //实测值
                var scValue = AppConfig.SCValue;
                //标准值
                var bzValue = AppConfig.BZValue;
                //通知书编号
                var tzsbh = AppConfig.TZSBH;
                //采集方式
                var cjfs = AppConfig.CJFS;
                //识别用户
                var sbyh = AppConfig.SBYH;
                //总数
                var total = AppConfig.Total;
                //序号
                var sn = AppConfig.SN;
                //备注
                var remark = AppConfig.Remark;
                //版本
                var ver = AppConfig.Ver;

                //取得案件的单张照片
                listWt = new InfCarAttachBll().Query(Yookey.WisdomClassed.SIP.Model.QueryCondition.Instance.AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_ResourceId, search.Id).
                    AddEqual(InfCarAttachEntity.Parm_INF_CAR_ATTACH_FileType, "1"));
                if (listWt != null && listWt.Count > 0)
                {
                    var filename = "";

                    #region 构造附件名称
                    filename = sbCode + "_"; //设备编号
                    var road = search.Road;

                    string _GLDJ = "9999";
                    filename += road + "_";//主干道地点代码
                    filename += _GLDJ + "_";//公路等级
                    filename += search.CheckSignAddress + "_";//违章地点
                    filename += "9_"; //方向

                    var checkDate = search.CheckDate;

                    var ctime = checkDate.ToString("yyyyMMddHHmmss");

                    filename += ctime + "_";//违章时间
                    filename += scValue + "_";//实测值
                    filename += bzValue + "_";//标准值
                    filename += new ComResourceBll().Get(search.CarType).RsValue + "_"; //号牌种类
                    var carno = search.CarNo;
                    if (carno.Substring(carno.Length - 1, 1) == "学" || carno.Substring(carno.Length - 1, 1) == "挂" || carno.Substring(carno.Length - 1, 1) == "警")//判断车牌号码后面是否带学或挂等字
                    {
                        //如果包含学或挂字，去掉
                        carno = carno.Substring(0, carno.Length - 1);
                    }
                    filename += carno + "_";//车牌号码
                    filename += wfxw + "_";//违法行为
                    filename += fxjg + "_";//发现机关
                    filename += zqmj + "_";//执勤民警
                    filename += tzsbh + "_";//通知书编号
                    filename += cjfs + "_";//采集方式
                    filename += sbyh + "_";//识别用户
                    filename += total + "_";//总数
                    filename += sn + "_";//序号
                    filename += remark + "_";//备注
                    filename += ver;//版本
                    #endregion

                    var fjFileName = filename + ".JPG";//合并的照片名称

                    #region 创建合成文件
                    string filePath1 = "", filePath2 = "", filePath3 = "";
                    for (var i = 0; i < listWt.Count; i++)
                    {
                        var imgAddr = "";
                        if (listWt[i].ImgAddress != null)
                            imgAddr = listWt[i].ImgAddress;  //单张照片的路径
                        switch (i)
                        {
                            case 0:
                                filePath1 = imgAddr;
                                break;
                            case 1:
                                filePath2 = imgAddr;
                                break;
                            case 2:
                                filePath3 = imgAddr;
                                break;
                        }
                    }
                    var pwh = AppConfig.Pwh;
                    var w = int.Parse(pwh.Split('|')[0]);//获得指定宽度
                    var h = int.Parse(pwh.Split('|')[1]);//获得指定高度

                    if (filePath1 != "" && filePath2 != "")  //判断如果本地照片数量大于2张的话，则调用合成方法
                    {
                        //调用服务执行合并生成违章停车照片方法
                        var pictureService = new PictureService.PictureService(AppConfig.FileSaveServiceLink);
                        picCompleteAddr = pictureService.MakewatermarkNew(filePath1, filePath2, filePath3, fjFileName, "", w, h, "HW", "1");
                    }
                    else if (filePath1 != "" && filePath2 == "" && filePath3 == "") //如果只有一张单张片,复制一张添加进去。
                    {
                        //调用服务执行复制重命名图片
                        var pictureService = new PictureService.PictureService(AppConfig.FileSaveServiceLink);
                        picCompleteAddr = pictureService.CopNewPic(filePath1, fjFileName);
                    }

                    //将新的合成图片保存附件至数据库中
                    if (picCompleteAddr != "")
                    {
                        var pic = new InfCarAttachEntity()
                        {
                            ImgAddress = picCompleteAddr,
                            FileType = "2",
                            FileName = fjFileName,
                            CreateBy = "",
                            CreateDate = DateTime.Now,
                            RowStatus = 1,
                            ResourceId = search.Id
                        };
                        new InfCarAttachBll().Add(pic);
                    }
                    #endregion
                }
                #endregion
            }
        }
    }
}
