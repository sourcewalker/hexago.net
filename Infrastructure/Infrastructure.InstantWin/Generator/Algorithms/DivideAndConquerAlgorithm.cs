using Infrastructure.InstantWin.Configuration;
using Infrastructure.InstantWin.Enums;
using Infrastructure.InstantWin.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.InstantWin.Generator.Algorithms
{
    public class DivideAndConquerAlgorithm : IGenerator
    {
        public IList<DateTimeOffset> Generate()
        {
            var startDate = ProviderConfiguration.Campaign.StartDate;
            var endDate = ProviderConfiguration.Campaign.EndDate;
            var openHour = ProviderConfiguration.Campaign.OpenTime;
            var closeHour = ProviderConfiguration.Campaign.CloseTime;

            // Dividing Timespan between start and end date into multiple intervals
            // According to limit option
            var intervalLength = GetDivisionInterval();
            var limitPerInterval = ProviderConfiguration.Generator.LimitNumber;

            var firstIntervalDate = startDate;

            if (firstIntervalDate.TimeOfDay < openHour.TimeOfDay)
            {
                firstIntervalDate = firstIntervalDate.Date + openHour.TimeOfDay;
            }

            if (closeHour.TimeOfDay < firstIntervalDate.TimeOfDay)
            {
                firstIntervalDate = firstIntervalDate.AddDays(1).Date + openHour.TimeOfDay;
            }

            var lastIntervalDate = endDate <= (firstIntervalDate + intervalLength) ?
                                    endDate :
                                    (firstIntervalDate + intervalLength);

            var dateList = new List<DateTimeOffset>();
            var random = new Random();
            byte[] bytes = new byte[8];
            var randomAddition = new Random();

            do
            {
                for (var i = 1; i <= limitPerInterval; i++)
                {
                    random.NextBytes(bytes);
                    var ranDouble = randomAddition.NextDouble();
                    var randomDate = GenerateRandomDateBetweenInterval(bytes, firstIntervalDate, lastIntervalDate);
                    var differentElement = EnsureDifferentDate(ranDouble, randomDate, dateList, firstIntervalDate, lastIntervalDate);
                    dateList.Add(differentElement);
                }

                var nextInterval = SwitchToNextInterval(lastIntervalDate, intervalLength, endDate);
                firstIntervalDate = nextInterval.nextIntervalStart;
                lastIntervalDate = nextInterval.nextIntervalEnd;
            }
            while (lastIntervalDate < endDate);

            return dateList;
        }

        private TimeSpan GetDivisionInterval()
        {
            var limitOptions = ProviderConfiguration.Generator.limitOption;

            switch (limitOptions)
            {
                case GeneratorLimitOptions.LimitPerHour:
                    return TimeSpan.FromHours(1);
                case GeneratorLimitOptions.LimitPerDay:
                    return TimeSpan.FromDays(1);
                case GeneratorLimitOptions.LimitPerMonth:
                    return TimeSpan.FromDays(30);
                case GeneratorLimitOptions.LimitPerCampaign:
                default:
                    return ProviderConfiguration.Campaign.EndDate - ProviderConfiguration.Campaign.StartDate;
            }
        }

        private (DateTime nextIntervalStart, DateTime nextIntervalEnd) SwitchToNextInterval(
            DateTime previousIntervalEnd,
            TimeSpan intervalLength,
            DateTime EndLimit)
        {
            var openHour = ProviderConfiguration.Campaign.OpenTime;
            var closeHour = ProviderConfiguration.Campaign.CloseTime;
            var nextIntervalStart = previousIntervalEnd;

            if (ProviderConfiguration.Generator.limitOption == GeneratorLimitOptions.LimitPerHour)
            {
                if (nextIntervalStart.TimeOfDay < openHour.TimeOfDay)
                {
                    nextIntervalStart = nextIntervalStart.Date + openHour.TimeOfDay;
                }

                if (closeHour.TimeOfDay <= nextIntervalStart.TimeOfDay)
                {
                    nextIntervalStart = nextIntervalStart.AddDays(1).Date + openHour.TimeOfDay;
                }
            }

            var nextIntervalEnd = EndLimit <= (nextIntervalStart + intervalLength) ?
                                    EndLimit :
                                    (nextIntervalStart + intervalLength);

            if (nextIntervalStart > nextIntervalEnd)
            {
                nextIntervalEnd = nextIntervalStart + intervalLength;
            }

            return (nextIntervalStart, nextIntervalEnd);
        }

        private DateTime GenerateRandomDateBetweenInterval(byte[] bytes, DateTime firstDate, DateTime lastDate)
        {
            var openHour = ProviderConfiguration.Campaign.OpenTime;
            var closeHour = ProviderConfiguration.Campaign.CloseTime;
            var timeSpan = lastDate - firstDate;
            var additionSpan = GetRandomTimeInTimeSpan(bytes, timeSpan);
            var newRandom = firstDate + additionSpan;

            // Ensure Interval time is between open and close hours
            if (newRandom.TimeOfDay < openHour.TimeOfDay || closeHour.TimeOfDay < newRandom.TimeOfDay)
            {
                var openHourInterval = closeHour.TimeOfDay - openHour.TimeOfDay;
                var addSpan = GetRandomTimeInTimeSpan(bytes, openHourInterval);
                var randomTime = openHour.TimeOfDay + addSpan;
                newRandom = newRandom.Date + randomTime;
            }

            return newRandom;
        }

        private TimeSpan GetRandomTimeInTimeSpan(byte[] bytes, TimeSpan timeSpan)
        {
            var ranInt64 = Math.Abs(BitConverter.ToInt64(bytes, 0)) % timeSpan.Ticks;
            return new TimeSpan(ranInt64);
        }

        private DateTime EnsureDifferentDate(
            double ranDouble,
            DateTime currentDatetime,
            IEnumerable<DateTimeOffset> dateList,
            DateTime firstDate,
            DateTime lastDate)
        {
            if (!dateList.Contains(currentDatetime))
            {
                return currentDatetime;
            }
            else
            {
                do
                {
                    if (ranDouble <= 0.5)
                    {
                        currentDatetime -= TimeSpan.FromSeconds(ranDouble * 10);
                    }
                    else
                    {
                        currentDatetime += TimeSpan.FromSeconds(ranDouble * 10);
                    }
                }
                while (dateList.Contains(currentDatetime) ||
                        currentDatetime < firstDate ||
                        lastDate < currentDatetime);
                return currentDatetime;
            }
        }
    }
}
