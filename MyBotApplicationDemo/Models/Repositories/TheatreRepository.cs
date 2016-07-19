using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class TheatreRepository:Repository<Theatre>,ITheatreRepository
    {
        public TheatreRepository(BookingContext context) : base(context)
        { }
        public BookingContext BookingContext { get { return Context as BookingContext; } }
    }
}
