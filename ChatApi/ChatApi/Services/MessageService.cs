using ChatApi.Data;
using ChatApi.DTOs;
using ChatApi.Model;

namespace ChatApi.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _dbContext;

        public MessageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateRoom(RoomToCreate Room)
        {
            var RoomToCreate = new Room()
            {
                Name = Room.Name,
            };
            _dbContext.Rooms.Add(RoomToCreate);
            _dbContext.SaveChanges();
        }

        public List<Room> GetAllGroups()
        {
            return _dbContext.Rooms.ToList();
        }

        public List<Message> GetMessagesInSpasificGroup(int RoomId)
        {
            var Messages = _dbContext.messages.Where(m => m.RoomId == RoomId).OrderByDescending(c => c.Id).Take(12).ToList();
            return Messages;
        }

        public Room GetRoomById(int RoomId)
        {
            var Roome = _dbContext.Rooms.Find(RoomId);

            return Roome;
        }

        public void SendMessageInSpasificGroup(MessageToCreate messageTo)
        {
            var MessageToSend = new Message()
            {
                RoomId = messageTo.RoomId,
                Text = messageTo.Message
            };
            _dbContext.messages.Add(MessageToSend);
            _dbContext.SaveChanges();
        }
    }
}