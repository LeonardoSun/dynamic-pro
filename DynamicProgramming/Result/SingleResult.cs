using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicProgramming
{
    public class SingleResult : DynamicObject
    {
        public object Value { get; set; }

        public override object Clone()
        {
            var result = new SingleResult();
            result.Value = this.Value;
            return result;
        }
    }
}
