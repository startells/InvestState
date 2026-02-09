using InvestInfo.Interface;
using InvestInfo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Services
{
    public class OperationService : IOperationService
    {
        private readonly InvestDbContext _context;

        public OperationService(InvestDbContext context)
        {
            _context = context; 
        }

        public async Task AddOperationAsync(Operation operation)
        {
            _context.Operations.Add(operation);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Operation>> GetAllOperationsAsync()
        {
            return await _context.Operations
                .Include(o => o.Category)
                .Include(o => o.Portfolio)
                .OrderByDescending(o => o.Date)
                .ToListAsync();
        }

        public async Task<Operation> GetOperationByIdAsync(int id)
        {
            try
            {
                return await _context.Operations
                    .Include(o => o.Category)
                    .Include(o => o.Portfolio)
                    .FirstAsync(o => o.Id == id);
            }
            catch (InvalidOperationException)
            {
                throw new KeyNotFoundException($"Операция с ID={id} не найдена");
            }
        }

        public async Task UpdateOperationAsync(Operation updatedOperation)
        {
            var existingOperation = await GetOperationByIdAsync(updatedOperation.Id);

            if (existingOperation == null) 
            {
                throw new InvalidOperationException("Операция для обновления не найдена");
            }

            _context.Entry(existingOperation).CurrentValues.SetValues(updatedOperation);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteOperationAsync(int id)
        {
            var operation = await GetOperationByIdAsync(id);
            
            if (operation == null)
            {
                return false;
            }

            _context.Operations.Remove(operation);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<string?> GetOperationCategoryName(int operationId)
        {
            var operation = await _context.Operations
                .Include(o => o.Category)
                .FirstOrDefaultAsync(o => o.Id == operationId);

            if (operation?.Category == null)
                return "Без категории";

            return operation.Category.Name;
        }

        public async Task AddOperationToCategory(int operationId, int categoryId)
        {
            var operation = await _context.Operations.FindAsync(operationId);
            var category = await _context.Categories.FindAsync(categoryId);

            if (operation != null && category != null) 
            {
                operation.Category = category; // Ef core автоматом ставит CategoryId
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveCategoryFromOperation(int operationId)
        {
            var operation = await _context.Operations.FindAsync(operationId);

            if (operation != null)
            {
                operation.Category = null; // Или operation.CategoryId = null
                await _context.SaveChangesAsync();
            }
        }
    }
}
