using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJEKTU_SKRYPTU_EBAZA.Data;
using PROJEKTU_SKRYPTU_EBAZA.Services.CategoryServ;
using PROJEKTU_SKRYPTU_EBAZA.Services.ProductServ;
using PROJEKTU_SKRYPTU_EBAZA.Services.SupplierServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        //Wstrzykiwanie interfejsów do wykonywania metod
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;


        public DashboardController(IProductService productService, ISupplierService supplierService, ICategoryService categoryService)
        {
            _productService = productService;
            _supplierService = supplierService;
            _categoryService = categoryService;
        }

        //Strona Panelu 
        public async Task<IActionResult> Home()
        {            
            return View("Views/Dashboard/Home.cshtml");
        }


        #region Produkty

        //Strona z listą produktów
        public async Task<IActionResult> Products()
        {
            //Pobranie listy produktów
            var products = await _productService.GetProductsAsync();
            return View("Views/Dashboard/Products/ListProducts.cshtml", products);
        }


        //Strona Edytowania Produktu
        public async Task<IActionResult> EditProduct(int id)
        {
            //Pobranie listy Dostawców do obiektu ViewData
            ViewData["Suppliers"] = await _supplierService.GetListSuppliersAsync();
            //Pobranie listy kategorii do obiektu ViewData 
            ViewData["Categories"] = await _categoryService.GetCategoriesAsync();

            //Pobranie listy produktów
            var product = await _productService.GetProductAsync(id);

            return View("Views/Dashboard/Products/EditProduct.cshtml", product);
        }



        //Wykonanie edycji produktu
        [HttpPost]
        public async Task<IActionResult> EditProduct(Product model)
        {
            //Sprawdzenie czy formularz jest dobrze wypełniony
            if (!ModelState.IsValid)
            {
                //Jeżeli został źle wypełniony
                //Pobranie listy Dostawców do obiektu ViewData
                ViewData["Suppliers"] = await _supplierService.GetListSuppliersAsync();
                //Pobranie listy kategorii do obiektu ViewData 
                ViewData["Categories"] = await _categoryService.GetCategoriesAsync();

                //Wyświetlenie strony edycji produktu
                return View("Views/Dashboard/Products/EditProduct.cshtml", model);
            }
           
            //Jeżeli dobrze to wykonywana jest edycja produktu
            var product = await _productService.EditProductAsync(model);

            //Powrót do strony z listą produktów
            return RedirectToAction(nameof(Products));
        }


        //Strona dodania produktu
        public async Task<IActionResult> AddProduct()
        {
            //Pobranie listy Dostawców do obiektu ViewData
            ViewData["Suppliers"] = await _supplierService.GetListSuppliersAsync();
            //Pobranie listy kategorii do obiektu ViewData 
            ViewData["Categories"] = await _categoryService.GetCategoriesAsync();

                        
            return View("Views/Dashboard/Products/AddProduct.cshtml");
        }


        //Wykonanie dodania produktu
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product model, IFormFile file)
        {
            //Sprawdzenie czy formularza czy dobrze wypełniony
            if (!ModelState.IsValid)
            {
                //Jeżeli nie jest
                //Pobranie listy Dostawców do obiektu ViewData
                ViewData["Suppliers"] = await _supplierService.GetListSuppliersAsync();
                //Pobranie listy kategorii do obiektu ViewData 
                ViewData["Categories"] = await _categoryService.GetCategoriesAsync();
                return View("Views/Dashboard/Products/AddProduct.cshtml", model);
            }

            //Sprawdzenie czy plik jest załączony
            if (file == null)
            {
                //Jeżeli nie jest

                //Pobranie listy Dostawców do obiektu ViewData
                ViewData["Suppliers"] = await _supplierService.GetListSuppliersAsync();
                //Pobranie listy kategorii do obiektu ViewData 
                ViewData["Categories"] = await _categoryService.GetCategoriesAsync();
                //Wyświetlenie komunikatu o braku załączonego zdjęcia
                ModelState.AddModelError("", "Zdjęcie musi zostać wybrane");
                return View("Views/Dashboard/Products/AddProduct.cshtml", model);
            }

            //Dodanie produktu do bazy
            await _productService.AddProductAsync(model, file);

            //Powrót do listy produktów
            return RedirectToAction(nameof(Products));
        }




        //Wykonanie usuwania Produktu
        [HttpPost]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            //Usuwanie produktu
            await _productService.RemoveProductAsync(id);
            
            //Powrót do listy produktów
            return RedirectToAction(nameof(Products));
        }


        #endregion
        #region Kategorie

        //Strona z listą kategorii
        public async Task<IActionResult> Categories()
        {
            //Pobranie listy kategorii
            var categories = await _categoryService.GetCategoriesAsync();
            
            return View("Views/Dashboard/Categories/ListCategories.cshtml", categories);
        }

        //Strona dodania kategorii
        public async Task<IActionResult> AddCategory()
        {           
            return View("Views/Dashboard/Categories/AddCategory.cshtml");
        }


        //Wykonanie dodania kategorii
        [HttpPost]
        public async Task<IActionResult> AddCategory(ProductCategory model)
        {

            //Sprawdzenie czy formularz jest dobrze wypełniony
            if (!ModelState.IsValid)
            {               
                //Jeżeli nie jest powrót na stronę formularza
                return View("Views/Dashboard/Categories/AddCategory.cshtml",model);
            }


            //Dodanie kategorii
            await _categoryService.AddCategoryAsync(model);

            //Powrót do listy kategorii
            return RedirectToAction(nameof(Categories));
        }


        //Strona edycji kategorii
        public async Task<IActionResult> EditCategory(int id)
        {
            //Pobranie kategorii do edycji
            var category = await _categoryService.GetCategoryAsync(id);

            //Wyświetlenie kategorii do Edycji
            return View("Views/Dashboard/Categories/EditCategory.cshtml",category);
        }



        //Wykonanie Edycji Kategorii
        [HttpPost]
        public async Task<IActionResult> EditCategory(ProductCategory model)
        {
            //Sprawdzenie czy formularz jest dobrze wypełniony
            if (!ModelState.IsValid)
            {
                return View("Views/Dashboard/Categories/EditCategory.cshtml", model);
            }


            //Edytowanie kategorii
            await _categoryService.EditCategoryAsync(model);

            //Powrót do listy kategorii
            return RedirectToAction(nameof(Categories));
        }


        //Wykonanie usunięcia Kategorii
        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int id)
        {

            //Usunięcie Kategorii
            await _categoryService.RemoveCategoryAsync(id);


            //Powrót do listy kategori
            return RedirectToAction(nameof(Categories));
        }




        #endregion

        #region Dostawcy 


        //Wyświetlenie listy dostawców
        public async Task<IActionResult> Suppliers()
        {
            //Pobranie listy dostawców
            var suppliers = await _supplierService.GetListSuppliersAsync();
            
            return View("Views/Dashboard/Suppliers/ListSuppliers.cshtml",suppliers);
        }


        //Strona dodawania dostawców
        public async Task<IActionResult> AddSupplier()
        {          

            return View("Views/Dashboard/Suppliers/AddSuppliers.cshtml");
        }


        //Wykonanie dodania dostawców
        [HttpPost]
        public async Task<IActionResult> AddSupplier(Supplier model)
        {
            //Sprawdzenie czy formularz jest dobrze wypełniony
            if (!ModelState.IsValid)
            {
                //Jeżeli nie jest powrót do strony dodania dostawcy
                return View("Views/Dashboard/Products/AddSuppliers.cshtml", model);
            }


            //Dodanie dostawcy
            await _supplierService.AddSupplierAsync(model);

            //Powrót do listy dostawców
            return RedirectToAction(nameof(Suppliers));
        }


        //Strona edycji dostawcy
        public async Task<IActionResult> EditSupplier(int id)
        {

            //Pobranie dostawcy
            var supplier = await _supplierService.GetSupplierAsync(id);

            //Wyświetlenie strony edycji z dostawcą
            return View("Views/Dashboard/Suppliers/EditSuppliers.cshtml",supplier);
        }

        //Wykonanie edycji dostawcy
        [HttpPost]
        public async Task<IActionResult> EditSupplier(Supplier model)
        {

            //Sprawdzenie czy formularz jest dobrze wypełniony
            if (!ModelState.IsValid)
            {
                //Jeżeli nie jest powrót do strony edycji
                return View("Views/Dashboard/Products/EditSuppliers.cshtml", model);
            }


            //Edytowanie dostawcy
            await _supplierService.EditSupplierAsync(model);

            //Powrót do listy dostawców
            return RedirectToAction(nameof(Suppliers));
        }


        [HttpPost]
        public async Task<IActionResult> RemoveSupplier(int id)
        {

            //Usunięcie dostawcy
            await _supplierService.RemoveSupplierAsync(id);


            //Powrót do listy dostawców
            return RedirectToAction(nameof(Suppliers));
        }




        #endregion

    }
}
