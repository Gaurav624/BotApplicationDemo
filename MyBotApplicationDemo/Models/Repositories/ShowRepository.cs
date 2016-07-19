using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class ShowRepository:Repository<Show>,IShowRepository
    {
        public ShowRepository(BookingContext context):base(context)
        { }
        public BookingContext BookingContext { get { return Context as BookingContext; } }
    }
}
