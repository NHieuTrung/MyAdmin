using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MyCoreAdmin.Controllers
{
    
    public class IntegrateToolController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;

        public IntegrateToolController(IHostingEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

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
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "pages\\formmailbox.html");
                string formMailHtml= System.IO.File.ReadAllText(path);
                StringBuilder sbFormMailHtml = new StringBuilder(formMailHtml);
                sbFormMailHtml.Replace("@ViewBag.MonthYear", System.DateTime.Now.ToShortDateString());
                sbFormMailHtml.Replace("@RenderBody()", body);

                mb.SendMail(toEmail, subject, sbFormMailHtml.ToString());
            }
            catch
            {
                result = false;
            }
            return new JsonResult(result);
        }
    }
}