using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
	[Serializable]
	public class Game : BaseEntity
	{
        public int GameId { get; set; }
        public DateTime GameTime { get; set; }
		public int PointsScoredByTeam1 { get; set; }
		public int PointsScoredByTeam2 { get; set; }
		public Team Team1 { get; set; }
		public int TeamId1 { get; set; }
		public Team Team2 { get; set; }
		public int TeamId2 { get; set; }

        
		public override string TableName => throw new NotImplementedException();

		public override string[] PrimaryKey => throw new NotImplementedException();

		public override string[] ForeignKeys => throw new NotImplementedException();

		public override string InsertValues => throw new NotImplementedException();

		public override string UpdateValues => throw new NotImplementedException();

		public override string WhereQueryId => throw new NotImplementedException();

		public override string Join => throw new NotImplementedException();

		public override List<SqlParameter> Parameters => throw new NotImplementedException();

		public override List<IEntity> GetListOfObjects(SqlDataReader reader)
		{
			throw new NotImplementedException();
		}
	}
}
