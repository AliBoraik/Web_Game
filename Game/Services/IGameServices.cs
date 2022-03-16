using System.Threading.Tasks;
using Game.Models.GameModels;


namespace Game.Services
{
    public interface IGameServices
    {
        public Task<Monster> GetRandomMonsterFromDb(Character character);
        void CalculationAutomatic(Character character);
    }
}