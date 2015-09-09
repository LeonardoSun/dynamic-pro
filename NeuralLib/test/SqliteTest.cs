using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralLib.test
{

    public class SqliteTest
    {
        //create table t_tablename(  id int primary key identity(1,1),  name varchar(20) not null  studentId int foreign key (**id)
        /// <summary>
        /// 创建“临时记忆区”表
        /// </summary>
        const string createTmpMemoTab = "create table TempMemory(  Id int identity(1,1) primary key,  KeyName text not null,  ResponseText text); ";

        const string insertResponse = "insert into TempMemory (KeyName, Response) values ({0}, {1})";

        static void Main(string[] args)
        {
            string file = "test.db";
            FileStream fs = new FileStream(file, FileMode.OpenOrCreate);
            fs.Close();
            var str = string.Format("Data Source={0};Pooling=true;FailIfMissing=false", file);
            using (SQLiteConnection conn = new SQLiteConnection(str))
            {
                //System.CodeDom.CodeBinaryOperatorType
                conn.Open();
                var param = Console.ReadLine();
                var cmd = Console.ReadLine();
                //LanguageHelper.AnalysisSentence(cmd, param);
                //var insert = ExcuteSqlCmd(conn, string.Format(insertResponse, new object[] { "'" + param + "'", "'" + param + "'" }));
                //if (insert == false)
                //{
                //    ExcuteSqlCmd(conn, createTmpMemoTab);
                //    ExcuteSqlCmd(conn, string.Format(insertResponse, new object[] { "'" + param + "'", "'" + param + "'" }));
                //}
            }
        }

        internal static bool ExcuteSqlCmd(SQLiteConnection conn, string cmdTxt)
        {
            SQLiteCommand cmd = new SQLiteCommand(cmdTxt, conn);
            //cmd.CommandText = ;
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
