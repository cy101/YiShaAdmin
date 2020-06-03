using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using ETAL.Cache.Factory;
using ETAL.Util;
using ETAL.Util.Model;
using ETAL.Business;
using ETAL.Business.SystemManage;
using ETAL.Entity.SystemManage;

namespace ETAL.CacheTest
{
    public class RedisCacheTest
    {
        [SetUp]
        public void Init()
        {
            GlobalContext.SystemConfig = new SystemConfig
            {
                DBProvider = "MySql",
                DBConnectionString = "server=localhost;database=etal_admin;user=root;password=luoyong;port=3306;pooling=true;max pool size=20;persist security info=True;charset=utf8mb4;",

                CacheProvider = "Redis",
                RedisConnectionString = "127.0.0.1:6379"
            };
        }

        [Test]
        public void TestRedisSimple()
        {
            string key = "test_simple_key";
            string value = "test_simple_value";
            CacheFactory.Cache.SetCache<string>(key, value);

            Assert.AreEqual(value, CacheFactory.Cache.GetCache<string>(key));
        }

        [Test]
        public void TestRedisComplex()
        {
            string key = "test_complex_key";
            TData<string> value = new TData<string> { Tag = 1, Result = "测试Redis" };
            CacheFactory.Cache.SetCache<TData<string>>(key, value);

            var result = CacheFactory.Cache.GetCache<TData<string>>(key);
            if (result.Tag == 1)
            {
                Assert.Pass(nameof(TestRedisComplex));
            }
            else
            {
                Assert.Fail(nameof(TestRedisComplex));
            }
        }

        [Test]
        public async Task TestRedisPerformance()
        {
            LogLoginBLL logLoginBLL = new LogLoginBLL();
            var obj = await logLoginBLL.GetList(null);

            string key = "test_performance_key";
            Stopwatch sw = new Stopwatch();
            sw.Start();
            CacheFactory.Cache.SetCache<List<LogLoginEntity>>(key, obj.Result);
            sw.Stop();
            Console.WriteLine(nameof(TestRedisPerformance) + " Redis Write Time:" + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            var result = CacheFactory.Cache.GetCache<List<LogLoginEntity>>(key);
            sw.Stop();
            if (obj.Result.Count == result.Count)
            {
                Console.WriteLine(nameof(TestRedisPerformance) + " Redis Read Time:" + sw.ElapsedMilliseconds + " ms");
            }
            else
            {
                Assert.Fail(nameof(TestRedisPerformance));
            }
        }
    }
}