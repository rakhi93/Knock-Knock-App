//Note:Communicating with database using entity framework
using KnockKnock.Web.Models;
using System.Data.Entity;

namespace KnockKnock.Web.Data
{
    public class RequestContext : DbContext
    //Note:Following OOP Concept Inheritence
    {
        public RequestContext() : base("name=KnockKnockDB") { }
        public DbSet<Request> Request { get; set; }
    }
}