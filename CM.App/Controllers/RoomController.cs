using CM.Services;
using CM.Services.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class RoomController : ApiController
    {
        private readonly RoomService service;

        public RoomController(RoomService roomService)
        {
            this.service = roomService;
        }

        public IHttpActionResult Get(int id)
        {
            var room = this.service.GetById(id);

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public IHttpActionResult Create(RoomCreationModel model)
        {
            var room = this.service.GetByCinemaAndNumber(model.CinemaId, model.Number);

            if (room != null)
            {
                return BadRequest("Room already exists");
            }

            bool isCreated = this.service.Insert(model);

            if (!isCreated)
            {
                return BadRequest("Error while creating a room");
            }

            return Ok(room);
        }
    }
}
