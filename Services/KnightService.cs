using System;
using System.Collections.Generic;
using knights.Models;
using knights.Repositories;

namespace knights.Services
{
    public class KnightService
    {
        private readonly KnightRepository _repo;

        public KnightService(KnightRepository kr)
        {
            _repo = kr;
        }

        internal List<Knight> Get()
        {
            return _repo.GetAll();
        }

        internal Knight Get(int id)
        {
            Knight found = Get(id);
            if (found == null)
            {
                throw new Exception("Invalid Id");
            }
            return found;
        }

        internal Knight Create(Knight newKnight)
        {
            _repo.Create(newKnight);
            return newKnight;
        }

        internal Knight Update(Knight updatedKnight)
        {
            Knight oldKnight = Get(updatedKnight.Id);
            updatedKnight.Name = updatedKnight.Name != null ? updatedKnight.Name : oldKnight.Name;
            updatedKnight.Type = updatedKnight.Type != null ? updatedKnight.Type : oldKnight.Type;
            return _repo.Update(updatedKnight);
        }

        internal void Remove(int id)
        {
            Knight knight = Get(id);
            _repo.Remove(id);
        }
    }
}