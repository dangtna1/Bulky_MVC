using BulkyWebRazor_Temp.Model;
using BulkyWebRazor_Temp.myData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;           
        }
        public void OnGet(int? id)
        {
            if (id != null && id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {
            if (Category == null)
            {
                return NotFound();
            }
            _db.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Delete successfully";
            return RedirectToPage("Index");
        }
    }
}
 