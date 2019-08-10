using System;
using System.Collections.Generic;

namespace Infrastructure.InstantWin.Interfaces
{
    public interface IGenerator
    {
        IList<DateTimeOffset> Generate();
    }
}
