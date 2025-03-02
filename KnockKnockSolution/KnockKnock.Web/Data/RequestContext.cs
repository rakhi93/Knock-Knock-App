using KnockKnock.Web.Models;
using System.Data.Entity;
//Note:Communicating with database using entity framework
namespace KnockKnock.Web.Data
{
    public class RequestContext : DbContext
    //Note:Following OOP Concept Inheritence
    {
        public RequestContext() : base("name=KnockKnockDB") { }
        public DbSet<Request> Requests { get; set; }
    }
}