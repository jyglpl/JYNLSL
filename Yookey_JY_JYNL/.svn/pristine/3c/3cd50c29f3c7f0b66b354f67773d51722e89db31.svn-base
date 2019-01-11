using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Com
{    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ComNoticeAttachEntity : ModelImp.BaseModel<ComNoticeAttachEntity>
    {
        public ComNoticeAttachEntity()
        {
            TB_Name = TB_ComNoticeAttach;
            Parm_Id = Parm_ComNoticeAttach_Id;
            Parm_Version = Parm_ComNoticeAttach_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_ComNoticeAttach_Insert;
            Sql_Update = Sql_ComNoticeAttach_Update;
            Sql_Delete = Sql_ComNoticeAttach_Delete;
        }
        #region Const of table ComNoticeAttach
        /// <summary>
        /// Table ComNoticeAttach
        /// </summary>
        public const string TB_ComNoticeAttach = "ComNoticeAttach";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateBy
        /// </summary>
        public const string Parm_ComNoticeAttach_CreateBy = "CreateBy";
        /// <summary>
        /// Parm CreateOn
        /// </summary>
        public const string Parm_ComNoticeAttach_CreateOn = "CreateOn";
        /// <summary>
        /// Parm CreatorId
        /// </summary>
        public const string Parm_ComNoticeAttach_CreatorId = "CreatorId";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_ComNoticeAttach_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_ComNoticeAttach_FileName = "FileName";
        /// <summary>
        /// Parm FileRemark
        /// </summary>
        public const string Parm_ComNoticeAttach_FileRemark = "FileRemark";
        /// <summary>
        /// Parm FileReName
        /// </summary>
        public const string Parm_ComNoticeAttach_FileReName = "FileReName";
        /// <summary>
        /// Parm FileSize
        /// </summary>
        public const string Parm_ComNoticeAttach_FileSize = "FileSize";
        /// <summary>
        /// Parm FileType
        /// </summary>
        public const string Parm_ComNoticeAttach_FileType = "FileType";
        /// <summary>
        /// Parm FileTypeName
        /// </summary>
        public const string Parm_ComNoticeAttach_FileTypeName = "FileTypeName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_ComNoticeAttach_Id = "Id";
        /// <summary>
        /// Parm IsCompleted
        /// </summary>
        public const string Parm_ComNoticeAttach_IsCompleted = "IsCompleted";
        /// <summary>
        /// Parm ResourceId
        /// </summary>
        public const string Parm_ComNoticeAttach_ResourceId = "ResourceId";
        /// <summary>
        /// Parm RowStatus
        /// </summary>
        public const string Parm_ComNoticeAttach_RowStatus = "RowStatus";
        /// <summary>
        /// Parm UpdateBy
        /// </summary>
        public const string Parm_ComNoticeAttach_UpdateBy = "UpdateBy";
        /// <summary>
        /// Parm UpdateId
        /// </summary>
        public const string Parm_ComNoticeAttach_UpdateId = "UpdateId";
        /// <summary>
        /// Parm UpdateOn
        /// </summary>
        public const string Parm_ComNoticeAttach_UpdateOn = "UpdateOn";
        /// <summary>
        /// Parm Version
        /// </summary>
        public const string Parm_ComNoticeAttach_Version = "Version";
        /// <summary>
        /// Insert Query Of ComNoticeAttach
        /// </summary>
        public const string Sql_ComNoticeAttach_Insert = "insert into ComNoticeAttach(CreateBy,CreateOn,CreatorId,FileAddress,FileName,FileRemark,FileReName,FileSize,FileType,FileTypeName,IsCompleted,ResourceId,RowStatus,UpdateBy,UpdateId,UpdateOn,Id) values(@CreateBy,@CreateOn,@CreatorId,@FileAddress,@FileName,@FileRemark,@FileReName,@FileSize,@FileType,@FileTypeName,@IsCompleted,@ResourceId,@RowStatus,@UpdateBy,@UpdateId,@UpdateOn,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of ComNoticeAttach
        /// </summary>
        public const string Sql_ComNoticeAttach_Update = "update ComNoticeAttach set CreateBy=@CreateBy,CreateOn=@CreateOn,CreatorId=@CreatorId,FileAddress=@FileAddress,FileName=@FileName,FileRemark=@FileRemark,FileReName=@FileReName,FileSize=@FileSize,FileType=@FileType,FileTypeName=@FileTypeName,IsCompleted=@IsCompleted,ResourceId=@ResourceId,RowStatus=@RowStatus,UpdateBy=@UpdateBy,UpdateId=@UpdateId,UpdateOn=@UpdateOn where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        public const string Sql_ComNoticeAttach_Delete = "update ComNoticeAttach set RowStatus=0 where Id=@Id And Version=@Version;select @@rowcount;";
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
        /// 
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
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override ComNoticeAttachEntity SetModelValueByDataRow(DataRow dr)
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
        public override ComNoticeAttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new ComNoticeAttachEntity();
            if (fields.Contains(Parm_ComNoticeAttach_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_ComNoticeAttach_Id].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_ResourceId) || fields.Contains("*"))
                tmp.ResourceId = dr[Parm_ComNoticeAttach_ResourceId].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_ComNoticeAttach_FileName].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileReName) || fields.Contains("*"))
                tmp.FileReName = dr[Parm_ComNoticeAttach_FileReName].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileSize) || fields.Contains("*"))
                tmp.FileSize = dr[Parm_ComNoticeAttach_FileSize].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_IsCompleted) || fields.Contains("*"))
                tmp.IsCompleted = int.Parse(dr[Parm_ComNoticeAttach_IsCompleted].ToString());
            if (fields.Contains(Parm_ComNoticeAttach_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_ComNoticeAttach_FileAddress].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileType) || fields.Contains("*"))
                tmp.FileType = dr[Parm_ComNoticeAttach_FileType].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileTypeName) || fields.Contains("*"))
                tmp.FileTypeName = dr[Parm_ComNoticeAttach_FileTypeName].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_FileRemark) || fields.Contains("*"))
                tmp.FileRemark = dr[Parm_ComNoticeAttach_FileRemark].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_RowStatus) || fields.Contains("*"))
                tmp.RowStatus = int.Parse(dr[Parm_ComNoticeAttach_RowStatus].ToString());
            if (fields.Contains(Parm_ComNoticeAttach_Version) || fields.Contains("*"))
            {
                var bts = (byte[])(dr[Parm_ComNoticeAttach_Version]);
                Array.Reverse(bts);
                tmp.Version = BitConverter.ToInt64(bts, 0);
            }
            if (fields.Contains(Parm_ComNoticeAttach_CreatorId) || fields.Contains("*"))
                tmp.CreatorId = dr[Parm_ComNoticeAttach_CreatorId].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_CreateBy) || fields.Contains("*"))
                tmp.CreateBy = dr[Parm_ComNoticeAttach_CreateBy].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_CreateOn) || fields.Contains("*"))
                tmp.CreateOn = DateTime.Parse(dr[Parm_ComNoticeAttach_CreateOn].ToString());
            if (fields.Contains(Parm_ComNoticeAttach_UpdateId) || fields.Contains("*"))
                tmp.UpdateId = dr[Parm_ComNoticeAttach_UpdateId].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_UpdateBy) || fields.Contains("*"))
                tmp.UpdateBy = dr[Parm_ComNoticeAttach_UpdateBy].ToString();
            if (fields.Contains(Parm_ComNoticeAttach_UpdateOn) || fields.Contains("*"))
                tmp.UpdateOn = DateTime.Parse(dr[Parm_ComNoticeAttach_UpdateOn].ToString());

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="comnoticeattach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(ComNoticeAttachEntity comnoticeattach, SqlParameter[] parms)
        {
            parms[0].Value = comnoticeattach.ResourceId;
            parms[1].Value = comnoticeattach.FileName;
            parms[2].Value = comnoticeattach.FileReName;
            parms[3].Value = comnoticeattach.FileSize;
            parms[4].Value = comnoticeattach.IsCompleted;
            parms[5].Value = comnoticeattach.FileAddress;
            parms[6].Value = comnoticeattach.FileType;
            parms[7].Value = comnoticeattach.FileTypeName;
            parms[8].Value = comnoticeattach.FileRemark;
            parms[9].Value = comnoticeattach.RowStatus;
            parms[10].Value = comnoticeattach.CreatorId;
            parms[11].Value = comnoticeattach.CreateBy;
            parms[12].Value = comnoticeattach.CreateOn;
            parms[13].Value = comnoticeattach.UpdateId;
            parms[14].Value = comnoticeattach.UpdateBy;
            parms[15].Value = comnoticeattach.UpdateOn;
            parms[16].Value = comnoticeattach.Id;

            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(ComNoticeAttachEntity model, SqlParameter[] parms)
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
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNoticeAttach_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_ComNoticeAttach_ResourceId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_FileName, SqlDbType.NVarChar, 100),
					new SqlParameter(Parm_ComNoticeAttach_FileReName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_FileSize, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_IsCompleted, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNoticeAttach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_ComNoticeAttach_FileType, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_FileTypeName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_FileRemark, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_RowStatus, SqlDbType.Int, 10),
					new SqlParameter(Parm_ComNoticeAttach_CreatorId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_CreateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_CreateOn, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_ComNoticeAttach_UpdateId, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_UpdateBy, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_ComNoticeAttach_UpdateOn, SqlDbType.DateTime, 23),
                    new SqlParameter(Parm_ComNoticeAttach_Id, SqlDbType.NVarChar, 50),

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_ComNoticeAttach_Insert, parms);
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

