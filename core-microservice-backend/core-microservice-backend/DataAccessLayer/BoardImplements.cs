using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_microservice_backend.Model;
using MongoDB.Driver;

namespace core_microservice_backend.DataAccessLayer
{
    public class BoardImplements : IBoardInterface
    {
        private readonly DBContext context;
        public BoardImplements(DBContext dBContext)
        {
            context = dBContext;
        }
        public void CreateList(int teamId,int boardId,List list)
        {
            
            var filter = Builders<Board>.Filter.Eq(c => c.BId,boardId );
            var update = Builders<Board>.Update.Push(c => c.Lists, list);
            var teams = context.Teams.Find(t => t.teamID == teamId).First();
            var board = teams.Boards.FirstOrDefault(z => z.BId ==boardId);
            board.Lists.Add(list);
            var update1 = Builders<Team>.Update.Set(z => z.Boards.FirstOrDefault(b=>b.BId==boardId),board);
            
            

        }

        public Board GetBoardById(int teamId,int Bid)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            Board _board = GetTeam.Boards.First(n => n.BId == Bid);
            return _board;
        }

        public ICollection<Invite> GetBoardInvites(int teamID,int boardID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamID).First();
            Board _board = GetTeam.Boards.First(n => n.BId == boardID);
            return _board.Invites;
        }

        public ICollection<Member> GetBoardMembers(int teamID, int boardID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamID).First();
            Board _board = GetTeam.Boards.First(n => n.BId == boardID);
            return _board.Members;
        }

        public List<Board> GetBoards(int teamId)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            return GetTeam.Boards;
        }

        public List<Card> GetCards(string ListId)
        {
            throw new NotImplementedException();
        }

        public List GetListById(int  teamId,int boardId,int listId)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            Board _board = GetTeam.Boards.Find(n => n.BId == boardId);
            List _list = _board.Lists.Find(n => n.LId == listId);
            return _list;
         }

        public ICollection<List> GetLists(int teamId,int boardId)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamId).First();
            Board _board = GetTeam.Boards.First(n => n.BId == boardId);
            return _board.Lists;

        }

        public void RemoveBoard(int teamID,int boardID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamID).First();
            Board _board = GetTeam.Boards.First(n => n.BId == boardID);
            var filter = Builders<Team>.Filter.Eq(n => n.teamID, teamID);
            var delete = Builders<Team>.Update.Pull(n => n.Boards, _board);
            context.Teams.FindOneAndUpdate(filter, delete);
        }

        public void RemoveList(int teamID, int boardID,int listID)
        {
            Team GetTeam = context.Teams.Find(n => n.teamID == teamID).First();
            Board _board = GetTeam.Boards.First(n => n.BId == boardID);
            List _list = _board.Lists.Find(n => n.LId == listID);
           
            var filter = Builders<Board>.Filter.Eq(n => n.BId, boardID);
            
            var delete = Builders<Board>.Update.Pull(n => n.Lists, _list);
            context.Teams.FindOneAndUpdate(filter, delete);
        }

        public void UpdateBoard(int teamID, Board board)
        { var filter = Builders<Team>.Filter.Eq(c => c.teamID, teamID);
            var update = Builders<Team>.Update.Push(c => c.Boards, board);
            //Team team_update = context.Teams.Find(c => c.teamID == teamID).First();
            //Board _board = team_update.Boards.First(l => l.BId == board.BId);
            context.Teams.UpdateMany(filter, update);
             

        }

        public bool UpdateList(string ListName, List list)
        {
            throw new NotImplementedException();
        }
    }
}
