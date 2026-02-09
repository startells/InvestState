using InvestInfo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Interface
{
    public interface IOperationService
    {
        Task AddOperationAsync(Operation operation);
        Task<List<Operation>> GetAllOperationsAsync();
        Task<Operation> GetOperationByIdAsync(int id);
        Task UpdateOperationAsync(Operation updatedOperation);
        Task<bool> DeleteOperationAsync(int id);
        Task<string?> GetOperationCategoryName(int operationId);
        Task AddOperationToCategory(int operationId, int categoryId);
        Task RemoveCategoryFromOperation(int operationId);
    }
}
