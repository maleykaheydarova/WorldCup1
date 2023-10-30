using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCup1.Models;
using WorldCup1.Operations.Abstract;

namespace WorldCup1.Operations.Concrete
{
    public class GroupManager : IGroupOperation
    {
        public void Add(Groups item)
        {
            DB.Groups.Add(item);
        }

        public void Delete(Groups item)
        {
            DB.Groups.Remove(item);
        }

        public Groups Get(int id)
        {
            return DB.Groups.FirstOrDefault(x => x.ID == id);
        }

        public List<Groups> GetAll()
        {
            return DB.Groups;
        }

        public void Update(Groups item)
        {
            var oldModel = DB.Groups.FirstOrDefault(x => x.ID == item.ID);
            oldModel = item;
        }

        public int GetNextId()
        {
            if (!DB.Groups.Any())
            {
                return DefaultConstants.DEFAULT_INITIAL_ID;
            }
            else
            {
                return DB.Groups.Max(x => x.ID) + 1;
            }
        }
    }
}