namespace BestFilms.Annotations
{
    using System.ComponentModel.DataAnnotations;
    public class YearFilmAttribute() : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is int year)
            {
                if (year >= 1 && year <= DateTime.Now.Year)
                    return true;
                else
                    return false;
            }
            return false;
        }
    }
}
