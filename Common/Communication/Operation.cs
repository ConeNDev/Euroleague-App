using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]
    public enum Operation
    {

        LoginUser,
        CreateTeam,
        CreatePlayer,
        FillComboBox,
        GetAllTeams,
        GetSelectedTeam,
		SearchTeam,
        UpdateTeam,
        GetAllPlayers,
    }
}
