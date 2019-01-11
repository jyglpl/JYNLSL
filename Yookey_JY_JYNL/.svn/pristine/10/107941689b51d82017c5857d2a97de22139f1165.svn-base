using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Common;
using Yookey.WisdomClassed.SIP.DataAccess.Mobile;

namespace Yookey.WisdomClassed.SIP.Business.Mobile
{
    /// <summary>
    /// 事部件
    /// </summary>
    public class DsfxcBll
    {
        private readonly DsfxcDal _dsfxcDal = new DsfxcDal();


        /// <summary>
        /// 获取所有的事件类型
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        ///           2015-08-06 周 鹏 增加父编号
        /// </history>
        /// <param name="parentId">父编号</param>
        /// <returns></returns>
        public DataTable GetCaseType(string parentId = "")
        {
            return _dsfxcDal.GetCaseType(parentId);
        }

        /// <summary>
        /// 获取所有待办【未回复】的事部件
        /// </summary>
        /// <param name="userId">用户编号</param>
        /// <param name="emergency">紧急程度</param>
        /// <param name="deptId">部门编号</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求条数</param>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <param name="timeType">时间类型：本日 day、本周 week、所有 all、自定义 user-defined</param>
        /// <param name="startTime">自定义开始时间</param>
        /// <param name="endTime">自定义截止时间</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="orderType">排序方式</param>
        /// <returns> Columns->
        /// ProblemNo  单号
        /// CaseClassI 大类
        /// CaseClassII 小类
        /// ReportCaseDesc 问题描述
        /// ReportAddress  上报地址
        /// ReportTime  上报时间
        /// </returns>
        public DataTable GetTask(string userId, string deptId, string caseClassI, string caseClassIi, string timeType,
                                 string startTime, string endTime, string emergency, int pageIndex, int pageSize, out int totalRecords,
                                 string orderType = "ASC")
        {
            return _dsfxcDal.GetTask(userId, deptId, caseClassI, caseClassIi, timeType, startTime, endTime, emergency,
                                     pageIndex, pageSize, out totalRecords, orderType);
        }


        /// <summary>
        /// 查看事部件详情
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">单号</param>
        /// <param name="netWork">请求网络的段（内、外网）</param>
        /// <returns></returns>
        public DataTable GetTaskDetails(string problemNo, CommonMethod.NetWorkEnum netWork)
        {
            return _dsfxcDal.GetTaskDetails(problemNo, netWork);
        }

