using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBotApplicationDemo.Models.Repositories
{
   public class LanguageRepository :Repository<Language>,ILanguageRepository
    {
        public LanguageRepository(BookingContext context):base(context)
        {

        }

        public BookingContext BookingContext
        {
           get { return Context as BookingContext;}
        }
    }
}
