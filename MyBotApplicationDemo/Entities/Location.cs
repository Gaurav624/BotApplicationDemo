using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace MyBotApplicationDemo.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Name { get; set; }

        public Location(int id,string locname)
        {
            this.LocationId = id;
            this.Name = locname;
        }
    }
}