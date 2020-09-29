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
    [RoutePrefix("api/students/test")]
    public class testController : ApiController
    {
        OnlineExamEntities data = new OnlineExamEntities();
        [HttpPost]
        [Route("easy")]
        public List<questionR> level1([FromBody] filepath filepath)
        {
            var all = data.Database.SqlQuery<questionR>(@"select sno,question,option1, option2, option3, option4, [correct option] as correct_option, difficulty from " + filepath.subject + "Question" + filepath.set + " where difficulty = 'easy' order by NEWID()").ToList();
            return all;
        }
        [HttpPost]
        [Route("medium")]
        public List<questionR> level2([FromBody] filepath filepath)
        {
            var all = data.Database.SqlQuery<questionR>(@"select sno,question,option1, option2, option3, option4, [correct option] as correct_option, difficulty from " + filepath.subject + "Question" + filepath.set + " where difficulty = 'medium' order by NEWID()").ToList();
            return all;
        }
        [HttpPost]
        [Route("hard")]
        public List<questionR> level3([FromBody] filepath filepath)
        {
            var all = data.Database.SqlQuery<questionR>(@"select sno,question,option1, option2, option3, option4, [correct option] as correct_option, difficulty from " + filepath.subject + "Question" + filepath.set + " where difficulty = 'hard' order by NEWID()").ToList();
            return all;
        }

        [HttpPost]
        [Route("insert")]
        public List<int> reportInsert([FromBody] reportStudent RS)
        {
            var exam_id = data.Database.SqlQuery<int>(@"select exam_id from Exam_List where exam_name = @exam_name", new SqlParameter("@exam_name", RS.subject)).ToList();
            var all = data.Database.ExecuteSqlCommand(@"insert into Reports(user_id,exam_id,exam_name,level1_score,level2_score,level3_score) values (@user_id,@exam_id,@exam_name,@level1_score,@level2_score,@level3_score)", new SqlParameter("@user_id", RS.user_id), new SqlParameter("@exam_id", exam_id.First()), new SqlParameter("@exam_name", RS.subject), new SqlParameter("@level1_score", RS.level1_score), new SqlParameter("@level2_score", RS.level2_score), new SqlParameter("@level3_score", RS.level3_score));
            var report_id = data.Database.SqlQuery<int>(@"select top 1 report_id from Reports order by report_id desc").ToList();
            return report_id;
        }

        [HttpPost]
        [Route("update")]
        public string reportUpdate([FromBody] reportStudent RS)
        {
            if (RS.level2_score > 0)
            {

                var all = data.Database.ExecuteSqlCommand(@"update Reports set level2_score =" + RS.level2_score + " where report_id =" + RS.report_id);
                return "Marks updated succesfully";
            }
            else if (RS.level3_score > 0)
            {
                var all = data.Database.ExecuteSqlCommand(@"update Reports set level3_score =" + RS.level3_score + " where report_id =" + RS.report_id);
                return "Marks updated successfully";
            }
            else
                return "0";
        }
    }
}
