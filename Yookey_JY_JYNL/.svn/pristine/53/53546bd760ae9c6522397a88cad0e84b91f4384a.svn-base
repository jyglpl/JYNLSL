//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="AssessmentProcessDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2017/3/14 15:04:12
//  功能描述：AssessmentProcess数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using DBHelper;
using System.Collections.Generic;
using System.Data;
using Yookey.WisdomClassed.SIP.Model.Assessment;

namespace Yookey.WisdomClassed.SIP.DataAccess.Assessment
{
    /// <summary>
    /// AssessmentProcess数据访问操作
    /// </summary>
    public class AssessmentProcessDal : DalImp.BaseDal<AssessmentProcessEntity>
    {
        public AssessmentProcessDal()
        {
            Model = new AssessmentProcessEntity();
        }


        /// <summary>
        /// 查询案件Id查询附件
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        public List<AssessmentProcessEntity> GetAssessmentProcessListByAssessmentId(string assessmentId, int state)
        {
            string selSql = string.Format(@"SELECT *  FROM AssessmentProcess  WITH (NOLOCK) WHERE AssessmentId = '{0}' ", assessmentId);
            if (state != -1)
            {
                selSql += string.Format(" AND Status={0} ", state);
            }

            DataSet data = SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, System.Data.CommandType.Text, selSql);

            return data != null && data.Tables[0] != null && data.Tables[0].Rows.Count > 0 ? DataTableToList(data.Tables[0]) : new List<AssessmentProcessEntity>();
        }


    }
}

