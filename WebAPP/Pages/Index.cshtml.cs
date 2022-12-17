using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAPP.Models;
using WebAPP.Services;

namespace WebAPP.Pages
{
    public class IndexModel : PageModel
    {
       

        public List<Products> Products { get; set; }

        private readonly IProductService _ProductService; 
        public IndexModel(IProductService productService)
        {
            _ProductService= productService;
        }
        
        
        public void OnGet()
        {
            Products = _ProductService.GetProducts();
        }
    }
}