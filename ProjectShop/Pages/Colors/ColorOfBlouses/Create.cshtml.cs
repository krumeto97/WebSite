﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Blouse;

namespace ProjectShop.Pages.Colors.ColorOfBlouses
{
    public class CreateModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public CreateModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["BrandName"] =new SelectList(_context.Set<Blouse>(), "Id", "Id");
            ViewData["ModelId"] = new SelectList(_context.Set<BlouseModel>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public BlouseColor BlouseColor { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BlouseColor.Add(BlouseColor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
