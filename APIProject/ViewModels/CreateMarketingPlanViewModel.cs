﻿using APIProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProject.ViewModels
{
    public class CreateMarketingPlanViewModel
    {
        public MarketingPlan Plan { get; set; }
        public ICollection<MarketingPlanDate> MarketingPlanDates { get; set; }
    }
}