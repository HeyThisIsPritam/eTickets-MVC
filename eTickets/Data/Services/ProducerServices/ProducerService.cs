using eTickets.Data.Base;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class ProducerService : EntityBaseRepository<Producer>, IProducerService
    {
        #region Alternet way code (Just remove EntityBaseRepository implementation)
        //private readonly AppDBContext _context;
        //public ProducerService(AppDBContext context)
        //{
        //    _context = context;
        //}
        //public async Task AddAsync(Producer entity)
        //{
        //    await _context.AddAsync(entity);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
        //    _context.Producers.Remove(result);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Producer>> GetAllAsync()
        //{
        //    var result = await _context.Producers.ToListAsync();
        //    return result;
        //}

        //public async Task<Producer> GetByIdAsync(int id)
        //{
        //    var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
        //    return result;
        //}

        //public async Task<Producer> UpdateAsync(int id, Producer entity)
        //{
        //    _context.Update(entity);
        //    await _context.SaveChangesAsync();
        //    return entity;
        //}
        #endregion
        public ProducerService(AppDBContext context) : base(context)
        {
        }
    }
}
