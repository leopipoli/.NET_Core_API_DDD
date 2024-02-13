using Domain.Dtos.Municipio;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services.Municipio
{
    public interface IMunicipioService
    {
        Task<MunicipioDto> Get(Guid id);
        Task<MunicipioCompletoDto> GetCompleteById(Guid id);
        Task<MunicipioCompletoDto> GetCompleteByIBGE(int codIBGE);
        Task<IEnumerable<MunicipioDto>> GetAll();
        Task<MunicipioCreateResultDto> Post(MunicipioCreateDto municipio);
        Task<MunicipioUpdateResultDto> Put(MunicipioCreateDto municipio);
        Task<bool> Delete(Guid id);
    }
}
