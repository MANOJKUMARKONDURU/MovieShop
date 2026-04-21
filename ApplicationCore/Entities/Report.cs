using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
    public class Report
    {
        public int Id { get; set; }

        [Required, MaxLength(256)]
        public string Name { get; set; }

        public DateTime GeneratedOn { get; set; }
    }
}