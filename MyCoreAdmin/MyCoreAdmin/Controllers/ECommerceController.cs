using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Models;

namespace MyCoreAdmin.Controllers
{
    public class ECommerceController : Controller
    {
        private readonly MyCoreAdminDBContext _context;
        public ECommerceController(MyCoreAdminDBContext context)
        {
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
    }
}