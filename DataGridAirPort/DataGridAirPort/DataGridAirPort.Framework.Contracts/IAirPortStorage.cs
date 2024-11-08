using DataGridAirPort.Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataGridAirPort.Framework.Contracts
{
    /// <summary>
    /// Интерфейс IAirPortStorage определяет контракт для хранилища самолетов
    /// </summary>
    public interface IAirPortStorage
    {
        Task<IReadOnlyCollection<Plane>> GetAllAsync();
        Task<Plane> AddAsync(Plane Plane);
        Task EditAsync(Plane Plane);
        Task<bool> DeleteAsync(Guid id);
    }
}
