using System;
using System.Collections.Generic;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data
{
    public interface ISheetsRepository
    {
        List<Character> GetCharacters(string userId = null);

        Character GetCharacter(Guid id);

        bool AddOrUpdateCharacter(Character character);
    }
}
