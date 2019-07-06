﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Shared.Tests.Configuration
{
    [TestClass]
    public class ConfigurationTests
    {
        [TestMethod]
        public void Storing_And_Retrieving_From_Configuration_Object_should_work()
        {
            // Arrange
            var config = new Shared.Configuration.Configuration();

            // Act
            config.AddSetting("testText", "This is an insert test");
            config.Settings.testAdd = "This is an add test";

            //Assert
            Assert.AreEqual<string>(config.GetSetting<string>("testText"), "This is an insert test");
            Assert.AreEqual(config.Settings.testAdd, "This is an add test");
        }
    }
}
