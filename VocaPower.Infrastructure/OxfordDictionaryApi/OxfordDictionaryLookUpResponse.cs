using System.Collections.Generic;

namespace VocaPower.Infrastructure.OxfordDictionaryApi
{
    public class OxfordDictionaryLookUpResponse
    {
        public Metadata Metadata { get; set; }
        public List<Result> Results { get; set; }
        
        public class Result
        {
            public string Id { get; set; }
            public string Language { get; set; }
            public string Type { get; set; }
            public string Word { get; set; }
            public List<LexicalEntry> LexicalEntries { get; set; }
        
            public class LexicalEntry
            {
                public string Language { get; set; }
                public string LexicalCategory { get; set; }
                public string Text { get; set; }
                public List<Entry> Entries { get; set; }
                
                public class Entry
                {
                    public List<Sense> Senses { get; set; }
                    
                    public class Sense
                    {
                        public List<string> Definitions { get; set; }
                        public List<string> ShortDefinitions { get; set; }
                    }
                }
            }
        }   
    }

    public class Metadata
    {
        public string Provider { get; set; }
    }
}