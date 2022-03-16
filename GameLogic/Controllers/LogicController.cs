using System;
using System.Collections.Generic;
using GameLogic.Models;
using GameLogic.Models.GameModels;
using Microsoft.AspNetCore.Mvc;

namespace GameLogic.Controllers
{
    public class LogicController : Controller
    {
        private readonly Random _random = new();
        

        // GET
        public IActionResult Index()
        {

            return Ok();
        }

        private DMag getDMag(string d)
        {
            var dm = d.Split("d");
            return new DMag
            {
                from = Convert.ToInt32(dm[0]),
                To = Convert.ToInt32(dm[1]),
            };
        }

        public int GetRandomRound(DMag damage)
        {
            int result = 3;
            for (int i = 0; i < damage.from; i++)
            {
                result += _random.Next(damage.from,damage.To);
            }
            return result;
        }
        
        public int GetRandomRound()
        {
         return _random.Next(1,20);
                
        }
        
        [HttpPost]
        public IActionResult Battle([FromBody] ModelGame modelGame)
        {
            
            modelGame.Character.DMag = getDMag(modelGame.Character.Damage);
            modelGame.Monster.DMag = getDMag(modelGame.Monster.Damage);
            
            var resultList = new List<Result>();

            while (StillAlive(modelGame.Character.HitPoints) && StillAlive(modelGame.Monster.Hits))
            {
                int dieAndModifier;
                int randomRound;
                int damage;
                
                // Character damage
                randomRound = GetRandomRound();
                dieAndModifier = randomRound + modelGame.Character.AttackModifier;

                if (dieAndModifier > modelGame.Monster.Ac)
                {
                    var random = GetRandomRound(modelGame.Character.DMag);
                    damage = random + modelGame.Character.AttackModifier;
                    modelGame.Monster.Hits -= damage;
                    resultList.Add(new Result{ResultDamage = 
                        randomRound+" ("+modelGame.Character.AttackModifier+") больше "+modelGame.Monster.Ac+"," +
                        " попадание. "+random+"("+modelGame.Character.AttackModifier+")" +
                        " наносит "+damage+" урона "+modelGame.Monster.Name+" ("+modelGame.Monster.Hits+"). "});
                }
                
                // Monster damage
                randomRound = GetRandomRound();
                dieAndModifier = randomRound + modelGame.Monster.AttackModifier;

                if (dieAndModifier > modelGame.Character.Ac)
                {
                    var random = GetRandomRound(modelGame.Monster.DMag);
                    damage = random + modelGame.Monster.AttackModifier;
                    modelGame.Character.HitPoints -= damage;
                    resultList.Add(new Result{ResultDamage = 
                        randomRound+" ("+modelGame.Monster.AttackModifier+") больше "+modelGame.Character.Ac+"," +
                        " попадание. "+random+"("+modelGame.Monster.AttackModifier+")" +
                        " наносит "+damage+" урона "+modelGame.Character.Name+" ("+modelGame.Character.HitPoints+"). "});
                }
            }

            var win = GetWin(modelGame.Character, modelGame.Monster);
            resultList.Add(new Result{ ResultDamage = win});
            
            return Ok(resultList);
        }

        private string GetWin(Character modelGameCharacter, Monster modelGameMonster)
        {
            return modelGameCharacter.HitPoints > 0 ? $"{modelGameCharacter.Name} победили" : $"{modelGameMonster.Name} победили";
        }


        private bool StillAlive(int hit)
        {
            return hit > 0;
        }
        
        
        [HttpGet]
        public IActionResult Battle()
        {
            return Ok("hello");
        }
    }
}