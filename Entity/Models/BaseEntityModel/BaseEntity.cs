using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Models.BaseEntityModel
{
    [Serializable]
    public abstract class BaseEntity:IEntity    
    {
        public abstract string TableName { get; }
        public abstract string[] PrimaryKey { get; }
        public abstract string[] ForeignKeys { get; }
        public abstract string InsertValues { get; }
        public abstract string UpdateValues { get; }
        public abstract string WhereQueryId { get; }
        public abstract string Join { get; }
        public abstract List<SqlParameter> Parameters { get; }
        public abstract List<IEntity> GetListOfObjects(SqlDataReader reader);
    }
}
