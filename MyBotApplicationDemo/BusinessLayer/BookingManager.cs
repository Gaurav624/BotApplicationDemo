using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBotApplicationDemo.Models.Repositories;
namespace MyBotApplicationDemo.BusinessLayer
{
   public static class BookingManager
    {
        /// <summary>
        /// Get the locations from the unit of work 
        /// </summary>
        /// <returns>List of  Location </returns>
        public static IEnumerable<Location> GetLocations()
        {
            using (var unitofWork = new UnitofWork(new BookingContext()))
            {
                return
                unitofWork.Locations.GetAll();
            }
        }

        public static IEnumerable<MovieDetail>  GetMovieDataFromLocation(string Location)
        {

            using (var unitofWork = new UnitofWork(new BookingContext()))
            {
                //GET LOCATION ID FROM NAME 
                //GET THEATRES FOR THAT LOCATION ID 
                return unitofWork.Theatres.Find(P => P.LocationId == unitofWork.Locations.Find(p => p.Name.Equals(Location)).FirstOrDefault().LocationId).Select(o => o.MovieDetail);


            }
                
        }

        //public static IEnumerable<Theatre> GetTheatresFromMovie(string movieName)
        //{
        //    //using(var unitofWork = new UnitofWork(new BookingContext())
        //    //{

        //    //}
        //}

    }
}
