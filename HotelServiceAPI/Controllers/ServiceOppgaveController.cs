using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SQLConnectionApplication.DataProviders;
using SQLConnectionApplication.Model;
using System.Data.Entity;
using HotelServiceAPI.Models;

namespace HotelServiceAPI.Controllers
{
    [RoutePrefix("ServiceOppgaver")]
    public class ServiceOppgaveController : ApiController
    {

        [Route("")]
        [HttpGet]
        public IHttpActionResult HentAlleOppgaver()
        {
            ServiceOppgaveDataprovider _serviceOppgaveDataprovider = new ServiceOppgaveDataprovider();
            List<ServiceOppgave> alleOppgaver = _serviceOppgaveDataprovider.FinnAlleOppgaver();

            var oppgaver = new List<ServiceOppgaveDTO>();

            foreach (var rom in alleOppgaver)
            {
                oppgaver.Add(new ServiceOppgaveDTO().CreateFromEntity(rom));
            }
            return Ok(oppgaver);
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult OppdaterOppgave([FromUri] int oppgaveId, [FromUri] string notat)
        {
            ServiceOppgaveDataprovider _serviceOppgaveDataprovider = new ServiceOppgaveDataprovider();

            _serviceOppgaveDataprovider.OppdaterServiceOppgave(oppgaveId, notat);
            return Ok();
        }
    }
}
