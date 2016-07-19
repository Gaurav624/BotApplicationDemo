using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
   public  interface IUnitofWork :IDisposable
    {
        ILanguageRepository Languages { get;}
        ILocationRepository Locations { get; }
        IShowRepository Shows { get; }
        IPricesRepository Prices { get; }
        ITheatreRepository Theatres { get;}
        ITheatreCategoryRepository TheatreCategories { get; }
        ISeatsCategoryRepository SeatCategories { get; }
        ISeatRepository Seats { get; }
        
        IUserRepository Users { get; }
        IMovieDetailRepository MovieDetails { get; }
        IBookingDetailRepository BookingDetails { get; }

        int Complete();
    }
}
