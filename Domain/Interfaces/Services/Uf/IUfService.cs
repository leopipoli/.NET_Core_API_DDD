using Domain.Dtos.Uf;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Domain.Interfaces.Services.Uf
{
    public interface IUfService
    {
        Task<UfDto> Get(Guid Id);
        Task<IEnumerable<UfDto>> GetAll();
    }
}
