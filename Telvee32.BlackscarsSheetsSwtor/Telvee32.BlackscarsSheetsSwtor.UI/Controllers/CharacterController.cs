using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        [Route("/Characters/{username}")]
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
        public IActionResult Create()
        {
            return View(new BasicInfoViewModel(new Character()));
        }

        [HttpPost]
        public async Task<IActionResult> Create(BasicInfoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();

                var character = new Character
                {
                    Id = Guid.NewGuid(),
                    User = user,
                    Name = viewModel.Name,
                    Nickname = viewModel.Nickname,
                    Species = viewModel.Species == "Other" ? viewModel.CustomSpecies : viewModel.Species,
                    Attribute = new Attribute
                    {
                        Intelligence = 1,
                        Willpower = 1,
                        Dexterity = 1,
                        Charisma = 1,
                        Wits = 1,
                        Strength = 1,
                        Stamina = 1
                    },
                    Skill = new Skill()
                };

                _repository.AddOrUpdateCharacter(character);

                return RedirectToAction("Sheet", new { characterId = character.Id });
            }

            return View(viewModel);
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
        [Route("/Character/{characterId}/BasicInfo")]
        public IActionResult BasicInfo(BasicInfoViewModel viewModel)
        {
            if (viewModel.Id == Guid.Empty)
            {
                throw new InvalidOperationException("Character ID not present.");
            }

            if (ModelState.IsValid)
            {
                var dbCharacter = _repository.GetCharacter(viewModel.Id);

                if (dbCharacter == null) return NotFound();

                if (!IsCharacterEditAuthorised(dbCharacter)) return Unauthorized();

                dbCharacter.Name = viewModel.Name;
                dbCharacter.Nickname = viewModel.Nickname;
                dbCharacter.AgeYears = viewModel.AgeYears;
                dbCharacter.Species = viewModel.Species == "Other" ? viewModel.CustomSpecies : viewModel.Species;
                dbCharacter.Homeworld = viewModel.Homeworld;
                dbCharacter.Rank = viewModel.Rank;

                _repository.AddOrUpdateCharacter(dbCharacter);

                return RedirectToAction("Sheet", new { characterId = viewModel.Id });
            }

            return View("EditBasicInfo", viewModel);
        }

        // API used for Vue.js app
        [HttpGet]
        [Route("/Character/api/{characterId}")]
        public IActionResult Get(Guid characterId)
        {
            throw new NotImplementedException();
        }

        // step 2
        [HttpGet]
        public IActionResult SkillsAndAttributes(Guid characterId)
        {
            throw new NotImplementedException();
        }

        // step 2
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SkillsAndAttributes(int id)
        {
            throw new NotImplementedException();
        }

        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        private bool IsCharacterEditAuthorised(Character character)
        {
            var currentUser = GetCurrentUserAsync().Result;

            return character.User.Id == currentUser.Id;
        }
    }
}
