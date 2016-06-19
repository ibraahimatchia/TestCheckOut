using StationeryWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StationeryWebAPI.Services;

namespace StationeryWebAPI.Controllers
{
    public class StationeryController : ApiController
    {
        // represent the instance of the repository
        private StationeryRepository StationeryRepository;

        public StationeryController()
        {
            //instantiating the Stationery repository
            this.StationeryRepository = new StationeryRepository();
        } 

        public Stationery[] Get()
        {
            return StationeryRepository.GetAllStationery();
        }

        public HttpResponseMessage Post(Stationery stationery)
        {
            this.StationeryRepository.AddStationery(stationery);

            var response = Request.CreateResponse<Stationery>(System.Net.HttpStatusCode.Created, stationery);

            return response;
        }
    }
}
