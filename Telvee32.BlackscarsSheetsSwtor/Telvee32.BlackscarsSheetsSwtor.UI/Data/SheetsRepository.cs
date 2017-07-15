using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Data
{
    public class SheetsRepository : ISheetsRepository
    {
        private ApplicationDbContext _dbcontext;

        public SheetsRepository(ApplicationDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public bool AddOrUpdateCharacter(Character character)
        {
            if (_dbcontext.Characters.FirstOrDefault(c => c.Id == character.Id) == null)
            {
                _dbcontext.Characters.Add(character);
            }
            else
            {
                _dbcontext.Characters.Update(character);
            }

            _dbcontext.SaveChanges();
            return true;
        }

        public Character GetCharacter(Guid id)
        {
            return _dbcontext.Characters
                .Include(c => c.Attribute)
                .Include(c => c.Skill)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Character> GetCharacters(string userId = null)
        {
            if(userId != null)
            {
                return _dbcontext.Characters.Where(c => c.User.Id == userId).ToList();
            }

            return _dbcontext.Characters.ToList();
        } 
    }
}
