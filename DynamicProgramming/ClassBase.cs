using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    [DataContract]
    public abstract class ClassBase : ProgrammingElementBase
    {
        #region Fields

        [DataMember]
        internal Dictionary<string, object> _fields = new Dictionary<string, object>();

        [DataMember]
        internal Dictionary<string, object> _properties = new Dictionary<string, object>();

        [DataMember]
        internal Dictionary<string, MethodBase> _methods = new Dictionary<string, MethodBase>();

        #endregion

        #region Properties
        public Dictionary<string, object> Fields
        {
            get { return _fields; }
        }

        public Dictionary<string, MethodBase> Methods
        {
            get { return _methods; }
        }

        public Dictionary<string, object> Properties
        {
            get { return _properties; }
        } 
        #endregion

        #region Methods
        public void New()
        {
            Clone();
        } 
        #endregion
    }
}
