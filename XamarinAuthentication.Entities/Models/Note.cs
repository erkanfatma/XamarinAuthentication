namespace XamarinAuthentication.Entities.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Note
    {
        public int NoteId { get; set; }

        public int UserId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public virtual User User { get; set; }
    }
}
