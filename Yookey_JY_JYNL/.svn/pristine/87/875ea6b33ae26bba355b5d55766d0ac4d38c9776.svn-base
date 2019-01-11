using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.SealUp
{
    /// <summary>
    /// 查封管理附件
    /// </summary>
    [Serializable]
    public class SealUpAttachEntity : ModelImp.BaseModel<SealUpAttachEntity>
    {
        public SealUpAttachEntity()
        {
            TB_Name = TB_SealUpAttach;
            Parm_Id = Parm_SealUpAttach_Id;
            Parm_Version = Parm_SealUpAttach_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_SealUpAttach_Insert;
            Sql_Update = Sql_SealUpAttach_Update;
            Sql_Delete = Sql_SealUpAttach_Delete;
        }
        #region Const of table SealUpAttach
        /// <summary>
        /// Table SealUpAttach
        /// </summary>
        public const string TB_SealUpAttach = "SealUpAttach";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_SealUpAttach_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_SealUpAttach_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_SealUpAttach_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_SealUpAttach_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_SealUpAttach_FileName = "FileName";
        /// <summary>
        /// Parm FileRemark
        /// </summary>
        public const string Parm_SealUpAttach_FileRemark = "FileRemark";
        /// <summary>
        /// Parm FileReName
        /// </summary>
        public const string Parm_SealUpAttach_FileReName = "FileReName";
        /// <summary>
        /// Parm FileSize
        /// </summary>
        public const string Parm_SealUpAttach_FileSize = "FileSize";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_SealUpAttach_FileType = "FileType";
        /// <summary>
        /// Parm FileTypeName
        /// </summary>
        public const string Parm_SealUpAttach_FileTypeName = "FileTypeName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_SealUpAttach_Id = "Id";
        /// <summary>
        /// Parm IsCompleted
        /// </summary>
        public const string Parm_SealUpAttach_IsCompleted = "IsCompleted";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_SealUpAttach_ResourceId = "ResourceId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_SealUpAttach_RowStatus = "RowStatus";
        /// <summary>
        /// Parm ShootAddr
        /// </summary>
        public const string Parm_SealUpAttach_ShootAddr = "ShootAddr";
        /// <summary>
        /// Parm ShootPersoneFirst
        /// </summary>
        public const string Parm_SealUpAttach_ShootPersoneFirst = "ShootPersoneFirst";
        /// <summary>
        /// Parm ShootPersoneNameFirst
        /// </summary>
        public const string Parm_SealUpAttach_ShootPersoneNameFirst = "ShootPersoneNameFirst";
        /// <summary>
        /// Parm ShootPersoneNameSecond
        /// </summary>
        public const string Parm_SealUpAttach_ShootPersoneNameSecond = "ShootPersoneNameSecond";
        /// <summary>
        /// Parm ShootPersoneSecond
        /// </summary>
        public const string Parm_SealUpAttach_ShootPersoneSecond = "ShootPersoneSecond";
        /// <summary>
        /// Parm ShootTime
        /// </summary>
        public const string Parm_SealUpAttach_ShootTime = "ShootTime";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_SealUpAttach_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_SealUpAttach_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_SealUpAttach_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_SealUpAttach_Version = "Version";
        /// <summary>
        /// Insert Query Of SealUpAttach
        /// </summary>
        public const string Sql_SealUpAttach_Insert = "insert into SealUpAttach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,ShootAddr,ShootPersoneFirst,ShootPersoneNameFirst,ShootPersoneNameSecond,ShootPersoneSecond,ShootTime,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@ShootAddr,@ShootPersoneFirst,@ShootPersoneNameFirst,@ShootPersoneNameSecond,@ShootPersoneSecond,@ShootTime,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of SealUpAttach
        /// </summary>
        public const string Sql_SealUpAttach_Update = "update SealUpAttach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,ShootAddr=@ShootAddr,ShootPersoneFirst=@ShootPersoneFirst,ShootPersoneNameFirst=@ShootPersoneNameFirst,ShootPersoneNameSecond=@ShootPersoneNameSecond,ShootPersoneSecond=@ShootPersoneSecond,ShootTime=@ShootTime,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_SealUpAttach_Delete = "update SealUpAttach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
        #endregion

        #region Properties
        private string _resourceId = string.Empty;
        /// <summary>
        /// 案件编号
        /// </summary>
        public string ResourceId
        {
            get { return _resourceId ?? string.Empty; }
            set { _resourceId = value; }
        }
        private string _fileName = string.Empty;
        /// <summary>
        /// 附件名称
        /// </summary>
        public string FileName
        {
            get { return _fileName ?? string.Empty; }
            set { _fileName = value; }
        }
        private string _fileReName = string.Empty;
        /// <summary>
        /// 重命名后名称
        /// </summary>
        public string FileReName
        {
            get { return _fileReName ?? string.Empty; }
            set { _fileReName = value; }
        }
        private string _fileSize = string.Empty;
        /// <summary>
        /// 附件大小
        /// </summary>
        public string FileSize
        {
            get { return _fileSize ?? string.Empty; }
            set { _fileSize = value; }
        }
        private int _isCompleted;
        /// <summary>
        /// 是否上传完成
        /// </summary>
        public int IsCompleted
        {
            get { return _isCompleted; }
            set { _isCompleted = value; }
        }
        private string _fileAddress = string.Empty;
        /// <summary>
        /// 附件保存路径
        /// </summary>
        public string FileAddress
        {
            get { return _fileAddress ?? string.Empty; }
            set { _fileAddress = value; }
        }
        private string _fileType = string.Empty;
        /// <summary>
        /// 所属类型
        /// </summary>
        public string FileType
        {
            get { return _fileType ?? string.Empty; }
            set { _fileType = value; }
        }
        private string _fileTypeName = string.Empty;
        /// <summary>
        /// 附件类型名称
        /// </summary>
        public string FileTypeName
        {
            get { return _fileTypeName ?? string.Empty; }
            set { _fileTypeName = value; }
        }
        private string _fileRemark = string.Empty;
        /// <summary>
        /// 附件备注
        /// </summary>
        public string FileRemark
        {
            get { return _fileRemark ?? string.Empty; }
            set { _fileRemark = value; }
        }
        private DateTime _shootTime = MinDate;
        /// <summary>
        /// 拍摄时间
        /// </summary>
        public DateTime ShootTime
        {
            get { return _shootTime; }
            set { _shootTime = value; }
        }
        private string _shootAddr = string.Empty;
        /// <summary>
        /// 拍摄地点
        /// </summary>
        public string ShootAddr
        {
            get { return _shootAddr ?? string.Empty; }
            set { _shootAddr = value; }
        }
        private string _shootPersoneFirst = string.Empty;
        /// <summary>
        /// 拍摄人员一
        /// </summary>
        public string ShootPersoneFirst
        {
            get { return _shootPersoneFirst ?? string.Empty; }
            set { _shootPersoneFirst = value; }
        }
        private string _shootPersoneSecond = string.Empty;
        /// <summary>
        /// 拍摄人员二
        /// </summary>
        public string ShootPersoneSecond
        {
            get { return _shootPersoneSecond ?? string.Empty; }
            set { _shootPersoneSecond = value; }
        }
        private string _shootPersoneNameFirst = string.Empty;
        /// <summary>
        /// 拍摄人员一名称
        /// </summary>
        public string ShootPersoneNameFirst
        {
            get { return _shootPersoneNameFirst ?? string.Empty; }
            set { _shootPersoneNameFirst = value; }
        }
        private string _shootPersoneNameSecond = string.Empty;
        /// <summary>
        /// 拍摄人员二名称
        /// </summary>
        public string ShootPersoneNameSecond
        {
            get { return _shootPersoneNameSecond ?? string.Empty; }
            set { _shootPersoneNameSecond = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override SealUpAttachEntity SetModelValueByDataRow(DataRow dr)
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
        public override SealUpAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new SealUpAttachEntity();
            if (fields.Contains(Parm_SealUpAttach_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_SealUpAttach_Id].ToString();
            if (fields.Contains(Parm_SealUpAttach_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_SealUpAttach_ResourceId].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_SealUpAttach_FileName].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileReName) || fields.Contains("*"))
                tmp.FileReName = dr[Parm_SealUpAttach_FileReName].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileSize) || fields.Contains("*"))
                tmp.FileSize = dr[Parm_SealUpAttach_FileSize].ToString();
            if (fields.Contains(Parm_SealUpAttach_IsCompleted) || fields.Contains("*"))
                tmp.IsCompleted = int.Parse(dr[Parm_SealUpAttach_IsCompleted].ToString());
            if (fields.Contains(Parm_SealUpAttach_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_SealUpAttach_FileAddress].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_SealUpAttach_FileType].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileTypeName) || fields.Contains("*"))
                tmp.FileTypeName = dr[Parm_SealUpAttach_FileTypeName].ToString();
            if (fields.Contains(Parm_SealUpAttach_FileRemark) || fields.Contains("*"))
                tmp.FileRemark = dr[Parm_SealUpAttach_FileRemark].ToString();
            if (fields.Contains(Parm_SealUpAttach_ShootTime) || fields.Contains("*"))
                tmp.ShootTime = DateTime.Parse(dr[Parm_SealUpAttach_ShootTime].ToString());
            if (fields.Contains(Parm_SealUpAttach_ShootAddr) || fields.Contains("*"))
                tmp.ShootAddr = dr[Parm_SealUpAttach_ShootAddr].ToString();
            if (fields.Contains(Parm_SealUpAttach_ShootPersoneFirst) || fields.Contains("*"))
                tmp.ShootPersoneFirst = dr[Parm_SealUpAttach_ShootPersoneFirst].ToString();
            if (fields.Contains(Parm_SealUpAttach_ShootPersoneSecond) || fields.Contains("*"))
                tmp.ShootPersoneSecond = dr[Parm_SealUpAttach_ShootPersoneSecond].ToString();
            if (fields.Contains(Parm_SealUpAttach_ShootPersoneNameFirst) || fields.Contains("*"))
                tmp.ShootPersoneNameFirst = dr[Parm_SealUpAttach_ShootPersoneNameFirst].ToString();
            if (fields.Contains(Parm_SealUpAttach_ShootPersoneNameSecond) || fields.Contains("*"))
                tmp.ShootPersoneNameSecond = dr[Parm_SealUpAttach_ShootPersoneNameSecond].ToString();
            if (fields.Contains(Parm_SealUpAttach_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_SealUpAttach_RowStatus].ToString());
            if (fields.Contains(Parm_SealUpAttach_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_SealUpAttach_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_SealUpAttach_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_SealUpAttach_CreatorId].ToString();
            if (fields.Contains(Parm_SealUpAttach_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_SealUpAttach_CreateBy].ToString();
            if (fields.Contains(Parm_SealUpAttach_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_SealUpAttach_CreateOn].ToString());
            if (fields.Contains(Parm_SealUpAttach_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_SealUpAttach_UpdateId].ToString();
            if (fields.Contains(Parm_SealUpAttach_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_SealUpAttach_UpdateBy].ToString();
            if (fields.Contains(Parm_SealUpAttach_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_SealUpAttach_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="sealupattach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(SealUpAttachEntity sealupattach, SqlParameter[] parms)
        {
            parms[0].Value = sealupattach.ResourceId;
            parms[1].Value = sealupattach.FileName;
            parms[2].Value = sealupattach.FileReName;
            parms[3].Value = sealupattach.FileSize;
            parms[4].Value = sealupattach.IsCompleted;
            parms[5].Value = sealupattach.FileAddress;
            parms[6].Value = sealupattach.FileType;
            parms[7].Value = sealupattach.FileTypeName;
            parms[8].Value = sealupattach.FileRemark;
            parms[9].Value = sealupattach.ShootTime;
            parms[10].Value = sealupattach.ShootAddr;
            parms[11].Value = sealupattach.ShootPersoneFirst;
            parms[12].Value = sealupattach.ShootPersoneSecond;
            parms[13].Value = sealupattach.ShootPersoneNameFirst;
            parms[14].Value = sealupattach.ShootPersoneNameSecond;
            parms[15].Value = sealupattach.RowStatus;
            parms[16].Value = sealupattach.CreatorId;
            parms[17].Value = sealupattach.CreateBy;
            parms[18].Value = sealupattach.CreateOn;
            parms[19].Value = sealupattach.UpdateId;
            parms[20].Value = sealupattach.UpdateBy;
            parms[21].Value = sealupattach.UpdateOn;
            parms[22].Value = sealupattach.Id;

            return parms;
        }

        /// <summary>
        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(SealUpAttachEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUpAttach_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_SealUpAttach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_SealUpAttach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUpAttach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_SealUpAttach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_ShootTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SealUpAttach_ShootAddr, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_SealUpAttach_ShootPersoneFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_ShootPersoneSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_ShootPersoneNameFirst, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_ShootPersoneNameSecond, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_SealUpAttach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SealUpAttach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SealUpAttach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_SealUpAttach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_SealUpAttach_Insert, parms);
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
