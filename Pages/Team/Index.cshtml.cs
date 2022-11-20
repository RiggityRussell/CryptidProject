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
    public class IndexModel : PageModel
    {
        private readonly CryptidProject.Data.CryptidProjectContext _context;

        public IndexModel(CryptidProject.Data.CryptidProjectContext context)
        {
            _context = context;
        }

        public IList<Cryptids> Cryptids { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cryptids != null)
            {
                Cryptids = await _context.Cryptids.ToListAsync();
            }
        }
    }
}
