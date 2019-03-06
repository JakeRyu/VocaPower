using System;
using System.ComponentModel.DataAnnotations;
using VocaPower.Domain.Users;

namespace VocaPower.Domain.LookUp
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

        [Required]
        public virtual AppUser User { get; set; }
    }
}