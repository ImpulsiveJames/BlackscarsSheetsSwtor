using System.Collections.Generic;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Models.CharacterViewModels
{
    public class MyCharactersViewModel
    {
        public List<Character> Characters { get; set; }

        public MyCharactersViewModel()
        {
        }

        public MyCharactersViewModel(List<Character> characters)
        {
            Characters = characters ?? new List<Character>();
        }
    }
}
