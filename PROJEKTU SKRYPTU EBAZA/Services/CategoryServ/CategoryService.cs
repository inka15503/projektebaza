using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.CategoryServ
{
    public class CategoryService : ICategoryService
    {

        //Klasa do używania bazy danych
        private readonly ApplicationDbContext _context;


        //Stworzenie konstruktowa wraz w wstrzyknięciem klasy do używania bazy danych.
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        //Metoda dodania katerogii
        public async Task<ProductCategory> AddCategoryAsync(ProductCategory model)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            {

                //Stworzenie query do stworzenia kategorii w bazie danych
                await _context.AddAsync(model);
                //Wykonanie stworzonego query 
                await _context.SaveChangesAsync();
                //Zwrócenie kategorii
                return model;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }


        //Metoda edycji kategorii
        public async Task<ProductCategory> EditCategoryAsync(ProductCategory model)
        { 
            //Obsługa try/catch do próby wyłapania błędu
            try { 
                //Stworzenie query do zaktualizowania kategorii
                _context.Update(model);
                //Wykonanie stworzonego query 
                await _context.SaveChangesAsync();
                //Zwrócenie kategorii
                return model;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }


        //Metoda pobrania listy kategorii
        public async Task<List<ProductCategory>> GetCategoriesAsync()
        {
           //Pobranie listy kategorii wraz z przypisanymi do nich produktami i dadanie ich do zmiennej 'list'
           var list = await _context.ProductCategories
                .Include(x => x.Products)
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            //Zwrócenie zmiennej listy jako listy kategorii
            return list;
        }


        //Metoda pobrania jednej kategorii
        public async Task<ProductCategory> GetCategoryAsync(int categoryid)
        {
            //Pobranie kategorii której ID w bazie to 'categoryid' wraz z połączonymi z nią produktami
            var category = await _context.ProductCategories.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == categoryid);

            //Zwrócenie pobranej kategorii
            return category;
        }


        //Metoda usunięcia kategorii
        public async Task<bool> RemoveCategoryAsync(int productId)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            { 
                //Pobranie kategorii po szukanym Id z 'categoryid'
                var category = await GetCategoryAsync(productId);
                //Wyczyszczenie powiązanych produktów z kategorią, przez to produkty z tą kategorią będą bez kategorii
                category.Products.Clear();
                //Stworzenie query do usunięcia kategorii
                _context.Remove(category);

                //Wykonanie stworzonego query 
                await _context.SaveChangesAsync();

                //Jeżeli wszystko się wykonało to zwróci true
                return true;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci false
            catch 
            {
                return false;
            }


        }
    }
}
