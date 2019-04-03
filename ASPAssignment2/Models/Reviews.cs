using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    public class Reviews
    {
        public virtual int ReviewsId { get; set; }
        public virtual int VideoGameId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Subject is required.")]
        public virtual string Subject { get; set; }

        [Required(ErrorMessage = "Review is required.")]
        [DataType(DataType.MultilineText)]
        public virtual string Review { get; set; }

        [Required(ErrorMessage = "Stars are required.")]
        [Range(1, 5)]
        public virtual int Stars { get; set; }

        public virtual VideoGame VideoGame { get; set; }

        public bool CheckModelState()
        {
            //Check for blanks
            if (ReviewsId.ToString() == "" || VideoGameId.ToString() == "" || Name == "" | Subject == "" || Review == "" || Stars.ToString() == "")
                return false;
            //Check for invalid entries
            if (ReviewsId < 0 || VideoGameId < 0 || Stars <= 0 || Stars > 5)
                return false;
            return true;
        }
    }
}