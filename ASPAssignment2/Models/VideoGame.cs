using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class VideoGame
    {
        public virtual int VideoGameId { get; set; }
        public virtual int GenreId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:c}")]
        public virtual decimal Price { get; set; }

        [Required(ErrorMessage = "Developer is required.")]
        public virtual string Developer { get; set; }

        [Required(ErrorMessage = "Publisher is required.")]
        public virtual string Publisher { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        public virtual Genre Genre { get; set; }
        public List<Reviews> Reviews { get; set; }
    }
}