using System;
using Core.Shared.DTO;
using Core.DAL.Interfaces;
using Core.Service.Interfaces;

namespace Core.Service.Domain
{
    public class FailedTransactionService : IFailedTransactionService
    {
        private readonly IFailedTransactionRepository _failedRepository;

        public FailedTransactionService(IFailedTransactionRepository failedRepository)
        {
            _failedRepository = failedRepository;
        }

        public bool Create(FailedTransactionDto transaction)
        {
            return _failedRepository.Add(transaction);
        }

        public bool Delete(Guid id)
        {
            return _failedRepository.Delete(id);
        }
    }
}
