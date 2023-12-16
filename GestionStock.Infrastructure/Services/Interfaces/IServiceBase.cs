using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionStock.Infrastructure.Services.Interfaces
{
    public interface IServiceBase<TOuputDto, TCreateDto, TUpdateDto>
    {
        Task<List<TOuputDto>> GetAllAsync();
        Task<TOuputDto> GetIdAsync(Guid id);
        Task<TOuputDto> CreateAsync(TCreateDto createDto);
        Task<TOuputDto> UpdateAsync(Guid Id, TUpdateDto updateDto);
        void DeleteAsync(Guid Id);
    }
}
