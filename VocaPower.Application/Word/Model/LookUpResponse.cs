using System.Collections.Generic;

namespace VocaPower.Application.Word.Model
{
    public class Metadata
    {
        public string Provider { get; set; }
    }

    public class GrammaticalFeature
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Note
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Example
    {
        public string Text { get; set; }
    }

    public class ThesaurusLink
    {
        public string EntryId { get; set; }
        public string SenseId { get; set; }
    }

    public class Subsense
    {
        public List<string> Definitions { get; set; }
        public List<Example> Examples { get; set; }
        public string Id { get; set; }
        public List<string> ShortDefinitions { get; set; }
        public List<Note> Notes { get; set; }
        public List<ThesaurusLink> ThesaurusLinks { get; set; }
        public List<string> Registers { get; set; }
        public List<string> Domains { get; set; }
    }

    public class Sense
    {
        public List<string> Definitions { get; set; }
        public List<Example> Examples { get; set; }
        public string Id { get; set; }
        public List<Note> Notes { get; set; }
        public List<string> ShortDefinitions { get; set; }
        public List<Subsense> Subsenses { get; set; }
        public List<ThesaurusLink> ThesaurusLinks { get; set; }
        public List<string> Registers { get; set; }
        public List<string> Regions { get; set; }
        public List<string> Domains { get; set; }
    }

    public class Entry
    {
        public List<string> Etymologies { get; set; }
        public List<GrammaticalFeature> GrammaticalFeatures { get; set; }
        public string HomographNumber { get; set; }
        public List<Note> Notes { get; set; }
        public List<Sense> Senses { get; set; }
    }

    public class Pronunciation
    {
        public string AudioFile { get; set; }
        public List<string> Dialects { get; set; }
        public string PhoneticNotation { get; set; }
        public string PhoneticSpelling { get; set; }
    }

    public class LexicalEntry
    {
        public List<Entry> Entries { get; set; }
        public string Language { get; set; }
        public string LexicalCategory { get; set; }
        public List<Pronunciation> Pronunciations { get; set; }
        public string Text { get; set; }
    }

    public class Result
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public List<LexicalEntry> LexicalEntries { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
    }

    public class LookUpResponse
    {
        public Metadata Metadata { get; set; }
        public List<Result> Results { get; set; }
    }
}