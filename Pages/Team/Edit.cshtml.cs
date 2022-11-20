using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CryptidProject.Data;
using CryptidProject.Models;

namespace CryptidProject.Pages.Team
{
    public class EditModel : PageModel
    {
        private readonly CryptidProject.Data.CryptidProjectContext _context;

        public EditModel(CryptidProject.Data.CryptidProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cryptids Cryptids { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cryptids == null)
            {
                return NotFound();
            }

            var cryptids =  await _context.Cryptids.FirstOrDefaultAsync(m => m.ID == id);
            if (cryptids == null)
            {
                return NotFound();
            }
            Cryptids = cryptids;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cryptids).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CryptidsExists(Cryptids.ID))
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

        private bool CryptidsExists(int id)
        {
          return _context.Cryptids.Any(e => e.ID == id);
        }
    }
}
