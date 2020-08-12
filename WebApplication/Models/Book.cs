using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Book
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 1)]
        [Required]
        public string Title { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage ="The input can contain only letters.")]
        [Required]
        public string Author { get; set; }

        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string Genre { get; set; }

        [Display(Name = "Numer Of Pages")]
        public int NumerOfPages { get; set; }

        public byte[] Image { get; set; } //Byte array

        public byte[] File { get; set; } 


    }
}
