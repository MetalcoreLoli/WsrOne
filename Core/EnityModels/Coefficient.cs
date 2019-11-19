namespace Wsr1.Core.EnityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Coefficient")]
    public partial class Coefficient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coefficient()
        {
            Manager = new HashSet<Manager>();
        }

        public decimal CoefficientAnalis { get; set; }

        public decimal CoefficientInstall { get; set; }

        public decimal CoefficientService { get; set; }

        public decimal CoefficientTime { get; set; }

        public decimal CoefficientDifficult { get; set; }

        public decimal CoefficientMoney { get; set; }

        public int Id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Manager> Manager { get; set; }
    }
}
