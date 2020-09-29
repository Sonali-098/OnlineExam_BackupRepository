using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Results;
using GladiatorBackend.Models;
using FileReader;

namespace GladiatorBackend.Controllers
{
    [RoutePrefix("api/admins/upload")]
    public class UploadController : ApiController
    {
        OnlineExamEntities data = new OnlineExamEntities();
        [HttpPost]
        [AllowAnonymous]
        [Route("removeJava")]
        public string removeJava([FromBody] filepath set)
        {
            var free = "javaQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table javaQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Java_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =1");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Available")]
        public List<string> available([FromBody] filepath subject)
        {
            var free = subject.subject + "_Sets";
            var avail = data.Database.SqlQuery<string>(@"select table_name from " + free + " where availability = 'no'").ToList();

            return avail;
        }




        [HttpPost]
        [AllowAnonymous]
        [Route("uploadJava")]
        public string javaSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=1").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Java_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Java_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =1");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("removeCplus")]
        public string removeCplus([FromBody] filepath set)
        {
            var free = "CplusQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table cplusQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Cplus_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =2");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadCplus")]
        public string CplusSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=2").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Cplus_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Cplus_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =2");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("removeCsharp")]
        public string removeCsharp([FromBody] filepath set)
        {
            var free = "CsharpQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table csharpQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Csharp_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =3");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadCsharp")]
        public string CsharpSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=3").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Csharp_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Csharp_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =3");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("removePhp")]
        public string removePhp([FromBody] filepath set)
        {
            var free = "PhpQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table phpQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Php_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =4");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadPhp")]
        public string PhpSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=4").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Php_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Php_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =4");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("removeSql")]
        public string removeSql([FromBody] filepath set)
        {
            var free = "SqlQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table sqlQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Sql_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =5");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadSql")]
        public string SqlSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=5").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Sql_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Sql_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =5");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("removePython")]
        public string removePython([FromBody] filepath set)
        {
            var free = "PythonQuestion" + set.set;
            data.Database.ExecuteSqlCommand(@"truncate table pythonQuestion" + set.set);
            data.Database.ExecuteSqlCommand(@"update Python_Sets set availability = 'yes' where table_name=@tablename", new SqlParameter("@tablename", free));
            data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts - 1 where exam_id =6");
            return "Deleted";
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("uploadPython")]
        public string PythonSet([FromBody] filepath csv_file_path)
        {
            var count = data.Database.SqlQuery<int>(@"select exam_set_counts from Exam_List where exam_id=6").FirstOrDefault<int>();
            if (count <= 2)
            {
                var free = data.Database.SqlQuery<string>(@"select top 1 table_name from Python_Sets where availability = 'yes'").FirstOrDefault<string>();
                string tableName = free;
                CSVtoSQL c = new CSVtoSQL();
                DataTable csvData = FileReader.CSVtoSQL.GetDataTabletFromCSVFile(csv_file_path.csv_file_path);
                Console.WriteLine("Rows count:" + csvData.Rows.Count);

                c.InsertDataIntoSQLServerUsingSQLBulkCopy(csvData, tableName);
                foreach (var column in csvData.Columns)
                {
                    Console.WriteLine(column);
                }
                data.Database.ExecuteSqlCommand(@"update Python_Sets set availability = 'no' where table_name=@tablename", new SqlParameter("@tablename", free));
                data.Database.ExecuteSqlCommand(@"update Exam_List set exam_set_counts = exam_set_counts + 1 where exam_id =6");
                return "Added Successfully";

            }
            else
                return "No More Set Can be Added";
        }

    }
}
