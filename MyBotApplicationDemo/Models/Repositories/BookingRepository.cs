using MyBotApplicationDemo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(BookingContext context) : base(context)
        {
        }

        public BookingContext BookingContext
        {
            get { return Context as BookingContext; }
        }

        public Booking GetBooking(DateTime? dateTime, int countTicket, string location = "Hyderabad", string Movie = "Avengers", string Theatre = "PVR")
        {
            Booking booking = new Booking();
            booking.Location = GetLocationDetails(location);
            return booking;
        }

        private IEnumerable<Location> GetLocationDetails(string location)
        {
            using (var unitofWork = new UnitofWork(BookingContext))
            {
                return unitofWork.Locations.GetLocation(location);
            }
        }

        public void Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Location> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Location> Find(Expression<Func<Location, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Location entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Location> entities)
        {
            throw new NotImplementedException();
        }
    }
}