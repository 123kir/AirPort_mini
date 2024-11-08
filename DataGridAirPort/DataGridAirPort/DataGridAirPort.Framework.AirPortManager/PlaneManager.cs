using DataGridAirPort.Framework.Contracts; 
using DataGridAirPort.Framework.Contracts.Models; 
using DataGridAirPort.Framework.AirPortManager.Models; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace DataGridAirPort.Framework.PlaneManager
{
    /// <summary>
    /// Менеджер для работы с самолетами в аэропорту
    /// </summary>
    public class PlaneManager : IAirPort 
    {
        private IAirPortStorage airPortStorage; 

        /// <summary>
        /// Конструктор для инициализации менеджера самолетов
        /// </summary>
        /// <param name="airPortStorage">Хранилище данных аэропорта</param> // 
        public PlaneManager(IAirPortStorage airPortStorage) 
        {
            this.airPortStorage = airPortStorage; 
        }

        /// <summary>
        /// Асинхронно добавляет новый самолет в хранилище
        /// </summary>
        /// <param name="plane">Модель самолета для добавления</param> 
        /// <returns>Возвращает добавленный самолет</returns> 
        public async Task<Plane> AddAsync(Plane plane) 
        {
            var result = await airPortStorage.AddAsync(plane); 
            result.RentalAmount = (decimal)plane.CalculateTotalCost(); 
            return result;
        }

        /// <summary>
        /// Асинхронно удаляет самолет по указанному идентификатору
        /// </summary>
        /// <param name="id">Идентификатор самолета, который нужно удалить</param>
        /// <returns>Возвращает результат удаления</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await airPortStorage.DeleteAsync(id);
            return result;
        }

        /// <summary>
        /// Асинхронно редактирует информацию о самолете
        /// </summary>
        /// <param name="plane">Модель самолета с обновленной информацией</param>
        /// <returns>Возвращает задачу, представляющую асинхронную операцию</returns>
        public Task EditAsync(Plane plane)
        {
            plane.RentalAmount = (int)plane.CalculateTotalCost();
            return airPortStorage.EditAsync(plane);
        }

        /// <summary>
        /// Асинхронно получает информацию о всех самолетах
        /// </summary>
        /// <returns>Возвращает коллекцию всех самолетов</returns>
        public Task<IReadOnlyCollection<Plane>> GetAllAsync() 
        {
            var planes = airPortStorage.GetAllAsync().Result;

            foreach (var plane in planes)
            {
                plane.RentalAmount = (decimal)plane.CalculateTotalCost();
            }
            return Task.FromResult(planes);
        }

        /// <summary>
        /// Асинхронно получает статистику по самолетам
        /// </summary>
        /// <returns>Возвращает объект статистики по самолетам</returns>
        public async Task<IPlaneStats> GetStatsAsync()
        {
            var items = await airPortStorage.GetAllAsync();
            decimal Total_passengers = items.Count(i => i.Number_crew < 7);

            foreach (var plane in items)
            {
                plane.RentalAmount = (decimal)plane.CalculateTotalCost();
            }

            return new PlaneStatsModel
            {
                Count = items.Count,
                Total_passengers = items.Sum(x => x.Number_passenger),

                Entire_crew = items.Sum(x => x.Number_crew),
                Total_coins = items.Sum(x => x.RentalAmount), 
            };
        }
    }
}
