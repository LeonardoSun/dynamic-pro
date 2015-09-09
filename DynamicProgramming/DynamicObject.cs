using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace DynamicProgramming
{
    [DataContract]
    public abstract class DynamicObject : ICloneable
    {

        /// <summary>
        /// 父类的类型
        /// </summary>
        public string ParentType
        {
            get;
            set;
        }

        /// <summary>
        /// 当前对象获类的类型
        /// </summary>
        public string Type
        {
            get;
            set;
        }
        public abstract object Clone();
    }
}
