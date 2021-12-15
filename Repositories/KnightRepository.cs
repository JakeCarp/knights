using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights.Models;

namespace knights.Repositories
{
    public class KnightRepository
    {
        private readonly IDbConnection _db;

        public KnightRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Knight> GetAll()
        {
            string sql = @"SELECT * FROM knights;";
            return _db.Query<Knight>(sql).ToList();
        }

        internal void Create(Knight newKnight)
        {
            throw new NotImplementedException();
        }

        internal Knight Update(Knight updatedKnight)
        {
            throw new NotImplementedException();
        }

        internal void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}