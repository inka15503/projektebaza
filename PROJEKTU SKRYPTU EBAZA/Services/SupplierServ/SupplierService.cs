using Microsoft.EntityFrameworkCore;
using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.SupplierServ
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext _contex;

        public SupplierService(ApplicationDbContext contex)
        {
            _contex = contex;
        }

        public async Task<Supplier> AddSupplierAsync(Supplier model)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            {
                //Utworzenie Query dodania dostawcy do bazy danych
                await _contex.AddAsync(model);

                //Wykonanie wcześniej utworzonego Query
                await _contex.SaveChangesAsync();
                return model;

            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
         
        }

        public async Task<Supplier> EditSupplierAsync(Supplier model)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            {
                //Stworzenie Query aktualizacji dostawcy
                _contex.Update(model);

                //Wykonanie wcześniej utworzonego Query
                await _contex.SaveChangesAsync();
                return model;
            }
            //Jeżeli podczas wykonywania czynności wystąpi błąd to catch go złapie i zwróci null
            catch
            {
                return null;
            }
        }

        public async Task<List<Supplier>> GetListSuppliersAsync()
        {
            //Pobranie dostawców z bazy danych wraz z produktami do nich przypisanymi
            var list = await _contex.Suppliers.Include(x => x.Products).ToListAsync();
            //Zwrócenie listy dostawców
            return list;
        }

        public async Task<Supplier> GetSupplierAsync(int supplierid)
        {
            //Pobranie dostawcy z bazy danych wraz z produktami do niego przypisanymi
            var list = await _contex.Suppliers.Include(x => x.Products).FirstOrDefaultAsync(x => x.Id == supplierid);
            //Zwrócenie listy dostawców
            return list;
        }

        public async Task<bool> RemoveSupplierAsync(int supplierId)
        {
            //Obsługa try/catch do próby wyłapania błędu
            try
            {
                //Pobranie dostawcy po ID
                var supplier = await GetSupplierAsync(supplierId);
                //Wyczyszczenie powiązanych produktów z dostawcą, usunie tego dostawcę z tych produktów bez usuwania produktów.
                supplier.Products.Clear();

                //Tworzenie Query usunięcia dostawcy
                _contex.Suppliers.Remove(supplier);
                
                //Wykonanie stworzonych query
                await _contex.SaveChangesAsync();

                //Zwrócenie true
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
