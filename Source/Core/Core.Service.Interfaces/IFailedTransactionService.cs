using Core.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service.Interfaces
{
    public interface IFailedTransactionService
    {
        bool Create(FailedTransactionDto transaction);

        bool Delete(Guid id);
    }
}
