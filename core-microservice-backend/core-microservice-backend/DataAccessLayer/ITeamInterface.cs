using core_microservice_backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.DataAccessLayer
{
    public  interface ITeamInterface
    {
        //Get all the teams
        List<Team> GetTeams();
        bool UpdateTeam(string Name, Team team);
        Team GetTeamByName(string TeamName);
        void CreateTeam(Team team);
        bool RemoveTeam(string Name);
        void CreateBoard(string TeamName, Board board);
        ICollection<Board> GetBoards(string TeamName);
        ICollection<Member> GetMembers(string TeamName);
        ICollection<Invite> GetInvites(string TeamName);
        
    }
}
