using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_microservice_backend.Model;
using MongoDB.Driver;

namespace core_microservice_backend.DataAccessLayer
{
    public class TeamImplements : ITeamInterface
    {
        private readonly DBContext context;
        public TeamImplements(DBContext dBContext)
        {
            context = dBContext;
        }
       

        public void CreateTeam(Team team)
        {
            context.Teams.InsertOne(team);
        }
        public Team GetTeamByName(string TeamName)
        {
            throw new NotImplementedException();
        }

        public List<Team> GetTeams()
        {
            return context.Teams.Find(_ => true).ToList();
        }

        public bool RemoveTeam(int teamID)
        {
            var deletedResult = context.Teams.DeleteOne(c => c.teamID==teamID);
            return deletedResult.IsAcknowledged && deletedResult.DeletedCount > 0;
        }

        public bool UpdateTeam(int teamID,Team team)
        {
            var filter = Builders<Team>.Filter.Where(c => c.teamID==teamID);
            var updatedResult = context.Teams.ReplaceOne(filter, team);
            return updatedResult.IsAcknowledged && updatedResult.ModifiedCount > 0;
        }

        public void CreateBoard(int teamID,Board board)
        {
            var filter = Builders<Team>.Filter.Eq(c => c.teamID,teamID);
            var update = Builders<Team>.Update.Push(c => c.Boards, board);
            context.Teams.FindOneAndUpdate(filter, update);
        }
       
        public ICollection<Board> GetBoards(int teamID)
        {
            Team GetBoards = context.Teams.Find(n => n.teamID==teamID).First();
            return GetBoards.Boards;
        }

        public ICollection<Invite> GetInvites(int teamID)
        {
            Team GetInvites = context.Teams.Find(n => n.teamID==teamID).First();
            return GetInvites.Invites;
        }

        public ICollection<Member> GetMembers(int teamID)
        {
            Team GetMembers = context.Teams.Find(n => n.teamID==teamID).First();
            return GetMembers.Members;
        }

       
    }
}
