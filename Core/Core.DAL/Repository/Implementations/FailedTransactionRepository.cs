﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Shared.DTO;
using Core.Shared.Mapping.Helper;
using Core.DAL.EF.Repository.Base;
using Core.DAL.Interfaces;
using Core.Model;

namespace Core.DAL.EF.Repository.Implementations
{
    public class FailedTransactionRepository : RepositoryBase<FailedTransaction>, IFailedTransactionRepository
    {

        public IEnumerable<FailedTransactionDto> GetAll()
            => Table?.toDtos();

        public async Task<IEnumerable<FailedTransactionDto>> GetAllAsync()
            => await Task.Run(() => Table?.toDtos());

        public FailedTransactionDto GetById(Guid id)
            => Find(id)?.toDto();

        public async Task<FailedTransactionDto> GetByIdAsync(Guid id)
            => await Task.Run(() => Find(id)?.toDto());

        public IEnumerable<FailedTransactionDto> GetPaged(int pageNumber, int pageSize)
            => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos();

        public async Task<IEnumerable<FailedTransactionDto>> GetPagedAsync(int pageNumber, int pageSize)
            => await Task.Run(() => GetRange(pageSize * (pageNumber - 1), pageSize)?.toDtos());

        public bool Add(FailedTransactionDto failedTransaction)
        {
            failedTransaction.Id = failedTransaction.Id != default ? failedTransaction.Id : Guid.NewGuid();
            failedTransaction.CreatedDate = DateTime.UtcNow;
            return Add(failedTransaction?.toEntity(), true) > 0;
        }

        public async Task<bool> AddAsync(FailedTransactionDto failedTransaction)
        {
            failedTransaction.Id = failedTransaction.Id != default ? failedTransaction.Id : Guid.NewGuid();
            failedTransaction.CreatedDate = DateTime.UtcNow;
            return await Task.Run(() => Add(failedTransaction?.toEntity(), true) > 0);
        }

        public bool Update(FailedTransactionDto failedTransaction)
        {
            failedTransaction.ModifiedDate = DateTime.UtcNow;
            return Update(failedTransaction?.toEntity(), true) > 0;
        }

        public async Task<bool> UpdateAsync(FailedTransactionDto failedTransaction)
        {
            failedTransaction.ModifiedDate = DateTime.UtcNow;
            return await Task.Run(() => Update(failedTransaction?.toEntity(), true) > 0);
        }

        public bool Delete(FailedTransactionDto failedTransaction)
            => Delete(failedTransaction?.toEntity(), true) > 0;

        public async Task<bool> DeleteAsync(FailedTransactionDto failedTransaction)
            => await Task.Run(() => Delete(failedTransaction?.toEntity(), true) > 0);

        public bool Delete(Guid id)
        {
            var failedTransaction = Find(id);
            return Delete(failedTransaction, true) > 0;
        }

        public async Task<bool> DeleteAsync(Guid id)
            => await Task.Run(() =>
            {
                var failedTransaction = Find(id);
                return Delete(failedTransaction, true) > 0;
            });
    }
}
