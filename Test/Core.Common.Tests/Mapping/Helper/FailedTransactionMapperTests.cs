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
    public class FailedTransactionMapperTests
    {

        [TestMethod]
        public void Convert_failed_transaction_entity_to_dto_should_work()
        {
            // Arrange
            var entity = new FailedTransaction
            {
                TermsConsent = true,
                NewsletterOptin = true,
                CreatedDate = DateTimeOffset.UtcNow,
                ModifiedDate = DateTimeOffset.UtcNow
            };

            // Act
            var dto = entity.toDto();

            //Assert
            Assert.AreEqual<bool>(dto.TermsConsent, entity.TermsConsent);
            Assert.AreEqual<bool>(dto.NewsletterOptin, entity.NewsletterOptin);
        }

        [TestMethod]
        public void Convert_failed_transaction_dto_to_entity_should_work()
        {
            // Arrange
            var dto = new FailedTransactionDto
            {
                TermsConsent = true,
                NewsletterOptin = true
            };

            // Act
            var entity = dto.toEntity();

            //Assert
            Assert.AreEqual<bool>(dto.TermsConsent, entity.TermsConsent);
            Assert.AreEqual<bool>(dto.NewsletterOptin, entity.NewsletterOptin);
        }

        [TestMethod]
        public void Convert_colletion_failed_transaction_dto_to_entity_should_work()
        {
            // Arrange
            List<FailedTransactionDto> dtos = new List<FailedTransactionDto>();
            for (int i = 0; i < 5; i++)
            {
                var dto = new FailedTransactionDto
                {
                    TermsConsent = true,
                    NewsletterOptin = true
                };
                dtos.Add(dto);
            }


            // Act
            var entities = dtos.toEntities().ToList();

            //Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.AreEqual<bool>(dtos[i].TermsConsent, entities[i].TermsConsent);
                Assert.AreEqual<bool>(dtos[i].NewsletterOptin, entities[i].NewsletterOptin);
            }
        }

        [TestMethod]
        public void Convert_collection_failed_transaction_entity_to_dto_should_work()
        {
            // Arrange
            List<FailedTransaction> entities = new List<FailedTransaction>();
            for (int i = 0; i < 5; i++)
            {
                var entity = new FailedTransaction
                {
                    TermsConsent = true,
                    NewsletterOptin = true,
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
                Assert.AreEqual<bool>(dtos[i].TermsConsent, entities[i].TermsConsent);
                Assert.AreEqual<bool>(dtos[i].NewsletterOptin, entities[i].NewsletterOptin);
            }
        }
    }
}