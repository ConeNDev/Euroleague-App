using Entity;
using Entity.Models;
using EuroleagueApp.Forms;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
    public class ChangesUIController
    {
        private Team selectedTeam;
        public MenuForm menuForm;
        public UCTeamEditData teamEditData;
        public UCTeamEditData MakeTeamEditWindow(Team selectedTeam)
        {
            this.selectedTeam = selectedTeam;
            teamEditData = new UCTeamEditData();
            teamEditData.txtName.Text = selectedTeam.Name;
            teamEditData.txtArena.Text = selectedTeam.Arena;
            teamEditData.txtEuroleagueTitles.Text = selectedTeam.
                EuroleagueChampionsTitles.ToString();

            List<City> cities= CommunicationHelper.Instance.GetAllCities();
            teamEditData.cmbCity.Items.Clear();
            teamEditData.cmbCity.Items.AddRange(cities.ToArray());
            teamEditData.cmbCity.DisplayMember = "Name";


            foreach (var city in cities)
            {
                if (city.CityId == selectedTeam.CityId)
                {
                    teamEditData.cmbCity.Text = city.Name;
                }
            }
            
            teamEditData.txtCoach.Text = selectedTeam.Coach;
            teamEditData.btnUpdate.Click += BtnUpdateTeam;
            return teamEditData;
        }

        private void BtnUpdateTeam(object sender, EventArgs e)
        {
            try
            {
                Team teamToUpdate = new Team()
                {
                    TeamId = selectedTeam.TeamId,
                    Name = teamEditData.txtName.Text,
                    EuroleagueChampionsTitles = int.Parse(teamEditData
                    .txtEuroleagueTitles.Text),
                    Coach = teamEditData.txtCoach.Text,
                    Arena = teamEditData.txtArena.Text,
                    City = (City)teamEditData.cmbCity.SelectedItem

                };
                if (string.IsNullOrEmpty(teamToUpdate.Name)
                   || !teamToUpdate.Name.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid team name." +
                        " Please enter a valid name without numbers.");
                    return;
                }

                if (string.IsNullOrEmpty(teamToUpdate.Coach)
                    || !teamToUpdate.Coach.All(c => char.IsLetter(c) || c == ' '))
                {
                    MessageBox.Show("Invalid coach name." +
                        " Please enter a valid name without numbers.");
                    return;
                }
                Team updatedTeam=CommunicationHelper.Instance.UpdateTeam(teamToUpdate);
                teamEditData.txtName.Text = updatedTeam.Name;
                teamEditData.txtEuroleagueTitles.Text = updatedTeam.EuroleagueChampionsTitles
                    +"";
                teamEditData.txtCoach.Text = updatedTeam.Coach;
                teamEditData.txtArena.Text = updatedTeam.Arena;
                //teamEditData.cmbCity.SelectedItem= updatedTeam.City.Name;
            }
            catch (Exception ex)
            {
                string message = "Team can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }
    }
}
