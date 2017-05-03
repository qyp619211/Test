using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using WebService;
using System.IO;
using System.IO.Compression;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            test8();
            // Console.WriteLine(a);
        }
        public void test6()
        {
            Task[] tasks = new Task[2];
            tasks[0] = new Task(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Threading.Thread.Sleep(1000);
                    Console.WriteLine("Hello,task" + i.ToString());
                }

            });
            tasks[0].Start();

            tasks[1] = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Hello,task started by task factory");
            });

            Task.WaitAll(tasks, 5000);
            for (int i = 0; i < tasks.Length; i++)
            {
                if (tasks[i].Status != TaskStatus.RanToCompletion)
                {
                    Console.WriteLine("Task {0} Error!", i + 1);
                }
            }
            Console.Read();

        }



        public static void test1()
        {
            for (int i = 0; i < 100000; i++)
            {
                Thread.Sleep(10000);
            }

        }

        public static string test2()
        {
            Thread td = new Thread(test1);
            td.Start();
            return "123123213";
        }

        public static void test3()
        {
            List<test> list1 = new List<test>() { 
                new test { a = "as", id = 1 }, 
                new test { a = "as2", id = 2 }, 
                new test { a = "as3", id = 3 }, 
                new test { a = "as4", id = 4 } 
            
            };//hw
            List<test> list2 = new List<test>() { 
                new test { a = "as", id = 1 }, 
                new test { a = "as2", id = 2 }, 
                new test { a = "as5", id = 5 }, 
                new test { a = "as6", id = 6 } 
            
            };//hw

            var a1 = list1.Except(list2).ToList();//差集  
            var a2 = list2.Except(list1).ToList();//差集  

            //List<int> Result = list1.Union(list2).ToList<int>();          //剔除重复项 
            //List<int> Result1 = list1.Concat(list2).ToList<int>();        //保留重复项   


            // var expectedList = list1.Except(list2);//差级
            var list3 = list1.FindAll(o => o != list2.FirstOrDefault(x => x.id == o.id)).ToList();
            var list4 = list2.FindAll(o => o != list2.FirstOrDefault(x => x.id == o.id)).ToList();

            var aa = (from c in list1
                      where
                          (from c1 in list1
                           select c1.id).Except(
                        from e in list2
                        select e.id).Contains(c.id)
                      select c).ToList();
            var aa2 = (from c in list2
                       where
                           (from c1 in list2
                            select c1.id).Except(
                         from e in list1
                         select e.id).Contains(c.id)
                       select c).ToList();

            //var a3 = (from c in list1
            //         select c.id).Contains(
            //         (from c in list1
            //          select c.id).Except(
            //           from e in list2
            //          select e.id)
            //);
            //var a4 =
            //         (from c in list2
            //          select c.id).Except(
            //          from e in list1
            //          select e.id).ToList();

        }

        public static void test4()
        {
            var cnn = "Data Source=.; Initial Catalog=WikTest; User ID=sa;Password=123456;Trusted_Connection=yes; Persist Security Info=true;Integrated Security=false;";

            var Test = new List<Test_Name>() { 
              new Test_Name(){ID=1,Name="1"},
              new Test_Name(){ID=2,Name="2"}
            };
            var dt = Common.ToDataTable(Test);
            var a = new string[] { "ID", "Name" };
            // Common.BulkUpdate(cnn,dt);
            Common.Update(cnn, dt, "Test_Name", "ID", a, "1=1", 100);
        }

        public static void test5()
        {
            try
            {
                int i, j = 0;
                ThreadPool.GetAvailableThreads(out i, out j);
                //ThreadPool.SetMaxThreads(10, 10);
                PMSGatewayService service = new PMSGatewayService();
                while (true)
                {
                    Parallel.For(0, 9, (k) =>
                    {
                        try
                        {
                            OTA_HotelInvCountNotifRQ item = new OTA_HotelInvCountNotifRQ();
                            var invCountRS = service.OTA_HotelInvCountNotifRQ(item);//房量
                            ThreadPool.GetAvailableThreads(out i, out j);
                            Console.WriteLine("i:" + i.ToString() + "------- j:" + j.ToString() + "----" + k.ToString());
                            Thread.Sleep(9000);
                        }
                        catch (Exception)
                        {

                        }

                    });

                    Thread.Sleep(9000);
                }
                Console.ReadLine();
                var a = i;
                var b = j;
            }
            catch (Exception e)
            {


            }

        }

        public static void test7()
        {
            var a = GetPersonList();

            var result = from x in a.AsParallel().WithDegreeOfParallelism(50)
                         select x;
            
        
        }

        public static void test8()
        {

            var b = @"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
";
            var a = GUnZipString(b);

            Console.Read();
        }
        public static string GUnZipString(string toDecompress)
        {
            if (!string.IsNullOrEmpty(toDecompress))
            {
                byte[] toDecompressBuffer = Convert.FromBase64String(toDecompress);

                using (MemoryStream decompressedStream = new MemoryStream())
                {
                    int len = BitConverter.ToInt32(toDecompressBuffer, 0);
                    decompressedStream.Write(toDecompressBuffer, 4, toDecompressBuffer.Length - 4);

                    byte[] outBuffer = new byte[len];

                    decompressedStream.Position = 0;
                    using (GZipStream gzip = new GZipStream(decompressedStream, CompressionMode.Decompress))
                    {
                        gzip.Read(outBuffer, 0, outBuffer.Length);
                    }

                    return Encoding.UTF8.GetString(outBuffer);
                }
            }
            else
            {
                return string.Empty;
            }
        }


        //模拟源数据
        static IList<Person> GetPersonList()
        {
            var personList = new List<Person>();

            var person1 = new Person();
            for (int i = 0; i < 100; i++)
            {
                person1.id = i.ToString();
                person1.name = "Leslie";
                person1.age = "30";
                personList.Add(person1);
            }


            return personList;
        }
        static void ThreadPoolMessage(Person person)
        {
            int a, b;
            ThreadPool.GetAvailableThreads(out a, out b);
            string message = string.Format("Person  ID:{0} Name:{1} Age:{2}\n" +
                  "  CurrentThreadId is {3}\n  WorkerThreads is:{4}" +
                  "  CompletionPortThreads is :{5}\n",
                  person.id, person.name, person.age,
                  Thread.CurrentThread.ManagedThreadId, a.ToString(), b.ToString());

            Console.WriteLine(message);
        }


        class test
        {
            public string a;
            public int id;

        }

        class Test_Name
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
    }
}
