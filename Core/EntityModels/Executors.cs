namespace Wsr1.Core.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Executors
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Executors()
        {
            Quest = new HashSet<Quest>();
        }

        public int Id { get; set; }

        public int IdGroup { get; set; }

        public int IdPerson { get; set; }

        public int IdExecutorStatus { get; set; }

        public virtual ExecutorStatus ExecutorStatus { get; set; }

        public virtual Group Group { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quest> Quest { get; set; }
    }
}
