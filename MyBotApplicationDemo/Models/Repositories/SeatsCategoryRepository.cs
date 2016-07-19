using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class SeatsCategoryRepository :Repository<SeatsCategory>,ISeatsCategoryRepository
    {
        public SeatsCategoryRepository(BookingContext context) : base(context) { }
        public BookingContext BookingContext
        {
            get { return Context as BookingContext; }
        }
    }
}
