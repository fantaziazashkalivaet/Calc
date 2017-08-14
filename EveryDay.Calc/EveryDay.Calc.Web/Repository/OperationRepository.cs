using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EveryDay.Calc.Web.Repository
{
    public class OperationRepository : IRepository<Operation>
    {
        public void Create(Operation obj)
        {
            throw new NotImplementedException();
        }

        public Operation Read(long Id)
        {
            var result = new Operation();

            var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Calc\EveryDay.Calc\EveryDay.Calc.Web\App_Data\Calc.mdf;Integrated Security=True";
            string queryString = "SELECT Id, Name, Description FROM dbo.Operation WHERE dbo.Operation.Id = Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                reader.Read();
                    result = ReadSingleRow(reader);

                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }

        public void Update(Operation obj, long id)
        {
            var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Calc\EveryDay.Calc\EveryDay.Calc.Web\App_Data\Calc.mdf;Integrated Security=True";
            string queryString = "UPDATE dbo.Operation SET Name = obj.Name Description = obj.Description WHERE Id = id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

            }
            //throw new NotImplementedException();
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }


       public IEnumerable<Operation> GetAll()
        {

            var result = new List<Operation>();

            var connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Calc\EveryDay.Calc\EveryDay.Calc.Web\App_Data\Calc.mdf;Integrated Security=True";
            string queryString = "SELECT Id, Name, Description FROM dbo.Operation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                // Call Read before accessing data.
                while (reader.Read())
                {
                    result.Add(ReadSingleRow(reader));
                }

                // Call Close when done reading.
                reader.Close();
            }
            return result;
        }

       private Operation ReadSingleRow(IDataRecord record)
       {
           return new Operation()
           {
               Id = record.GetInt64(0),
               Name = record.GetString(1)
           };
           //Console.WriteLine(String.Format("{0}, {1}", record[0], record[1]));
       }

      
    }

    public class Operation
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}