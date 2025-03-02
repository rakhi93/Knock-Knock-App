using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Import this namespace

namespace KnockKnock.Web.Models
{
    [Table("Request")] // Map this entity to the "Request" table
     public class Request
    {
        [Key]
        public int RequestID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Status { get; set; } = 0; // 0 = Pending, 1 = Approved, 2 = Rejected
        public DateTime? UpdatedAt { get; set; }
    }
}
