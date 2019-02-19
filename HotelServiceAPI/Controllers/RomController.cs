using HotelServiceAPI.Models;
using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelServiceAPI.Controllers
{
    [RoutePrefix("Rom")]
    public class RomController : ApiController
    {

        [HttpGet]
        [Route("")]
        public IHttpActionResult HentAlleRom()
        {
            RomDataprovider romDataprovider = new RomDataprovider();
            List<RomDTO> alleRom = romDataprovider.FinnAlleRom().Select(RomDTO.CreateFrom).ToList();
            if (alleRom.Count == 0)
            {
                return NotFound();
            }

            return Ok(alleRom);
        }
    }
}
