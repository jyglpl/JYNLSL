//-------------------------------------------------------------------------
// <copyright  company="友科软件" file="INF_SIMPLE_NUMBERBll.cs">
//  Copyright (c) 版本 V1
//  所属部门：技术部
//  所属项目：智慧城管
//  作    者：周 鹏
//  创建日期：2015/4/13 10:53:50
//  功能描述：INF_SIMPLE_NUMBER业务逻辑类
//  版本历史:
//      如有新增或修改请再次添加描述(格式：时间+作者+描述)
//</copyright>
//-------------------------------------------------------------------------


using System;
using Yookey.WisdomClassed.SIP.Business.BllImp;
using Yookey.WisdomClassed.SIP.DataAccess.Case;
using Yookey.WisdomClassed.SIP.Model.Case;

namespace Yookey.WisdomClassed.SIP.Business.Case
{
    /// <summary>
    /// INF_SIMPLE_NUMBER业务逻辑
    /// </summary>
    public class InfSimpleNumberBll : BaseBll<InfSimpleNumberEntity>
    {
        public InfSimpleNumberBll()
        {
            BaseDal = new InfSimpleNumberDal();
        }

        /// <summary>
        /// 保存生成的编号
        /// 添加人：周 鹏
        /// 添加时间：2015-04-13
        /// </summary>
        /// <history>
        /// 修改描述：时间+作者+描述
        /// </history>
        /// <param name="num">生成的编号</param>
        /// <param name="createId">创建人ID</param>
        /// <param name="createBy">创建人姓名</param>
        public void Add(string num, string createId, string createBy)
        {
            var entity = new InfSimpleNumberEntity()
                {
                    Id = Guid.NewGuid().ToString(),
                    Num = num,
                    RowStatus = 1,
                    CreatorId = createId,
                    CreateBy = createBy,
                    CreateOn = DateTime.Now
                };
            Add(entity);
        }
    }
}
