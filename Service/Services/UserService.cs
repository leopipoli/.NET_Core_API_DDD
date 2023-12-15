using AutoMapper;
using Data.Repository;
using Domain.Dtos.User;
using Domain.Entities;
using Domain.Interfaces.Services.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserService : IUserService
    {
        private IRepository<UserEntity> _repository;
        public readonly IMapper _mapper;

        public UserService(IRepository<UserEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<UserDto> Get(Guid id)
        {
            var entity = await _repository.SelectAsync(id);
            return _mapper.Map<UserDto>(entity) ?? new UserDto();
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var entity = await _repository.SelectAsync();
            return _mapper.Map<IEnumerable<UserDto>>(entity);
        }

        public async Task<UserCreateResultDto> Post(UserCreateDto user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result =await _repository.InsertAsync(entity);

            return _mapper.Map<UserCreateResultDto>(result);
        }

        public async Task<UserUpdateResultDto> Put(UserUpdateDto user)
        {
            var model = _mapper.Map<UserModel>(user);
            var entity = _mapper.Map<UserEntity>(model);
            var result = await _repository.UpdateAsync(entity);

            return _mapper.Map<UserUpdateResultDto>(result);
        }
    }
}
