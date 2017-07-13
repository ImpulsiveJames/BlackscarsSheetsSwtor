using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telvee32.BlackscarsSheetsSwtor.UI.Data;
using Telvee32.BlackscarsSheetsSwtor.UI.Entities;
using Telvee32.BlackscarsSheetsSwtor.UI.Models;
using Telvee32.BlackscarsSheetsSwtor.UI.Models.CharacterViewModels;
using Attribute = Telvee32.BlackscarsSheetsSwtor.UI.Entities.Attribute;

namespace Telvee32.BlackscarsSheetsSwtor.UI.Controllers
{
    [Authorize]
    public class CharacterController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private ISheetsRepository _repository;

        public CharacterController(UserManager<ApplicationUser> userManager,
            ISheetsRepository repository)
        {
            _userManager = userManager;
            _repository = repository;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/Character/{characterId}")]
        public IActionResult Index(Guid characterId)
        {
            return RedirectToAction("Sheet", new { characterId = characterId });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult All(string userId = null)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> MyCharacters()
        {
            var user = await GetCurrentUserAsync();

            List<Character> characters = _repository.GetCharacters(user.Id);

            return View("MyCharacters", new MyCharactersViewModel(characters));
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Characters(string username)
        {
            // redirect to MyCharacters if username is current logged-in user
            throw new NotImplementedException();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("/Character/{characterId}/Sheet")]
        public async Task<IActionResult> Sheet(Guid characterId)
        {
            var dbCharacter = _repository.GetCharacter(characterId);

            if (dbCharacter == null) return NotFound();

            return View("Sheet", new CharacterSheetViewModel(dbCharacter));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var user = await GetCurrentUserAsync();
            var character = new Character
            {
                Id = Guid.NewGuid(),
                User = user,
                Name = "Default name",
                Nickname = "Default nickname",
                Species = "Default species"
            };
            character.Attribute = new Attribute
            {
                Intelligence = 1,
                Willpower = 1,
                Dexterity = 1,
                Charisma = 1,
                Wits = 1,
                Strength = 1,
                Stamina = 1
            };
            character.Skill = new Skill();

            _repository.AddOrUpdateCharacter(character);

            return RedirectToAction("BasicInfo", new { characterId = character.Id });
        }

        // step 1
        [HttpGet]
        [Route("/Character/{characterId}/BasicInfo")]
        public IActionResult BasicInfo(Guid characterId)
        {
            var character = _repository.GetCharacter(characterId);
            return View("EditBasicInfo", new BasicInfoViewModel(character));
        }

        // step 1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BasicInfo(BasicInfoViewModel viewModel)
        {
            // validate - IValidatableObject perhaps or just data annotations
            if (viewModel.Id == Guid.Empty)
            {
                throw new InvalidOperationException("Character ID not present.");
            }

            var user = await GetCurrentUserAsync();
            var dbCharacter = _repository.GetCharacter(viewModel.Id);

            if (dbCharacter == null) return NotFound();

            if (user.Id != dbCharacter.User.Id) return Unauthorized();

            dbCharacter.Name = viewModel.Name;
            dbCharacter.Nickname = viewModel.Nickname;
            dbCharacter.AgeYears = viewModel.AgeYears;
            dbCharacter.Species = viewModel.Species;
            dbCharacter.Homeworld = viewModel.Homeworld;
            dbCharacter.Rank = viewModel.Rank;

            _repository.AddOrUpdateCharacter(dbCharacter);

            return RedirectToAction("Sheet", new { characterId = viewModel.Id });
        }

        // step 2
        [HttpGet]
        public IActionResult Attributes(Guid characterId)
        {
            throw new NotImplementedException();
        }

        // step 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Attributes(int id)
        {
            throw new NotImplementedException();
        }

        // step 3
        [HttpGet]
        public IActionResult Skills(Guid characterId)
        {
            throw new NotImplementedException();
        }

        // step 3
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Skills(int id)
        {
            throw new NotImplementedException();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private bool IsCharacterEditAuthorised(Character character, ApplicationUser currentUser)
        {            
            return character.User.Id == currentUser.Id;
        }
    }
}
