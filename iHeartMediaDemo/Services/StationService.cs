using iHeartMediaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iHeartMediaDemo.Services
{
    public class StationService
    {
        private StationDbEntities _db = new StationDbEntities();

        public List<Station> getAll()
        {
            return _db.Stations.ToList();
        }

        public void addStation(Station station)
        {
            if(_db.Stations.FirstOrDefault(s => s.Id == station.Id) != null)
            {
                throw new System.ArgumentException("This station already exists");
            }
            else
            {
                _db.Stations.Add(station);
                _db.SaveChanges();
            }
        }

        public Station getStationById(int id)
        {
            return _db.Stations.FirstOrDefault(s => s.Id == id);
        }

        public Station getStationByName(String name)
        {
            return _db.Stations.FirstOrDefault(s => s.Name == name);
        }
    }
}