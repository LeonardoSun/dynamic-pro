using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DynamicProgramming.DataDefination;
using DynamicProgramming.Operation;
using DynamicProgramming;

namespace UnitTestProject1
{
    [TestClass]
    public class NumberTest
    {
        [TestMethod]
        public void TestAddMethod()
        {
            if (!new Number().add(new Number("23")).Equals(new Number("23")))
                Assert.Fail();

            if (!new Number().add(new Number()).Equals(new Number("0")))
                Assert.Fail();

            if (!new Number("57").add(new Number("23")).Equals(new Number("80")))
                Assert.Fail();

            if (!new Number("220993100").add(new Number("2432563")).Equals(new Number("223425663")))
                Assert.Fail();

            if (new Number().Equals(0))
                Assert.Fail();

            if (new Number().Equals(null))
                Assert.Fail();
        }

        [TestMethod]
        public void TestAddOperation()
        {
            var add = new Add();
            add.AddOperateObject(BinaryOperation.RequiredOperators.Left.ToString(), new Number());
            add.AddOperateObject(BinaryOperation.RequiredOperators.Right.ToString(), new Number("23"));
            var result = new SingleResult();
            add.AddOperateObject(BinaryOperation.RequiredOperators.SingleResult.ToString(), result);
            add.Call();
            if (!result.Value.Equals(new Number("23")))
                Assert.Fail();

            add.ClearOperateObjects();
            add.AddOperateObject(BinaryOperation.RequiredOperators.Left.ToString(), new Number());
            add.AddOperateObject(BinaryOperation.RequiredOperators.Right.ToString(), new Number());
            result = new SingleResult();
            add.AddOperateObject(BinaryOperation.RequiredOperators.SingleResult.ToString(), result);
            add.Call();
            if (!result.Value.Equals(new Number("0")))
                Assert.Fail();

            add.ClearOperateObjects();
            add.AddOperateObject(BinaryOperation.RequiredOperators.Left.ToString(), new Number("57"));
            add.AddOperateObject(BinaryOperation.RequiredOperators.Right.ToString(), new Number("23"));
            result = new SingleResult();
            add.AddOperateObject(BinaryOperation.RequiredOperators.SingleResult.ToString(), result);
            add.Call();
            if (!result.Value.Equals(new Number("80")))
                Assert.Fail();

            add.ClearOperateObjects();
            add.AddOperateObject(BinaryOperation.RequiredOperators.Left.ToString(), new Number("220993100"));
            add.AddOperateObject(BinaryOperation.RequiredOperators.Right.ToString(), new Number("2432563"));
            result = new SingleResult();
            add.AddOperateObject(BinaryOperation.RequiredOperators.SingleResult.ToString(), result);
            add.Call();
            if (!result.Value.Equals(new Number("223425663")))
                Assert.Fail();

        }
    }
}
