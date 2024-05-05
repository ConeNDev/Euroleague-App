using Entity;
using Entity.Models;
using EuroleagueApp.UserControls.UCPlayers;
using EuroleagueApp.UserControls.UCTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EuroleagueApp.UIControllers
{
	public class PlayerUIController
	{
		private UCPlayerCreate playerCreate;
        Player player;

		public UCPlayerCreate MakeCreatePlayerWindow()
		{
			playerCreate = new UCPlayerCreate();
			CmbTeamsFill();
            CmbPositionsFill();
			playerCreate.btnCreate.Click += BtnCreate;
            return playerCreate; 

		}

        

        private void BtnCreate(object sender, EventArgs e)
        {
			try
			{
				Player player = new Player()
				{
					FirstName = playerCreate.txtFirstName.Text,
					LastName = playerCreate.txtLastName.Text,
					Position = playerCreate.cmbPositions.SelectedItem + "",
					Team = (Team)playerCreate.cmbTeams.SelectedItem
				};
                if (string.IsNullOrWhiteSpace(player.FirstName) 
					|| !player.FirstName.All(char.IsLetter))
                {
                    MessageBox.Show("Invalid player name." +
						" Please enter a valid name without numbers.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(player.LastName)
                    || !player.LastName.All(char.IsLetter))
                {
                    MessageBox.Show("Invalid player name." +
                        " Please enter a valid name without numbers.");
                    return;
                }
                player = CommunicationHelper.Instance.InsertPlayer(player);
                this.player = player;
            }
			catch (Exception ex)
			{
                string message = "Player can't be null and" + " " + ex.Message;
                MessageBox.Show(message);
            }
        }
        private void CmbPositionsFill()
        {
            object[] positions = { 1, 2, 3, 4, 5 };
            playerCreate.cmbPositions.Items.Clear();
            playerCreate.cmbPositions.Items.AddRange(positions);
   
            
        }
        private void CmbTeamsFill()
        {
			try
			{
                List<Team> teams = CommunicationHelper.Instance.GetAllTeams();
                playerCreate.cmbTeams.Items.Clear();
                playerCreate.cmbTeams.Items.AddRange(teams.ToArray());
                playerCreate.cmbTeams.DisplayMember = "Name";
            }
			catch (Exception)
			{

				string message = "ComboBox with teams can't be empty";
				MessageBox.Show(message);
			}
        }
    }
}
