using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    [DataContract]
    public abstract class OperationBase : ProgrammingElementBase, ICallable
    {
        [DataMember]
        internal Dictionary<string, DynamicObject> _operateObjects = new Dictionary<string, DynamicObject>();

        /// <summary>
        /// 当前操作所在函数/语句中可访问的变量集
        /// </summary>
        /// <param name="objs"></param>
        public virtual void SetOperateObjects(Dictionary<string, DynamicObject> objs)
        {
            _operateObjects = objs;
        }

        public virtual void AddOperateObject(string key, DynamicObject obj)
        {
            _operateObjects.Add(key, obj);
        }

        public virtual void ClearOperateObjects()
        {
            _operateObjects.Clear();
        }

        /// <summary>
        /// 执行操作
        /// </summary>
        public abstract void Call();

        public override object Clone()
        {
            return null;
        }
    }
}
