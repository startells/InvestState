using InvestInfo.Model;
using InvestInfo.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace InvestInfo.Data
{
    public interface IOperationRepository
    {
        Task<List<OperationModel>> GetAllAsync();
        Task AddAsync(OperationModel operation);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
