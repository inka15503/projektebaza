using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.ProductServ
{
    public class ProductService : IProductService
    {
        //Klasa do używania bazy danych
        private readonly ApplicationDbContext _context;


        //Stworzenie konstruktowa wraz w wstrzyknięciem klasy do używania bazy danych.
        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metoda dodania produktu
        public async Task<Product> AddProductAsync(Product product, IFormFile file)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            { 
                //Sprawdzenie czy został załączony plik przy dodawaniu produktu
                if (file != null)
                {
                    //Jeżeli tak

                    //Stworzenie ścieżki pliku do zapisu która zawiera "_photoNazwaProduktuDataAktualnaWMinucieDataAktualnaWSekundzie.Rozszerzenie"
                    var pathfile = Path.Combine("/img/photos/", $"photo_{product.Name}{DateTime.UtcNow.Minute}{DateTime.UtcNow.Second}{Path.GetExtension(file.FileName)}");

                    //Jeżeli plik o takiej ścieżce istnieje
                    if (File.Exists("wwwroot" + product.ImgPath))
                    {
                        //Usuń plik
                        File.Delete("wwwroot" + product.ImgPath);
                    }

                    //Zapisanie pliku do stworzonej ścieżki
                    using (var stream = new FileStream("wwwroot" + pathfile, FileMode.Create))
                    {

                        //Zapis pliku
                        await file.CopyToAsync(stream);
                        //Przypisanie ścieżki do parametru 'ImgPath'
                        product.ImgPath = pathfile;
                    }
                }

                //Stworzenie query do dodania produktu do bazy danych
                await _context.AddAsync(product);

                //Wykonanie query
                await _context.SaveChangesAsync();

                //Zwrócenie produktu
                return product;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }

        //Metoda edycji produktu 
        public async Task<Product> EditProductAsync(Product product)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            { 
                //Stworzenie query do aktualizacji produktu
                _context.Update(product);

                //Wykonanie query
                await _context.SaveChangesAsync();

                return product;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }

        //Metoda pobrania produktu po podaniu Id kategorii
        public async Task<List<Product>> GerProductsFromCategoryAsync(int categoryid)
        {
            //Pobranie listy produktów gdzie id kategorii równa się 'categoryid' i przypisanie do zmiennej 'products'
            var products = await _context.Products.Where(x => x.CategoryId == categoryid).ToListAsync();

            //Zwrócenie listy produktów
            return products;
        }


        //Metoda pobrania produktu po Id
        public async Task<Product> GetProductAsync(int id)
        {  
            //Obsługa try/catch do próby wyłapania błędu
            try { 
                //Pobranie produktu którego ID równa się 'id' 
                var product = await _context.Products.FindAsync(id);
                //Zwrócenie produktu
                return product;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }

        //Metoda pobrania listy produktów
        public async Task<List<Product>> GetProductsAsync()
        {
            //Pobranie listy produktów wraz z kategorią i dostawcami 
            var products = await _context.Products.Include(x => x.Category).Include(x => x.Supplier).ToListAsync();
            //zwrócenie listy produktów
            return products;
        }


        //Metoda pobrania produktów po Id dostawców
        public async Task<List<Product>> GetProductsFromSupplierAsync(int id)
        {
            //Pobranie listy produktów gdzie supplierId równa się id;
            var products = await _context.Products.Where(x => x.SupplierId == id).ToListAsync();
            //Zwrócenie listy produktów
            return products;
        }

        //Metoda usuwania produktu

        public async Task<bool> RemoveProductAsync(int productId)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            {
                //Pobranie produktu do usunięcia
                var product = await GetProductAsync(productId);
                //Wyczyszczenie kategorii i dostawcy danego produktu
                product.Category = null;
                product.Supplier = null;

                //Stworzenie query do usunięcia produktu
                _context.Products.Remove(product);
                //Wykonanie query 
                await _context.SaveChangesAsync();

                //Zwrócenie true
                return true;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return false;
            }


        }
    }
}
