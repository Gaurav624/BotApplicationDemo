using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class UserRepository :Repository<User>,IUserRepository
    {
        public UserRepository(BookingContext context):base(context)
        { }

        public BookingContext BookingContext
        { get { return Context as BookingContext; } }
    }
}
