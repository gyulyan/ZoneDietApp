namespace ZoneDietApp.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string DateTime { get; set; } = null!;
    }
}
