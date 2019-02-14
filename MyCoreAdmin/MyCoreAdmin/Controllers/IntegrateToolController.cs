using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace MyCoreAdmin.Controllers
{
    
    public class IntegrateToolController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly MyCoreAdminDBContext _context;

        //Mail tool
        public IntegrateToolController(IHostingEnvironment environment, MyCoreAdminDBContext context)
        {
            _hostingEnvironment = environment;
            _context = context;
        }

        //Send mail Html form integrate Document editor Summer Note
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

        //Image Tool
        public IActionResult Croppie()
        {
            return View();
        }

        public JsonResult UploadImageFromBase64(string stringBase64)
        {
            //data:image/gif;base64,
            int indexPoint = stringBase64.IndexOf(";base64,") + 8;
            var base64 = stringBase64.Substring(indexPoint);
            byte[] bytes = Convert.FromBase64String(base64);
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images\\temp.jpg");
            bool result = true;


            using (var imageFile = new FileStream(path, FileMode.Create))
            {
                try
                { 
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                    
                }
                catch
                {
                    result = false;
                }
            }
            
            return new JsonResult(result);
        }
    }
}