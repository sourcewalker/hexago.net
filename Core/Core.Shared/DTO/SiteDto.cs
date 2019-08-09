using System;

namespace Core.Shared.DTO
{
    public class SiteDto
    {
        public Guid Id { get; set; }

        public string Culture { get; set; }

        public string Name { get; set; }

        public string Domain { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
