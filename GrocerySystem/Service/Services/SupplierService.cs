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
    public class SupplierService: IService<SupplierDto>
    {
        private readonly IRepository<Supplier> _repository;
        private readonly IMapper _mapper;

        public SupplierService(IRepository<Supplier> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public SupplierDto Add(SupplierDto item)
        {
            //if (_repository.GetAll().Any(x => x.Email == item.Email))
            //{
            //    throw new InvalidOperationException("Email already exists in the system");
            //}

            return _mapper.Map<SupplierDto>(_repository.Add(_mapper.Map<Supplier>(item)));
        }

        public List<SupplierDto> GetAll()
        {
            return _mapper.Map<List<SupplierDto>>(_repository.GetAll());
        }

        public SupplierDto GetById(int id)
        {
            return _mapper.Map<SupplierDto>(_repository.GetById(id));
        }

        public SupplierDto Update(int id, SupplierDto item)
        {
            throw new NotImplementedException();
        }
    }
}
