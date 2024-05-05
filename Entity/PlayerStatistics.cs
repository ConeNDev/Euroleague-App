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
	public class PlayerStatistics : BaseEntity
	{
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int PlayersPoints { get; set; }

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
