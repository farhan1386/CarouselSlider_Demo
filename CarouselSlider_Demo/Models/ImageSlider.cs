using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarouselSlider_Demo.Models
{
    public class ImageSlider
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Image Name")]
        [StringLength(100)]
        public string ImageName { get; set; }

        [Display(Name ="Image Path")]
        [StringLength(255)]
        [Required(ErrorMessage ="Please choose image file")]
        public string ImagePath { get; set; }

        public DateTime Created { get; set; }

        public ImageSlider()
        {
            Created = DateTime.Now;
        }

    }
}