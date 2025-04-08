using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepository : IRepository<User>
    {

        private readonly IContext _context;
        public UserRepository(IContext context)
        {
            this._context = context;
        }


        public User Add(User item)
        {
            _context.users.Add(item);
            _context.save();
            return item;
        }

        public List<User> GetAll()
        {
            return _context.users.ToList();
        }

        public User GetById(int id)
        {
            return _context.users.FirstOrDefault(user => user.Id == id);
        }

        public User Update(int id, User item)
        {
            throw new NotImplementedException();
        }
    }
}
