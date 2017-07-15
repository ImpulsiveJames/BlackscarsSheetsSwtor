using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Models.CharacterViewModels
{
    public class CharacterSheetViewModel
    {
        public Character Character { get; set; }

        public CharacterSheetViewModel(Character character)
        {
            Character = character;
        }
    }
}
