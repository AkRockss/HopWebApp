using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HopClassLib;

namespace HopWebApp.Managers
{
    public class HopsManager
    {

        private static int _nextId = 1;

        private static readonly List<Hop> Data = new List<Hop>
        {
            new Hop {Id = _nextId++, Name = "Amarillo", AlphaAcid = 7.5, HarvestYear = 2019, Price = 49},
            new Hop {Id = _nextId++, Name = "Cascade US", AlphaAcid = 6.5, HarvestYear = 2020, Price = 69},
            new Hop {Id = _nextId++, Name = "Chinook", AlphaAcid = 11.3, HarvestYear = 2020, Price = 65},
        };


        public List<Hop> GetAll(string sortBy = null)
        {
            List<Hop> hopSearch = new List<Hop>(Data);

            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "alphaacid":
                        hopSearch = hopSearch.OrderByDescending(hopSearch => hopSearch.AlphaAcid).ToList();
                        break;

                }
            }

            return hopSearch;
        }

        public Hop GetById(int id)
        {
            return Data.Find(Hop => Hop.Id == id);
        }

        public Hop Add(Hop newHop)
        {
            newHop.Id = _nextId++;
            Data.Add(newHop);
            return newHop;
        }

        public Hop Delete(int id) { 
            Hop hop = Data.Find(hop1 => hop1.Id == id);
            if (hop == null) return null;
            Data.Remove(hop);
            return hop;
        }

        public List<Hop> GetByPrice(int price)
        {
            List<Hop> hopPrice = new List<Hop>(Data);
            {
                if (price != null)
                {
                    hopPrice = hopPrice.FindAll(hopPrice => hopPrice.Price != null);

                }
                return hopPrice;
            }
        }



    }
}
