using MCRSearch.src.MCRSearch.Core.Entities;
using MCRSearch.src.MCRSearch.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MCRSearch.src.MCRSearch.Infrastructure.Repositories
{
    /// <summary>
    /// Repositorio para gestionar operaciones relacionadas con la disponibilidad de vehiculos en la base de datos.
    /// </summary>
    public class AvailableVehicleRepository : IAvailableVehicleRepository
    {
        private readonly ApplicationDbContext _context;
        public AvailableVehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles.
        /// </summary>
        public async Task<List<AvailableVehicle>> GetAvailableVehicles()
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun localidad de recogida y de retorno por nombre.
        /// </summary>
        public async Task<List<AvailableVehicle>> GetAvailableVehicles(string pickUpCityName, string returnCityName)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(av => av.PickUpCity.Name.ToLower().Trim() == pickUpCityName.ToLower().Trim() && av.ReturnCity.Name.ToLower().Trim() == returnCityName.ToLower().Trim()).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun localidad de recogida y de retorno por ID.
        /// </summary>
        public async Task<List<AvailableVehicle>> GetAvailableVehicles(int pickUpCityId, int returnCityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(av=>av.PickUpCityId == pickUpCityId && av.ReturnCityId == returnCityId).ToListAsync();
        }

        /// <summary>
        /// Obtiene el vehiculo disponible según su ID.
        /// </summary>
        public async Task<AvailableVehicle?> GetAvailableVehicle(int id)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .FirstOrDefaultAsync(av => av.Id == id);
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun la ID de la clase del vehiculo.
        /// </summary>
        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInVehicle(int vehicleId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleModel)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleBrand)
                .Include(av => av.Vehicle)
                    .ThenInclude(v => v.VehicleType)
                .Include(av => av.ReturnCity)
                .Include(av => av.PickUpCity)
                .Where(ve=> ve.VehicleId == vehicleId).ToListAsync();
        }

        /// <summary>
        /// Obtiene todos los vehiculos disponibles segun la ciudad.
        /// </summary>
        public async Task<List<AvailableVehicle>> GetAvailableVehiclesInCity(int cityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.ReturnCity)
                    .ThenInclude(c => c.Department)
                    .ThenInclude(d => d.Country)
                .Include(av => av.PickUpCity)
                    .ThenInclude(c => c.Department)
                    .ThenInclude(d => d.Country)
                .Where(c => c.PickUpCityId == cityId || c.ReturnCityId == cityId).ToListAsync();
        }

        /// <summary>
        /// Valida si el mercado es valido segun la ubicacion del cliente y la localidad de recogida por ID.
        /// </summary>
        public async Task<bool> IsEnabledMarket(int localizedCustomerCountryId, int pickUpCityId)
        {
            return await _context.AvailableVehicles
                .Include(av => av.PickUpCity.Department)
                .AnyAsync(av => av.PickUpCityId == pickUpCityId && av.PickUpCity.Department.CountryId == localizedCustomerCountryId);
        }

        /// <summary>
        /// Valida si el mercado es valido segun la ubicacion del cliente y la localidad de recogida por nombre. 
        /// </summary>
        public async Task<bool> IsEnabledMarket(string localizedCustomerCountryName, string pickUpCityName)
        {
            return await _context.AvailableVehicles
                .Include(av => av.PickUpCity.Department)
                .AnyAsync(av => av.PickUpCity.Name.ToLower().Trim() == pickUpCityName.ToLower().Trim() && av.PickUpCity.Department.Country.Name.ToLower().Trim() == localizedCustomerCountryName.ToLower().Trim());
        }

        /// <summary>
        /// Agrega un vehiculo a la disponibilidad. 
        /// </summary>
        public async Task<bool> CreateAvailableVehicle(AvailableVehicle availableVehicle)
        {
            availableVehicle.CreateDate = DateTime.Now;
            await _context.AvailableVehicles.AddAsync(availableVehicle);
            return await Save();
        }

        /// <summary>
        /// Actualiza la disponibilidad de un vehiculo.
        /// </summary>
        public async Task<bool> UpdateAvailableVehicle(AvailableVehicle availableVehicle)
        {
            availableVehicle.UpdatedDate = DateTime.Now;
            _context.AvailableVehicles.Update(availableVehicle);
            return await Save();
        }

        /// <summary>
        /// Elimina la disponibilidad de un vehiculo.
        /// </summary>
        public async Task<bool> DeleteAvailableVehicle(AvailableVehicle availableVehicle)
        {
            _context.AvailableVehicles.Remove(availableVehicle);
            return await Save();
        }

        /// <summary>
        /// Guarda los cambios en la BD.
        /// </summary>
        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
