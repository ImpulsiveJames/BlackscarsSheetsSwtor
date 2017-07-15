using System;
using System.ComponentModel.DataAnnotations;
using Telvee32.BlackscarsSheetsSwtor.UI.Models;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Entities
{
    public class Character
    {
        public Guid Id { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        public Attribute Attribute { get; set; }

        public Skill Skill { get; set; }

        [Required]
        [Display(Name = "Age (years)")]
        public int AgeYears { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public string Homeworld { get; set; }

        [Required]
        public Rank Rank { get; set; }

        public int Perception => 1 + 1;

        public int Initiative => 1 + 1;

        public int Health => 1 + 1;

        [Required]
        public bool Completed { get; set; }

        [Required]
        public bool Approved { get; set; }

        [Display(Name = "Other information (1000 chars max)")]
        [MaxLength(1000)]
        public bool OtherInformation { get; set; }
    }
}
