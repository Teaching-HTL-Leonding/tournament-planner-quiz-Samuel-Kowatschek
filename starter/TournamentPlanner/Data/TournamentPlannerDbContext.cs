using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TournamentPlanner.Data
{
    public enum PlayerNumber { Player1 = 1, Player2 = 2 };

    public class TournamentPlannerDbContext : DbContext
    {
        public TournamentPlannerDbContext(DbContextOptions<TournamentPlannerDbContext> options)
            : base(options)
        { }

        public DbSet<Match> Matches { get; set; }
        public DbSet<Player> Players { get; set; }

        // This class is NOT COMPLETE.
        // Todo: Complete the class according to the requirements

        /// <summary>
        /// Adds a new player to the player table
        /// </summary>
        /// <param name="newPlayer">Player to add</param>
        /// <returns>Player after it has been added to the DB</returns>
        public async Task<Player> AddPlayer(Player newPlayer)
        {
            Players.Add(newPlayer);
            await SaveChangesAsync();
            return newPlayer;
        }

        /// <summary>
        /// Adds a match between two players
        /// </summary>
        /// <param name="player1Id">ID of player 1</param>
        /// <param name="player2Id">ID of player 2</param>
        /// <param name="round">Number of the round</param>
        /// <returns>Generated match after it has been added to the DB</returns>
        public async Task<Match> AddMatch(int player1Id, int player2Id, int round)
        {
            var match = new Match { Player1ID = player1Id, Player2ID = player2Id, Round = round };
            await SaveChangesAsync();
            return match;
        }

        /// <summary>
        /// Set winner of an existing game
        /// </summary>
        /// <param name="matchId">ID of the match to update</param>
        /// <param name="player">Player who has won the match</param>
        /// <returns>Match after it has been updated in the DB</returns>
        public async Task<Match> SetWinner(int matchId, PlayerNumber player)
        {
            var match = await Matches.FirstAsync(m => m.ID == matchId);
            switch (player)
            {
                case PlayerNumber.Player1:
                    match.WinnerID = match.Player1ID;
                    match.Winner = match.Player1;
                    break;
                case PlayerNumber.Player2:
                    match.WinnerID = match.Player2ID;
                    match.Winner = match.Player2;
                    break;
                default:
                    break;
            }
            return match;


        }

        /// <summary>
        /// Get a list of all matches that do not have a winner yet
        /// </summary>
        /// <returns>List of all found matches</returns>
        public Task<IList<Match>> GetIncompleteMatches()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete everything (matches, players)
        /// </summary>
        public Task DeleteEverything()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a list of all players whose name contains <paramref name="playerFilter"/>
        /// </summary>
        /// <param name="playerFilter">Player filter. If null, all players must be returned</param>
        /// <returns>List of all found players</returns>
        public Task<IList<Player>> GetFilteredPlayers(string playerFilter = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate match records for the next round
        /// </summary>
        /// <exception cref="InvalidOperationException">Error while generating match records</exception>
        public Task GenerateMatchesForNextRound()
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Player1)
                .WithMany()
                .HasForeignKey(m => m.Player1ID)
                .IsRequired();
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Player2)
                .WithMany()
                .HasForeignKey(m => m.Player2ID)
                .IsRequired();
            modelBuilder.Entity<Match>()
                .HasOne(m => m.Winner)
                .WithMany()
                .HasForeignKey(m => m.WinnerID)
                .IsRequired();
        }
    }
}
