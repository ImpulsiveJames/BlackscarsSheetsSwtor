﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Telvee32.BlackscarsSheetsSwtor.UI.Models;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Entities
{
    public class Character
    {
        public Guid Id { get; set; }

        public ApplicationUser User { get; set; }
        
        public string Name { get; set; }

        public string Nickname { get; set; }

        [ForeignKey("AttributeId")]
        public Attribute Attribute { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }
    }
}