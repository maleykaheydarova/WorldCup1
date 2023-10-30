using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WorldCup1.Models;
using WorldCup1.Operations.Abstract;

namespace WorldCup1.Operations.Concrete
{
    public class CountryManager : ICountryOperation
    {
        public void Add(Country item)
        {
            DB.Countries.Add(item);
        }

        public void Delete(Country item)
        {
            DB.Countries.Remove(item);
        }

        public Country Get(int id)
        {
            return DB.Countries.FirstOrDefault(x => x.ID == id);
        }

        public List<Country> GetAll()
        {
            return DB.Countries;
        }

        public int GetNextId()
        {
            if (!DB.Countries.Any())
            {
                return DefaultConstants.DEFAULT_INITIAL_ID;
            }
            else
            {
                return DB.Countries.Max(x => x.ID) + 1;
            }
        }

        public void Update(Country item)
        {
            var oldModel = DB.Countries.FirstOrDefault(x => x.ID == item.ID);
            oldModel = item;
        }
    }
}