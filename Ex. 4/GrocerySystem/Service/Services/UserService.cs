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
    public class UserService: IService<UserDto>
    {
        private readonly IRepository<User> _repository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public UserDto Add(UserDto item)
        {
            return _mapper.Map<UserDto>(_repository.Add(_mapper.Map<User>(item)));
        }

        public List<UserDto> GetAll()
        {
            return _mapper.Map<List<UserDto>>(_repository.GetAll());
        }

        public UserDto GetById(int id)
        {
            return _mapper.Map<UserDto>(_repository.GetById(id));
        }

        public UserDto Update(int id, UserDto item)
        {
            throw new NotImplementedException();
        }
    }
}
