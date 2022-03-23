using System.Linq;
using System.Threading.Tasks;
using Game.Models.GameModels;
using GameDataBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameDataBase.Controllers
{
    public class ApiController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ApiController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public IActionResult GetMonster([FromBody] Character character)
        {
            var monster = _db.Monsters
                .AsQueryable()
                .RandomElement(c=> true);

            if (monster != null) return Ok(monster);
            return NotFound("There are no monsters available");
        }

        [HttpPost]
        public async Task<IActionResult> Save(Monster monster)
        {
            if (monster != null)
            {
                await _db.Monsters.AddAsync(monster);
                await _db.SaveChangesAsync();
                return RedirectToAction("Monster");
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Monster result)
        {
            _db.Monsters.Remove(result);
            await _db.SaveChangesAsync();
            return Ok();
        }

        public IActionResult Monster()
        {
            return Ok(_db.Monsters.ToList());
        }
    }
}