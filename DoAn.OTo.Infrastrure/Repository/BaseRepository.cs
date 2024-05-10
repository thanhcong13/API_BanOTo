using Dapper;
using DoAn.OTo.Core.BuidAttribute;
using DoAn.OTo.Core.Entities;
using DoAn.OTo.Core.Interfaces.Infrastrure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DoAn.OTo.Infrastrure.Repository
{
    public class BaseRepository<OToEntity> : IBaseRepository<OToEntity>
    {
        protected readonly string ConnectionString = "Port=3306;Database = banoto; User Id=root;Host=localhost;Character Set=utf8;Allow User Variables=True";
        protected MySqlConnection SqlConnection;

        public int Delete(Guid entityID)
        {
            var className = typeof(OToEntity).Name;
            var propNameID = string.Empty;
            var propValueID = string.Empty;
            DynamicParameters parameters = new DynamicParameters();
            var props = typeof(OToEntity).GetProperties();

            bool isFirstElement = true;
            foreach (var prop in props)
            {

                if (isFirstElement)
                {
                    propNameID = prop.Name;
                    propValueID = $"@{propNameID}";
                    parameters.Add(propValueID, entityID);
                    isFirstElement = false;
                    break;
                }

            }
            var sqlCommand = $"DELETE FROM {className} WHERE {propNameID} = {propValueID}";
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var res = SqlConnection.Execute(sql: sqlCommand, param: parameters);
                return res;
            }
        }

        public virtual IEnumerable<OToEntity> GetAll()
        {
            var className = typeof(OToEntity).Name;
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var entities = SqlConnection.Query<OToEntity>($"SELECT * FROM {className}");
                return entities;
            }
        }
      
        public virtual int Inssert(OToEntity entity)
        {
            var className = typeof(OToEntity).Name;
            var sqlColumsName = new StringBuilder();
            var sqlColumnValue = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();
            string delimiter = "";
            var props = typeof(OToEntity).GetProperties();
            foreach (var prop in props)
            {
                var propName = prop.Name;
                var propValue = prop.GetValue(entity);

                var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));
                if (primaryKey == true)
                {
                    if (prop.PropertyType == typeof(Guid))
                    {
                        propValue = Guid.NewGuid();
                    }
                }

                var paramName = $"@{propName}";
                sqlColumsName.Append($"{delimiter} {propName}");
                sqlColumnValue.Append($"{delimiter}{paramName}");
                delimiter = ",";

                parameters.Add(paramName, propValue);
            }
            var sqlCommand = $"INSERT INTO {className} ({sqlColumsName.ToString()}) VALUES ({sqlColumnValue.ToString()})";
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var res = SqlConnection.Execute(sql: sqlCommand, param: parameters);
                return res;
            }

        }

        public virtual int Update(OToEntity entity, Guid entityID)
        {
            var className = typeof(OToEntity).Name;
            var paramNameID = string.Empty;
            var propNameID = string.Empty;
            var propValueID = string.Empty;
            var sqlColumsName = new StringBuilder();
            var sqlColumnValue = new StringBuilder();
            DynamicParameters parameters = new DynamicParameters();
            string delimiter = "";
            var props = typeof(OToEntity).GetProperties();

            bool isFirstElement = true;
            foreach (var prop in props)
            {

                if (isFirstElement)
                {
                    propNameID = prop.Name;
                    propValueID = $"@{propNameID}";
                    parameters.Add(propValueID, entityID);
                    isFirstElement = false;
                }
                else
                {
                    var propName = prop.Name;
                    var propValue = prop.GetValue(entity);
                    var paramName = $"@{propName}";
                    var sqlColumsNames = ($"{propName}= {paramName}");
                    sqlColumnValue.Append($"{delimiter}{sqlColumsNames}");
                    delimiter = ",";
                    parameters.Add(paramName, propValue);

                }


            }
            var sqlCommand = $"UPDATE {className} SET {sqlColumnValue} WHERE {propNameID} = {propValueID}";
            using (SqlConnection = new MySqlConnection(ConnectionString))
            {
                var res = SqlConnection.Execute(sql: sqlCommand, param: parameters);
                return res;
            }
        }
       

        


        /* public bool CheckDulicateCode(Guid entityID)
         {
             var className = typeof(OToEntity).Name;
             var propNameID = string.Empty;
             var propValueID = string.Empty;
             DynamicParameters parameters = new DynamicParameters();
             var props = typeof(OToEntity).GetProperties();

             bool isFirstElement = true;
             foreach (var prop in props)
             {

                 if (isFirstElement)
                 {
                     propNameID = prop.Name;
                     propValueID = $"@{propNameID}";
                     parameters.Add(propValueID, entityID);
                     isFirstElement = false;
                     break;
                 }

             }
             var sqlCommand = $"SELECT {propNameID} FROM {className} WHERE {propNameID} = {propValueID}";
             var res = SqlConnection.QueryFirstOrDefault<Guid>(sqlCommand, param: parameters);
             if (res != null)
             {
                 return true;
             }
             else
                 return false;

         }*/
    }
}