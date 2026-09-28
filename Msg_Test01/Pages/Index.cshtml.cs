using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msg_Test01.Data;
using Msg_Test01.Models;

using System.ComponentModel.DataAnnotations;


namespace Msg_Test01.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        [BindProperty]
        [Required(ErrorMessage = "填空不能为空")]
        public Message NewMessage { get; set; } = new Message();

        public  List<Message> messages = new List<Message>();

        public int TotalChars { get; set; }
        private void InitPage()
        {
            messages = _db.Messages.ToList();
            TotalChars = _db.Messages.Sum(m=>m.Content.Length);
            
        }

        public IndexModel(AppDbContext db) {
            _db = db;
        }
        public IActionResult OnGet()
        {
            InitPage();
            return Page();
        }
        public IActionResult OnPost() {
            if (ModelState.IsValid)
            {
                _db.Messages.Add(NewMessage);
                _db.SaveChanges();
                return RedirectToPage();
            }
            InitPage();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            var m = _db.Messages.Find(id);
            if (m != null)
            {
                _db.Messages.Remove(m);
                _db.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}
