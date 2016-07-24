namespace MyBotApplicationDemo.Entities
{
    using System.Collections.Generic;

    public class Booking
    {
        private IEnumerable<MyBotApplicationDemo.Location> _location;

        private IEnumerable<MovieDetails> _movieDetails;

        private IEnumerable<Screen> _screen;

        private IEnumerable<Seats> _seats;

        private IEnumerable<Theatre> _theatre;

        public Booking()
        {
            _location = new List<MyBotApplicationDemo.Location>();
            _movieDetails = new List<MovieDetails>();
            _screen = new List<Screen>();
            _seats = new List<Seats>();
            _theatre = new List<Theatre>();
        }

        public IEnumerable<MyBotApplicationDemo.Location> Location
        {
            get
            {
                return this._location;
            }

            set
            {
                this._location = value;
            }
        }

        public IEnumerable<MovieDetails> MovieDetails
        {
            get
            {
                return this._movieDetails;
            }

            set
            {
                this._movieDetails = value;
            }
        }
        public IEnumerable<Screen> Screen
        {
            get
            {
                return this._screen;
            }

            set
            {
                this._screen = value;
            }
        }
        public IEnumerable<Seats> Seats
        {
            get
            {
                return this._seats;
            }

            set
            {
                this._seats = value;
            }
        }
        public IEnumerable<Theatre> Theatre
        {
            get
            {
                return this._theatre;
            }

            set
            {
                this._theatre = value;
            }
        }
    }
}