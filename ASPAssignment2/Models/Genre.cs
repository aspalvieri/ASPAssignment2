﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPAssignment2.Models
{
    /*Genre class*/
    public class Genre
    {
        /*[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Genre()
        {
            VideoGames = new HashSet<VideoGame>();
        }*/

        //[Key]
        public virtual int GenreId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [DisplayName("Genre Name")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //[ForeignKey("VideoGameId")]
        public virtual ICollection<VideoGame> VideoGames { get; set; }
    }
}