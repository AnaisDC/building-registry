namespace BuildingRegistry.Api.CrabImport.Infrastructure
{
    using System.Data;
    using BuildingRegistry.Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using ValueObjects;

    public class SqlOsloIdGenerator : IOsloIdGenerator
    {
        private readonly SequenceContext _context;

        public SqlOsloIdGenerator(SequenceContext context)
        {
            _context = context;
        }

        public OsloId GenerateNextOsloId()
        {
            var sqlStatement = $"SELECT NEXT VALUE FOR {Schema.Sequence}.{SequenceContext.BuildingOsloIdSequenceName}";

            int nextNumber;
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.Connection.Open();
                command.CommandText = sqlStatement;
                command.CommandType = CommandType.Text;

                nextNumber = (int)command.ExecuteScalar();
                command.Connection.Close();
            }

            return new OsloId(nextNumber);
        }
    }
}
