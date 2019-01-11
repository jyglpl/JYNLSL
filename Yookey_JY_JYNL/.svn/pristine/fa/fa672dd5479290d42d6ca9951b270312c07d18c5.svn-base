//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="IllegalConstruction_AttachDal.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2018/4/14 14:05:55
//  功能描述：IllegalConstruction_Attach数据访问类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------

using System;
using System.Data;
using System.Text;
using DBHelper;
using Yookey.WisdomClassed.SIP.Model.IllegalConstruction;

namespace Yookey.WisdomClassed.SIP.DataAccess.IllegalConstruction
{
    /// <summary>
    /// IllegalConstruction_Attach数据访问操作
    /// </summary>
    public class IllegalConstructionAttachDal : DalImp.BaseDal<IllegalConstructionAttachEntity>
    {
        public IllegalConstructionAttachDal()
        {           
            Model = new IllegalConstructionAttachEntity();
        }


        /// <summary>
        /// 批量删除照片
        /// 添加人：周 鹏
        /// 添加时间：2015-03-03
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="ids">照片数据集,使用逗号分隔开</param>
        /// <returns></returns>
        public bool DeleteAttach(string ids)
        {
            var transaction = new TransactionLoader().BeginTransaction("DeleteAttach");
            try
            {
                var idsplit = ids.Split(',');
                var sbSql = new StringBuilder("");
                if (idsplit.Length > 0)
                {
                    foreach (var s in idsplit)
                    {
                        sbSql.AppendFormat(@"UPDATE IllegalConstruction_Attach SET RowStatus=0 WHERE Id='{0}';", s);
                    }
                    SqlHelper.ExecuteNonQuery(transaction, CommandType.Text, sbSql.ToString());
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return false;
            }
            transaction.Commit();
            return true;
        }


        /// <summary>
        /// 获取案件附件
        /// 添加人：周 鹏
        /// 添加时间：2015-04-22
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="caseinfoId">案件编号</param>
        /// <param name="fileViewLink"></param>
        /// <returns></returns>
        public DataTable GetFileList(string caseinfoId, string fileViewLink)
        {
            var strSql = new StringBuilder("");
            strSql.AppendFormat("SELECT Id,'{0}' AS FileView,FileTypeName,FileAddress FROM IllegalConstruction_Attach WHERE RowStatus=1 AND ResourceId='{1}' ORDER BY CreateOn", fileViewLink, caseinfoId);

            return SqlHelper.ExecuteDataset(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 通过照片名称删除照片
        /// </summary>
        /// <param name="imgName">照片名称</param>
        /// <returns></returns>
        public bool DeleteAttachByImgName(string imgName)
        {
            if (string.IsNullOrEmpty(imgName))
                return false;
            var strSql = new StringBuilder("");
            strSql.AppendFormat("UPDATE IllegalConstruction_Attach SET RowStatus=0 WHERE FileReName='{0}'", imgName);

            return SqlHelper.ExecuteNonQuery(SqlHelper.SqlConnStringRead, CommandType.Text, strSql.ToString())>0;

        }
    }
}
                                                                                                                                         
