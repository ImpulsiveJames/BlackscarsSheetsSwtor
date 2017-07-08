using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {       
        public ICollection<Character> Characters { get; set; }
    }
}
