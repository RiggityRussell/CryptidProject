using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CryptidProject.Data;
using CryptidProject.Models;

namespace CryptidProject.Pages.Team
{
    public class CreateModel : PageModel
    {
        private readonly CryptidProject.Data.CryptidProjectContext _context;

        public CreateModel(CryptidProject.Data.CryptidProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cryptids Cryptids { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cryptids.Add(Cryptids);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
