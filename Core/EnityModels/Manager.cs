namespace Wsr1.Core.EnityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manager")]
    public partial class Manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manager()
        {
            Group = new HashSet<Group>();
        }

        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public int? CoefficientId { get; set; }

        public int? SalaryId { get; set; }

        public virtual Coefficient Coefficient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Group> Group { get; set; }

        public virtual Person Person { get; set; }

        public virtual Salary Salary { get; set; }
    }
}
