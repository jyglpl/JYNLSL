using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.DataAccess.Crm;
using Yookey.WisdomClassed.SIP.Model.Case;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Microsoft.Office.Interop.Word;
using Yookey.WisdomClassed.SIP.Business.TempDetain;
using Yookey.WisdomClassed.SIP.Model.TempDetain;
using Yookey.WisdomClassed.SIP.Business.SealUp;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// 文书管理
    /// </summary>
    public class InfWritBll
    {
        public object Obj = new object();

        /// <summary>
        /// 请求文书
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2016-01-11 周 鹏 增加票据打印
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="isToPdf">是否需要转PDF格式</param>
        /// <returns></returns>
        public string GetWrit(string writIdentify, string resourceId, bool isToPdf = false)
        {
            try
            {

                int whilecount = 0;

                int isUse = new InfPunishDocumentDal().IsUse();
                while (isUse == 1)
                {
                    Thread.Sleep(5000);
                    isUse = new InfPunishDocumentDal().IsUse();
                    whilecount++;
                    if (whilecount >= 10)
                    {
                        break;
                    }
                }
                if (whilecount >= 10)
                {
                    return "";
                }
                new InfPunishDocumentDal().UpdateUse(1);

                lock (Obj)
                {
                    var writAddress = "";
                    if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId))
                    {
                        //验证文书是否已经生成过,如果已生成就直接返回
                        writAddress = CheckWrit(writIdentify, resourceId);
                        if (!string.IsNullOrEmpty(writAddress)) return writAddress;

                        //模板实体
                        var models =
                            new CrmIssuanceModelBll().GetSearchResult(new CrmIssuanceModelEntity()
                                {
                                    ModelIdentify = writIdentify
                                });
                        var modelEntity = new CrmIssuanceModelEntity();
                        if (models.Any())
                        {
                            modelEntity = models[0];
                        }


                        var fileAddress = AppConfig.FileSaveAddr;
                        var model = fileAddress + modelEntity.ModelAddress; //模板路径

                        if (CommonMethod.FileIsUsed(model))
                        {
                            Thread.Sleep(2000);
                        }

                        //生成文书
                        switch (writIdentify)
                        {
                            case "Registration": //立案审批表
                            case "Processration": //处理审批表
                            case "CaceBackCard": //送达回证(告知书)
                            case "CaceBackCardD": //送达回证（决定书）
                            case "Dossier": //卷宗
                            case "CaseOrder": //委托单（一般、简易）
                            case "Inform": //告知书（A4）
                            case "InformTD": //告知书（套打）
                            case "Decision": //决定书（A4）
                            case "DecisionTD": //决定书（套打）
                            case "Endration": //结案审批表
                            case "SimpleCase": //简易案件决定书
                            case "SimpleCar": //违章停车决定书
                            case "SimpleCarChapter": //违法停车决定书（带章）
                            case "CarOrder": //违章停车委托单
                            case "CarBill": //违章停车罚没款票据
                            case "CaseBill": //一般案件罚没款票据
                            case "PleadApproval": //陈述申辩、听证情况处理审批表
                            case "PleadRecord": //陈述申辩笔录
                            case "ForceDecision": //实施行政强制措施决定书
                            case "RelieveForceDecision": //解除行政强制措施决定书
                            case "LicenseAcceptance": //行政许可受理通知书
                            case "LicenseDisposableNotice": //一次性告知书
                            case "LicenseInadmissibleDecision": //行政许可不予受理决定书
                            case "LicenseGrantDecision": //准予行政许可决定书
                            case "LicenseNonDecision": //不予行政许可决定书
                            case "LicenseApprovalForm": //户外广告设置审批意见表
                            case "LicenseApprovalFormB": //大型户外广告设置审批意见表
                            case "LicenseTemporaryLaneHeap": //临时占道堆物/搭建审批意见表
                            case "PetitionRegister":
                                writAddress = Registration(writIdentify, resourceId, modelEntity);
                                break;
                            case "Record": //询问笔录
                                writAddress = Record(writIdentify, resourceId, modelEntity);
                                break;
                            case "CasePhoto": //案件照片
                            case "CarPhoto":
                                writAddress = CasePhoto(writIdentify, resourceId, modelEntity);
                                break;
                            case "Leave": //请假单
                                writAddress = Leave(writIdentify, resourceId, modelEntity);
                                break;
                            case "Inventory": //暂扣物品单
                            case "SealUpList": //查封（扣押）清单
                            case "ReturnSealUpList": //查封（扣押）退还清单
                                writAddress = Inventory(writIdentify, resourceId, modelEntity);
                                break;
                            //--------------------------------------
                            // 责令停止违反城市管理行为通知书
                            case "OrderStopInform":
                                writAddress = CaseInfRegistration(writIdentify, resourceId, modelEntity, isToPdf);
                                break;
                            // 现场检查/勘验笔录
                            case "FieldInspectionRecord":
                                writAddress = CheckRecord(writIdentify, resourceId, modelEntity, isToPdf);
                                break;
                            // 整合文书
                            case "CaseAllDocument":
                            case "CaseAllDocumentZG":
                                writAddress = CheckRecord(writIdentify, resourceId, modelEntity, isToPdf);
                                break;
                        }
                    }
                    return writAddress;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                new InfPunishDocumentDal().UpdateUse(0);
            }
        }

        /// <summary>
        /// 生成文书
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <returns></returns>
        private static string Registration(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var writAddress = ""; //文书路径

            Application app = null;
            Document doc = null;
            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }
                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    var tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);

                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                var rangeText = rowDate[col.ColumnName].ToString();
                                if (writIdentify.Equals("CaseBill") || writIdentify.Equals("CarBill"))
                                {
                                    if (rangeText.Equals("/"))
                                    {
                                        rangeText = "ⓧ";
                                    }
                                }
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rangeText;
                                //doc.Bookmarks.Item[objName].Range.Text = rowDate[col.ColumnName].ToString();
                            }
                        }

                        //图片数据
                        var writPic = dataSource.Columns.Contains("WritPictures") ? rowDate["WritPictures"].ToString() : "";
                        //插入图片
                        if (!string.IsNullOrEmpty(modelEntity.PictureSets) && !string.IsNullOrEmpty(writPic))
                        {
                            var modelPicList =
                                JsonConvert.DeserializeObject<List<ModelPictureSet>>(modelEntity.PictureSets);
                            var writPicList = JsonConvert.DeserializeObject<List<WritPicture>>(writPic);

                            var missing = Type.Missing;
                            object objectTrue = true;


                            foreach (var writPicEntity in writPicList)
                            {
                                var modelPicWhere =
                                    modelPicList.Where(x => x.PictureName.Equals(writPicEntity.PictureName)).ToList();
                                if (!modelPicWhere.Any())
                                {
                                    throw new Exception(string.Format("模板中未能找到索引为{0}的图片设置信息。", writPicEntity.PictureName));
                                }
                                else
                                {
                                    ////插入图片
                                    //var modelPicEntity = modelPicWhere[0];
                                    //object picLeft = modelPicEntity.Left;
                                    //object picTop = modelPicEntity.Top;

                                    //var signAddress = fileAddress + @"\Sign\" + writPicEntity.SignName;
                                    //if (File.Exists(signAddress))
                                    //{
                                    //    doc.Shapes.AddPicture(signAddress,
                                    //                          ref missing, ref objectTrue, ref picLeft, ref picTop,
                                    //                          ref missing, ref missing, ref missing);
                                    //}

                                    var modelPicEntity = modelPicWhere[0];
                                    var picWidth = modelPicEntity.Width.ToString();
                                    var picHeight = modelPicEntity.Height.ToString();


                                    var signAddress = fileAddress + @"\Sign\" + writPicEntity.SignName;
                                    if (File.Exists(signAddress))
                                    {
                                        object item = writPicEntity.PictureName;
                                        var bmk = doc.Bookmarks.get_Item(ref item);
                                        if (bmk != null)
                                        {
                                            object start = bmk.Start;
                                            object end = bmk.End;
                                            var rang = doc.Range(ref start, ref end);
                                            var il = rang.InlineShapes.AddPicture(signAddress, ref missing, ref missing, ref missing);
                                            if (!picWidth.Equals("0") && !picHeight.Equals("0"))
                                            {
                                                il.Width = float.Parse(picWidth);
                                                il.Height = float.Parse(picHeight);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;

                        //将数据保存至数据库
                        var punishDocument = new InfPunishDocumentEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CaseInfoId = resourceId,
                            ModelId = modelEntity.Id,
                            ModelIdentify = modelEntity.ModelIdentify,
                            ModelName = modelEntity.ModelName,
                            WritName = fileNewName,
                            WritAddress = path + @"\" + fileNewName,
                            RowStatus = 1,
                            CreateBy = "",
                            CreatorId = "",
                            CreateOn = DateTime.Now,
                            UpdateBy = "",
                            UpdateId = "",
                            UpdateOn = DateTime.Now
                        };

                        new InfPunishDocumentBll().Add(punishDocument);
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
            }
            return writAddress;
        }

        /// <summary>
        /// 验证文书是否已经生成
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <returns></returns>
        private static string CheckWrit(string writIdentify, string resourceId)
        {
            try
            {
                var writAddress = "";   //文书路径
                var list = new InfPunishDocumentBll().GetSearchResult(new InfPunishDocumentEntity() { ModelIdentify = writIdentify, CaseInfoId = resourceId });
                if (list != null && list.Any())
                {
                    if (!string.IsNullOrEmpty(list[0].WritAddress))
                    {
                        writAddress = AppConfig.FileWritViewLink + list[0].WritAddress;
                    }
                }
                return writAddress;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 查封（扣押）清单
        /// /// </summary>
        /// <param name="writIdentify"></param>
        /// <param name="resourceId"></param>
        /// <param name="modelEntity"></param>
        /// <returns></returns>
        private static string Inventory(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var writAddress = ""; //文书路径
            Application app = null;
            Document doc = null;
            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }
                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    var tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        System.Data.DataTable InventoryList = new System.Data.DataTable();
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure, resourceId);
                        if (writIdentify == "Inventory")
                        {
                            //清单数据源
                            InventoryList = new TempDetainGoodsBll().GetInventory(resourceId);
                        }
                        else
                        {
                            //清单数据源
                            InventoryList = new SealUpGoodsBll().GetInventory(resourceId);
                        }
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);

                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rowDate[col.ColumnName].ToString();
                            }

                            switch (objName.ToString())
                            {
                                case "ArticleName":   //名称
                                case "Specifications"://规格型号
                                case "Number":        //数量（质量)
                                case "Remark":        //备注
                                case "Num":           //序号

                                    if (InventoryList.Rows.Count > 0)
                                    {
                                        for (int i = 1; i <= 10; i++)
                                        {
                                            if (i <= InventoryList.Rows.Count)
                                            {
                                                if (doc.Bookmarks.Exists(objName.ToString() + i))
                                                {
                                                    doc.Bookmarks.get_Item(objName.ToString() + i).Range.Text = InventoryList.Rows[i - 1][objName.ToString()].ToString();
                                                }
                                            }
                                            else
                                            {
                                                doc.Bookmarks.get_Item(objName.ToString() + i).Range.Text = "";
                                            }
                                        }
                                    }
                                    break;
                            }
                        }


                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
            }
            return writAddress;
        }

        /// <summary>
        /// 生成调查询问笔录
        /// 添加人：周 鹏
        /// 添加时间：2015-04-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <returns>文书预览地址</returns>
        private static string Record(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var writAddress = ""; //文书路径

            Application app = null;
            Document doc = null;
            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }
                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    var tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);

                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rowDate[col.ColumnName].ToString();
                            }
                        }

                        #region 生成调查询问笔录动态内容
                        var content = dataSource.Columns.Contains("RecordInfo") ? rowDate["RecordInfo"].ToString() : "";
                        if (content.IndexOf("\n", System.StringComparison.Ordinal) != -1)
                        {
                            while (content.IndexOf("\n", System.StringComparison.Ordinal) != -1)
                            {
                                var info = content.Substring(0, content.IndexOf("\n", System.StringComparison.Ordinal));
                                if (info.Length <= 42)
                                {
                                    if (!string.IsNullOrEmpty(info))
                                    {
                                        object beforeRow = doc.Tables[1].Rows[doc.Tables[1].Rows.Count - 1];
                                        var row = doc.Tables[1].Rows.Add(ref beforeRow);
                                        row.Range.Text = info;
                                    }
                                }
                                else
                                {
                                    var count = info.Length / 42;
                                    if (info.Length % 42 != 0)
                                    {
                                        count++;
                                    }
                                    for (var i = 0; i < count; i++)
                                    {
                                        var info1 = "";
                                        if (info.Length > 42)
                                        {
                                            info1 = info.Substring(0, 42);
                                            info = info.Remove(0, 42);
                                        }
                                        else
                                        {
                                            info1 = info;
                                        }
                                        object beforeRow = doc.Tables[1].Rows[doc.Tables[1].Rows.Count - 1];
                                        var row = doc.Tables[1].Rows.Add(ref beforeRow);
                                        row.Range.Text = !string.IsNullOrEmpty(info1) ? info1 : "";
                                    }
                                }
                                content = content.Remove(0, content.IndexOf("\n", System.StringComparison.Ordinal) + 1);
                            }
                            if (content != "")
                            {
                                var count = content.Length / 42;
                                if (content.Length % 42 != 0)
                                {
                                    count++;
                                }
                                for (var i = 0; i < count; i++)
                                {
                                    var info1 = "";
                                    if (content.Length > 42)
                                    {
                                        info1 = content.Substring(0, 42);
                                        content = content.Remove(0, 42);
                                    }
                                    else
                                    {
                                        info1 = content;
                                    }
                                    if (info1 == "")
                                    {
                                        info1 = "";
                                    }
                                    object beforeRow = doc.Tables[1].Rows[doc.Tables[1].Rows.Count - 1];
                                    var row = doc.Tables[1].Rows.Add(ref beforeRow);
                                    row.Range.Text = !string.IsNullOrEmpty(info1) ? info1 : "";
                                }
                            }
                        }
                        #endregion

                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
            }
            return writAddress;
        }


        /// <summary>
        /// 生成案件证据
        /// 添加人：周 鹏
        /// 添加时间：2015-01-07
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <returns></returns>
        private static string CasePhoto(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var writAddress = ""; //文书路径

            Application app = null;
            Document doc = null;
            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }
                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    var tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);

                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rowDate[col.ColumnName].ToString();
                                //doc.Bookmarks.Item[objName].Range.Text = rowDate[col.ColumnName].ToString();
                            }
                        }

                        //图片数据
                        var writPic = dataSource.Columns.Contains("WritPictures") ? rowDate["WritPictures"].ToString() : "";
                        //插入图片
                        if (!string.IsNullOrEmpty(modelEntity.PictureSets) && !string.IsNullOrEmpty(writPic))
                        {
                            var modelPicList =
                                JsonConvert.DeserializeObject<List<ModelPictureSet>>(modelEntity.PictureSets);
                            var writPicList = JsonConvert.DeserializeObject<List<WritPicture>>(writPic);

                            var missing = Type.Missing;
                            object objectTrue = true;

                            Bookmark bmk;
                            object start;
                            object end;
                            foreach (var writPicEntity in writPicList)
                            {
                                var modelPicWhere =
                                    modelPicList.Where(x => x.PictureName.Equals(writPicEntity.PictureName)).ToList();
                                if (!modelPicWhere.Any())
                                {
                                    throw new Exception(string.Format("模板中未能找到索引为{0}的图片设置信息。", writPicEntity.PictureName));
                                }
                                else
                                {
                                    ////插入图片
                                    //var modelPicEntity = modelPicWhere[0];
                                    //object picLeft = modelPicEntity.Left;
                                    //object picTop = modelPicEntity.Top;
                                    //object picWidth = modelPicEntity.Width;
                                    //object picHeight = modelPicEntity.Height;

                                    //var signAddress = fileAddress + writPicEntity.SignName;
                                    //if (File.Exists(signAddress))
                                    //{
                                    //    doc.Shapes.AddPicture(signAddress,
                                    //                          ref missing, ref objectTrue, ref picLeft, ref picTop,
                                    //                          ref picWidth, ref picHeight, ref missing);
                                    //}

                                    //由于文件存储在另一台服务器上，需要将图片下载到本地
                                    var virtualAddr = writPicEntity.SignName;
                                    if (!string.IsNullOrEmpty(virtualAddr))
                                    {
                                        var saveAddr = fileAddress + virtualAddr;
                                        if (!File.Exists(saveAddr))
                                        {
                                            //执行文件下载存储到本地
                                            CommonMethod.HttpDownload(AppConfig.FileViewLink + virtualAddr, saveAddr);
                                        }
                                    }

                                    var modelPicEntity = modelPicWhere[0];
                                    object picLeft = modelPicEntity.Left;
                                    object picTop = modelPicEntity.Top;
                                    var picWidth = modelPicEntity.Width.ToString();
                                    var picHeight = modelPicEntity.Height.ToString();

                                    var signAddress = fileAddress + writPicEntity.SignName;
                                    object item = "Picture";
                                    bmk = doc.Bookmarks.get_Item(ref item);
                                    start = bmk.Start;
                                    end = bmk.End;

                                    var rang = doc.Range(ref start, ref end);
                                    //rang.ShapeRange.Width = float.Parse(picWidth);
                                    //rang.ShapeRange.Height = float.Parse(picHeight);

                                    var il = rang.InlineShapes.AddPicture(signAddress, ref missing, ref missing, ref missing);
                                    il.Width = float.Parse(picWidth);
                                    il.Height = float.Parse(picHeight);


                                    //doc.Range(ref start, ref end).InlineShapes.AddPicture(signAddress, ref missing, ref missing, ref missing);
                                }
                            }
                        }

                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;

                        //将数据保存至数据库
                        var punishDocument = new InfPunishDocumentEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CaseInfoId = resourceId,
                            ModelId = modelEntity.Id,
                            ModelIdentify = modelEntity.ModelIdentify,
                            ModelName = modelEntity.ModelName,
                            WritName = fileNewName,
                            WritAddress = path + @"\" + fileNewName,
                            RowStatus = 1,
                            CreateBy = "",
                            CreatorId = "",
                            CreateOn = DateTime.Now,
                            UpdateBy = "",
                            UpdateId = "",
                            UpdateOn = DateTime.Now
                        };

                        new InfPunishDocumentBll().Add(punishDocument);
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
            }
            return writAddress;
        }

        /// <summary>
        /// 生成请假单
        /// 添加人：周 鹏
        /// 添加时间：2015-04-30
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <returns></returns>
        private static string Leave(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var writAddress = ""; //文书路径

            Application app = null;
            Document doc = null;
            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }
                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    var tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);
                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rowDate[col.ColumnName].ToString();
                                //doc.Bookmarks.Item[objName].Range.Text = rowDate[col.ColumnName].ToString();
                            }
                        }


                        #region 动态绑定审批意见


                        var idea = new CrmIdeaListBll().GetFlowIdea(resourceId, "请假审批");
                        if (idea != null && idea.Rows.Count > 0)
                        {
                            foreach (DataRow ideaRow in idea.Rows)
                            {
                                object beforeRow = doc.Tables[1].Rows[doc.Tables[1].Rows.Count];
                                var row = doc.Tables[1].Rows.Add(ref beforeRow);
                                row.Height = float.Parse("40");
                                row.Range.Text = string.Format("{0}：{1}。\n                                     审批人：{2} 审批日期：{3}",
                                    ideaRow["Duty"], ideaRow["Idea"], ideaRow["UserName"], (Convert.ToDateTime(ideaRow["Adate"]).ToString(AppConst.DateFormat)));
                            }
                        }

                        #endregion

                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
            }
            return writAddress;
        }


        #region  增加领导签名

        /// <summary>
        /// 添加领导签名
        /// </summary>
        /// <param name="lstrInputFile">输入文件名称</param>
        /// <param name="lstrOutFile">输出文件名称</param>
        /// <returns></returns>
        public bool AddLeaderSign(object lstrInputFile, string lstrOutFile)
        {
            Application app = null;
            Document doc = null;
            try
            {
                app = new Application(); //创建word应用程序
                object oMissing = System.Reflection.Missing.Value;

                //打开模板文件
                doc = app.Documents.Open(ref lstrInputFile,
                                             ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                             ref oMissing,
                                             ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                             ref oMissing,
                                             ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                             ref oMissing);


                //插件图片
                var fileAddress = AppConfig.FileSaveAddr;
                var signAddress = fileAddress + @"\Sign\倪局2.png";

                object item = "Sign";
                object linkToFile = false;
                object saveWithDocument = true;
                object Nothing = System.Reflection.Missing.Value;

                if (doc.Bookmarks.Exists(item.ToString()))
                {
                    doc.Bookmarks.get_Item(ref item).Select();

                    InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(signAddress, ref linkToFile, ref saveWithDocument, ref Nothing);
                    shape.Width = 70;//图片宽度
                    shape.Height = 30;//图片高度
                    shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapFront;
                }
                else
                {
                    //定位至文档的最后一行
                    object dummy = System.Reflection.Missing.Value;
                    object what = WdGoToItem.wdGoToLine;
                    object which = WdGoToDirection.wdGoToLast;
                    object count = 99999999;
                    doc.Application.Selection.GoTo(ref what, ref which, ref count, ref dummy);

                    object range = app.Selection.Range;
                    InlineShape shape = app.ActiveDocument.InlineShapes.AddPicture(signAddress, ref linkToFile, ref saveWithDocument, ref range);
                    shape.Width = 70;//图片宽度
                    shape.Height = 30;//图片高度
                    shape.ConvertToShape().WrapFormat.Type = WdWrapType.wdWrapFront;
                }

                //对替换好的word模板另存为一个新的word文档
                doc.SaveAs(lstrOutFile,
                           oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                           oMissing,
                           oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();
                }
                if (app != null)
                {
                    app.Quit();
                }
            }
        }

        #endregion


        /// <summary>
        /// 执法案件生成文书
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <param name="isToPdf">是否需要转换成PDF</param>
        /// <returns></returns>
        private static string CaseInfRegistration(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity, bool isToPdf)
        {
            var writAddress = ""; //文书路径
            var tempWritAddress = ""; //文书本地存储路径
            Application app = null;
            Document doc = null;
            object CopyFilePath = "";

            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }

                    if (!Directory.Exists(fileAddress + "\\CopyFile"))
                    {
                        Directory.CreateDirectory(fileAddress + "\\CopyFile");
                    }
                    CopyFilePath = fileAddress + "\\CopyFile\\" + Guid.NewGuid().ToString() + ".doc";
                    File.Copy(model.ToString(), CopyFilePath.ToString());

                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    tempWritAddress = fileAddress + path + @"\" + fileNewName;
                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;

                        //打开模板文件
                        doc = app.Documents.Open(ref model,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);

                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                doc.Bookmarks.get_Item(ref objName).Range.Text = rowDate[col.ColumnName].ToString();
                                //doc.Bookmarks.Item[objName].Range.Text = rowDate[col.ColumnName].ToString();
                            }
                        }

                        //图片数据
                        var writPic = dataSource.Columns.Contains("WritPictures") ? rowDate["WritPictures"].ToString() : "";
                        //插入图片
                        if (!string.IsNullOrEmpty(modelEntity.PictureSets) && !string.IsNullOrEmpty(writPic))
                        {
                            var modelPicList =
                                JsonConvert.DeserializeObject<List<ModelPictureSet>>(modelEntity.PictureSets);
                            var writPicList = JsonConvert.DeserializeObject<List<WritPicture>>(writPic);
                            if (writIdentify == "CaceBackCard")
                            {
                                writPicList.RemoveAt(1);
                            }

                            object Nothing = System.Reflection.Missing.Value;
                            var missing = Type.Missing;
                            object objectTrue = true;

                            Bookmark bmk;
                            object start;
                            object end;
                            foreach (var writPicEntity in writPicList)
                            {
                                var modelPicWhere =
                                    modelPicList.Where(x => x.PictureName.Equals(writPicEntity.PictureName)).ToList();
                                if (!modelPicWhere.Any())
                                {
                                    throw new Exception(string.Format("模板中未能找到索引为{0}的图片设置信息。", writPicEntity.PictureName));
                                }
                                else
                                {
                                    var modelPicEntity = modelPicWhere[0];
                                    var picWidth = modelPicEntity.Width.ToString();
                                    var picHeight = modelPicEntity.Height.ToString();
                                    var picLeft = modelPicEntity.Left;
                                    var picTop = modelPicEntity.Top;

                                    var signAddress = "";

                                    if (writPicEntity.PictureName == "Mark" || writPicEntity.PictureName == "Mark1")
                                    {
                                        signAddress = fileAddress + "/Seal/" + writPicEntity.SignName;
                                    }
                                    else
                                    {
                                        signAddress = fileAddress + @"\Sign\" + writPicEntity.SignName;
                                    }

                                    if (File.Exists(signAddress))
                                    {
                                        object item = writPicEntity.PictureName;
                                        bmk = doc.Bookmarks.get_Item(ref item);
                                        start = bmk.Start;
                                        end = bmk.End;

                                        doc.Bookmarks.get_Item(ref item).Select();


                                        InlineShape inlineShape = app.Selection.InlineShapes.AddPicture(signAddress, ref objectTrue, ref objectTrue, ref Nothing);

                                        app.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                        //设置图片大小
                                        inlineShape.Width = float.Parse(picWidth);
                                        inlineShape.Height = float.Parse(picHeight);
                                        //doc.Range(start, end);
                                        
                                        if (writPicEntity.PictureName == "Mark" || writPicEntity.PictureName == "Mark1")
                                        {
                                            Microsoft.Office.Interop.Word.Shape cShape = inlineShape.ConvertToShape();
                                            cShape.WrapFormat.Type = WdWrapType.wdWrapFront;
                                            cShape.Top = float.Parse(picTop);
                                            cShape.Left = float.Parse(picLeft);
                                        }
                                        else
                                        {
                                            inlineShape.ConvertToShape().WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapThrough;
                                        }
                                    }

                                }
                            }
                        }
                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;

                        //将数据保存至数据库
                        var punishDocument = new InfPunishDocumentEntity()
                        {
                            Id = Guid.NewGuid().ToString(),
                            CaseInfoId = resourceId,
                            ModelId = modelEntity.Id,
                            ModelIdentify = modelEntity.ModelIdentify,
                            ModelName = modelEntity.ModelName,
                            WritName = fileNewName,
                            FileType = "WORD",
                            WritAddress = path + @"\" + fileNewName,
                            RowStatus = 1,
                            CreateBy = "",
                            CreatorId = "",
                            CreateOn = DateTime.Now,
                            UpdateBy = "",
                            UpdateId = "",
                            UpdateOn = DateTime.Now
                        };

                        new InfPunishDocumentBll().Add(punishDocument);
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序

                    if (CopyFilePath != null)
                    {
                        File.Delete(CopyFilePath.ToString());
                    }
                }
            }

            if (isToPdf)
            {
                writAddress = WordToPdf(tempWritAddress, resourceId, modelEntity);
            }

            return writAddress;
        }


        /// <summary>
        /// 现场检查笔录
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="writIdentify">文书标识</param>
        /// <param name="resourceId">外键编号</param>
        /// <param name="modelEntity">模板实体</param>
        /// <param name="isToPdf">是否需要转换成PDF</param>
        /// <returns>文书预览地址</returns>
        private static string CheckRecord(string writIdentify, string resourceId, CrmIssuanceModelEntity modelEntity, bool isToPdf)
        {
            var writAddress = ""; //文书路径

            Application app = null;
            Document doc = null;
            var tempWritAddress = ""; //文书本地存储路径
            object CopyFilePath = "";

            try
            {
                if (!string.IsNullOrEmpty(writIdentify) && !string.IsNullOrEmpty(resourceId) && modelEntity != null)
                {
                    var fileAddress = AppConfig.FileSaveAddr;
                    object model = fileAddress + modelEntity.ModelAddress; //模板路径
                    var path = string.Format(@"\Writ\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
                    if (!Directory.Exists(fileAddress + path))
                    {
                        Directory.CreateDirectory(fileAddress + path);
                    }

                    if (!Directory.Exists(fileAddress + "\\CopyFile"))
                    {
                        Directory.CreateDirectory(fileAddress + "\\CopyFile");
                    }
                    CopyFilePath = fileAddress + "\\CopyFile\\" + Guid.NewGuid().ToString() + ".doc";
                    File.Copy(model.ToString(), CopyFilePath.ToString());

                    var fileNewName = Guid.NewGuid().ToString() + ".doc";
                    tempWritAddress = fileAddress + path + @"\" + fileNewName;


                    //文书生成的路径
                    if (File.Exists(model.ToString()))
                    {
                        //数据源
                        var dataSource = new InfPunishDocumentDal().GetDataSource(modelEntity.StoredProcedure,
                                                                                  resourceId);
                        var rowDate = dataSource.Rows[0];
                        app = new Application(); //创建word应用程序
                        object oMissing = System.Reflection.Missing.Value;
                        object format = WdSaveFormat.wdFormatTextLineBreaks;

                        //打开模板文件
                        doc = app.Documents.Open(ref CopyFilePath,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing,
                                                     ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                     ref oMissing);
                        //遍历列名进行数据替换
                        foreach (DataColumn col in dataSource.Columns)
                        {
                            if (app.Selection == null) continue;
                            object objName = col.ColumnName;

                            //书签存在并且列名不为“WritPictures”
                            if (doc.Bookmarks.Exists(objName.ToString()) && !col.ColumnName.Equals("WritPictures"))
                            {
                                var content = rowDate[col.ColumnName].ToString().Replace(@"\n", Environment.NewLine);
                                //var content = rowDate[col.ColumnName].ToString();
                                doc.Bookmarks.get_Item(ref objName).Range.Text = content;
                            }
                        }

                        //图片数据
                        var writPic = dataSource.Columns.Contains("WritPictures") ? rowDate["WritPictures"].ToString() : "";
                        //插入图片
                        if (!string.IsNullOrEmpty(modelEntity.PictureSets) && !string.IsNullOrEmpty(writPic))
                        {
                            var modelPicList =
                                JsonConvert.DeserializeObject<List<ModelPictureSet>>(modelEntity.PictureSets);
                            var writPicList = JsonConvert.DeserializeObject<List<WritPicture>>(writPic);

                            object Nothing = System.Reflection.Missing.Value;
                            var missing = Type.Missing;
                            object objectTrue = true;

                            Bookmark bmk;
                            object start;
                            object end;
                            foreach (var writPicEntity in writPicList)
                            {
                                var modelPicWhere =
                                    modelPicList.Where(x => x.PictureName.Equals(writPicEntity.PictureName)).ToList();
                                if (!modelPicWhere.Any())
                                {
                                    throw new Exception(string.Format("模板中未能找到索引为{0}的图片设置信息。", writPicEntity.PictureName));
                                }
                                else
                                {
                                    var modelPicEntity = modelPicWhere[0];
                                    var picLeft = modelPicEntity.Left;
                                    var picTop = modelPicEntity.Top;
                                    var picWidth = modelPicEntity.Width.ToString();
                                    var picHeight = modelPicEntity.Height.ToString();

                                    //修改
                                    var signAddress = "";
                                    if (writPicEntity.PictureName == "Mark")
                                    {
                                        signAddress = fileAddress + "/Seal/" + writPicEntity.SignName;
                                    }
                                    else
                                    {
                                        signAddress = fileAddress + "/PunishCase/" + resourceId + "/" + writPicEntity.SignName;
                                    }

                                    if (File.Exists(signAddress))
                                    {
                                        object item = writPicEntity.PictureName;
                                        doc.Bookmarks.get_Item(ref item).Select();

                                        app.Selection.ParagraphFormat.Alignment = Microsoft.Office.Interop.Word.WdParagraphAlignment.wdAlignParagraphCenter;

                                        InlineShape inlineShape = app.Selection.InlineShapes.AddPicture(signAddress, ref objectTrue, ref objectTrue, ref Nothing);

                                        //设置图片大小
                                        inlineShape.Width = float.Parse(picWidth);
                                        inlineShape.Height = float.Parse(picHeight);
                                        if (writPicEntity.PictureName == "Mark")
                                        {
                                            Microsoft.Office.Interop.Word.Shape cShape = inlineShape.ConvertToShape();
                                            cShape.WrapFormat.Type = WdWrapType.wdWrapFront;
                                            cShape.Top = float.Parse(picTop);
                                            cShape.Left = float.Parse(picLeft);
                                        }
                                        else
                                        {
                                            inlineShape.ConvertToShape().WrapFormat.Type = Microsoft.Office.Interop.Word.WdWrapType.wdWrapThrough;
                                        }
                                    }
                                }
                            }
                        }

                        //对替换好的word模板另存为一个新的word文档
                        doc.SaveAs(tempWritAddress,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                                   oMissing,
                                   oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                        writAddress = AppConfig.FileWritViewLink + path + @"\" + fileNewName;
                    }
                    else
                    {
                        throw new Exception("在服务器上没有找到模板。");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序

                    if (CopyFilePath != null)
                    {
                        File.Delete(CopyFilePath.ToString());
                    }
                }
            }

            if (isToPdf)
            {
                writAddress = WordToPdf(tempWritAddress, resourceId, modelEntity);
            }

            return writAddress;
        }


        /// <summary>
        /// Word转PDF
        /// </summary>
        /// <param name="sourcePath">Word 绝对路径</param>
        /// <param name="resourceId">文件外键编号</param>
        /// <returns></returns>
        public static string WordToPdf(string sourcePath, string resourceId, CrmIssuanceModelEntity modelEntity)
        {
            var netWork = CommonMethod.GetNetWork();    //获取当前网络请求的段
            //本地存储路径
            var fileAddress = AppConfig.FileSaveAddr;
            //预览地址
            var fileViewAddress = AppConfig.FileViewLink;
            switch (netWork)
            {
                case CommonMethod.NetWorkEnum.Intranet:   //内网
                    fileViewAddress = AppConfig.FileWritViewLink;
                    break;
                case CommonMethod.NetWorkEnum.OutNet:     //外网
                    fileViewAddress = AppConfig.FileViewOutNetLink;
                    break;
            }

            var tempWritAddress = string.Format(@"WritPDF\{0}\{1}", DateTime.Now.Year.ToString("d4"), resourceId);
            if (!Directory.Exists(fileAddress + tempWritAddress))
            {
                Directory.CreateDirectory(fileAddress + tempWritAddress);
            }
            var fileNewName = Guid.NewGuid().ToString() + ".pdf";
            var targetPath = fileAddress + tempWritAddress + @"\" + fileNewName;
            var result = "";
            var application = new Application();
            Document document = null;

            try
            {
                application.Visible = false;
                document = application.Documents.Open(sourcePath);
                document.ExportAsFixedFormat(targetPath, WdExportFormat.wdExportFormatPDF);
                result = fileViewAddress + tempWritAddress + @"\" + fileNewName;


                //将数据保存至数据库
                var punishDocument = new InfPunishDocumentEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    CaseInfoId = resourceId,
                    ModelId = modelEntity.Id,
                    ModelIdentify = modelEntity.ModelIdentify,
                    ModelName = modelEntity.ModelName,
                    WritName = fileNewName,
                    FileType = "PDF",
                    WritAddress = tempWritAddress + @"\" + fileNewName,
                    RowStatus = 1,
                    CreateBy = "",
                    CreatorId = "",
                    CreateOn = DateTime.Now,
                    UpdateBy = "",
                    UpdateId = "",
                    UpdateOn = DateTime.Now
                };

                new InfPunishDocumentBll().Add(punishDocument);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = e.Message.ToString();
            }
            finally
            {
                if (document != null)
                {
                    document.Close();
                }
                if (application != null)
                {
                    application.Quit();
                }
            }
            return result;
        }
    }

    #region 辅助类

    /// <summary>
    /// 文书图片数据类
    /// </summary>
    class WritPicture
    {
        /// <summary>
        /// 图片的名称
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// 签字、名图片名称
        /// </summary>
        public string SignName { get; set; }
    }

    /// <summary>
    /// 模板图片设置类
    /// </summary>
    class ModelPictureSet
    {
        /// <summary>
        /// 图片的索引
        /// </summary>
        public string PictureName { get; set; }

        /// <summary>
        /// 宽度
        /// </summary>
        public double Width { get; set; }

        /// <summary>
        /// 高度
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// 图片距上方距离
        /// </summary>
        public string Top { get; set; }

        /// <summary>
        /// 图片距左侧距离
        /// </summary>
        public string Left { get; set; }
    }

    #endregion
}