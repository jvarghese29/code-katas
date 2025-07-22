using System.Collections.Generic;
using System.Linq;
using Dapper;
using ProjectKanban.Data;
using ProjectKanban.Tasks;

namespace ProjectKanban.Users
{
    public sealed class UserRepository
    {
        private readonly IDatabase _database;

        public UserRepository(IDatabase database)
        {
            _database = database;
        }

        public void Create(UserRecord userRecord)
        {
            using (var connection = _database.Connect())
            {
                connection.Open();
                using var transaction = connection.BeginTransaction();
                connection.Execute("insert into user(username, password, client_id) VALUES (@Username, @Password, @ClientId)", userRecord);
                transaction.Commit();
            }
        }

        public UserRecord GetByUsername(string username)
        {
            using (var connection = _database.Connect())
            {
                connection.Open();
                return connection.QuerySingleOrDefault<UserRecord>(
                    "SELECT * FROM user WHERE username = @Username", new { Username = username });
            }
        }

        public List<UserRecord> GetAll()
        {
            using (var connection = _database.Connect())
            {
                connection.Open();
                var users =connection.Query<UserRecord>("SELECT * from user Order by Username Asc;");
                return users.ToList();
            }
        }
    }
}