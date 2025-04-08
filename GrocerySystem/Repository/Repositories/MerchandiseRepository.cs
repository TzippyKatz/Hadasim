using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    internal class MerchandiseRepository: IRepository<Merchandise>
    {

        private readonly IContext _context;
        public MerchandiseRepository(IContext context)
        {
            this._context = context;
        }


        public Merchandise Add(Merchandise item)
        {
            _context.merchs.Add(item);
            _context.save();
            return item;
        }

        public List<Merchandise> GetAll()
        {
            return _context.merchs.ToList();
        }

        public Merchandise GetById(int id)
        {
            return _context.merchs.FirstOrDefault(user => user.Id == id);
        }

        public Merchandise Update(int id, Merchandise item)
        {
            throw new NotImplementedException();
        }
    }
}
