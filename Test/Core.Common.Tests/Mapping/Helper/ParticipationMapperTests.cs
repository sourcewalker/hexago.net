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
    public class ParticipationMapperTests
    {

        [TestMethod]
        public void Convert_vote_entity_to_dto_should_work()
        {
            // Arrange
            var entity = new Participation
            {
                Status = "Tested",
                ApiStatus = "Success",
                ApiMessage = "Transaction success",
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            // Act
            var dto = entity.toDto();

            //Assert
            Assert.AreEqual<string>(dto.Status, entity.Status);
            Assert.AreEqual<string>(dto.ApiStatus, entity.ApiStatus);
            Assert.AreEqual<string>(dto.ApiMessage, entity.ApiMessage);
        }

        [TestMethod]
        public void Convert_vote_dto_to_entity_should_work()
        {
            // Arrange
            var dto = new ParticipationDto
            {
                Status = "Tested",
                ApiStatus = "Success",
                ApiMessage = "Transaction success",
            };

            // Act
            var entity = dto.toEntity();

            //Assert
            Assert.AreEqual<string>(dto.Status, entity.Status);
            Assert.AreEqual<string>(dto.ApiStatus, entity.ApiStatus);
            Assert.AreEqual<string>(dto.ApiMessage, entity.ApiMessage);
        }

        [TestMethod]
        public void Convert_colletion_vote_dto_to_entity_should_work()
        {
            // Arrange
            List<ParticipationDto> dtos = new List<ParticipationDto>();
            for (int i = 0; i < 5; i++)
            {
                var dto = new ParticipationDto
                {
                    Status = "Tested" + i,
                    ApiStatus = "Success" + i,
                    ApiMessage = "Transaction success" + i,
                };
                dtos.Add(dto);
            }


            // Act
            var entities = dtos.toEntities().ToList();

            //Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual<string>(dtos[i].Status, entities[i].Status);
                Assert.AreEqual<string>(dtos[i].ApiStatus, entities[i].ApiStatus);
                Assert.AreEqual<string>(dtos[i].ApiMessage, entities[i].ApiMessage);
            }
        }

        [TestMethod]
        public void Convert_collection_vote_entity_to_dto_should_work()
        {
            // Arrange
            List<Participation> entities = new List<Participation>();
            for (int i = 0; i < 5; i++)
            {
                var entity = new Participation
                {
                    Status = "Tested" + i,
                    ApiStatus = "Success" + i,
                    ApiMessage = "Transaction success" + i,
                    CreatedDate = DateTimeOffset.UtcNow,
                    ModifiedDate = DateTimeOffset.UtcNow
                };
                entities.Add(entity);
            }

            // Act
            var dtos = entities.toDtos().ToList();

            //Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual<string>(dtos[i].Status, entities[i].Status);
                Assert.AreEqual<string>(dtos[i].ApiStatus, entities[i].ApiStatus);
                Assert.AreEqual<string>(dtos[i].ApiMessage, entities[i].ApiMessage);
            }
        }
    }
}