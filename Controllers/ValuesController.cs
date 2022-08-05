using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication3.DataLayer;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public List<Student> Get()
        {
            //SQLDataHelper sqlData = new SQLDataHelper();
            ObjectCache cache = MemoryCache.Default;
            if (cache["students"] == null)
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

            //return sqlData.GetStudentData();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
