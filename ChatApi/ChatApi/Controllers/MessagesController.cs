using ChatApi.DTOs;
using ChatApi.Model;
using ChatApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("CreateRoom")]
        public IActionResult CreateRoom(RoomToCreate room)
        {
            if (room.Name is null)
                return BadRequest(ModelState);

            _messageService.CreateRoom(room);
            return Ok();
        }

        [HttpGet]
        [Route("GetAllRooms")]
        public IActionResult GetAllRooms()
        {
            var Rooms = _messageService.GetAllGroups();
            return Ok(Rooms);
        }

        [HttpPost]
        [Route("SendMessage")]
        public IActionResult SendMessage(MessageToCreate messageTo)
        {
            if (messageTo.Message is null)
                return BadRequest(ModelState);
            var Room = _messageService.GetRoomById(messageTo.RoomId);
            if (Room == null)
                return NotFound(ModelState);

            _messageService.SendMessageInSpasificGroup(messageTo);

            return Ok();
        }

        [HttpGet]
        [Route("GetMessagesinSpasificRoom/{RoomId}")]
        public IActionResult GetMessages(int RoomId)
        {
            var Message = _messageService.GetMessagesInSpasificGroup(RoomId);

            return Ok(Message);
        }
    }
}