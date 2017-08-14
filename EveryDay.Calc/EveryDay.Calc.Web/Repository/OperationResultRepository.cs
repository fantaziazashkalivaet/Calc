using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EveryDay.Calc.Web.Repository
{
    public class OperationResultRepository : IRepository<OperationResult>
    {
        public void Create(OperationResult obj)
        {
            var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Calc\EveryDay.Calc\EveryDay.Calc.Web\App_Data\Calc.mdf;Integrated Security=True";
            string queryString = String.Format("INSERT into dbo.Operation (OperationId, Inputs, ExecutionDate, ExecutionTime, Result, Error, UserId) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}')", obj.OperationId, obj.Inputs, obj.ExecutionDate, obj.ExecutionTime, obj.Result, obj.Error, obj.UserId);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                command.ExecuteNonQuery();

            }
 	        throw new NotImplementedException();
        }

        public OperationResult Read(long Id)
        {
 	        throw new NotImplementedException();
        }

        public void Update(OperationResult obj)
        {
 	        throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
 	        throw new NotImplementedException();
        }

        public IEnumerable<OperationResult> GetAll()
        {
 	        throw new NotImplementedException();
        }
    }

    public class OperationResult
    {
        public long Id { get; set;  }

        public long OperationId { get; set; }

        public string Inputs { get; set; }

        public DateTime ExecutionDate { get; set; }

        public long ExecutionTime { get; set; }

        public double Result { get; set; }

        public string Error { get; set; }

        public long UserId { get; set; }
    }
}