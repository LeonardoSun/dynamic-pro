using System;
using LightningDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Text;
using LightningDB.Ext;

namespace UnitTestProject1
{
    [TestClass]
    public class LMDBTest
    {
        [TestMethod]
        public void TestCreateOpenDataBaseAndPut()
        {
            using (var env = new LightningEnvironment("pathtofolder"))
            {
                env.MaxDatabases = 2;
                env.Open();

                using (var tx = env.BeginTransaction())
                using (var db = tx.OpenDatabase("custom", new DatabaseConfiguration { Flags = DatabaseOpenFlags.Create }))
                {
                    tx.Put(db, "hello", "world");
                    tx.Commit();
                }
            }
        }
        [TestMethod]
        public void TestGet()
        {
            using (var env = new LightningEnvironment("pathtofolder"))
            {
                env.MaxDatabases = 2;
                env.Open();

                using (var tx = env.BeginTransaction(TransactionBeginFlags.ReadOnly))
                {
                    var db = tx.OpenDatabase("custom");
                    var result = tx.Get(db, "hello");
                    Debug.Assert(result == "world");
                }
            }
        }
    }
}
