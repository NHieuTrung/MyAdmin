using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;

namespace MyCoreAdmin.Controllers
{
    public class IntegrateToolController : Controller
    {
        public IActionResult SummerNote()
        {
            return View();
        }
        
        public JsonResult SendMail(string toEmail,string subject,string body)
        {
            bool result = true;
            try
            {
                MailBox mb = new MailBox();
                mb.SendMail(toEmail, subject, body);
            }
            catch
            {
                result = false;
            }
            return new JsonResult(result);
        }
    }
}