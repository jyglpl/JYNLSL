//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="ComNoteBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/9 10:53:33
//  功能描述：ComNote业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model;
using System.Diagnostics;
using Yookey.WisdomClassed.SIP.Common;
using System.Data;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Model.Crm;
using Yookey.WisdomClassed.SIP.Business.FlowEditor;
using Yookey.WisdomClassed.SIP.Model.FlowEditor;
using System.Linq;
using Yookey.WisdomClassed.SIP.Model.License;
using Yookey.WisdomClassed.SIP.Business.Base;
namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// ComNote业务逻辑
    /// </summary>
    public class ComNoteBll : BaseBll<ComNoteEntity>
    {
        public ComNoteBll()
        {
            BaseDal = new ComNoteDal();
        }

        /// <summary>
        /// 短信消息查询
        /// </summary>
        /// <param name="person">姓名</param>
        /// <param name="phoneNumber">手机号码</param>
        /// <param name="dateStart">开始时间</param>
        /// <param name="dateEnd">结束时间</param>
        /// <param name="pageSzie"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        public PageJqDatagrid<ComNoteContentEntity> GetCommonQuryGetCommonQury(string person, string phoneNumber, string dateStart, string dateEnd, int pageSzie = 15,
                                                              int pageIndex = 1)
        {
            //计时
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            int totalRecords;
            var data = new ComNoteDal().GetCommonQury(person, phoneNumber, dateStart, dateEnd, pageSzie, pageIndex, out totalRecords);

            var list = ConvertListHelper<ComNoteContentEntity>.ConvertToList(data);

            stopwatch.Stop();
            var totalPage = (totalRecords + pageSzie - 1) / pageSzie;   //计算页数
            return new PageJqDatagrid<ComNoteContentEntity>
            {
                page = pageIndex,
                rows = list,
                total = totalPage,
                records = totalRecords,
                costtime = stopwatch.ElapsedMilliseconds.ToString()
            };
        }

        /// <summary>
        /// 获取树手机号码
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public List<Node> GetNodeQury(string pId)
        {
            return new ComNoteDal().GetNodeQury(pId);
        }

        /// <summary>
        /// 删除消息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteMessage(string id)
        {
            return new ComNoteDal().DeleteMessage(id);
        }

        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="noteContent"></param>
        /// <returns></returns>
        public bool SaveMessage(ComNoteContentEntity noteContent)
        {
            ComNoteEntity note = new ComNoteEntity();

            note.ResourcesId = noteContent.Id;
            note.MistakeInfo = noteContent.MistakeInfo;
            note.ReceiveTime = noteContent.ReceiveTime;
            note.Status = 0;
            note.RowStatus = 1;
            Regex regex = new Regex(@"<[^>]+>|</[^>]+>"); //去掉尖括号里面的数据
            var strContent = noteContent.ReceivePhone.Split(new char[] { ';' });
            for (int i = 0; i < strContent.Length; i++)
            {
                if (strContent[i] == string.Empty)
                    break;
                note.Id = Guid.NewGuid().ToString();
                note.ReceivePhone = regex.Replace(strContent[i].ToString(), string.Empty);
                //数据发送
                new ComNoteDal().Add(note);
            }
            return new ComNoteDal().SaveNoteContent(noteContent);
        }

        /// <summary>
        /// 查询详细实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ComNoteContentEntity QueryNoteContent(string id)
        {
            return new ComNoteDal().QueryNoteContent(id);
        }


        /// <summary>
        /// 发送短信
        /// 添加人：周 鹏
        /// 添加时间：2015-07-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="msg">消息内容</param>
        /// <returns></returns>
        public void SendNote(string userId, string msg)
        {
            if (!AppConfig.IsEnableNote) return;
            if (string.IsNullOrEmpty(userId)) return;
            var userEntity = new BaseUserBll().Get(userId);
            if (userEntity == null || string.IsNullOrEmpty(userEntity.Mobile) || userEntity.Mobile.Equals("&nbsp;"))
                return;

            if (userEntity.Mobile.Equals("13913573300"))    //高局的手机号发送给倪局
            {
                userEntity.Mobile = "18896729504";
            }

            ////2018.6.20 至 2018.06.27 
            //if (userEntity.Mobile.Equals("18896729504") || userEntity.Mobile.Equals("18662590709"))
            //{
            //    return;
            //}

            if (!msg.Contains("null"))
            {
                var entity = new ComNoteEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    ResourcesId = "",
                    ReceivePhone = userEntity.Mobile,
                    MistakeInfo = msg,
                    ReceiveTime = DateTime.Now,
                    Status = 0,
                    RowStatus = 1
                };
                Add(entity);
            }
        }


        /// <summary>
        /// 短信查询
        /// 添加人：周 鹏
        /// 添加时间：2014-08-07
        /// </summary>
        /// <history> 
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="search">查询实体</param>
        /// <returns></returns>
        public List<ComNoteEntity> GetSearchResultByFormId(ComNoteEntity search)
        {
            var queryCondition = QueryCondition.Instance.AddEqual(ComNoteEntity.Parm_ComNote_RowStatus, "1");
            if (!string.IsNullOrEmpty(search.ResourcesId))
            {
                queryCondition.AddEqual(ComNoteEntity.Parm_ComNote_ResourcesId, search.ResourcesId);
            }
            queryCondition.AddOrderBy(ComNoteEntity.Parm_ComNote_CreateOn, false);
            return Query(queryCondition) as List<ComNoteEntity>;
        }

        /// <summary>
        /// 按期无效短信
        /// </summary>
        /// <param name="resourcesId">案件编号</param>
        /// <returns></returns>
        public bool DelteByFormId(string resourcesId)
        {
            return new ComNoteDal().DelteByFormId(resourcesId);
        }



        /// <summary>
        /// 处理完成向节点发送提醒短信
        /// </summary>
        /// <param name="licenseEntity">关联案件</param>
        /// <param name="activityName">发送的节点名称</param>
        /// <param name="mes">消息</param>
        /// <param name="receiveTime">发送时间</param>
        /// <returns></returns>
        public bool LicenseActionNote(LicenseMainEntity licenseEntity, string activityName, string mes, DateTime receiveTime)
        {

            if (string.IsNullOrEmpty(licenseEntity.Id) || string.IsNullOrEmpty(licenseEntity.Area) || string.IsNullOrEmpty(activityName) || string.IsNullOrEmpty(mes) || receiveTime == default(DateTime))
                return false;
            var formId = licenseEntity.Id;
            var feActivityBll = new FeActivityBll();
            var userBll = new CrmUserBll();
            var searchModel = new CrmMessageWorkEntity();
            searchModel.FormID = formId;
            searchModel.State = 0;//未处理！！
            var crmMessageList = new CrmMessageWorkBll().GetSearchResultByEnd(searchModel).Where(i =>
            {
                var activityEntity = feActivityBll.GetActivity(i.ActivityInstanceID);
                return activityEntity.FirstOrDefault(z => z.NoneName.Equals(activityName)) != null;
            }).ToList();
            if (crmMessageList != null && crmMessageList.Count > 0)//存在要发送消息的未处理的待办
            {
                var actionInstance = new FeActionInstanceBll().GetSearchResultByEnd(new FeActionInstanceEntity() { ActivityID = crmMessageList[0].ActivityInstanceID, CommunityID = licenseEntity.Area });//获取人员
                foreach (var item in actionInstance)
                {
                    var user = userBll.Get(item.UserID);
                    var entity = new ComNoteEntity()
                    {
                        Id = Guid.NewGuid().ToString(),
                        ResourcesId = formId,
                        ReceivePhone = user.Mobile,
                        MistakeInfo = mes,
                        ReceiveTime = receiveTime,
                        Status = 0,
                        RowStatus = 1
                    };
                    Add(entity);
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 向片区发送短信
        /// </summary>
        /// <param name="licenseEntity">关联案件</param>        
        /// <param name="mes">消息</param>
        /// <returns></returns>
        public bool SendNoteByArea(LicenseMainEntity licenseEntity, string mes)
        {
            string actionNameOne = "批文街道查勘";
            string actionNameTwo = "批文街道审核";
            var areaResult = false;
            var areaSResut = false;
            var noticeList = this.GetSearchResultByFormId(new ComNoteEntity() { ResourcesId = licenseEntity.Id });
            var actionTime = DateTime.Parse(new ComHolidaysBll().GetWorkTime(DateTime.Now, 3).ToString(AppConst.DateFormat) + " 09:00:00");
            if (noticeList != null & noticeList.Count > 0)
                actionTime = noticeList[0].ReceiveTime;
            var sendTime = actionTime;
            areaResult = this.LicenseActionNote(licenseEntity, actionNameOne, mes, sendTime);//向批文街道查勘发送短信            
            areaSResut = this.LicenseActionNote(licenseEntity, actionNameTwo, mes, sendTime);//向批文街道审核发送短信
            if (!areaResult && !areaSResut)
            {
                this.DelteByFormId(licenseEntity.Id);
            }
            return areaResult || areaSResut;
        }
    }
}
