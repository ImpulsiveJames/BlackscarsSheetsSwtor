using System;
using System.ComponentModel.DataAnnotations;
using Telvee32.BlackscarsSheetsSwtor.UI.Models;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Entities
{
    public class Character
    {
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; }
        
        public string Name { get; set; }

        public string Nickname { get; set; }

        public Attribute Attribute { get; set; }

        public Skill Skill { get; set; }

        [Display(Name = "Age (years)")]
        public int AgeYears { get; set; }

        public string Species { get; set; }

        public string Homeworld { get; set; }

        public Rank Rank { get; set; }

        public int Perception => 1 + 1;

        public int Initiative => 1 + 1;

        public bool Completed { get; set; }

        public bool Approved { get; set; }
    }
}
