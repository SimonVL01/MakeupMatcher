/*using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net;
using MakeupMatcher.Core.Models;
using SQLite.Net.Attributes;
using System.Threading.Tasks;


namespace MakeupMatcher.Core.Repositories
{
    public class UserRepository
    {
        private SQLiteConnection _connection;

        //Constructor

        public UserRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _connection.CreateTable<UserModel>();
        }

        public void Create(UserModel user)
        {
            _connection.Insert(user);
            _connection.Commit();
        }

        public void Delete(UserModel user)
        {
            _connection.Delete(user);
            _connection.Commit();
        }

        public UserModel Get(int userId)
        {
            var query = from c in _connection.Table<UserModel>()
                        where c.UserId == userId
                        select c;

            return query.FirstOrDefault();
        }

        public List<UserModel> GetAll()
        {
            var query = from c in _connection.Table<UserModel>()
            select c;

            return query.ToList();
        }

        public void Update(UserModel user)
        {
            _connection.Update(user);
            _connection.Commit();
        }
    }
}*/