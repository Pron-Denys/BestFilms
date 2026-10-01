namespace BestFilms
{
    using System.ComponentModel.DataAnnotations;
    public class Film
    {
        public int Id {  get; set; }
        [Display(Name="Name")]
        [Required(ErrorMessage="Заповніть поле")]
        public string? Name { get; set; }
        [Display(Name= "FilmDirector")]
        [Required(ErrorMessage = "Заповніть поле")]
        public string? FilmDirector { get; set; }
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Заповніть поле")]
        public string? Genre { get; set; }
        [Display(Name = "Year")]
        [Required(ErrorMessage = "Заповніть поле")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Оберіть постер")]
        public string? Poster { get; set; }
        [Display(Name = "Короткий опис")]
        [Required(ErrorMessage = "Напишіть короткий опис")]
        public string? Description { get; set; }

    }
}
