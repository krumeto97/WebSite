﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectShop.Data;
using ProjectShop.Models.Clothes.Coat;

namespace ProjectShop.Pages.Cloathes.Coats
{
    public class EditModel : PageModel
    {
        private readonly ProjectShop.Data.ProjectShopContext _context;

        public EditModel(ProjectShop.Data.ProjectShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Coat Coat { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Coat = await _context.Coat.FirstOrDefaultAsync(m => m.Id == id);

            if (Coat == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Coat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoatExists(Coat.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoatExists(Guid id)
        {
            return _context.Coat.Any(e => e.Id == id);
        }
    }
}
