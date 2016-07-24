namespace MyBotApplicationDemo.Models.Repositories
{
    using MyBotApplicationDemo.Entities;
    using System;
    public interface IBookingRepository
    {
        Booking GetBooking(DateTime? dateTime, int countTicket, string Location = "Hyderabad", string Movie = "Avengers", string Theatre = "PVR");
    }
}
