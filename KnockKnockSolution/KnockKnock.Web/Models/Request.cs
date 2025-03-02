using System;
using System.ComponentModel.DataAnnotations;

namespace KnockKnock.Web.Models  // Ensure correct namespace
{
    public class Request
    {
        [Key]
        //using OOP Concept-Encapsulation
        public int RequestID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int Status { get; set; } = 0; // 0 = Pending, 1 = Approved, 2 = Rejected
        public DateTime? UpdatedAt { get; set; }
    }
}
