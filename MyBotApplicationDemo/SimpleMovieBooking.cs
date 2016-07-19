using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.FormFlow;
using System.Data.SqlClient;
using MyBotApplicationDemo.Helper;

namespace MyBotApplicationDemo
{
    public enum Cities
    {
        NCR,Mumbai,Pune,Bengaluru,Chennai,Hyderabad,Kolkata
    };

    public enum Categories
    {
        Movies,Events,Plays,Sports
    };
    public enum Languages
    {
        Hindi,English
    };
    public enum Movies
    {
        Conjuring,IndepedenceDay,RamanRaghav,ImitationGames,Housefull3,
    };
    public enum Cinemas
    {
        CinetownMiyapur,PVRKukatpally,PVRMadhapur,InorbitBanjaraHills
    };

    public enum ShowTimings
    {
        Morning,Afternoon,Evening,Night
    };
    public enum NoOfTickets
    {
        One=1,Two,Three,Four,Five
    }
    [Serializable]
    public class SimpleMovieBooking
    {
        public Cities? City;
        public Categories? Category;
        public Movies? Movie;
        public Cinemas? Cinema;
        public ShowTimings? Timing;
        public NoOfTickets? Number;


        public static IForm<SimpleMovieBooking> BuildForm()
        {
            //MyBotApplicationDemo.BusinessLayer.BookingManager mgr = new MyBotApplicationDemo.BusinessLayer.BookingManager();
            //IEnumerable<MyBotApplicationDemo.Location> locationData = mgr.GetLocations();
            //MyBotApplicationDemo.BusinessLayer.BookingManager.
            // GetSqlConnection();
            return new FormBuilder<SimpleMovieBooking>()
                    .Message("Welcome to Booking Center using an intelligent BOT!")
                    .Build();
        }

        public static List<Entities.Location> GetSqlConnection()
        {
            //SqlConnection conn = null;
            List<Entities.Location>conn =
            DBHelper.ConnectToDatabase();

            return conn;
        }
    }
}
