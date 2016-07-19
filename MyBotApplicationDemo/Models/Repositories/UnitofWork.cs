using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
    public class UnitofWork :IUnitofWork
    {
        private readonly BookingContext _context;
        public UnitofWork(BookingContext context)
        {
            _context = context;
            Languages = new LanguageRepository(_context);
            Locations = new LocationRepository(_context);
            Seats = new SeatRepository(_context);
            Shows = new ShowRepository(_context);
            TheatreCategories = new TheatreCategoryRepository(_context);
            Theatres = new TheatreRepository(_context);
            SeatCategories = new SeatsCategoryRepository(_context);
            MovieDetails = new MovieDetailRepository(_context);
            BookingDetails = new BookingDetailRepository(_context);
            Users = new UserRepository(_context);
            Prices = new PricesRepository(_context);

        }


        public ILanguageRepository Languages { get; private set; }
        public ILocationRepository Locations { get; private set; }
        public IShowRepository Shows { get; private set; }
       public IPricesRepository Prices { get; private set; }
       public ITheatreRepository Theatres { get; private set; }
      public  ITheatreCategoryRepository TheatreCategories { get; private set; }
       public  ISeatsCategoryRepository SeatCategories { get; private set; }
       public  ISeatRepository Seats { get; private set; }

      public   IUserRepository Users { get; private set; }
       public  IMovieDetailRepository MovieDetails { get; private set; }
      public  IBookingDetailRepository BookingDetails { get; private set; }
        public int Complete()
        {
           return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
