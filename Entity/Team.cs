using Entity.Models;
using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	[Serializable]
	public class Team : BaseEntity
    {
        public int TeamId { get; set; }
        public string Name { get; set; }
        public int EuroleagueChampionsTitles { get; set; }
        public string Coach { get; set; }
		public string Arena { get; set; }
		[Browsable(false)]
		public City City { get; set; }
        public int CityId { get; set; }
        public List<Player> PlayersList { get; set; }
		[Browsable(false)]
		public override string TableName => "Teams";
		[Browsable(false)]
		public override string[] PrimaryKey => new string[] {"TeamId"};
		[Browsable(false)]
		public override string[] ForeignKeys => new string[] { "CityId" };
		[Browsable(false)]
		public override string InsertValues =>$"@Name, @EuroleagueChampionsTitles," +
			$"@Coach, @Arena, @CityId";
		[Browsable(false)]
		public override string UpdateValues => "Name=@Name, EuroleagueChampionsTitles=" +
			"@EuroleagueChampionsTitles, Coach=@Coach, Arena=@Arena, CityId=@CityId";
		[Browsable(false)]
		public override string WhereQueryId => "";
		[Browsable(false)]
		public override string Join => "";

		public override List<SqlParameter> Parameters => new List<SqlParameter>
		{
		   new SqlParameter("Name", Name),
		   new SqlParameter("EuroleagueChampionsTitles", EuroleagueChampionsTitles),
		   new SqlParameter("Coach", Coach),
		   new SqlParameter("Arena", Arena),
		   new SqlParameter("CityId", City.CityId)
		   
		};

        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
        {
			try
			{
				List<IEntity> teamList = new List<IEntity>();
				while (reader.Read())
				{
					Team team = new Team()
					{
						TeamId= reader.GetInt32(0),
						Name = reader.GetString(1),
						EuroleagueChampionsTitles = reader.GetInt32(2),
						Coach = reader.GetString(3),
						Arena = reader.GetString(4),
						CityId=reader.GetInt32(5),						
					};
					teamList.Add(team);
				}
				return teamList;
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.Message);
				reader.Close();
				throw ex;
			}
            
        }
    }
}
