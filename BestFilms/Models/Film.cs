namespace BestFilms
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Mvc;
    using BestFilms.Annotations;
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
        [YearFilm(ErrorMessage="Не коректно вказано рік")]
        public int Year { get; set; }
        public string? Poster { get; set; }
        [Display(Name = "Короткий опис")]
        [Required(ErrorMessage = "Напишіть короткий опис")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage="Довжина тексту повинна бути від 10 до 1000 символів")]
        public string? Description { get; set; }

    }
}
