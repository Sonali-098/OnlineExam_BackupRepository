using GladiatorBackend.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Web.Http.Results;

namespace GladiatorBackend.Controllers
{
    [RoutePrefix("api/accounts")]
    public class ExamController : ApiController
    {

        OnlineExamEntities data = new OnlineExamEntities();
        [HttpPost]
        [Route("getUser")]
        public List<string> validateUser([FromBody] User userDetails)
        {
            var name = data.Database.SqlQuery<string>(@"Select full_name from Users where email_id =@email and password = @password", new SqlParameter("@email", userDetails.email_id), new SqlParameter("@password", userDetails.password)).ToList();
            return name;
        }

        [HttpGet]
        [Route("showAllUsers")]
        public IEnumerable<User> getAllUsers()
        {
            var all = data.Database.SqlQuery<User>(@"select * from Users").ToList();
            return all;
        }

        [HttpPost]
        [Route("registerUser")]
        public string registerUser([FromBody] User registerDetails)
        {
            var checkEmail = data.Database.SqlQuery<string>(@"select email_id from Users where email_id=@email", new SqlParameter("@email", registerDetails.email_id)).ToList();
            var checkMobile = data.Database.SqlQuery<string>(@"select mobile from Users where mobile=@mobile", new SqlParameter("@mobile", registerDetails.mobile)).ToList();

            if (checkEmail.Count != 0)
            {
                return "Email ID Already Exists";
            }
            else if (checkMobile.Count != 0)
            {
                return "Mobile Number Already Exists";
            }
            else
            {
                var register = data.Database.SqlQuery<register>(@"insert into Users (full_name,mobile,email_id,password,city,dob,state,qualification,yoc) values (@full_name,@mobile,@email_id,@password,@city,@dob,@state,@qualification,@yoc) ", new SqlParameter("@city", registerDetails.city), new SqlParameter("@password", registerDetails.password), new SqlParameter("@dob", registerDetails.dob), new SqlParameter("@state", registerDetails.state), new SqlParameter("@qualification", registerDetails.qualification), new SqlParameter("@yoc", registerDetails.yoc), new SqlParameter("@email_id", registerDetails.email_id), new SqlParameter("@full_name", registerDetails.full_name), new SqlParameter("@mobile", registerDetails.mobile)).ToList();
                return "Added Successfully";
            }
        }

        [HttpPost]
        [Route("getAdmin")]
        public List<string> validateAdmin([FromBody] User userDetails)
        {
            var name = data.Database.SqlQuery<string>(@"Select full_name from Admin where email_id =@email and password = @password", new SqlParameter("@email", userDetails.email_id), new SqlParameter("@password", userDetails.password)).ToList();
            return name;
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("sendMail")]
        public string PostSendGmail([FromBody] User userDetails)
        {
            Random rnd = new Random();
            int otp = rnd.Next(1000, 9999);

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential("ltieq.noreply@gmail.com", "saurav_123");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;
            //can be obtained from your model
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("ltieq.noreply@gmail.com");
            msg.To.Add(new MailAddress(userDetails.email_id));
            msg.Subject = "Dear User, your otp is " + otp;
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>Message Email</b></body>");
            try
            {
                client.Send(msg);
                return otp.ToString();
            }
            catch (Exception ex)
            {
                return "error:" + ex.ToString();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        [Route("resetPassword")]
        public string resetPassword([FromBody] User userDetails)
        {
            data.Database.ExecuteSqlCommand(@"update Users set password = @password where email_id = @email", new SqlParameter("@password", userDetails.password), new SqlParameter("@email", userDetails.email_id));
            return "Password Changed Successfully";

        }
    }
}
