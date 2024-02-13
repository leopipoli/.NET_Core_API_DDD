using Domain.Dtos.Cep;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Cep
{
    public interface ICepService
    {
        Task<CepDto> Get(Guid id);
        Task<CepDto> Get(string cep);
        Task<CepCreateResultDto> Post(CepCreateDto dto);
        Task<CepUpdateResultDto> Put(CepUpdateDto dto);
        Task<bool> Delete(Guid id);
    }
}
