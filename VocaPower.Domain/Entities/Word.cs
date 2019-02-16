using System.Collections.Generic;

namespace VocaPower.Domain.Entities
{
    public class Word
    {
        public string Id { get; set; }
        public string Definition { get; set; }
        
        public ICollection<string> Examples { get; set; }
    }
}