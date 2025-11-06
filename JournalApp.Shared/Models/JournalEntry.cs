using System;

namespace JournalApp.Shared.Models
{
    public class JournalEntry
    {
        public DateTime Date { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Mood { get; set; } = string.Empty;
    }
}
