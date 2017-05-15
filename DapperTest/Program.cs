using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using DapperTest.Models;
using Dapper;

namespace DapperTest
{
    class Program
    {
        //Dapper用法:http://www.cnblogs.com/Leo_wl/p/5863066.html
        static void Main(string[] args)
        {
         //   Console.WriteLine("Today's date: {0:D}", DateTime.Now);

            const string _connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=10.72.0.250 )(PORT=1521)) (CONNECT_DATA=(SERVICE_NAME=orcl)));User ID=sajet;Password=foxlink;";
            using (OracleConnection dbConnection = new OracleConnection(_connectionString))
            {
                dbConnection.Open();
/*
               // 通过匿名类型插入单条数据
                dbConnection.Execute("insert into sajet.t_schools(Name,Address) values(:Name,:Address)", new { Name = "西南大学", Address = "重庆市北碚区天生路2号" });
                //批量插入数据
                List<School> schools = new List<School>()
    {
      new School() {Address="ChinaBeiJing",Name="清华大学" },
      new School() {Address="杭州",Name="浙江大学" },
      new School() {Address="US",Name="哈弗大学" }
    };
                //在执行参数化的SQL时，SQL中的参数（如@title可以和数据表中的字段不一致，但要和实体类型的属性Title相对应）
                dbConnection.Execute("insert into t_schools(Address,Name) values(:address,:name)", schools);
                //通过匿名类型批量插入数据
                dbConnection.Execute("insert into t_schools(Address,Name) values(:address,:name)",
                new[] {
      new {Address="杨浦区四平路1239号",Name="同济大学"},
      new {Address="英国",Name="剑桥"},
      new {Address="美国·硅谷",Name="斯坦福大学"}
    });
 
 */

               // 默认情况下Dapper会将查询到的整个数据集放到内存中，可以在Query方法中通过参数buffered来设置是否将查询结果存放到内存中
/*
                //1、查询结果映射到强类型
                var sqlCommand = "select * from t_schools where Name=:name";
                var schools = dbConnection.Query<School>(sqlCommand, new { Name = "西南大学" });
                foreach (var school in schools)
                {
                    Console.WriteLine(school.Address);
                }
*/
/*
                //2、查询结果映射到匿名类型
                var result = dbConnection.Query("select * from t_schools");
                var resultList = result.AsList();
                foreach (var list in resultList)
                {
                    Console.WriteLine("schools's name is:{0}", list.NAME);
                }
      */
/*
                // in
                var result = dbConnection.Query<Student>("select * from t_students where SchoolId in :schoolId", new { schoolId = new int[] { 2, 3 } });
                foreach (var r in result)
                {
                    var ps = r.GetType().GetProperties();
                    foreach (var p in ps)
                    {
                        Console.Write(p.Name + "=" + p.GetValue(r) + " ");
                    }
                    Console.WriteLine();
                }
*/



            }

        }
    }
}
