using Microsoft.EntityFrameworkCore;
using Roulette.Core.Interfaces;
using Roulette.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Roulette.Infrastructure.Repositories
{
    public class RouletteRepository : IRouletteRepository
    {
        private readonly RouletteDBContext _context;
        public RouletteRepository(RouletteDBContext context)
        {
            _context = context;
        }
        public async Task<Core.Entities.Roulette> GetRouletteById(int id)
        {
            var roulettes = await _context.Roulettes.FindAsync(id);
            return roulettes;
        }
        public async Task<IEnumerable<Core.Entities.Roulette>> GetRoulettes()
        {
            var roulettes = await _context.Roulettes.ToListAsync();
            return roulettes;
        }
        public async Task<Core.Entities.Roulette> PostRoulette(Core.Entities.Roulette roulette)
        {
            _context.Roulettes.Add(roulette);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La ruleta no fue creada");
            }
            return roulette;
        }
        public async Task<Core.Entities.Roulette> PutRoulette(Core.Entities.Roulette roulette)
        {
            _context.Entry(roulette).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La ruleta no fue editada");
            }
            return roulette;
        }
        public async Task<bool> DeleteRoulette(Core.Entities.Roulette roulette)
        {
            int row;
            _context.Remove(roulette);
            try
            {
                row = await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La ruleta no fue eliminada");
            }
            return row > 0;
        }
        public async Task<string> OpeningRoulette(Core.Entities.Roulette roulette)
        {
            _context.Entry(roulette).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La ruleta no fue abierta, consulte al administrador");
            }
            return "La operación fue exitosa";
        }
        public async Task<string> CloseRoulette(Core.Entities.Roulette roulette)
        {
            _context.Entry(roulette).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("La ruleta no fue cerrada, consulte al administrador");
            }
            return "La ruleta fue cerrada con exito";
        }
    }
}
