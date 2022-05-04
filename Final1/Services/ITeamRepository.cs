using Final1.Models.Entities;

namespace Final1.Services
{
    public interface ITeamRepository
    {
        Team? Read(int id);
        ICollection<Team> ReadAll();
    }
}
