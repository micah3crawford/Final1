using Final1.Models.Entities;

namespace Final1.Services
{
    public class Initializer
    {
        private readonly ApplicationDbContext _db;

        public Initializer(ApplicationDbContext db)
        {
            _db = db;
        }

        public void SeedDatabase()
        {
            _db.Database.EnsureCreated();

            if (_db.Players.Any()) return;
            var players = new List<Player>
            {
                new Player
                {Number = "1", FirstName = "Zac", LastName = "Crawford" },
                new Player
                {Number = "2", FirstName = "Lucas", LastName = "Adkins"},
                new Player
                {Number = "3", FirstName = "Cam", LastName = "Hill"},
                new Player
                {Number = "4", FirstName = "Tristen", LastName = "Cox"},
                new Player
                {Number = "5", FirstName = "Matt", LastName = "Johnson"},
                new Player
                {Number = "6", FirstName = "Dakota", LastName = "Hicks"},
            };
            _db.Players.AddRange(players);
            _db.SaveChanges();

            var teams = new List<Team>
        {
            new Team { Code = "Falcons", ScheduledGames = 15 },
            new Team { Code = "Lions", ScheduledGames = 15 },
            new Team { Code = "Hawks", ScheduledGames = 15 },
            new Team { Code = "Bucks", ScheduledGames= 15 },
            new Team { Code = "Tigers", ScheduledGames = 15 },
            new Team { Code = "Panthers", ScheduledGames = 15 }
        };

            _db.Teams.AddRange(teams);
            _db.SaveChanges();

            //Team? Falcons = _db.Teams.FirstOrDefault(t => t.Code =="Falcons");
            //Team? Lions = _db.Teams.FirstOrDefault(t => t.Code == "Lions");
            //Team? Hawks = _db.Teams.FirstOrDefault(t => t.Code == "Hawks");
            //Team? Bucks = _db.Teams.FirstOrDefault(t => t.Code == "Bucks");
            //Team? Tigers = _db.Teams.FirstOrDefault(t => t.Code == "Tigers");
            //Team? Panthers = _db.Teams.FirstOrDefault(t => t.Code == "Panthers");

            //Player? zac = _db.Players.FirstOrDefault(p => p.Number == "1");
            //Player? lucas = _db.Players.FirstOrDefault(p => p.Number == "2");
            //Player? cam = _db.Players.FirstOrDefault(p => p.Number == "3");
            //Player? tristen = _db.Players.FirstOrDefault(p => p.Number == "4");
            //Player? matt = _db.Players.FirstOrDefault(p => p.Number == "5");
            //Player? dakota = _db.Players.FirstOrDefault(p => p.Number == "6");

            //zac!.TeamRanks.Add(new PlayerTeamRank { Rank = "D1", Team = Falcons });
            //lucas!.TeamRanks.Add(new PlayerTeamRank { Rank = "D2", Team = Lions });
            //cam!.TeamRanks.Add(new PlayerTeamRank { Rank = "D3", Team = Hawks });
            //tristen!.TeamRanks.Add(new PlayerTeamRank { Rank = "D1", Team = Bucks });
            //matt!.TeamRanks.Add(new PlayerTeamRank { Rank = "Average", Team = Tigers });
            //dakota!.TeamRanks.Add(new PlayerTeamRank { Rank = "U", Team = Panthers });
            //_db.SaveChanges();
        }

    }
}
