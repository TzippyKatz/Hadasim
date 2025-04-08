using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class SupplierRepository: IRepository<Supplier>
    {

        private readonly IContext _context;
        public SupplierRepository(IContext context)
        {
            this._context = context;
        }


        public Supplier Add(Supplier item)
        {
            _context.suppliers.Add(item);
            _context.save();
            return item;
        }

        public List<Supplier> GetAll()
        {
            return _context.suppliers.ToList();
        }

        public Supplier GetById(int id)
        {
            return _context.suppliers.FirstOrDefault(user => user.Id == id);
        }

        public Supplier Update(int id, Supplier item)
        {
            throw new NotImplementedException();
        }
    }
}
