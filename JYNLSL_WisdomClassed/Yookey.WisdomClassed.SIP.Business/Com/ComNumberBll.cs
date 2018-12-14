using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yookey.WisdomClassed.SIP.Business.Crm;
using Yookey.WisdomClassed.SIP.Business.License;
using Yookey.WisdomClassed.SIP.DataAccess.Com;
using Yookey.WisdomClassed.SIP.Model.Com;
using Yookey.WisdomClassed.SIP.Model.License;

namespace Yookey.WisdomClassed.SIP.Business.Com
{
    /// <summary>
    /// 内部编号业务处理
    /// </summary>
    public class ComNumberBll
    {
        readonly ComResourceBll _comResourceBll = new ComResourceBll();
        readonly ComAttributeValueBll _attributeValueBll = new ComAttributeValueBll();

        /// <summary>
        /// 通过资源表ID返回相关流水号的值
        /// </summary>
        /// <param name="rsCode">编号</param>
        /// <param name="where">查询条件</param>
        /// <param name="htTable">参数【区分大小写】</param>
        /// <returns></returns>
        public string GetNumber(string rsCode, string where, Hashtable htTable)
        {
            try
            {
                //00300011
                //3	起始编号
                //4	是否启用年
                //5	是否启用月
                //6	是否启用日
                //7	流水号位数
                //8	后缀字符串
                //9	对应表名
                //10对应列表

                var numberStart = "";//流水号开头字符串

                //流水号位数
                string strLength = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 7 })[0].Value;
                string strBick = "";
                //表名
                string tableName = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 9 })[0].Value;
                //列表
                string dataField = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 10 })[0].Value;
                //起始编号
                string qsh = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 3 })[0].Value;
                if (qsh == "")
                    qsh = "0";
                var ht = new Hashtable();
                string strQz = _comResourceBll.GetSearchResult(new ComResourceEntity() { Id = rsCode })[0].RsValue;       //前置
                numberStart = _comResourceBll.GetSearchResult(new ComResourceEntity() { Id = rsCode })[0].RsValue;

                if (strQz == rsCode)
                    strQz = "";
                if (numberStart == rsCode)
                    numberStart = "";
                if (strQz != "")
                {
                    // ReSharper disable StringIndexOfIsCultureSpecific.1
                    if (strQz.IndexOf("【") != -1 && htTable != null)
                    // ReSharper restore StringIndexOfIsCultureSpecific.1
                    {
                        IDictionaryEnumerator pParams = htTable.GetEnumerator();
                        while (pParams.MoveNext())
                        {

                            // ReSharper disable StringIndexOfIsCultureSpecific.1
                            if (strQz.ToLower().IndexOf("【" + pParams.Key.ToString().Trim().ToLower() + ":0】") != -1 || strQz.ToLower().IndexOf("【" + pParams.Key.ToString().Trim().ToLower() + "：0】") != -1)
                            // ReSharper restore StringIndexOfIsCultureSpecific.1
                            {
                                strQz = strQz.Replace("【" + pParams.Key.ToString().Trim() + ":0】", "%").Replace("【" + pParams.Key.ToString().Trim() + "：0】", "%");
                                numberStart = numberStart.Replace("【" + pParams.Key.ToString().Trim() + ":0】", pParams.Value.ToString()).Replace("【" + pParams.Key.ToString().Trim() + "：0】", pParams.Value.ToString());
                            }
                            else
                            {
                                strQz = strQz.Replace("【" + pParams.Key.ToString().Trim() + "】", pParams.Value.ToString());
                                numberStart = numberStart.Replace("【" + pParams.Key.ToString().Trim() + "】", pParams.Value.ToString());
                            }

                        }
                    }
                }
                strBick = strQz;

                var isYear = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 4 })[0].Value;
                var isMonth = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 5 })[0].Value;
                var isDay = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 6 })[0].Value;

                if (isYear == "1")
                {
                    // ReSharper disable SpecifyACultureInStringConversionExplicitly
                    strBick += DateTime.Now.Year.ToString();

                    numberStart += DateTime.Now.Year.ToString();
                }
                if (isMonth == "1")
                {
                    strBick += DateTime.Now.Month.ToString().PadLeft(2, '0');
                    numberStart += DateTime.Now.Month.ToString().PadLeft(2, '0');
                }
                if (isDay == "1")
                {
                    strBick += DateTime.Now.Day.ToString().PadLeft(2, '0');
                    numberStart += DateTime.Now.Day.ToString().PadLeft(2, '0');
                }
                // ReSharper restore SpecifyACultureInStringConversionExplicitly
               
                //后缀
                var strHz = _attributeValueBll.GetSearchResult(new ComAttributeValueEntity() { RsId = rsCode, AttributeId = 8 })[0].Value;
                numberStart += strHz;
                strBick += strHz;
                if (strHz != "")
                {
                    if (strHz.IndexOf("【", System.StringComparison.Ordinal) != -1 && htTable != null)
                    {
                        var pParams = htTable.GetEnumerator();
                        while (pParams.MoveNext())
                        {
                            if (strBick.ToLower().IndexOf("【" + pParams.Key.ToString().Trim().ToLower() + ":0】", System.StringComparison.Ordinal) != -1 || strBick.ToLower().IndexOf("【" + pParams.Key.ToString().Trim().ToLower() + "：0】", System.StringComparison.Ordinal) != -1)
                            {
                                strBick = strBick.Replace("【" + pParams.Key.ToString().Trim() + ":0】", "%").Replace("【" + pParams.Key.ToString().Trim() + "：0】", "%");
                                numberStart = numberStart.Replace("【" + pParams.Key.ToString().Trim() + ":0】", pParams.Value.ToString()).Replace("【" + pParams.Key.ToString().Trim() + "：0】", pParams.Value.ToString());
                            }
                            else
                            {
                                strBick = strBick.Replace("【" + pParams.Key.ToString().Trim() + "】", pParams.Value.ToString());
                                numberStart = numberStart.Replace("【" + pParams.Key.ToString().Trim() + "】", pParams.Value.ToString());
                            }
                        }
                    }
                }
                if (strBick == "")
                    throw new Exception("流水号配置不正确");
                if (strLength == "")
                    throw new Exception("流水号的长度不能为空");
                if (tableName == "")
                    throw new Exception("流水号配置的表名不能为空");
                if (dataField == "")
                    throw new Exception("流水号配置的字段名不能为空");

                var tables = tableName.Split(new char[] { ',', '，' });
                if (tables.Length > 1)
                    return numberStart + GetMaxCode(strBick, int.Parse(strLength), dataField, tables, where, int.Parse(qsh.Trim()));
                else
                    return numberStart + GetMaxCode(strBick, int.Parse(strLength), dataField, tables[0], where, int.Parse(qsh.Trim()));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }


        /// <summary>
        /// 获取流水号的最大值
        /// </summary>
        /// <param name="strBick">字符串</param>
        /// <param name="numleng">流水号的长度</param>
        /// <param name="dataField">表的字段名</param>
        /// <param name="tableName">表名集合</param>
        /// <param name="where">查询条件无需where</param>
        /// <param name="qsh">起始号</param>
        /// <returns>最大流水号</returns>
        private string GetMaxCode(string strBick, int numleng, string dataField, string[] tableName, string where,
                                  int qsh)
        {
            return new ComNumberDal().GetMaxCode(strBick, numleng, dataField, tableName, where, qsh);
        }

        /// <summary>
        /// 获取流水号的最大值
        /// </summary>
        /// <param name="strBick">字符串</param>
        /// <param name="numleng">流水号的长度</param>
        /// <param name="dataField">表的字段名</param>
        /// <param name="tableName">表名</param>
        /// <param name="where">查询条件无需where</param>
        /// <param name="qsh">起始号</param>
        /// <returns>最大流水号</returns>
        private string GetMaxCode(string strBick, int numleng, string dataField, string tableName, string where, int qsh)
        {
            return new ComNumberDal().GetMaxCode(strBick, numleng, dataField, tableName, where, qsh);
        }

        public string GetLicenseSetNo(LicenseMainEntity entity)
        {
            string licenseOutDoor_itemCode = "JS050800ZJ-XK-0090";//户外广告
            string licensePositionOutDoor_itemCode = "JS050800ZJ-XK-0190";//大型户外广告
            string licenseJeeves_itemCode = "JS050800ZJ-XK-0020";//占道
            var mainBll = new LicenseMainBll();
            if (entity == null || string.IsNullOrEmpty(entity.Id) || string.IsNullOrEmpty(entity.ItemCode))
                return string.Empty;
            var setNo = "GS:";
            var company = new CrmCompanyBll().Get(entity.Area);
            var companyName = company == null ? string.Empty : company.FullName.Substring(0, company.FullName.Length - 2);//去掉大队           
            if (entity.ItemCode.Contains(licenseJeeves_itemCode))//占道
            {                
                setNo += "Z-";
                setNo +=(DateTime.Now.Year%100).ToString();//年份                
                setNo += mainBll.GetLicenseCount(setNo, entity.ItemCode) + "-";//流水号
                setNo += new ComInitial().GetSpellCode(companyName);//片区的首字母
            }
            else if(entity.ItemCode.Contains(licenseOutDoor_itemCode))//户外广告
            {
                var LicenseOutDoorEntity= new LicenseOutDoorBll().GetEntityByLicenseId(entity.Id);
                setNo += "G";
                setNo +=LicenseOutDoorEntity.SetUpCycle == "00590001"?"01-":"02-";//长期短期广告
                setNo += (DateTime.Now.Year % 100).ToString();//年份
                var LicenseJeevesEntity = new LicenseJeevesBll().GetEntityByLicenseId(entity.Id);
                setNo += mainBll.GetLicenseCount(setNo,entity.ItemCode) + "-";//流水号
                setNo += new ComInitial().GetSpellCode(companyName);//片区的首字母
            }
            else if (entity.ItemCode.Contains(licensePositionOutDoor_itemCode))//大型户外广告
            {
                var LicenseOutDoorEntity = new LicenseOutDoorBll().GetEntityByLicenseId(entity.Id);
                setNo += "D";
                setNo += LicenseOutDoorEntity.SetUpCycle == "00590001" ? "01-" : "02-";//长期短期广告
                setNo += (DateTime.Now.Year % 100).ToString();//年份
                var LicenseJeevesEntity = new LicenseJeevesBll().GetEntityByLicenseId(entity.Id);
                setNo += mainBll.GetLicenseCount(setNo.Replace("01", "__").Replace("02", "__"),entity.ItemCode);//流水号
            }
            return setNo;
        }        
    }
}
