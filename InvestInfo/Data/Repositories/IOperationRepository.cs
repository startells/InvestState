using InvestInfo.Model;
using InvestInfo.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Data
{
    public interface IOperationRepository
    {
        event EventHandler? OperationsChanged;

        Task<List<OperationModel>> GetAllAsync();
        Task AddAsync(OperationModel operation);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
