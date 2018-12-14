using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yookey.WisdomClassed.SIP.Model.Case
{
  
        /// <summary>
        /// 违章停车实体类


        /// </summary>
        public class SubmittedXML
        {
            /// <summary>
            /// 案件编号
            /// </summary>
            public string autoID = "";

            /// <summary>
            /// 贴单号 
            /// </summary>
            public string noticeNO = "";

            /// <summary>
            /// 车牌号 
            /// </summary>
            public string carNo = "";

            /// <summary>
            /// 路段ID
            /// </summary>
            public string streetID = "";

            /// <summary>
            /// 地址
            /// </summary>
            public string address = "";

            /// <summary>
            /// 年龄
            /// </summary>
            public string Age = "";

            /// <summary>
            /// 当前用户
            /// </summary>
            public string createBy = "";

            /// <summary>
            /// 创建时间
            /// </summary>
            public string createDate = "";

            /// <summary>
            /// 
            /// </summary>
            public string IsDeleted = "";

            /// <summary>
            /// 车辆类型
            /// </summary>
            public string carType = "";

            /// <summary>
            /// 执法人员，1and2
            /// </summary>
            public string PartnerID = "";

            /// <summary>
            /// 检查日期


            /// </summary>
            public string CheckDate = "";

            /// <summary>
            /// 纬度
            /// </summary>
            public string Latitude = "";

            /// <summary>
            /// 经度
            /// </summary>
            public string Longitude = "";

            /// <summary>
            /// PDA编号
            /// </summary>
            public string pDANo = "";

            /// <summary>
            ///  是否打印通知书 
            /// </summary>
            public int PrintTZS = 0;

            /// <summary>
            /// 是否打印决定书


            /// </summary>
            public int PrintJDS = 0;

            /// <summary>
            /// 决定书编号


            /// </summary>
            public string CFJDID = "";

            /// <summary>
            /// 案件编号
            /// </summary>
            public string CheckSignNo = "";

            /// <summary>
            /// 部门名称
            /// </summary>
            public string DeptName = "";

            /// <summary>
            /// 部门ID
            /// </summary>
            public string DeptID = "";

            /// <summary>
            /// 执法队员1
            /// </summary>
            public string person1 = "";

            /// <summary>
            /// 执法队员2
            /// </summary>
            public string person2 = "";
            /// <summary>
            /// 数据大小
            /// </summary>
            public string DataBytes = "";

            /// <summary>
            /// 是否是分配任务

            /// </summary>
            public int isTask = 0;

            /// <summary>
            /// 备注 说明照片的张数

            /// </summary>
            public string remark = "";

            public List<PhotoInfo> Photos;

            public int upCount = 0;
        }
    }

