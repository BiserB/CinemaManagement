﻿using CM.Common.BindingModels;
using CM.Common.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;

namespace CM.App.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomService service;

        public RoomController(IRoomService roomService)
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
        public async Task<IHttpActionResult> Create(CreateRoomBindingModel model)
        {
            var room = this.service.GetByCinemaAndNumber(model.CinemaId, model.Number);

            if (room != null)
            {
                return BadRequest("Room already exists");
            }

            bool isCreated = await this.service.Insert(model);

            if (!isCreated)
            {
                return BadRequest("Error while creating a room");
            }

            return Ok(room);
        }
    }
}