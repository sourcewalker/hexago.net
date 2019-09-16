using AutoMapper;
using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;

namespace Infrastructure.AutoMapper.Helper
{
    public static class FailedTransactionMapper
    {
        public static FailedTransactionDto toDto(this FailedTransaction transaction)
            => Mapper.Map<FailedTransaction, FailedTransactionDto>(transaction);

        public static FailedTransaction toEntity(this FailedTransactionDto transaction)
            => Mapper.Map<FailedTransactionDto, FailedTransaction>(transaction);

        public static IEnumerable<FailedTransaction> toEntities(this IEnumerable<FailedTransactionDto> FailedTransactionDtos)
            => Mapper.Map<IEnumerable<FailedTransactionDto>, IEnumerable<FailedTransaction>>(FailedTransactionDtos);

        public static IEnumerable<FailedTransactionDto> toDtos(this IEnumerable<FailedTransaction> FailedTransactions)
            => Mapper.Map<IEnumerable<FailedTransaction>, IEnumerable<FailedTransactionDto>>(FailedTransactions);
    }
}
