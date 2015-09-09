using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.DataDefination
{
    [DataContract]
    public class Number : DynamicProgramming.DynamicObject
    {
        [DataMember]
        internal LinkedList<byte> _bitSet = new LinkedList<byte>();

        public Number()
        {
            _bitSet.AddLast(0);
        }

        public Number(string value)
        {
            foreach(char c in value)
            {
                if (c < '0' || c > '9')
                    throw new ArgumentException("it is not a number: " + value);
                _bitSet.AddLast((byte)(c - '0'));
            }
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (!(obj is Number))
                return false;
            var right = (Number)obj;
            if (this._bitSet == null || right._bitSet == null)
            {
                throw new ArgumentNullException("m_bitSet");
            }
            if (this._bitSet.Count == 0 || right._bitSet.Count == 0)
            {
                throw new ArgumentException("m_bitSet.Count is 0.");
            }
            if (this._bitSet.Count != right._bitSet.Count)
                return false;
            var leftN = this._bitSet.First;
            var rightN = right._bitSet.First;
            for (int i = 0; i < this._bitSet.Count; i++)
            {
                if (leftN.Value != rightN.Value)
                    return false;
                leftN = leftN.Next;
                rightN = rightN.Next;
            }
            return true;
        }


        public Number add(Number other)
        {
            if (this._bitSet == null || other._bitSet == null)
            {
                throw new ArgumentNullException("m_bitSet");
            }
            if (this._bitSet.Count == 0 || other._bitSet.Count == 0)
            {
                throw new ArgumentException("m_bitSet.Count is 0.");
            }
            Number result = new Number();
            result._bitSet.Clear();
            // 是否向前进一位
            bool pushToUpperBit = false;

            int minCount = 0;
            int maxCount = 0;
            LinkedListNode<byte> minNode = null;
            LinkedListNode<byte> maxNode = null;
            if (_bitSet.Count < other._bitSet.Count)
            {
                minCount = _bitSet.Count;
                maxCount = other._bitSet.Count;
                minNode = _bitSet.Last;
                maxNode = other._bitSet.Last;
            }
            else
            {
                minCount = other._bitSet.Count;
                maxCount = _bitSet.Count;
                minNode = other._bitSet.Last;
                maxNode = _bitSet.Last;
            }
            for (int i = 0; i < minCount; i++)
            {
                var t = minNode.Value + maxNode.Value;
                if (pushToUpperBit)
                {
                    t++;
                    pushToUpperBit = false;
                }
                if (t > 9)
                {
                    pushToUpperBit = true;
                    t = t % 10;
                }
                result._bitSet.AddFirst((byte)t);
                minNode = minNode.Previous;
                maxNode = maxNode.Previous;
            }

            for (int i = 0; i < maxCount - minCount; i++)
            {
                int t = maxNode.Value;
                if (pushToUpperBit)
                {
                    t++;
                    pushToUpperBit = false;
                }
                if (t > 9)
                {
                    pushToUpperBit = true;
                    t = t % 10;
                }
                result._bitSet.AddFirst((byte)t);
            }
            if (pushToUpperBit)
                result._bitSet.AddFirst(1);
            if (result._bitSet.Count == 0)
                result._bitSet.AddLast(0);
            return result;
        }

        public override object Clone()
        {
            var result = new Number();
            result._bitSet.Clear();
            foreach(var chara in this._bitSet)
            {
                result._bitSet.AddLast(chara);
            }
            return result;
        }
    }
}
