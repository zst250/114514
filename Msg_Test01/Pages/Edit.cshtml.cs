using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msg_Test01.Data;
using Msg_Test01.Models;
using System.ComponentModel.DataAnnotations;

namespace Msg_Test01.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _db;

        [BindProperty]
        
        public Message EditMessage {  get; set; }=new Message();
        public EditModel(AppDbContext db) {
            _db = db;
        }
        public IActionResult OnGet(int id)
        {
            var m = _db.Messages.Find(id);
            if (m == null)
            {
                return NotFound();
            }
            EditMessage = m;
            return Page();
        }
        public IActionResult OnPostEdit() {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var m = _db.Messages.Find(EditMessage.Id);
            if (m == null)
            {
                return NotFound();
            }
            m.Name= EditMessage.Name;
            m.Content = EditMessage.Content;
            _db.SaveChanges();
            return RedirectToPage("/Index");
        }

    }
}
