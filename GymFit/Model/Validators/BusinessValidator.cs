using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.Validators
{
    public class BusinessValidator
    {
        public static string SprawdzVat(decimal? vat)
        {
            try
            {
                if (vat < 0 || vat > 100)
                    return "Vat powinien być z przedziału od 0 - 100";
            }
            catch (Exception)
            {
                return "Zły vat";
            }
            return null;
        }
        public static string SprawdzMarze(decimal? marza, decimal? cena)
        {
            try
            {
                if (marza < 0 || marza > cena)
                    return "Marza powinien być większa od 0 ale mniejsza niż cena";
            }
            catch (Exception)
            {
                return "Zła marża";
            }
            return null;
        }
        public static string SprawdzCene(decimal? cena)
        {
            try
            {
                if (cena < 0)
                    return "Cena powinien być liczbą dodatnią";
            }
            catch (Exception)
            {
                return "Zła cena";
            }
            return null;
        }
    }
}
