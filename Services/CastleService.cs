using System;
using System.Collections.Generic;
using knights.Models;
using knights.Repositories;

namespace knights.Services
{
    public class CastleService
    {
        private readonly CastleRepository _repo;

        public CastleService(CastleRepository repo)
        {
            _repo = repo;
        }

        internal List<Castle> Get()
        {
            return _repo.GetAll();
        }

        internal Castle Get(int id)
        {
            Castle found = _repo.GetById(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Castle Create(Castle newCastle)
        {
            _repo.Create(newCastle);
            return newCastle;
        }

        internal Castle Update(Castle updatedCastle)
        {
            Castle oldCastle = Get(updatedCastle.Id);
            updatedCastle.Name = updatedCastle.Name != null ? updatedCastle.Name : oldCastle.Name;
            updatedCastle.Country = updatedCastle.Country != null ? updatedCastle.Country : oldCastle.Country;
            return _repo.Update(updatedCastle);
        }

        internal void Remove(int id)
        {
            Castle castle = Get(id);
            _repo.Remove(id);
        }
    }
}