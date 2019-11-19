namespace Wsr1.Core.EnityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quest")]
    public partial class Quest
    {
        public int Id { get; set; }

        public int IdStatus { get; set; }

        public int IdNatureOfWork { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Difficult { get; set; }

        public TimeSpan Time { get; set; }

        public int? ExecutorId { get; set; }

        public virtual Executors Executors { get; set; }

        public virtual NatureOfWork NatureOfWork { get; set; }

        public virtual QuestStatus QuestStatus { get; set; }
    }
}
