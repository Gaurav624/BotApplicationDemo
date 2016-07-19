using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class PricesRepository : Repository<Price>,IPricesRepository
    {
        public PricesRepository(BookingContext context) :base (context)
        {

        }

        public BookingContext BookingContext
        {
            get { return Context as BookingContext; }
        }
    }
}
