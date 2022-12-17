using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPP.Models;
using WebAPP.Services;

namespace WebAPP.Pages
{
    public class IndexModel : PageModel
    {
       

        public List<Products> Products { get; set; }
        public void OnGet()
        {
            ProductService serv = new ProductService();
            Products = serv.GetProducts();
        }
    }
}