        /// <summary>
        /// 事件问题上报
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="dsfxcId">上报问题ID</param>
        /// <param name="reporterId">上报人编号</param>
        /// <param name="reporter">报告人</param>
        /// <param name="phone">市民联系电话</param>
        /// <param name="desc">问题的描述</param>
        /// <param name="address">位置描述</param>
        /// <param name="caseType">案件类型（上传编码0601 0602）</param>
        /// <param name="caseTypeDesc">类型描述</param>
        /// <param name="caseClassi">事件大类（上传编码 ，如上传01、02等）</param>
        /// <param name="caseClassiDesc">大类描述</param>
        /// <param name="caseClassii">事件小类（上传编码取代汉字，如上传0101、0201等）</param>
        /// <param name="caseClassiiDesc">小类描述</param>
        /// <param name="caseClassiii">事件子类（上传编码取代汉字，如上传010101、020101等）</param>
        /// <param name="caseClassiiiDesc">子类描述</param>
        /// <param name="lng">位置经度，无值为""</param>
        /// <param name="lat">位置纬度 ，无值为""</param>
        /// <param name="attachment">附件地址</param>
        /// <param name="caseCondition">立案条件</param>
        /// <param name="caseConditionDesc">立案条件描述</param>
        /// <param name="emergency">紧急程序</param>
        /// <returns></returns>
        public bool ReportProblem(string dsfxcId, string reporterId, string reporter, string phone, string desc,
                                  string address, string caseType,
                                  string caseTypeDesc, string caseClassi, string caseClassiDesc, string caseClassii,
                                  string caseClassiiDesc, string caseClassiii, string caseClassiiiDesc, string lng,
                                  string lat, string attachment, string caseCondition, string caseConditionDesc,
                                  string emergency)
        {
            try
            {
                return _dsfxcDal.ReportProblem(dsfxcId, reporterId, reporter, phone, desc, address, caseType,
                                               caseTypeDesc, caseClassi, caseClassiDesc, caseClassii, caseClassiiDesc,
                                               caseClassiii, caseClassiiiDesc, lng, lat, attachment, caseCondition,
                                               caseConditionDesc, emergency);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 事件回复处理
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="staffID">处理部门guid</param>
        /// <param name="dealTime">处理时间</param>
        /// <param name="dealComment">处理意见</param>
        /// <param name="filePath">附件地址</param>
        /// <param name="cmdID">处理指令ID</param>
        /// <returns></returns>
        public bool HandleProblem(string problemNo, string staffID, string dealTime, string dealComment, string filePath,
                                  string cmdID)
        {
            try
            {
                return _dsfxcDal.HandleProblem(problemNo, staffID, dealTime, dealComment, filePath, cmdID);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 两小时处理回复
        /// 添加人：周 鹏
        /// 添加时间：2018-07-31
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="staffID">处理部门guid</param>
        /// <param name="dealTime">处理时间</param>
        /// <param name="dealComment">处理意见</param>
        /// <param name="filePath">附件地址</param>
        /// <param name="cmdID">处理指令ID</param>
        /// <returns></returns>
        public string TwoHourReply(string problemNo, string staffID, string dealTime, string dealComment, string filePath, string cmdID, string fileName, string userId)
        {
            try
            {
                return _dsfxcDal.TwoHourReply(problemNo, staffID, dealTime, dealComment, filePath, cmdID, fileName,
                                              userId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        /// <summary>
        /// 事部件问题的接收
        /// 添加人：周 鹏
        /// 添加时间：2015-03-04
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <param name="userId">接收人ID</param>
        /// <param name="userName">接收人姓名</param>
        /// <returns></returns>
        public
        bool ProblemAccept(string problemNo, string userId, string userName)
        {
            return _dsfxcDal.ProblemAccept(problemNo, userId, userName);
        }

        /// <summary>
        /// 查询个人接收的事件
        /// 添加人：周 鹏
        /// 添加时间：2015-03-06
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">接收人员编号</param>
        /// <param name="emergency">紧急程序</param>
        /// <param name="stateType">状态类型：0 接收 1：回复处理</param>
        /// <param name="pageIndex">当前索引页</param>
        /// <param name="pageSize">每页请求的条数</param>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <param name="timeType">时间类型：本日 day、本周 week、所有 all、自定义 user-defined</param>
        /// <param name="startTime">自定义开始时间</param>
        /// <param name="endTime">自定义截止时间</param>
        /// <param name="totalRecords">总条数</param>
        /// <param name="orderType">排序方式</param>
        /// <returns></returns>
        public DataTable GetMineTask(string userId, string caseClassI, string caseClassIi, string timeType,
                                     string startTime, string endTime, string emergency, int? stateType, int pageIndex,
                                     int pageSize, out int totalRecords, string orderType = "DESC")
        {
            return _dsfxcDal.GetMineTask(userId, caseClassI, caseClassIi, timeType, startTime, endTime, emergency,
                                         stateType, pageIndex, pageSize, out totalRecords, orderType);
        }

        /// <summary>
        /// 案件退回
        /// 添加人：周 鹏
        /// 添加时间：2015-04-09
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskBack(string userId, string problemNo, string dealContent)
        {
            return _dsfxcDal.TaskBack(userId, problemNo, dealContent);
        }

        /// <summary>
        /// 获取立案条件
        /// 添加人：周 鹏
        /// 添加时间：2015-04-16
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseClassI">大类</param>
        /// <param name="caseClassIi">小类</param>
        /// <returns>DataTable.</returns>
        public DataTable GetCaseCondition(string caseClassI, string caseClassIi)
        {
            return _dsfxcDal.GetCaseCondition(caseClassI, caseClassIi);
        }

        /// <summary>
        /// 根据问题编号查询问题接收人
        /// 添加人：周 鹏
        /// 添加时间：2015-05-12
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="problemNo">问题编号</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.Exception"></exception>
        public string GetAcceptIdByProblemNo(string problemNo)
        {
            return _dsfxcDal.GetAcceptIdByProblemNo(problemNo);
        }


        /// <summary>
        /// 申请拒签
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyRefuse(string userId, string problemNo, string dealContent)
        {
            return _dsfxcDal.TaskApplyRefuse(userId, problemNo, dealContent);
        }

        /// <summary>
        /// 获取申请拒签信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyRefuse(string userId, string problemNo)
        {
            return _dsfxcDal.TaskGetApplyRefuse(userId, problemNo);
        }


        /// <summary>
        /// 申请延时
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <param name="applyAsk">申请天数</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyDelay(string userId, string problemNo, string dealContent, int applyAsk)
        {
            return _dsfxcDal.TaskApplyDelay(userId, problemNo, dealContent, applyAsk);
        }

        /// <summary>
        /// 获取申请拒签信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyDelay(string userId, string problemNo)
        {
            return _dsfxcDal.TaskGetApplyDelay(userId, problemNo);
        }


        /// <summary>
        /// 申请拒签
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">处理人员</param>
        /// <param name="problemNo">案件编号</param>
        /// <param name="dealContent">处理人员意见</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool TaskApplyPostPone(string userId, string problemNo, string dealContent)
        {
            return _dsfxcDal.TaskApplyPostPone(userId, problemNo, dealContent);
        }

        /// <summary>
        /// 获取申请拒签信息
        /// 添加人：周 鹏
        /// 添加时间：2015-06-01
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="userId">UserId</param>
        /// <param name="problemNo">问题编号</param>
        /// <returns>DataTable</returns>
        public DataTable TaskGetApplyPostPone(string userId, string problemNo)
        {
            return _dsfxcDal.TaskGetApplyPostPone(userId, problemNo);
        }

        /// <summary>
        /// 获取上传GPS坐标参数信息
        /// 添加人：周 鹏
        /// 添加时间：2015-07-08
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public DataTable GetServerParams()
        {
            return _dsfxcDal.GetServerParams();
        }


        /// <summary>
        /// 根据部门、时间段统计事件数据
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        public DataTable DsfxcStatistics(string departmentId, string startTime, string endTime)
        {
            return _dsfxcDal.DsfxcStatistics(departmentId, startTime, endTime);
        }
    }
}
