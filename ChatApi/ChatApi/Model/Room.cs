namespace ChatApi.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Message> Messages { get; set; }
    }
}