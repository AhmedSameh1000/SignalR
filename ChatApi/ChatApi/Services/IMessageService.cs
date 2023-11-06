using ChatApi.DTOs;
using ChatApi.Model;
using System.Text.RegularExpressions;

namespace ChatApi.Services
{
    public interface IMessageService
    {
        List<Message> GetMessagesInSpasificGroup(int RoomId);

        List<Room> GetAllGroups();

        void SendMessageInSpasificGroup(MessageToCreate messageTo);

        void CreateRoom(RoomToCreate Room);

        Room GetRoomById(int RoomId);
    }
}