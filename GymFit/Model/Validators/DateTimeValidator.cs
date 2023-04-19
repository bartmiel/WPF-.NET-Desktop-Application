using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.Validators
{
    public class DateTimeValidator : Validator
    {
        public static string CzyDataZPrzeszlosci(DateTime? date)
        {
            try
            {
                if (date <= DateTime.Now.Date)
                {
                    return "Wprowadzono datę z przeszłości";
                }
            }
            catch (Exception) { }; return null;
        }
        public static string CzyDataPozniejszaNiz1Rok(DateTime? date)
        {
            try
            {
                if (date > DateTime.Now.AddYears(1))
                {
                    return "Wprowadzono zbyt odległą datę";
                }
            }
            catch (Exception) { }; return null;
        }
    }
}
