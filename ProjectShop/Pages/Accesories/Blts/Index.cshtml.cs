﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Accessories.Belts;

namespace ProjectShop.Pages.Accesories.Blts
{
    public class IndexModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public IndexModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IList<Belts> Belts { get;set; }

        public async Task OnGetAsync()
        {
            Belts = await _context.Belts.ToListAsync();
        }
    }
}
