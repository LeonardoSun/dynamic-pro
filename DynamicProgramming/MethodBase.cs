using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    [DataContract]
    public abstract class MethodBase : ProgrammingElementBase, ICallable
    {
        [DataMember]
        internal Dictionary<string, object> _returns = new Dictionary<string, object>();

        [DataMember]
        internal Dictionary<string, object> _parameters = new Dictionary<string, object>();

        [DataMember]
        internal Sequence<ICallable> _callables = new Sequence<ICallable>();

        internal volatile bool m_isPausing = false;
        internal volatile int m_lastIndex = -1;
        public void Pause()
        {
            lock (this)
            {
                m_isPausing = true;
            }
        }

        public bool Continue()
        {
            lock (this)
            {
                if (m_isPausing)
                    return false;
                Call(m_lastIndex);
                return true;
            }
        }

        public virtual void Call(int startPoint)
        {
                for (int i = startPoint; i < _callables.Count; i++)
                {
                    lock (this)
                    {
                        if (m_isPausing)
                        {
                            m_lastIndex = i;
                            m_isPausing = false;
                            break;
                        }
                    }
                    _callables[i].Call();
                }
            
        }

        public void Call()
        {
            this.Call(0);
        }
    }
}
