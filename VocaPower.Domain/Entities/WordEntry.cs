using System.Collections.Generic;
using System.Threading;

namespace VocaPower.Domain.Entities
{
    public class WordEntry
    {
        public WordEntry()
        {
            
        }
        public WordEntry(string word)
        {
            Word = word;
            LexicalEntries = new List<LexicalEntry>();
        }
        public string Word { get; }
        public ICollection<LexicalEntry> LexicalEntries { get; }
    }

    public class LexicalEntry
    {
        public LexicalEntry(string category)
        {
            LexicalCategory = category;
            SenseEntries = new List<SenseEntry>();
        }
        public string LexicalCategory { get; }
        public ICollection<SenseEntry> SenseEntries { get; }
    }

    public class SenseEntry
    {
        public SenseEntry()
        {
            Examples = new List<string>();
        }
        public string Definition { get; set; }
        public string ShortDefinition { get; set; }
        public string Domain { get; set; }
        public ICollection<string> Examples { get; }
    }
}