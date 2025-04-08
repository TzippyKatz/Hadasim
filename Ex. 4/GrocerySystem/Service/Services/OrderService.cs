using AutoMapper;
using Repository.Entities;
using Repository.Interfaces;
using Service.Dto;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public OrderDto Add(OrderDto item)
        {
            return _mapper.Map<OrderDto>(_repository.Add(_mapper.Map<Order>(item)));
        }

        public List<OrderDto> GetAll()
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetAll());
        }

        public OrderDto GetById(int id)
        {
            return _mapper.Map<OrderDto>(_repository.GetById(id));
        }

        public List<OrderDto> GetBySupplierId(int supplierId)
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetBySupplierId(supplierId));
        }


        public List<OrderDto> GetPendingOrders()
        {
            return _mapper.Map<List<OrderDto>>(_repository.GetPendingOrders());
        }

        public OrderDto Update(int id, OrderDto item)
        {
            return _mapper.Map<OrderDto>(_repository.Update(id, _mapper.Map<Order>(item)));
        }
    }
}
