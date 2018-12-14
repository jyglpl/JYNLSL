namespace Yookey.WisdomClassed.SIP.Business.Base
{
    public interface IBll<T>
    {
        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则抛出异常</returns>
        T Single(object key);

        /// <summary>
        /// 用主键查找相关的实体
        /// </summary>
        /// <param name="key">主健值</param>
        /// <returns>返回的实体,没有则返回一个默认值</returns>
        T SingleOrDefault(object key);


        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="key">实体</param>
        /// <returns>成功为true,错误为false</returns>
        bool PersistDeletedItem(object key);

        /// <summary>
        /// 新建实体
        /// </summary>
        /// <param name="item">
        /// 实体
        /// </param>
        /// <returns>
        /// true为成功,false为失败
        /// </returns>
        bool PersistNewItem(T item);


        bool PersistUpdatedItem(T item);
    }
}
