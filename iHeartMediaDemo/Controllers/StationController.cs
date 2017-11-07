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
        public List<Station> get()
        {
            return _stationService.getAll();
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage addStation([FromBody]Station station)
        {
            _stationService.addStation(station);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}")]
        public Station getById(int id)
        {
            return _stationService.getStationById(id);
        }

        [HttpGet]
        [Route("getByName/{name}")]
        public Station getByName(String Name)
        {
            return _stationService.getStationByName(Name);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
