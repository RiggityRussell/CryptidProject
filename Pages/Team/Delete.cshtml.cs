using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CryptidProject.Data;
using CryptidProject.Models;

namespace CryptidProject.Pages.Team
{
    public class DeleteModel : PageModel
    {
        private readonly CryptidProject.Data.CryptidProjectContext _context;

        public DeleteModel(CryptidProject.Data.CryptidProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cryptids Cryptids { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cryptids == null)
            {
                return NotFound();
            }

            var cryptids = await _context.Cryptids.FirstOrDefaultAsync(m => m.ID == id);

            if (cryptids == null)
            {
                return NotFound();
            }
            else 
            {
                Cryptids = cryptids;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cryptids == null)
            {
                return NotFound();
            }
            var cryptids = await _context.Cryptids.FindAsync(id);

            if (cryptids != null)
            {
                Cryptids = cryptids;
                _context.Cryptids.Remove(Cryptids);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
