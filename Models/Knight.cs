namespace knights.Models
{
    public class Knight
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int CastelId { get; set; }
        public Castle Castle { get; set; }
        public int Id { get; set; }
    }
}