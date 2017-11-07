using iHeartMediaDemo.Models;
using iHeartMediaDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace iHeartMediaDemo.Controllers
{
    [RoutePrefix("api/stations")]
    public class StationController : ApiController
    {
        StationService _stationService = new StationService();

        [HttpGet]
        [Route("")]
        public List<Station> Get()
        {
            return _stationService.GetAll();
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage AddStation([FromBody]Station station)
        {
            _stationService.AddStation(station);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}")]
        public Station GetById(int id)
        {
            return _stationService.GetStationById(id);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public Station GetByName(String Name)
        {
            return _stationService.GetStationByName(Name);
        }

        [HttpGet]
        [Route("getByHdEnabled/{hdEnabled}")]
        public List<Station> GetByHdEnabled(bool hdEnabled)
        {
            return _stationService.GetByHdEnabled(hdEnabled);
        }

        [HttpDelete]
        [Route("deleteStation/{id}")]
        public HttpResponseMessage DeleteStation(int id)
        {
            _stationService.DeleteStation(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        [Route("updateStation/")]
        public HttpResponseMessage UpdateStation([FromBody]Station station)
        {
            _stationService.UpdateStation(station);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
