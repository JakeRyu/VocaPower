using System.Collections.Generic;

namespace VocaPower.Domain.Entity
{
    public class LookUpHistory
    {
        public string Word { get; set; }
        public ICollection<string> Definitions { get; set; }
    }
}