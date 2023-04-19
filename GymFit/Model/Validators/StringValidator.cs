using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymFit.Model.Validators
{
    public class StringValidator : Validator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string text)
        {
            try
            {
                if (!char.IsUpper(text, 0))
                {
                    return "Rozpocznij dużą literą";
                }
            }
            catch (Exception) { }
            return null;
        }
        public static string SprawdzCzyDuzeLitery(string text)
        {
            try
            {
                for(int i=0; i<text.Length; i++)
                {
                    if (!char.IsUpper(text, i))
                    {
                        return "Użyj wyłącznie wielkich liter";
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static string SprawdzCzyCyfryILitery(string text)
        {
            try
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (!char.IsUpper(text, i))
                    {
                        if(!char.IsNumber(text, i))
                            return "Użyj wyłącznie wielkich liter lub cyfr";
                    }
                }
            }
            catch (Exception) { }
            return null;
        }
        public static string SprawdzCzyZawieraCyfręNaPoczatku(string text)
        {
            try
            {
                if (!char.IsNumber(text, 0))
                    return "To pole powinno na początku zawierać cyfrę";
            }
            catch (Exception) { }
            return null;
        }
        public static string SprawdzCzyZawieraCyfręNaPoczatkuLubPuste(string text)
        {
            try
            {
                if (text != "")
                {
                    if (!char.IsNumber(text, 0))
                        return "To pole powinno na początku zawierać cyfrę lub pozostać puste";
                }
            }
            catch (Exception) { }
            return null;
        }
    }
}
