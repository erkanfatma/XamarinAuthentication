namespace XamarinAuthentication.Entities.Models {
      using System;
      using System.Collections.Generic;
      using System.ComponentModel.DataAnnotations;
      using System.ComponentModel.DataAnnotations.Schema;
      using System.Data.Entity.Spatial;

      public partial class User {
            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
            public User() {
                  Notes = new HashSet<Note>();
            }

            public int UserId { get; set; }

            [StringLength(50)]
            public string FullName { get; set; }

            [StringLength(100)]
            public string Email { get; set; }

            [StringLength(50)]
            public string Password { get; set; }

            [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
            public virtual ICollection<Note> Notes { get; set; }
      }
}
