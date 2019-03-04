﻿using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
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

        //C2CProductManager
        public async Task<IActionResult> BranchAndTypeListC2C()
        {
            return View(await _context.Branch.Include(m=>m.Type).ToListAsync());
        }


        //Upload image
        public void UploadImageTypeFromBase64(string stringBase64)
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
        public void UploadImageProductFromBase64(string stringBase64)
        {
            int productId = _context.Product.Last().ProductId;
            //data:image/gif;base64,
            int indexPoint = stringBase64.IndexOf(";base64,") + 8;
            var base64 = stringBase64.Substring(indexPoint);
            byte[] bytes = Convert.FromBase64String(base64);

            //Result path file to save
            var path = Path.Combine(_hostingEnvironment.WebRootPath, "images\\product\\" + productId.ToString() + ".jpg");

            ////Save image to path
            //using (var imageFile = new FileStream(path, FileMode.Create))
            //{
            //    imageFile.Write(bytes, 0, bytes.Length);
            //    imageFile.Flush();
            //}

            var pathLargeSize = Path.Combine(_hostingEnvironment.WebRootPath, "images\\product\\largesize\\" + productId.ToString() + ".jpg");
            using (Image<Rgba32> image = Image.Load(bytes)) //open the file and detect the file type and decode it
            {
                image.Save(pathLargeSize);
                // image is now in a file format agnositic structure in memory as a series of Rgba32 pixels
                image.Mutate(ctx => ctx.Resize(image.Width / 4, image.Height / 4)); // resize the image in place and return it for chaining
                image.Save(path); // based on the file extension pick an encoder then encode and write the data to disk
            } // dispose - releasing memory into a memory pool ready for the next image you wish to process
        }
        public IActionResult CreateType()
        {
            var mtype = new Type();
            return PartialView("_CreateTypeModal",mtype);
        }
        //-------------------------------------------------------------

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateType([Bind("TypeId,BranchId,TypeName")] Type mtype,string stringBase64)
        {
            if (ModelState.IsValid)
            {
                 _context.Add(mtype);
                await _context.SaveChangesAsync();
                UploadImageTypeFromBase64(stringBase64);
                return RedirectToAction(nameof(BranchAndTypeListC2C));
            }
            return PartialView("_CreateTypeModal", mtype);
        }

        public IActionResult CreateBranch()
        {
            var mbranch = new Branch();
            return PartialView("_CreateBranchModal", mbranch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBranch([Bind("BranchId,BranchName")] Branch mbranch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mbranch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(BranchAndTypeListC2C));
            }
            return PartialView("_CreateBranchModal", mbranch);
        }

        public async Task<IActionResult> ProductListC2C(int? typeId)
        {
            ViewData["ProductTypeId"] = typeId;
            ViewData["ProductTypeName"] = _context.Type.Find(typeId).TypeName;
            IQueryable<Product> listProduct = _context.Product;
            if (typeId != null)
            {
                listProduct = listProduct.Where(m => m.TypeId == typeId);
            }

            return View(await listProduct.ToListAsync());
        }

        public IActionResult CreateProduct()
        {
            var mproduct = new Product();
            return PartialView("_CreateProductModal", mproduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([Bind("ProductId,ProductName,AddedDate,EstablishedDate,TypeId,Price,Quantity")] Product mproduct, string stringBase64)
        {
            if (ModelState.IsValid)
            {
                mproduct.AddedDate = System.DateTime.Now;
                _context.Add(mproduct);
                await _context.SaveChangesAsync();
                UploadImageProductFromBase64(stringBase64);
                return RedirectToAction(nameof(ProductListC2C),new { typeId=mproduct.TypeId});
            }
            return PartialView("_CreateProductModal", mproduct);
        }

        public async Task<IActionResult> ProductDetailC2C(int? productId)
        {
            if (productId == null)
            {
                return NotFound();
            }

            var mproduct = await _context.Product
                .FirstOrDefaultAsync(m => m.ProductId == productId);
            if (mproduct == null)
            {
                return NotFound();
            }

            return View(mproduct);
        }

    }
}