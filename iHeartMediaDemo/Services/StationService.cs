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

        public List<Station> GetAll()
        {
            return _db.Stations.ToList();
        }

        public void AddStation(Station station)
        {
            if(_db.Stations.FirstOrDefault(s => s.Id == station.Id) != null)
            {
                throw new System.ArgumentException("This station already exists");
            }

            _db.Stations.Add(station);
            _db.SaveChanges();            
        }

        public Station GetStationById(int id)
        {
            return _db.Stations.FirstOrDefault(s => s.Id == id);
        }

        public Station GetStationByName(String name)
        {
            return _db.Stations.FirstOrDefault(s => s.Name == name);
        }

        public List<Station> GetByHdEnabled(bool hdEnabled)
        {
            return _db.Stations.Where(s => s.HdEnabled == hdEnabled).ToList();
        }

        public void DeleteStation(int id)
        {
            Station toRemove = _db.Stations.FirstOrDefault(s => s.Id == id);

            if (toRemove == null)
            {
                throw new System.ArgumentException("This stationId does not exist");
            }

            _db.Stations.Remove(toRemove);
            _db.SaveChanges();
        }

        public void UpdateStation(Station station)
        {
            Station toUpdate = _db.Stations.FirstOrDefault(s => s.Id == station.Id);

            if (toUpdate == null)
            {
                throw new System.ArgumentException("This stationId does not exist");
            }

            toUpdate.Name = station.Name;
            toUpdate.HdEnabled = station.HdEnabled;
            toUpdate.CallSign = station.CallSign;

            _db.SaveChanges();
        }
    }
}