using Domain.Dtos.User;
using Domain.Entities;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Xunit;

namespace Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTesteService
    {
        [Fact(DisplayName = "É possível mapear os modelos")]
        public void E_Possivel_Mappear_os_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreateAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(item);
            }

            //Model => Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreateAt, model.CreateAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            //Entity para Dto
            var userDto = Mapper.Map<UserDto>(entity);
            Assert.Equal(userDto.Id, entity.Id);
            Assert.Equal(userDto.Name, entity.Name);
            Assert.Equal(userDto.Email, entity.Email);
            Assert.Equal(userDto.CreateAt, entity.CreateAt);

            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listaDto[i].CreateAt, listaEntity[i].CreateAt);
            }

            var userCreateResultDto = Mapper.Map<UserCreateResultDto>(entity);
            Assert.Equal(userCreateResultDto.Id, entity.Id);
            Assert.Equal(userCreateResultDto.Name, entity.Name);
            Assert.Equal(userCreateResultDto.Email, entity.Email);
            Assert.Equal(userCreateResultDto.CreateAt, entity.CreateAt);

            var userUpdateResultDto = Mapper.Map<UserUpdateResultDto>(entity);
            Assert.Equal(userUpdateResultDto.Id, entity.Id);
            Assert.Equal(userUpdateResultDto.Name, entity.Name);
            Assert.Equal(userUpdateResultDto.Email, entity.Email);
            Assert.Equal(userUpdateResultDto.UpdateAt, entity.UpdateAt);

            //Dto para Model
            var userModel = Mapper.Map<UserModel>(userDto);
            Assert.Equal(userModel.Id, userDto.Id);
            Assert.Equal(userModel.Name, userDto.Name);
            Assert.Equal(userModel.Email, userDto.Email);
            Assert.Equal(userModel.CreateAt, userDto.CreateAt);

            var userCreateDto = Mapper.Map<UserCreateDto>(userModel);
            Assert.Equal(userCreateDto.Name, userModel.Name);
            Assert.Equal(userCreateDto.Email, userModel.Email);

            var userUpdateDto = Mapper.Map<UserUpdateDto>(userModel);
            Assert.Equal(userUpdateDto.Id, userModel.Id);
            Assert.Equal(userUpdateDto.Name, userModel.Name);
            Assert.Equal(userUpdateDto.Email, userModel.Email);
        }
    }
}
