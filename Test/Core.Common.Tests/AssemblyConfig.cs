using AutoMapper;
using Core.Shared.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Shared.Tests
{
    [TestClass]
    public class AssemblyConfig
    {
        [AssemblyInitialize]
        public static void Init(TestContext context)
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<DomainMapperProfile>();
                config.AddProfile(new DomainMapperProfile());
            });
        }

        [AssemblyCleanup]
        public static void Clean()
        {
            Mapper.Reset();
        }
    }
}
