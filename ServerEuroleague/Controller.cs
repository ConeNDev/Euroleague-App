using Common.Communication;
using Entity;
using Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations.SystemOperations;

namespace ServerEuroleague
{
    public class Controller
    {
        private static Controller instance;
        public static Controller Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Controller();
                }
                return instance;
            }
        }
        private Controller() { }

        public Response HandleSingleRequest(Request request)
        {
            Response response = new Response();
            try
            {
                switch (request.Operation)
                {
                    case Operation.LoginUser:
                        return response = LoginUser((User)request.Body);
                    case Operation.CreateTeam:
                        return response = CreateTeam((Team)request.Body);
                    case Operation.FillComboBox:
                        return response = FillComboBox();
                    case Operation.GetAllTeams:
                        return response = GetAllTeams();
                    case Operation.SearchTeam:
                        return response = SearchTeam((string)request.Body);
                    case Operation.CreatePlayer:
                        return response = CreatePlayer((Player)request.Body);
                    case Operation.GetSelectedTeam:
                        return response = GetSelectedTeam((Team)request.Body);
                    case Operation.UpdateTeam:
                        return response = UpdateTeam((Team)request.Body);
                    case Operation.GetAllPlayers:
                        return response = GetAllPlayers();
                }

            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        

        private Response UpdateTeam(Team team)
        {
            UpdateTeamSystemOperation updateTeamSO = new UpdateTeamSystemOperation();
            updateTeamSO.Team = team;
            updateTeamSO.Execute();
            return new Response(updateTeamSO.Team, Operation.UpdateTeam, "Successfully updated" +
                "team");
        }

        private Response CreatePlayer(Player player)
        {
            CreatePlayerSystemOperation createPlayerSO = new CreatePlayerSystemOperation();
            createPlayerSO.Player = player;
            createPlayerSO.Execute();
            return new Response(createPlayerSO.Player, Operation.CreatePlayer,
                "Successfully created player");
        }
        private Response CreateTeam(Team team)
        {
            CreateTeamSystemOperation createTeamSo = new CreateTeamSystemOperation();
            createTeamSo.Team = team;
            createTeamSo.Execute();
            return new Response(createTeamSo.Team, Operation.CreateTeam,
                "Successfully created team");
        }
        private Response SearchTeam(string filter)
		{
            SearchTeamSystemOperation searchTeamSo=new SearchTeamSystemOperation();
            searchTeamSo.filter = filter;
            searchTeamSo.Execute();
            return new Response(searchTeamSo.filteredTeams,Operation.SearchTeam,
                "Teams are filtered");
		}
        private Response GetSelectedTeam(Team selectedTeam)
        {
            GetSelectedTeamSystemOperation getSelectedTeamSO =
                new GetSelectedTeamSystemOperation();
            getSelectedTeamSO.selectedTeam = selectedTeam;
            getSelectedTeamSO.Execute();
            return new Response(getSelectedTeamSO.selectedTeam, Operation.GetSelectedTeam,
                "Successfully selected team, now you can edit him");
        }
        private Response GetAllTeams()
		{
			GetAllTeamSystemOperation getAllSo=new GetAllTeamSystemOperation();
            getAllSo.Execute();
            return new Response(getAllSo.TeamList,Operation.GetAllTeams,
				"Successfully withdrawn teams from the base");
		}
        private Response GetAllPlayers()
        {
            GetAllPlayerSystemOperation getAllSo = new GetAllPlayerSystemOperation();
            getAllSo.Execute();
            return new Response(getAllSo.PlayerList, Operation.GetAllPlayers,
                "Successfully withdrawn players from the base");
        }
        private Response FillComboBox()
		{
            FillCmbCitiesSystemOperation fillCmbBoxSo = new FillCmbCitiesSystemOperation();
            fillCmbBoxSo.Execute();
            return new Response(fillCmbBoxSo.cities, Operation.FillComboBox,
                "ComboBox successfully filled");
		}

		

        public Response LoginUser(User user)
        {
            LoginUserSystemOperation loginSo= new LoginUserSystemOperation();
            loginSo.User = user;
            loginSo.Execute();
            return new Response(data: loginSo.User, operation: Operation.LoginUser,
                message: "Successful login");
        }
    }
}
