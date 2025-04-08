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
    public class SupplierMerchandiseService : ISuppMerchService
    {
        private readonly ISuppMerchRepository _repository;
        private readonly IMapper _mapper;

        public SupplierMerchandiseService(ISuppMerchRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public SupplierMerchandiseDto Add(SupplierMerchandiseDto item)
        {
            return _mapper.Map<SupplierMerchandiseDto>(_repository.Add(_mapper.Map<SupplierMerchandise>(item)));
        }

        public List<SupplierMerchandiseDto> GetAll()
        {
            return _mapper.Map<List<SupplierMerchandiseDto>>(_repository.GetAll());
        }

        public SupplierMerchandiseDto GetById(int id)
        {
            return _mapper.Map<SupplierMerchandiseDto>(_repository.GetById(id));
        }

        public List<SupplierMerchandiseDto> GetByIdSupp(int id)
        {
            return _mapper.Map<List<SupplierMerchandiseDto>>(_repository.GetByIdSupp(id));
        }

        public SupplierMerchandiseDto Update(int id, SupplierMerchandiseDto item)
        {
            throw new NotImplementedException();
        }
    }
}
