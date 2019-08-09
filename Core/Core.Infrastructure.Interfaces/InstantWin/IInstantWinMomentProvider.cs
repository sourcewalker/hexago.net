using System;
using System.Collections.Generic;

namespace Core.Infrastructure.Interfaces.InstantWin
{
    public interface IInstantWinMomentProvider
    {
        IList<DateTime> GenerateWinningMoments();

        IList<(Guid Id, string Name)> AllocatePrizes(IList<Allocable> allocable, int instantWinNumber);
    }
}
