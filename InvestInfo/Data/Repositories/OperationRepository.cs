using InvestInfo.Model;
using InvestInfo.View;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace InvestInfo.Data.Repositories
{
    public class OperationRepository : IOperationRepository
    {
        private readonly AppDbContext _context;

        public OperationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<OperationModel>> GetAllAsync()
        {
            return await _context.Operations
                .OrderByDescending(o => o.Date)
                .ToListAsync();
        }

        public async Task AddAsync(OperationModel operation)
        {
            await _context.Operations.AddAsync(operation);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Operations.FindAsync(id);
            if (entity != null)
                _context.Operations.Remove(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
