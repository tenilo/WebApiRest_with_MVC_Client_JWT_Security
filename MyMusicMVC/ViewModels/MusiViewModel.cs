using Microsoft.AspNetCore.Mvc.Rendering;
using MyMusicMVC.Models;
using System.ComponentModel.DataAnnotations;

namespace MyMusicMVC.ViewModels
{
    public class MusiViewModel
    {
        public string MusicID { get; set; }
        public Music Music { get; set; }
        public SelectList ArtistList { get; set; }
        [Required(ErrorMessage = "Please enter the Artist")]
        [Display(Name = "Artist")]
        public string AristId { get; set; }
    }
}
