using DataGridAirPort.Framework.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataGridAirPort.Framework.Contracts
{
    /// <summary>
    /// Интерфейс IAirPort определяет контракт для работы с аэропортом и его самолетами
    /// </summary>
    public interface IAirPort
    {
        Task<IReadOnlyCollection<Plane>> GetAllAsync();
        Task<Plane> AddAsync(Plane plane);
        Task EditAsync(Plane plane);
        Task<bool> DeleteAsync(Guid id);
        Task<IPlaneStats> GetStatsAsync();
    }
}
