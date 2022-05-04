using Final1.Models.Entities;

namespace Final1.Services
{
    public interface IPlayerRepository
    {
        Player? Read(string number);
        ICollection<Player> ReadAll();
    }
}
