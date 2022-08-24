

namespace dm_api.Domain.Entities
{
    public class Client: Base
    {
        public string FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? MobilePhone { get; set; }
        public string? email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}