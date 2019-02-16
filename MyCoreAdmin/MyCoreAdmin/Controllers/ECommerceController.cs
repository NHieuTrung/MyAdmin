using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using Type = Model.Models.Type;

namespace MyCoreAdmin.Controllers
{
    public class ECommerceController : Controller
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly MyCoreAdminDBContext _context;
        public ECommerceController(IHostingEnvironment environment, MyCoreAdminDBContext context)
        {
            _hostingEnvironment = environment;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        //C2CProduct
        public async Task<IActionResult> ProductListC2C()
        {
            return View(await _context.Type.Include(m => m.Branch).ToListAsync());
        }

        public async Task<IActionResult> ProductTypeDetailC2C(int? typeId)
        {
            ViewData["ProductTypeName"] = _context.Type.Find(typeId).TypeName;
            IQueryable<Product> listProduct = _context.Product;
            if (typeId != null)
            {
                listProduct = listProduct.Where(m => m.TypeId == typeId);
            }

            return View(await listProduct.ToListAsync());
        }

        public void UploadImageFromBase64(string stringBase64)
        {
            int typeId = _context.Type.Last().TypeId;
            //data:image/gif;base64,
            int indexPoint = stringBase64.IndexOf(";base64,") + 8;
            var base64 = stringBase64.Substring(indexPoint);
            byte[] bytes = Convert.FromBase64String(base64);
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images\\type\\"+typeId.ToString()+".jpg");


            using (var imageFile = new FileStream(path, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }
        public IActionResult CreateType()
        {
            var mtype = new Type();
            return PartialView("_CreateTypeModal",mtype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateType([Bind("TypeId,BranchId,TypeName")] Type mtype,string stringBase64)
        {
            if (ModelState.IsValid)
            {
                 _context.Add(mtype);
                await _context.SaveChangesAsync();
                UploadImageFromBase64(stringBase64);
                return RedirectToAction(nameof(ProductListC2C));
            }
            return PartialView("_CreateTypeModal", mtype);
        }


    }
}