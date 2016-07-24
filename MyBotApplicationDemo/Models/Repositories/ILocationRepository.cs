using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public interface IlocationRepository : IRepository<Location>
    {
        IEnumerable<Location> GetLocation(string location);
    }
}
