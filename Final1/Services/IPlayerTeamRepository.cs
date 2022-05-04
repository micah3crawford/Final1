using Final1.Models.Entities;

namespace Final1.Services
{
    public interface IPlayerTeamRepository
    {
        PlayerTeamRank? Read(int id);
        ICollection<PlayerTeamRank> ReadAll();

        PlayerTeamRank? Create(string number, int teamId);
        void UpdatePlayerRank(int playerTeamId, string Rank);
        void Remove(string number, int playerTeamtId);
    }
}
