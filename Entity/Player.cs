using Entity.Models;
using Entity.Models.BaseEntityModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entity
{
	[Serializable]
	public class Player:BaseEntity
    {
        public int PlayerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
		public Team Team {  get; set; }
        public int TeamId { get; set; }

		public override string TableName => "Players";

		public override string[] PrimaryKey => new string[] { "PlayerId" };

        public override string[] ForeignKeys => new string[] { "TeamId" };

        public override string InsertValues => $"@FirstName, @LastName," +
            $"@Position, @TeamId";

        public override string UpdateValues => throw new NotImplementedException();

		public override string WhereQueryId => throw new NotImplementedException();

		public override string Join => throw new NotImplementedException();

		public override List<SqlParameter> Parameters => new List<SqlParameter>
        {
           new SqlParameter("FirstName", FirstName),
           new SqlParameter("LastName", LastName),
           new SqlParameter("Position", Position),
           new SqlParameter("TeamId", Team.TeamId)

        };
        public override List<IEntity> GetListOfObjects(SqlDataReader reader)
		{
			throw new NotImplementedException();
		}
	}
}
