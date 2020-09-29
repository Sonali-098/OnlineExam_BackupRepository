using GladiatorBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GladiatorBackend.Controllers
{
    [RoutePrefix("api/report")]
    public class reportController : ApiController
    {
        OnlineExamEntities data = new OnlineExamEntities();
       
        [HttpPost]
        [Route("getAllReport")]
        public List<User> allReport()
        {
            var all = data.Database.SqlQuery<User>(@"select Distinct Users.* from Users inner join Reports on Reports.user_id = Users.user_id").ToList();
            return all;
        }

        [HttpPost]
        [Route("getReport")]
        public List<customReport> studentReport([FromBody] User user)
        {

            var all = data.Database.SqlQuery<customReport>(@"select exam_name, level1_score, level2_score, level3_score from Reports where user_id=@user_id", new SqlParameter("@user_id", user.user_id)).ToList();
            return all;
        }


        [HttpPost]
        [Route("getCity")]
        public List<string> city()
        {
            var all = data.Database.SqlQuery<string>(@"select Distinct city from Users").ToList();
            return all;
        }

        [HttpPost]
        [Route("getState")]
        public List<string> state()
        {
            var all = data.Database.SqlQuery<string>(@"select Distinct state from Users").ToList();
            return all;
        }

        [HttpPost]
        [Route("searchReport")]
        public List<reportOne> searchReport([FromBody] searchReport SR)
        {

            if (SR.level.Length == 1)
            {
                var all = data.Database.SqlQuery<reportOne>(@"select Users.full_name, Users.email_id, Users.mobile, Users.city, Users.state, Reports.level" + SR.level[0] + "_score as Score" + SR.level[0] + " from Users inner join Reports on Reports.user_id = Users.user_id inner join Exam_List on Reports.exam_name = Exam_List.exam_name where Users.city =@city and Users.state =@state and Exam_List.exam_name =@tech and Reports.level" + SR.level[0] + "_score > @marks", new SqlParameter("@city", SR.city), new SqlParameter("@state", SR.state), new SqlParameter("@tech", SR.tech), new SqlParameter("@marks", SR.marks)).ToList();
                return all;

            }


            else if (SR.level.Length == 2)
            {
                var all = data.Database.SqlQuery<reportOne>(@"select Users.full_name, Users.email_id, Users.mobile, Users.city, Users.state, Reports.level" + SR.level[0] + "_score as Score" + SR.level[0] + ", Reports.level" + SR.level[1] + "_score as Score" + SR.level[1] + " from Users inner join Reports on Reports.user_id = Users.user_id inner join Exam_List on Reports.exam_name = Exam_List.exam_name where Users.city =@city and Users.state=@state and Exam_List.exam_name=@tech and Reports.level" + SR.level[0] + "_score>@marks and Reports.level" + SR.level[1] + "_score > @marks", new SqlParameter("@city", SR.city), new SqlParameter("@state", SR.state), new SqlParameter("@tech", SR.tech), new SqlParameter("@marks", SR.marks)).ToList();
                return all;

            }


            else if (SR.level.Length == 3)
            {
                var all = data.Database.SqlQuery<reportOne>(@"select Users.full_name, Users.email_id, Users.mobile, Users.city, Users.state, Reports.level" + SR.level[0] + "_score as Score" + SR.level[0] + " , Reports.level" + SR.level[1] + "_score as Score" + SR.level[1] + ", Reports.level" + SR.level[2] + "_score as Score" + SR.level[2] + " from Users inner join Reports on Reports.user_id = Users.user_id inner join Exam_List on Reports.exam_name = Exam_List.exam_name where Users.city =@city and Users.state =@state and Exam_List.exam_name =@tech and Reports.level" + SR.level[0] + "_score>@marks and Reports.level" + SR.level[1] + "_score > @marks and Reports.level" + SR.level[2] + "_score > @marks", new SqlParameter("@city", SR.city), new SqlParameter("@state", SR.state), new SqlParameter("@tech", SR.tech), new SqlParameter("@marks", SR.marks)).ToList();
                return all;

            }
            else
                return null;
        }
    }
}
