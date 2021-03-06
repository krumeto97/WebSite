﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;
using ProjectShop.Pages.Cloathes.Blouses.PaginatedList;

namespace ProjectShop.Pages.Cloathes.Blouses
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public string BrandSort { get; set; }

        public string CurrentFilter { get; set; }

        public string CurrentSort { get; set; }

        public PaginatedList<Blouse> Blouse { get;set; }

        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            this.CurrentFilter = searchString;
            //Blouse = await _context.Blouse.ToListAsync();
            BrandSort = sortOrder == "Brand" ? "Brand_desc" : "Brand";
           if (searchString != null)
           {
               pageIndex = 1;
           }
           else
           {
               searchString = currentFilter;
           }

           this.CurrentSort = sortOrder;
           this.CurrentFilter = searchString;

           IQueryable<Blouse> blouseIQ = from a in _context.Blouse
               select a;
           if (!String.IsNullOrEmpty(searchString))
           {
               blouseIQ = blouseIQ.Where(a => a.Brand.Contains(searchString));
           }

           switch (sortOrder)
           {
                case "Brand":
                    blouseIQ = blouseIQ.OrderBy(a => a.Brand);
                    break;
                case "Brand_desc":
                    blouseIQ = blouseIQ.OrderByDescending(a => a.Brand);
                    break;
           }

           int pageSize = 3;
           this.Blouse = await PaginatedList<Blouse>.CreateAsync(
               blouseIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
