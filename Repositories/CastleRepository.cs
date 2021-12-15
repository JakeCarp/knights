using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using knights.Models;

namespace knights.Repositories
{
    public class CastleRepository
    {
        private readonly IDbConnection _db;

        public CastleRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Castle> GetAll()
        {
            string sql = @"SELECT * FROM castles;";
            return _db.Query<Castle>(sql).ToList();
        }

        internal Castle GetById(int id)
        {
            string sql = @"SELECT * FROM castles WHERE id = @id;";
            return _db.QueryFirstOrDefault<Castle>(sql, new { id });
        }

        internal Castle Create(Castle newCastle)
        {
            string sql = @"
            INSERT INTO castles
             (name, country)
            VALUES
             (@Name, @Country)
            ;
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCastle);
            newCastle.Id = id;
            return newCastle;

        }

        internal Castle Update(Castle updatedCastle)
        {
            string sql = @"
            UPDATE castles
            SET
            name = @Name,
            country = @Country
            WHERE id = @Id
            ;";
            int rows = _db.Execute(sql, updatedCastle);
            if (rows <= 0)
            {
                throw new Exception("Castle was not updated!");
            }
            return updatedCastle;
        }

        internal void Remove(int id)
        {
            string sql = @"
            DELETE FROM castles
            WHERE id = @Id;";
            int rows = _db.Execute(sql, new { id });
            if (rows <= 0)
            {
                throw new Exception("Invalid ID");
            }
        }
    }
}