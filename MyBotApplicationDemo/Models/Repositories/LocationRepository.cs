using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class LocationRepository : Repository<Location>, IlocationRepository
    {
        public LocationRepository(BookingContext context)
            : base(context)
        {
        }

        public IEnumerable<Location> GetLocation(string location)
        {
            return this.GetQuery<Location>().Where(x => x.Name == location);
        }
    }
}
