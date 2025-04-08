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
    public class MerchandiseService : IService<MerchandiseDto>
    {
        private readonly IRepository<Merchandise> _repository;
        private readonly IMapper _mapper;

        public MerchandiseService(IRepository<Merchandise> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public MerchandiseDto Add(MerchandiseDto item)
        {
            return _mapper.Map<MerchandiseDto>(_repository.Add(_mapper.Map<Merchandise>(item)));
        }

        public List<MerchandiseDto> GetAll()
        {
            return _mapper.Map<List<MerchandiseDto>>(_repository.GetAll());
        }

        public MerchandiseDto GetById(int id)
        {
            return _mapper.Map<MerchandiseDto>(_repository.GetById(id));
        }

        public MerchandiseDto Update(int id, MerchandiseDto item)
        {
            throw new NotImplementedException();
        }
    }
}
