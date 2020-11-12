﻿using System;

namespace BB.DAL.Entities
{
    public class CreditBranch
    {
        public int CreditBranchId { get; set; }
        public decimal Available { get; set; }
        public decimal Balance { get; set; }
        public double Interest { get; set; }
        public TimeSpan TimeOver { get; set; }
        public decimal Debt { get; set; }
        
        public int? CardId { get; set; }
        public Card Card { get; set; }
    }
}