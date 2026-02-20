namespace TasKManagementAPI.Models
{
    public class User
    {

        public int id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHadh { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }  = DateTime.UtcNow;

        // Nevigation Property
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
