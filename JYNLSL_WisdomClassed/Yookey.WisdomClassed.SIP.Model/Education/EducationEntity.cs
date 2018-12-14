using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Education
{
    /// <summary>
    /// 教育纠处
    /// </summary>
    [Serializable]
    public class EducationEntity : ModelImp.BaseModel<EducationEntity>
    {
        public EducationEntity()
        {
            TB_Name = TB_Education;
            Parm_Id = Parm_Education_Id;
            Parm_Version = Parm_Education_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_Education_Insert;
            Sql_Update = Sql_Education_Update;
            Sql_Delete = Sql_Education_Delete;
        }
        #region Const of table Education
        /// <summary>
        /// Table Education
        /// </summary>
        public const string TB_Education = "Education";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_Education_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_Education_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_Education_CreatorId = "CreatorId";
        /// <summary>
        /// Parm DepartmentId
        /// </summary>
        public const string Parm_Education_DepartmentId = "DepartmentId";
        /// <summary>
        /// Parm DepartmentName
        /// </summary>
        public const string Parm_Education_DepartmentName = "DepartmentName";
        /// <summary>
        /// Parm EducationAddress
        /// </summary>
        public const string Parm_Education_EducationAddress = "EducationAddress";
        /// <summary>
        /// Parm EducationTime
        /// </summary>
        public const string Parm_Education_EducationTime = "EducationTime";
        /// <summary>
        /// Parm FirstUserId
        /// </summary>
        public const string Parm_Education_FirstUserId = "FirstUserId";
        /// <summary>
        /// Parm FirstUserName
        /// </summary>
        public const string Parm_Education_FirstUserName = "FirstUserName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_Education_Id = "Id";
        /// <summary>
        /// Parm IsRefused
        /// </summary>
        public const string Parm_Education_IsRefused = "IsRefused";
        /// <summary>
        /// Parm ItemName
        /// </summary>
        public const string Parm_Education_ItemName = "ItemName";
        /// <summary>
        /// Parm ItemNo
        /// </summary>
        public const string Parm_Education_ItemNo = "ItemNo";
        /// <summary>
        /// Parm LegislationId
        /// </summary>
        public const string Parm_Education_LegislationId = "LegislationId";
        /// <summary>
        /// Parm PartyFeatures
        /// </summary>
        public const string Parm_Education_PartyFeatures = "PartyFeatures";
        /// <summary>
        /// Parm Remark
        /// </summary>
        public const string Parm_Education_Remark = "Remark";
        /// <summary>
        /// Parm RoadId
        /// </summary>
        public const string Parm_Education_RoadId = "RoadId";
        /// <summary>
        /// Parm RoadName
        /// </summary>
        public const string Parm_Education_RoadName = "RoadName";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_Education_RowStatus = "RowStatus";
        /// <summary>
        /// Parm SecondUserId
        /// </summary>
        public const string Parm_Education_SecondUserId = "SecondUserId";
        /// <summary>
        /// Parm SecondUserName
        /// </summary>
        public const string Parm_Education_SecondUserName = "SecondUserName";
        /// <summary>
        /// Parm Sync
        /// </summary>
        public const string Parm_Education_Sync = "Sync";
        /// <summary>
        /// Parm TargetAddress
        /// </summary>
        public const string Parm_Education_TargetAddress = "TargetAddress";
        /// <summary>
        /// Parm TargetAge
        /// </summary>
        public const string Parm_Education_TargetAge = "TargetAge";
        /// <summary>
        /// Parm TargetName
        /// </summary>
        public const string Parm_Education_TargetName = "TargetName";
        /// <summary>
        /// Parm TargetPaperNum
        /// </summary>
        public const string Parm_Education_TargetPaperNum = "TargetPaperNum";
        /// <summary>
        /// Parm TargetPaperType
        /// </summary>
        public const string Parm_Education_TargetPaperType = "TargetPaperType";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_Education_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_Education_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_Education_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_Education_Version = "Version";
        /// <summary>
        /// Insert Query Of Education
        /// </summary>
        public const string Sql_Education_Insert = "insert into Education(CreateBy,CreateOn,CreatorId,DepartmentId,DepartmentName,EducationAddress,EducationTime,FirstUserId,FirstUserName,IsRefused,ItemName,ItemNo,LegislationId,PartyFeatures,Remark,RoadId,RoadName,RowStatus,SecondUserId,SecondUserName,Sync,TargetAddress,TargetAge,TargetName,TargetPaperNum,TargetPaperType,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@DepartmentId,@DepartmentName,@EducationAddress,@EducationTime,@FirstUserId,@FirstUserName,@IsRefused,@ItemName,@ItemNo,@LegislationId,@PartyFeatures,@Remark,@RoadId,@RoadName,@RowStatus,@SecondUserId,@SecondUserName,@Sync,@TargetAddress,@TargetAge,@TargetName,@TargetPaperNum,@TargetPaperType,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of Education
        /// </summary>
        public const string Sql_Education_Update = "update Education set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,DepartmentId=@DepartmentId,DepartmentName=@DepartmentName,EducationAddress=@EducationAddress,EducationTime=@EducationTime,FirstUserId=@FirstUserId,FirstUserName=@FirstUserName,IsRefused=@IsRefused,ItemName=@ItemName,ItemNo=@ItemNo,LegislationId=@LegislationId,PartyFeatures=@PartyFeatures,Remark=@Remark,RoadId=@RoadId,RoadName=@RoadName,RowStatus=@RowStatus,SecondUserId=@SecondUserId,SecondUserName=@SecondUserName,Sync=@Sync,TargetAddress=@TargetAddress,TargetAge=@TargetAge,TargetName=@TargetName,TargetPaperNum=@TargetPaperNum,TargetPaperType=@TargetPaperType,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id ;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_Education_Delete = "update Education set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _departmentId = string.Empty;
        /// <summary>
        /// 执法部门
        /// </summary>
        public string DepartmentId
        {
            get { return _departmentId ?? string.Empty; }
            set { _departmentId = value; }
        }
        private string _departmentName = string.Empty;
        /// <summary>
        /// 执法部门名称
        /// </summary>
        public string DepartmentName
        {
            get { return _departmentName ?? string.Empty; }
            set { _departmentName = value; }
        }
        private string _firstUserId = string.Empty;
        /// <summary>
        /// 执法人员一
        /// </summary>
        public string FirstUserId
        {
            get { return _firstUserId ?? string.Empty; }
            set { _firstUserId = value; }
        }
        private string _firstUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FirstUserName
        {
            get { return _firstUserName ?? string.Empty; }
            set { _firstUserName = value; }
        }
        private string _secondUserId = string.Empty;
        /// <summary>
        /// 执法人员二
        /// </summary>
        public string SecondUserId
        {
            get { return _secondUserId ?? string.Empty; }
            set { _secondUserId = value; }
        }
        private string _secondUserName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SecondUserName
        {
            get { return _secondUserName ?? string.Empty; }
            set { _secondUserName = value; }
        }
        private string _legislationId = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string LegislationId
        {
            get { return _legislationId ?? string.Empty; }
            set { _legislationId = value; }
        }
        private string _itemNo = string.Empty;
        /// <summary>
        /// 案由编码
        /// </summary>
        public string ItemNo
        {
            get { return _itemNo ?? string.Empty; }
            set { _itemNo = value; }
        }
        private string _itemName = string.Empty;
        /// <summary>
        /// 纠处行为
        /// </summary>
        public string ItemName
        {
            get { return _itemName ?? string.Empty; }
            set { _itemName = value; }
        }
        private DateTime _educationTime = MinDate;
        /// <summary>
        /// 纠处时间
        /// </summary>
        public DateTime EducationTime
        {
            get { return _educationTime; }
            set { _educationTime = value; }
        }
        private string _educationAddress = string.Empty;
        /// <summary>
        /// 纠处地址
        /// </summary>
        public string EducationAddress
        {
            get { return _educationAddress ?? string.Empty; }
            set { _educationAddress = value; }
        }
        private string _roadId = string.Empty;
        /// <summary>
        /// 路段编号
        /// </summary>
        public string RoadId
        {
            get { return _roadId ?? string.Empty; }
            set { _roadId = value; }
        }
        private string _roadName = string.Empty;
        /// <summary>
        /// 路段名称
        /// </summary>
        public string RoadName
        {
            get { return _roadName ?? string.Empty; }
            set { _roadName = value; }
        }
        private string _partyFeatures = string.Empty;
        /// <summary>
        /// 当事人特征，用逗号分隔开
        /// </summary>
        public string PartyFeatures
        {
            get { return _partyFeatures ?? string.Empty; }
            set { _partyFeatures = value; }
        }
        private int _isRefused;
        /// <summary>
        /// 是否拒绝表达身份，1：是；0：否
        /// </summary>
        public int IsRefused
        {
            get { return _isRefused; }
            set { _isRefused = value; }
        }
        private string _targetName = string.Empty;
        /// <summary>
        /// nvarchar 	当事人姓名/负责人姓名
        /// </summary>
        public string TargetName
        {
            get { return _targetName ?? string.Empty; }
            set { _targetName = value; }
        }
        private string _targetAddress = string.Empty;
        /// <summary>
        /// nvarchar 	当事人地址
        /// </summary>
        public string TargetAddress
        {
            get { return _targetAddress ?? string.Empty; }
            set { _targetAddress = value; }
        }
        private string _targetPaperType = string.Empty;
        /// <summary>
        /// nvarchar 	证件类型
        /// </summary>
        public string TargetPaperType
        {
            get { return _targetPaperType ?? string.Empty; }
            set { _targetPaperType = value; }
        }
        private string _targetPaperNum = string.Empty;
        /// <summary>
        /// varchar 	证件号码
        /// </summary>
        public string TargetPaperNum
        {
            get { return _targetPaperNum ?? string.Empty; }
            set { _targetPaperNum = value; }
        }
        private int _targetAge;
        /// <summary>
        /// int 	当事人年龄
        /// </summary>
        public int TargetAge
        {
            get { return _targetAge; }
            set { _targetAge = value; }
        }
        private string _remark = string.Empty;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark ?? string.Empty; }
            set { _remark = value; }
        }
        private int _sync;
        /// <summary>
        /// 0
        /// </summary>
        public int Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override EducationEntity SetModelValueByDataRow(DataRow dr)
        {
            IList<string> fields = new List<string> { "*" };
            return SetModelValueByDataRow(dr, fields);
        }

        /// <summary>
        /// 根据DataRow给实体相应字段赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fields">字段集合</param>
        /// <returns>实体</returns>
        public override EducationEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new EducationEntity();
            if (fields.Contains(Parm_Education_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_Education_Id].ToString();
            if (fields.Contains(Parm_Education_DepartmentId) || fields.Contains("*"))
                tmp.DepartmentId = dr[Parm_Education_DepartmentId].ToString();
            if (fields.Contains(Parm_Education_DepartmentName) || fields.Contains("*"))
                tmp.DepartmentName = dr[Parm_Education_DepartmentName].ToString();
            if (fields.Contains(Parm_Education_FirstUserId) || fields.Contains("*"))
                tmp.FirstUserId = dr[Parm_Education_FirstUserId].ToString();
            if (fields.Contains(Parm_Education_FirstUserName) || fields.Contains("*"))
                tmp.FirstUserName = dr[Parm_Education_FirstUserName].ToString();
            if (fields.Contains(Parm_Education_SecondUserId) || fields.Contains("*"))
                tmp.SecondUserId = dr[Parm_Education_SecondUserId].ToString();
            if (fields.Contains(Parm_Education_SecondUserName) || fields.Contains("*"))
                tmp.SecondUserName = dr[Parm_Education_SecondUserName].ToString();
            if (fields.Contains(Parm_Education_LegislationId) || fields.Contains("*"))
                tmp.LegislationId = dr[Parm_Education_LegislationId].ToString();
            if (fields.Contains(Parm_Education_ItemNo) || fields.Contains("*"))
                tmp.ItemNo = dr[Parm_Education_ItemNo].ToString();
            if (fields.Contains(Parm_Education_ItemName) || fields.Contains("*"))
                tmp.ItemName = dr[Parm_Education_ItemName].ToString();
            if (fields.Contains(Parm_Education_EducationTime) || fields.Contains("*"))
                tmp.EducationTime = DateTime.Parse(dr[Parm_Education_EducationTime].ToString());
            if (fields.Contains(Parm_Education_EducationAddress) || fields.Contains("*"))
                tmp.EducationAddress = dr[Parm_Education_EducationAddress].ToString();
            if (fields.Contains(Parm_Education_RoadId) || fields.Contains("*"))
                tmp.RoadId = dr[Parm_Education_RoadId].ToString();
            if (fields.Contains(Parm_Education_RoadName) || fields.Contains("*"))
                tmp.RoadName = dr[Parm_Education_RoadName].ToString();
            if (fields.Contains(Parm_Education_PartyFeatures) || fields.Contains("*"))
                tmp.PartyFeatures = dr[Parm_Education_PartyFeatures].ToString();
            if (fields.Contains(Parm_Education_IsRefused) || fields.Contains("*"))
                tmp.IsRefused = int.Parse(dr[Parm_Education_IsRefused].ToString());
            if (fields.Contains(Parm_Education_TargetName) || fields.Contains("*"))
                tmp.TargetName = dr[Parm_Education_TargetName].ToString();
            if (fields.Contains(Parm_Education_TargetAddress) || fields.Contains("*"))
                tmp.TargetAddress = dr[Parm_Education_TargetAddress].ToString();
            if (fields.Contains(Parm_Education_TargetPaperType) || fields.Contains("*"))
                tmp.TargetPaperType = dr[Parm_Education_TargetPaperType].ToString();
            if (fields.Contains(Parm_Education_TargetPaperNum) || fields.Contains("*"))
                tmp.TargetPaperNum = dr[Parm_Education_TargetPaperNum].ToString();
            if (fields.Contains(Parm_Education_TargetAge) || fields.Contains("*"))
                tmp.TargetAge = int.Parse(dr[Parm_Education_TargetAge].ToString());
            if (fields.Contains(Parm_Education_Remark) || fields.Contains("*"))
                tmp.Remark = dr[Parm_Education_Remark].ToString();
            if (fields.Contains(Parm_Education_Sync) || fields.Contains("*"))
                tmp.Sync = int.Parse(dr[Parm_Education_Sync].ToString());
            if (fields.Contains(Parm_Education_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_Education_RowStatus].ToString());
            if (fields.Contains(Parm_Education_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_Education_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_Education_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_Education_CreatorId].ToString();
            if (fields.Contains(Parm_Education_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_Education_CreateBy].ToString();
            if (fields.Contains(Parm_Education_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_Education_CreateOn].ToString());
            if (fields.Contains(Parm_Education_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_Education_UpdateId].ToString();
            if (fields.Contains(Parm_Education_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_Education_UpdateBy].ToString();
            if (fields.Contains(Parm_Education_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_Education_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="education">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(EducationEntity education, SqlParameter[] parms)
        {
            parms[0].Value = education.DepartmentId;
            parms[1].Value = education.DepartmentName;
            parms[2].Value = education.FirstUserId;
            parms[3].Value = education.FirstUserName;
            parms[4].Value = education.SecondUserId;
            parms[5].Value = education.SecondUserName;
            parms[6].Value = education.LegislationId;
            parms[7].Value = education.ItemNo;
            parms[8].Value = education.ItemName;
            parms[9].Value = education.EducationTime;
            parms[10].Value = education.EducationAddress;
            parms[11].Value = education.RoadId;
            parms[12].Value = education.RoadName;
            parms[13].Value = education.PartyFeatures;
            parms[14].Value = education.IsRefused;
            parms[15].Value = education.TargetName;
            parms[16].Value = education.TargetAddress;
            parms[17].Value = education.TargetPaperType;
            parms[18].Value = education.TargetPaperNum;
            parms[19].Value = education.TargetAge;
            parms[20].Value = education.Remark;
            parms[21].Value = education.Sync;
            parms[22].Value = education.RowStatus;
            parms[23].Value = education.CreatorId;
            parms[24].Value = education.CreateBy;
            parms[25].Value = education.CreateOn;
            parms[26].Value = education.UpdateId;
            parms[27].Value = education.UpdateBy;
            parms[28].Value = education.UpdateOn;
            parms[29].Value = education.Id;
            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(EducationEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            var parsAll = new SqlParameter[parms.Length - 2];
            for (int i = 0; i < parsAll.Length; i++)
            {
                parsAll[i] = parms[i];
            }
            return parsAll;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_Education_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_Education_DepartmentId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_DepartmentName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_FirstUserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_FirstUserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_SecondUserId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_SecondUserName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_LegislationId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_ItemNo, SqlDbType.NVarChar, 10),
					new SqlParameter(Parm_Education_ItemName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_EducationTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Education_EducationAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Education_RoadId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_RoadName, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Education_PartyFeatures, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_Education_IsRefused, SqlDbType.Int, 10),
					new SqlParameter(Parm_Education_TargetName, SqlDbType.VarChar, 10),
					new SqlParameter(Parm_Education_TargetAddress, SqlDbType.VarChar, 500),
					new SqlParameter(Parm_Education_TargetPaperType, SqlDbType.VarChar, 50),
					new SqlParameter(Parm_Education_TargetPaperNum, SqlDbType.VarChar, 200),
					new SqlParameter(Parm_Education_TargetAge, SqlDbType.Int, 10),
					new SqlParameter(Parm_Education_Remark, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_Education_Sync, SqlDbType.Int, 10),
					new SqlParameter(Parm_Education_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_Education_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_Education_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_Education_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_Education_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_Education_Insert, parms);
                }
                return parms;
            }
            catch (Exception e)
            {
                throw new Exception("获取查询参数时出错！", e);
            }
        }
    }
}
