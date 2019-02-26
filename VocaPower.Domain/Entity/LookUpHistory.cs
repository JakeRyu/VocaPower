using System.Collections.Generic;

namespace VocaPower.Domain.Entity
{
    public class LookUpHistory
    {
        public LookUpHistory()
        {
            Definitions = new List<string>();
        }
        public string Word { get; set; }
        public List<string> Definitions { get; set; }
    }
}