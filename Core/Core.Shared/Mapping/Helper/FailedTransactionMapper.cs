using Core.Shared.DTO;
using Core.Model;
using System.Collections.Generic;

namespace Core.Shared.Mapping.Helper
{
    public static class FailedTransactionMapper
    {
        public static FailedTransactionDto toDto(this FailedTransaction transaction)
            => AutoMapper.Mapper.Map<FailedTransaction, FailedTransactionDto>(transaction);

        public static FailedTransaction toEntity(this FailedTransactionDto transaction)
            => AutoMapper.Mapper.Map<FailedTransactionDto, FailedTransaction>(transaction);

        public static IEnumerable<FailedTransaction> toEntities(this IEnumerable<FailedTransactionDto> FailedTransactionDtos)
            => AutoMapper.Mapper.Map<IEnumerable<FailedTransactionDto>, IEnumerable<FailedTransaction>>(FailedTransactionDtos);

        public static IEnumerable<FailedTransactionDto> toDtos(this IEnumerable<FailedTransaction> FailedTransactions)
            => AutoMapper.Mapper.Map<IEnumerable<FailedTransaction>, IEnumerable<FailedTransactionDto>>(FailedTransactions);
    }
}
