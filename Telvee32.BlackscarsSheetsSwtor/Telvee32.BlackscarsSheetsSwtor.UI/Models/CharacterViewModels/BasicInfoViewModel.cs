using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Models.CharacterViewModels
{
    public class BasicInfoViewModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Nickname { get; set; }

        [Display(Name = "Age (years)")]
        [Required]
        public int AgeYears { get; set; }

        [Required]
        public string Species { get; set; }

        public string CustomSpecies { get; set; }

        [Required]
        public string Homeworld { get; set; }

        public Rank Rank { get; set; }

        public BasicInfoViewModel()
        {
        }

        public BasicInfoViewModel(Character character)
        {
            Id = character.Id;
            Name = character.Name;
            Nickname = character.Nickname;
            AgeYears = character.AgeYears;
            Rank = character.Rank;
            Homeworld = character.Homeworld;

            if (SpeciesList.Contains(character.Species))
            {
                Species = character.Species;
            }
            else
            {
                CustomSpecies = character.Species;
                Species = "Other";
            }
        }

        public List<SelectListItem> SpeciesDropdown
        {
            get
            {
                var list = new List<SelectListItem>();

                foreach(var species in SpeciesList)
                {
                    list.Add(new SelectListItem
                    {
                        Text = species,
                        Value = species
                    });
                }

                list.Add(new SelectListItem
                {
                    Text = "Other (please specify)",
                    Value = "Other"
                });

                return list;
            }
        }

        public static List<string> SpeciesList = new List<string>
        {
            "Cathar", "Chiss", "Cyborg", "Human", "Miraluka", "Mirialan", "Rattataki", "Sith",
            "Twi'lek", "Togruta", "Zabrak"
        };

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Species == "Other" && string.IsNullOrEmpty(CustomSpecies))
            {
                yield return new ValidationResult("Please enter a species.", new[] { nameof(CustomSpecies) });
            }

            if(Rank == Rank.Undefined)
            {
                yield return new ValidationResult("Please select a rank.", new[] { nameof(Rank) });
            }
        }
    }
}
