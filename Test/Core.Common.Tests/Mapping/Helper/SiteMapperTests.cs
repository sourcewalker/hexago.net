using AutoMapper;
using Core.Shared.DTO;
using Core.Shared.Mapping.Helper;
using Core.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Shared.Tests.Mapping.Helper
{
    [TestClass]
    public class SiteMapperTests
    {

        [TestMethod]
        public void Convert_site_entity_to_dto_should_work()
        {
            // Arrange
            var entity = new Site
            {
                Culture = "en-GB",
                Name = "uk",
                Domain = "cadbury.co.uk",
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            // Act
            var dto = entity.toDto();

            //Assert
            Assert.AreEqual<string>(dto.Culture, entity.Culture);
            Assert.AreEqual<string>(dto.Name, entity.Name);
            Assert.AreEqual<string>(dto.Domain, entity.Domain);
        }

        [TestMethod]
        public void Convert_site_dto_to_entity_should_work()
        {
            // Arrange
            var dto = new SiteDto
            {
                Culture = "en-GB",
                Name = "uk",
                Domain = "cadbury.co.uk"
            };

            // Act
            var entity = dto.toEntity();

            //Assert
            Assert.AreEqual<string>(dto.Culture, entity.Culture);
            Assert.AreEqual<string>(dto.Name, entity.Name);
            Assert.AreEqual<string>(dto.Domain, entity.Domain);
        }

        [TestMethod]
        public void Convert_colletion_site_dto_to_entity_should_work()
        {
            // Arrange
            List<SiteDto> dtos = new List<SiteDto>();
            for (int i = 0; i < 5; i++)
            {
                var dto = new SiteDto
                {
                    Culture = "en-GB",
                    Name = "uk",
                    Domain = "cadbury.co.uk"
                };
                dtos.Add(dto);
            }


            // Act
            var entities = dtos.toEntities().ToList();

            //Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual<string>(dtos[i].Culture, entities[i].Culture);
                Assert.AreEqual<string>(dtos[i].Name, entities[i].Name);
                Assert.AreEqual<string>(dtos[i].Domain, entities[i].Domain);
            }
        }

        [TestMethod]
        public void Convert_collection_site_entity_to_dto_should_work()
        {
            // Arrange
            List<Site> entities = new List<Site>();
            for (int i = 0; i < 5; i++)
            {
                var entity = new Site
                {
                    Culture = "en-GB",
                    Name = "uk",
                    Domain = "cadbury.co.uk",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow
                };
                entities.Add(entity);
            }


            // Act
            var dtos = entities.toDtos().ToList();

            //Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual<string>(dtos[i].Culture, entities[i].Culture);
                Assert.AreEqual<string>(dtos[i].Name, entities[i].Name);
                Assert.AreEqual<string>(dtos[i].Domain, entities[i].Domain);
            }
        }
    }
}