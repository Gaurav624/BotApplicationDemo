using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
   public  class MovieDetailRepository :Repository<MovieDetail>,IMovieDetailRepository
    {
        public MovieDetailRepository(BookingContext context):base(context)
        {

        }


    }
}
