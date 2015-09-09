using DynamicProgramming.DataDefination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Operation
{
    /// <summary>
    /// 加法运算符。
    /// </summary>
    [DataContract]
    public class Add : BinaryOperation
    {
        public override void Call()
        {
                var left = _operateObjects[RequiredOperators.Left.ToString()] as Number;
                var right = _operateObjects[RequiredOperators.Right.ToString()] as Number;
                var result = _operateObjects[RequiredOperators.SingleResult.ToString()] as SingleResult;

                if (left == null || right == null)
                {
                    throw new ArgumentNullException("left or right");
                }
                if (left._bitSet == null || right._bitSet == null)
                {
                    throw new ArgumentNullException("m_bitSet");
                }
                if (left._bitSet.Count == 0 || right._bitSet.Count == 0)
                {
                    throw new ArgumentException("m_bitSet.Count is 0.");
                }
                Number resultValue = new Number();
                resultValue._bitSet.Clear();
                // 是否向前进一位
                bool pushToUpperBit = false;

                int minCount = 0;
                int maxCount = 0;
                LinkedListNode<byte> minNode = null;
                LinkedListNode<byte> maxNode = null;
                if (left._bitSet.Count < right._bitSet.Count)
                {
                    minCount = left._bitSet.Count;
                    maxCount = right._bitSet.Count;
                    minNode = left._bitSet.Last;
                    maxNode = right._bitSet.Last;
                }
                else
                {
                    minCount = right._bitSet.Count;
                    maxCount = left._bitSet.Count;
                    minNode = right._bitSet.Last;
                    maxNode = left._bitSet.Last;
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
                    resultValue._bitSet.AddFirst((byte)t);
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
                    resultValue._bitSet.AddFirst((byte)t);
                }
                if (pushToUpperBit)
                    resultValue._bitSet.AddFirst(1);
                if (resultValue._bitSet.Count == 0)
                    resultValue._bitSet.AddLast(0);

                result.Value = resultValue;
        }
    }
}
