#define UsingDictionary
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeuralLib.Ext;

namespace NeuralLib
{
    /// <summary>
    /// Neural base class.
    /// </summary>
    public class Neural
    {
        protected Guid Guid;
        public dynamic Value { get; set; }

#if UsingDictionary
        public List<int> Position { get; set; }
        public Dictionary<string, List<Neural>> ConnectedTo { get; set; }
        public Dictionary<string, List<Neural>> ConnectedFrom { get; set; }
#else
        public Relationship<Guid, string, SequenceNeural> ConnectedTo { get; set; }
        
        public Relationship<Guid, string, SequenceNeural> ConnectedFrom { get; set; }
#endif

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="value">神经元的值</param>
        /// <param name="pos">神经元所在位置</param>
        public Neural(dynamic value = null, int pos = 0)
        {
            this.Value = value;
            this.Position = new List<int>() { pos };
            this.ConnectedTo = new Dictionary<string, List<Neural>>();
            this.ConnectedFrom = new Dictionary<string, List<Neural>>();
            this.Guid = System.Guid.NewGuid();
        }

        /// <summary>
        /// 连接两个神经元
        /// </summary>
        /// <param name="other">另一个要连接的神经元</param>
        /// <param name="connToType">第一个神经元连向第二个神经元连接类型</param>
        /// <param name="connFromType">第二个神经元连向第一个神经元的连接类型</param>
        public void Connect(Neural other, string connToType, string connFromType = null)
        {
            var connToTypeStr = connToType;
            var connFromTypeStr = connFromType;

            this.ConnectedTo.SetDefault(connToTypeStr).Add(other);

            if (connFromType == null)
                return;
            other.ConnectedFrom.SetDefault(connFromTypeStr).Add(this);
        }

        public void Disconnect(Neural other, string connToType, string connFromType = null)
        {
            var connToTypeStr = connToType;
            var connFromTypeStr = connFromType;

            this.ConnectedTo.Get(connToTypeStr).Remove(other);

            if (connFromType == null)
                return;
            other.ConnectedFrom.Get(connFromTypeStr).Remove(this);
        }

        public List<Neural> GetConnectedNeurals(string connType)
        {
            return this.ConnectedTo.Get(connType);
        }

        public List<string> GetConnections(Neural targetNeu)
        {
            var result = new List<string>();
            foreach (var klstp in this.ConnectedTo)
            {
                if (klstp.Value.Contains(targetNeu))
                    result.Add(klstp.Key);
            }
            foreach (var klstp in this.ConnectedFrom)
            {
                if (klstp.Value.Contains(targetNeu))
                    result.Add(klstp.Key);
            }
            return result;
        }
    };
}
