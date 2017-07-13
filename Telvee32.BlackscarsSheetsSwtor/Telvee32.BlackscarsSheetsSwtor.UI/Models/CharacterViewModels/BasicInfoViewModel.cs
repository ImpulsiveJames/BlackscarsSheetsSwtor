using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Models.CharacterViewModels
{
    public class BasicInfoViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        [Display(Name = "Age (years)")]
        public int AgeYears { get; set; }

        public string Species { get; set; }

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
            Species = character.Species;
            Rank = character.Rank;
        }

        public List<SelectListItem> SpeciesDropdown => new List<SelectListItem>
        {
            new SelectListItem
            {
                Text = "Cathar",
                Value = "Cathar"
            },
            new SelectListItem
            {
                Text = "Chiss",
                Value = "Chiss"
            },
            new SelectListItem
            {
                Text = "Cyborg",
                Value = "Cyborg"
            },
            new SelectListItem
            {
                Text = "Human",
                Value = "Human"
            },
            new SelectListItem
            {
                Text = "Miraluka",
                Value = "Miraluka"
            },
            new SelectListItem
            {
                Text = "Mirialan",
                Value = "Mirialan"
            },
            new SelectListItem
            {
                Text = "Rattataki",
                Value = "Rattataki"
            },
            new SelectListItem
            {
                Text = "Sith",
                Value = "Sith"
            },
            new SelectListItem
            {
                Text = "Twi'lek",
                Value = "Twi'lek"
            },
            new SelectListItem
            {
                Text = "Togruta",
                Value = "Togruta"
            },
            new SelectListItem
            {
                Text = "Zabrak",
                Value = "Zabrak"
            }
        };
    }
}
