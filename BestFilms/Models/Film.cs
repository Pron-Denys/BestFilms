namespace BestFilms
{
    using System.ComponentModel.DataAnnotations;
    public class Film
    {
        public int Id {  get; set; }
        [Display(Name="Name")]
        public string? Name { get; set; }
        [Display(Name= "FilmDirector")]
        public string? FilmDirector { get; set; }
        [Display(Name = "Genre")]
        public string? Genre { get; set; }
        [Display(Name = "Year")]
        public int Year { get; set; }
        public string? Poster { get; set; }
        [Display(Name = "Description")]
        public string? Description { get; set; }

    }
}
