using core_microservice_backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.DataAccessLayer
{
    public interface IBoardInterface
    {
        List<Board> GetBoards();
        Board GetBoardByName(string BoardName);
        bool UpdateBoard(string BoardName, Board board);
        void RemoveBoard(string BoardName);
        void CreateList(string BoardName, List list);
        List GetListByName(string ListName);
        bool UpdateList(string ListName, List list);
        void RemoveList(string List);
        List<Card> GetCards(string ListId);
        


        ICollection<List> GetLists(string BoardName);
        ICollection<Member> GetBoardMembers(string BoardName);
        ICollection<Invite> GetBoardInvites(string BoardName);
    }
}
