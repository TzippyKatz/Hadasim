using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class OrderRepository : IOrderRepository
    {

        private readonly IContext _context;
        public OrderRepository(IContext context)
        {
            this._context = context;
        }


        public Order Add(Order item)
        {
            _context.orders.Add(item);
            _context.save();
            return item;
        }

        public List<Order> GetAll()
        {
            return _context.orders.ToList();
        }

        public Order GetById(int id)
        {
            return _context.orders.FirstOrDefault(order => order.Id == id);
        }

        public List<Order> GetBySupplierId(int supplierId)
        {
            return _context.orders.Where(order => order.SupplietId == supplierId).ToList();
        }

        public List<Order> GetPendingOrders()
        {
            return _context.orders.Where(order => order.Status == States.Pending).ToList();
        }

        public Order Update(int id, Order item)
        {
            Order o = GetById(id);
            o.Status = item.Status;

            _context.orders.Update(o);
            _context.save();  // תקפידי לקרוא ל-SaveChanges() (לא save())

            return o;
        }
    }
}
