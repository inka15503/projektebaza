using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.SupplierServ
{
    public interface ISupplierService
    {
        public Task<List<Supplier>> GetListSuppliersAsync();
        public Task<Supplier> GetSupplierAsync(int supplierid);
        public Task<Supplier> AddSupplierAsync(Supplier model);
        public Task<Supplier> EditSupplierAsync(Supplier model);
        public Task<bool> RemoveSupplierAsync(int supplierId);
    }
}
