using System;

namespace GroupMe.Models
{
    public class GroupMember
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string AccountId { get; set; }
        public int GroupId { get; set; }
        public string Role { get; set; } = "member";
    }
}