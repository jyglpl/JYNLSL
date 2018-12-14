using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.DataAccess.Case
{
    public class SimpleProgramDal
    {
        #region 简易程序插入语句

        /// <summary>
        /// UserId,DeptId,QId,QTypeName,DId,DNum,DMoney,DTime,DDescript
        /// </summary>
        public string InserValue
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(@"INSERT INTO [SimpleProgram] (Id,OrgId,SimpleProgramID,InternalNo,DeptName,RePersonelIdI,RePersonelIdII,
RePersonelNameI,RePersonelNameII,TargetType,TargetName,TargetAddress,TargetPaperNum,TargetGender,TargetAge,TargetPhone,TargetMobile,
CaseDate,RoadNo,RoadName,CaseAddress,CaseFact,PunishProcess,Lng,Lat,ItemNo,ItemName,PunishAmount,PaymentType,PaymentNum,CreateDateTime,
SyncDateTime,TargetPaperType) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}', '{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',
'{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}' );");
                
                return sb.ToString();
            }
        }
        #endregion

        #region 简易程序附件插入

        /// <summary>
        /// 简易程序附件插入
        /// </summary>
        /// <returns></returns>
        public string InserValueAttach
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append("INSERT INTO SimpleProgram_Attach(Id,SimpleProgramID,FileName,FileDesc,FileContent,FileAddress,CreateDateTime,SyncDateTime)");
                sb.Append(" VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}') ");
                return sb.ToString();
            }
        }
        #endregion

        #region 简易案件查询语句
        /// <summary>
        ///  简易案件查询语句
        /// </summary>
        public string SynchronizeSimpleProgram()
        {
            try
            {
                //简易案件查询语句
                const string sql = @"SELECT TOP 10 INF_PUNISH_CASEINFO.ID, '001' OrgId,INF_PUNISH_CASEINFO.Id CaseInfoID,CaseInfoNo AS InternalNo,DeptName,
(SELECT CertificateNo FROM Base_Certificate WHERE USERID= RePersonelIdFist) RePersonelIdFist,
(SELECT CertificateNo FROM Base_Certificate WHERE USERID= RePersonelIdSecond) RePersonelIdSecond,
RePersonelNameFist,RePersonelNameSecond,(SELECT rskey from ComResource where id= TargetType) TargetType,
TargetName,TargetAddress,( select rskey from ComResource where id= TargetPaperType ) TargetPaperType,
TargetPaperNum,TargetGender,TargetAge,TargetPhone,TargetMobile,CaseDate,RoadNo,RoadName,
CaseAddress,CaseFact,(SELECT RSKEY FROM ComResource WHERE ID=PunishType ) PunishProcess,
INF_PUNISH_LEGISLATION.ItemNo,ItemName,PunishAmount,
(SELECT RSKEY FROM ComResource WHERE ID=PaymentType) PaymentType,PaymentNum,Lng,Lat
FROM INF_PUNISH_CASEINFO 
INNER JOIN INF_PUNISH_LEGISLATION ON INF_PUNISH_CASEINFO.id=INF_PUNISH_LEGISLATION.CaseInfoId
INNER JOIN INF_PUNISH_FINISH ON INF_PUNISH_CASEINFO.ID=INF_PUNISH_FINISH.CaseInfoId
WHERE INF_PUNISH_CASEINFO.PunishProcess='00280001' 
AND (INF_PUNISH_CASEINFO.IsSync IS NULL OR INF_PUNISH_CASEINFO.IsSync='' OR INF_PUNISH_CASEINFO.IsSync='0') 
AND INF_PUNISH_CASEINFO.CreateOn>'2017-01-01'";

                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 简易程序附件内容
        /// </summary>
        public string SynchronAttachSimple()
        {
            try
            {
                const string sql = @"SELECT TOP 10 * FROM(
SELECT ID,ResourceId CaseInfoID,
(SELECT CaseInfoNo FROM INF_PUNISH_CASEINFO WHERE ID=ResourceId AND PunishProcess='00280001') InternalNo, FileReName,FileTypeName,FileAddress
FROM INF_PUNISH_ATTACH 
WHERE INF_PUNISH_ATTACH.Rowstatus=1 
AND (IsSync IS NULL OR IsSync='' OR IsSync='0')
AND INF_PUNISH_ATTACH.CreateOn >'2017-01-01') AS tab 
WHERE InternalNo IS NOT NULL";

                return sql;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion
    }
}
