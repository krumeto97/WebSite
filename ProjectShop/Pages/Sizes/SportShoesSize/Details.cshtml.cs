﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Shoes.SportShoes;

namespace ProjectShop.Pages.Sizes.SportShoesSize
{
    public class DetailsModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public DetailsModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public SizeOfShoes SizeOfShoes { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SizeOfShoes = await _context.SizeOfShoes
                .Include(s => s.Shoes).FirstOrDefaultAsync(m => m.Id == id);

            if (SizeOfShoes == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
