﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Site.ViewModels
{
    public class SiteViewModel
    {
        public Guid SiteId { get; set; }

        public string Name { get; set; }

        public string Culture { get; set; }

        public string Domain { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActivePhase()
        {
            return DateTime.UtcNow < EndDate;
        }

        public bool IsHoldingPhase()
        {
            return EndDate < DateTime.UtcNow;
        }
    }
}