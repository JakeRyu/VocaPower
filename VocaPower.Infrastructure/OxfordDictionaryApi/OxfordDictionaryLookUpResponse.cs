using System.Collections.Generic;

namespace VocaPower.Infrastructure.OxfordDictionaryApi
{
    public class Metadata
    {
        public string provider { get; set; }
    }

    public class GrammaticalFeature
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Note
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Example
    {
        public string text { get; set; }
    }

    public class ThesaurusLink
    {
        public string entry_id { get; set; }
        public string sense_id { get; set; }
    }

    public class Subsense
    {
        public List<string> definitions { get; set; }
        public List<Example> examples { get; set; }
        public string id { get; set; }
        public List<string> short_definitions { get; set; }
        public List<Note> notes { get; set; }
        public List<ThesaurusLink> thesaurusLinks { get; set; }
        public List<string> registers { get; set; }
        public List<string> domains { get; set; }
    }

    public class Sense
    {
        public List<string> definitions { get; set; }
        public List<Example> examples { get; set; }
        public string id { get; set; }
        public List<Note> notes { get; set; }
        public List<string> short_definitions { get; set; }
        public List<Subsense> subsenses { get; set; }
        public List<ThesaurusLink> thesaurusLinks { get; set; }
        public List<string> registers { get; set; }
        public List<string> regions { get; set; }
        public List<string> domains { get; set; }
    }

    public class Entry
    {
        public List<string> etymologies { get; set; }
        public List<GrammaticalFeature> grammaticalFeatures { get; set; }
        public string homographNumber { get; set; }
        public List<Note> notes { get; set; }
        public List<Sense> senses { get; set; }
    }

    public class Pronunciation
    {
        public string audioFile { get; set; }
        public List<string> dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
    }

    public class LexicalEntry
    {
        public List<Entry> entries { get; set; }
        public string language { get; set; }
        public string lexicalCategory { get; set; }
        public List<Pronunciation> pronunciations { get; set; }
        public string text { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string language { get; set; }
        public List<LexicalEntry> lexicalEntries { get; set; }
        public string type { get; set; }
        public string word { get; set; }
    }

    public class OxfordDictionaryLookUpResponse
    {
        public Metadata metadata { get; set; }
        public List<Result> results { get; set; }
    }
}