using System;
using System.Runtime.Serialization;

namespace Yookey.WisdomClassed.SIP.Model.Base
{
    [Serializable]
    [DataContract]
    public abstract class EntityBase : IEntity
    {
        [DataMember]
        private object _key;

        protected EntityBase()
            : this(null)
        {
        }

        protected EntityBase(object key)
        {
            _key = key;
        }

        public object Key
        {
            get { return _key; }
            set { _key = value; }
        }

    }
}
