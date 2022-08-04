using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WebApplication3.Models;
using System.Runtime.Caching;

namespace WebApplication3.DataLayer
{
    public class SQLDataHelper
    {
        string cs = "";
        public SQLDataHelper()
        {
            cs = WebConfigurationManager.ConnectionStrings["DBSC"].ConnectionString;
        }
        public List<Student> GetStudentData()
        {
            ObjectCache cache = MemoryCache.Default;
            if (cache["students"]==null)
            {
                var cacheItemPolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddDays(1)
                };
                SQLDataHelper sqlData = new SQLDataHelper();
                var cacheItem = new CacheItem("students", sqlData.GetStudentData());
                cache.Add(cacheItem, cacheItemPolicy);
            }
            return (List<Student>)cache.Get("students");
            //List<Student> lstStudent = new List<Student>();

            //using (SqlConnection con = new SqlConnection(cs))
            //{
            //    string qeury = "select * From Student";

            //    SqlCommand cmd = new SqlCommand(qeury, con);

            //    con.Open();
            //    SqlDataReader rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        Student std = new Student();

            //        std.ID = Convert.ToString(rdr["ID"]);
            //        std.Name = (rdr["Name"].ToString());
            //        //std.Email = rdr["Email"].ToString();
            //        std.Class = rdr["Class"].ToString();
            //        lstStudent.Add(std);
            //    }
            //    con.Close();
            //}
            //return lstStudent;
        }
    }
}