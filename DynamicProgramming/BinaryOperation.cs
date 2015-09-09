using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Operation
{
    public abstract class BinaryOperation : OperationBase
    {
        public enum RequiredOperators
        {
            Left,
            Right,
            SingleResult
        }
    }
}
