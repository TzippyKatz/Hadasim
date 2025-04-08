using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SupplierMerchandiseRepository : ISuppMerchRepository
    {

        private readonly IContext _context;
        public SupplierMerchandiseRepository(IContext context)
        {
            this._context = context;
        }


        public SupplierMerchandise Add(SupplierMerchandise item)
        {
            _context.supplierMerchandises.Add(item);
            _context.save();
            return item;
        }

        public List<SupplierMerchandise> GetAll()
        {
            return _context.supplierMerchandises.ToList();
        }

        //מחזיר מוצר בודד ולא רשימה
        public SupplierMerchandise GetById(int id)
        {
            return _context.supplierMerchandises.FirstOrDefault(user => user.SupplierId == id);
        }

        public List<SupplierMerchandise> GetByIdSupp(int id)
        {
            return _context.supplierMerchandises.Where(user => user.SupplierId == id).ToList();
        }

        // פונקציה לשמירה של SupplierMerchandise
        public void AddSupplierMerchandise(SupplierMerchandise supplierMerchandise)
        {
            _context.supplierMerchandises.Add(supplierMerchandise); // הוספה של אובייקט SupplierMerchandise לטבלה
            _context.save(); // שמירה במסד הנתונים
        }

        public SupplierMerchandise Update(int id, SupplierMerchandise item)
        {
            throw new NotImplementedException();
        }
    }
}
