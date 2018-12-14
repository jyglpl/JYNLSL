using DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Case
{
    [Serializable]
    public class SimpleProgram_AttachEntity : ModelImp.BaseModel<SimpleProgram_AttachEntity>
    {
        public SimpleProgram_AttachEntity()
        {
            TB_Name = TB_SimpleProgram_Attach;
            Parm_Id = Parm_SimpleProgram_Attach_Id;
            //Parm_Version = Parm_SimpleProgram_Attach_Version;
            Parm_All_Base = Parm_All;
            Sql_Insert = Sql_SimpleProgram_Attach_Insert;
            //Sql_Update = Sql_SimpleProgram_Attach_Update;
            //Sql_Delete = Sql_SimpleProgram_Attach_Delete;
        }
        #region Const of table SimpleProgram_Attach
        /// <summary>
        /// Table SimpleProgram_Attach
        /// </summary>
        public const string TB_SimpleProgram_Attach = "SimpleProgram_Attach";
        public const string Parm_All = "*";
        /// <summary>
        /// Parm CreateDateTime
        /// </summary>
        public const string Parm_SimpleProgram_Attach_CreateDateTime = "CreateDateTime";
        /// <summary>
        /// Parm FileAddress
        /// </summary>
        public const string Parm_SimpleProgram_Attach_FileAddress = "FileAddress";
        /// <summary>
        /// Parm FileContent
        /// </summary>
        public const string Parm_SimpleProgram_Attach_FileContent = "FileContent";
        /// <summary>
        /// Parm FileDesc
        /// </summary>
        public const string Parm_SimpleProgram_Attach_FileDesc = "FileDesc";
        /// <summary>
        /// Parm FileName
        /// </summary>
        public const string Parm_SimpleProgram_Attach_FileName = "FileName";
        /// <summary>
        /// Parm Id
        /// </summary>
        public const string Parm_SimpleProgram_Attach_Id = "Id";
        /// <summary>
        /// Parm InternalNo
        /// </summary>
        public const string Parm_SimpleProgram_Attach_InternalNo = "InternalNo";
        /// <summary>
        /// Parm IsSync
        /// </summary>
        public const string Parm_SimpleProgram_Attach_IsSync = "IsSync";
        /// <summary>
        /// Parm SimpleProgramID
        /// </summary>
        public const string Parm_SimpleProgram_Attach_SimpleProgramID = "SimpleProgramID";
        /// <summary>
        /// Parm Sync
        /// </summary>
        public const string Parm_SimpleProgram_Attach_Sync = "Sync";
        /// <summary>
        /// Parm SyncDateTime
        /// </summary>
        public const string Parm_SimpleProgram_Attach_SyncDateTime = "SyncDateTime";
        /// <summary>
        /// Parm SyncErrorDesc
        /// </summary>
        public const string Parm_SimpleProgram_Attach_SyncErrorDesc = "SyncErrorDesc";
        /// <summary>
        /// Insert Query Of SimpleProgram_Attach
        /// </summary>
        public const string Sql_SimpleProgram_Attach_Insert = "insert into SimpleProgram_Attach(CreateDateTime,FileAddress,FileContent,FileDesc,FileName,InternalNo,IsSync,SimpleProgramID,Sync,SyncDateTime,SyncErrorDesc,Id) values(@CreateDateTime,@FileAddress,@FileContent,@FileDesc,@FileName,@InternalNo,@IsSync,@SimpleProgramID,@Sync,@SyncDateTime,@SyncErrorDesc,@Id);select @@identity;";
        /// <summary>
        /// Update Query Of SimpleProgram_Attach
        /// </summary>
        //public const string Sql_SimpleProgram_Attach_Update = "update SimpleProgram_Attach set CreateDateTime=@CreateDateTime,FileAddress=@FileAddress,FileContent=@FileContent,FileDesc=@FileDesc,FileName=@FileName,InternalNo=@InternalNo,IsSync=@IsSync,SimpleProgramID=@SimpleProgramID,Sync=@Sync,SyncDateTime=@SyncDateTime,SyncErrorDesc=@SyncErrorDesc where Id=@Id;select @@rowcount;";
        /// <summary>
        /// Set RowStatus=0
        /// </summary>
        //public const string Sql_SimpleProgram_Attach_Delete = "update SimpleProgram_Attach set RowStatus=0 where Id=@Id;select @@rowcount;";
        #endregion

        #region Properties
        private string _simpleProgramID = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SimpleProgramID
        {
            get { return _simpleProgramID ?? string.Empty; }
            set { _simpleProgramID = value; }
        }
        private string _internalNo = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string InternalNo
        {
            get { return _internalNo ?? string.Empty; }
            set { _internalNo = value; }
        }
        private string _fileName = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            get { return _fileName ?? string.Empty; }
            set { _fileName = value; }
        }
        private string _fileDesc = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileDesc
        {
            get { return _fileDesc ?? string.Empty; }
            set { _fileDesc = value; }
        }
        private byte[] _fileContent;
        /// <summary>
        /// 
        /// </summary>
        public byte[] FileContent
        {
            get { return _fileContent; }
            set { _fileContent = value; }
        }
        private DateTime _createDateTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }
        private DateTime _sync = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime Sync
        {
            get { return _sync; }
            set { _sync = value; }
        }
        private DateTime _syncDateTime = MinDate;
        /// <summary>
        /// 
        /// </summary>
        public DateTime SyncDateTime
        {
            get { return _syncDateTime; }
            set { _syncDateTime = value; }
        }
        private string _syncErrorDesc = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string SyncErrorDesc
        {
            get { return _syncErrorDesc ?? string.Empty; }
            set { _syncErrorDesc = value; }
        }
        private string _fileAddress = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string FileAddress
        {
            get { return _fileAddress ?? string.Empty; }
            set { _fileAddress = value; }
        }
        private string _isSync = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string IsSync
        {
            get { return _isSync ?? string.Empty; }
            set { _isSync = value; }
        }
        private string _id = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string Id
        {
            get { return _id ?? string.Empty; }
            set { _id = value; }
        }
        #endregion

        /// <summary>
        /// 根据DataRow给实体赋值
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <returns>实体</returns>
        public override SimpleProgram_AttachEntity SetModelValueByDataRow(DataRow dr)
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
        public override SimpleProgram_AttachEntity SetModelValueByDataRow(DataRow dr, IList<string> fields)
        {
            var tmp = new SimpleProgram_AttachEntity();
            if (fields.Contains(Parm_SimpleProgram_Attach_Id) || fields.Contains("*"))
                tmp.Id = dr[Parm_SimpleProgram_Attach_Id].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_SimpleProgramID) || fields.Contains("*"))
                tmp.SimpleProgramID = dr[Parm_SimpleProgram_Attach_SimpleProgramID].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_InternalNo) || fields.Contains("*"))
                tmp.InternalNo = dr[Parm_SimpleProgram_Attach_InternalNo].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_FileName) || fields.Contains("*"))
                tmp.FileName = dr[Parm_SimpleProgram_Attach_FileName].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_FileDesc) || fields.Contains("*"))
                tmp.FileDesc = dr[Parm_SimpleProgram_Attach_FileDesc].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_FileContent) || fields.Contains("*"))
                tmp.FileContent = (byte[])(dr[Parm_SimpleProgram_Attach_FileContent]);
            if (fields.Contains(Parm_SimpleProgram_Attach_CreateDateTime) || fields.Contains("*"))
                tmp.CreateDateTime = DateTime.Parse(dr[Parm_SimpleProgram_Attach_CreateDateTime].ToString());
            if (fields.Contains(Parm_SimpleProgram_Attach_Sync) || fields.Contains("*"))
                tmp.Sync = DateTime.Parse(dr[Parm_SimpleProgram_Attach_Sync].ToString());
            if (fields.Contains(Parm_SimpleProgram_Attach_SyncDateTime) || fields.Contains("*"))
                tmp.SyncDateTime = DateTime.Parse(dr[Parm_SimpleProgram_Attach_SyncDateTime].ToString());
            if (fields.Contains(Parm_SimpleProgram_Attach_SyncErrorDesc) || fields.Contains("*"))
                tmp.SyncErrorDesc = dr[Parm_SimpleProgram_Attach_SyncErrorDesc].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_FileAddress) || fields.Contains("*"))
                tmp.FileAddress = dr[Parm_SimpleProgram_Attach_FileAddress].ToString();
            if (fields.Contains(Parm_SimpleProgram_Attach_IsSync) || fields.Contains("*"))
                tmp.IsSync = dr[Parm_SimpleProgram_Attach_IsSync].ToString();

            return tmp;
        }

        /// <summary>
        /// 通过实体对参数赋值用于新增
        /// </summary>
        /// <param name="simpleprogram_attach">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForAdd(SimpleProgram_AttachEntity simpleprogram_attach, SqlParameter[] parms)
        {
            parms[0].Value = simpleprogram_attach.SimpleProgramID;
            parms[1].Value = simpleprogram_attach.InternalNo;
            parms[2].Value = simpleprogram_attach.FileName;
            parms[3].Value = simpleprogram_attach.FileDesc;
            parms[4].Value = simpleprogram_attach.FileContent;
            parms[5].Value = simpleprogram_attach.CreateDateTime;
            parms[6].Value = simpleprogram_attach.Sync;
            parms[7].Value = simpleprogram_attach.SyncDateTime;
            parms[8].Value = simpleprogram_attach.SyncErrorDesc;
            parms[9].Value = simpleprogram_attach.FileAddress;
            parms[10].Value = simpleprogram_attach.IsSync;
            parms[11].Value = simpleprogram_attach.Id;
            return parms;
        }

        /// <summary>
        /// 通过实体对参数(Id,Version)赋值用于修改
        /// </summary>
        /// <param name="model">实体</param>
        /// <param name="parms">参数</param>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] SetParmsValueByModelForUpdate(SimpleProgram_AttachEntity model, SqlParameter[] parms)
        {
            parms = SetParmsValueByModelForAdd(model, parms);
            parms[parms.Length - 2] = new SqlParameter(Parm_SimpleProgram_Attach_Id, model.Id);
            //parms[parms.Length - 1] = new SqlParameter(Parm_SimpleProgram_Attach_Version, model.Version);
            return parms;
        }

        /// <summary>
        /// 获取一个给SQL语句传参用的参数集合
        /// </summary>
        /// <returns>SqlParameter[] 集合</returns>
        public override SqlParameter[] GetParms()
        {
            try
            {
                var parms = SqlHelperParameterCache.GetCachedParameterSet(SqlHelper.SqlConnStringWrite, Sql_SimpleProgram_Attach_Insert);
                if (parms == null)
                {
                    parms = new[]{
	                 								new SqlParameter(Parm_SimpleProgram_Attach_SimpleProgramID, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SimpleProgram_Attach_InternalNo, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SimpleProgram_Attach_FileName, SqlDbType.NVarChar, 50),
					new SqlParameter(Parm_SimpleProgram_Attach_FileDesc, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_SimpleProgram_Attach_FileContent, SqlDbType.Image, 2147483647),
					new SqlParameter(Parm_SimpleProgram_Attach_CreateDateTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SimpleProgram_Attach_Sync, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SimpleProgram_Attach_SyncDateTime, SqlDbType.DateTime, 23),
					new SqlParameter(Parm_SimpleProgram_Attach_SyncErrorDesc, SqlDbType.NVarChar, 1000),
					new SqlParameter(Parm_SimpleProgram_Attach_FileAddress, SqlDbType.NVarChar, 200),
					new SqlParameter(Parm_SimpleProgram_Attach_IsSync, SqlDbType.NVarChar, 10),
                    new SqlParameter(Parm_SimpleProgram_Attach_Id, SqlDbType.NVarChar, 50)

				};
                    SqlHelperParameterCache.CacheParameterSet(SqlHelper.SqlConnStringWrite, Sql_SimpleProgram_Attach_Insert, parms);
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
