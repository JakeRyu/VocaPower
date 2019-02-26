using System;
using System.Collections.Generic;

namespace VocaPower.Domain.Entity
{
    public class LookUpHistory
    {
        public LookUpHistory()
        {
            Date = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Word { get; set; }
        public string Definition { get; set; }
        public DateTime Date { get; set; }
    }
}