using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class VideoGame
    {
        //[Key]
        public virtual int VideoGameId { get; set; }

        public virtual int GenreId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        [Range(0.00,1000)]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Developer is required.")]
        public virtual string Developer { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        public virtual string Publisher { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        //[ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public List<Reviews> Reviews { get; set; }
        public Reviews newReview { get; set; }
    }
}