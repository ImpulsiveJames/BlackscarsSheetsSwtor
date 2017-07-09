using System.ComponentModel.DataAnnotations;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        public Character Character { get; set; }

        [Display(Name = "Animal Ken")]
        public int AnimalKen { get; set; }

        public int Athletics { get; set; }

        public int Brawling { get; set; }

        public int Firearms { get; set; }

        public int Interrogation { get; set; }

        public int Larceny { get; set; }

        public int Mechanics { get; set; }

        public int Medicine { get; set; }

        [Display(Name = "Heavy Ordnance")]
        public int HeavyOrdnance { get; set; }

        public int Persuasion { get; set; }

        public int Piloting { get; set; }

        public int Slicing { get; set; }

        public int Stealth { get; set; }

        public int Survival { get; set; }

        public int Weaponry { get; set; }
    }
}
