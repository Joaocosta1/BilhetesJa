using System;
using Domain.Entity;

namespace Domain.Interface
{
    public abstract class Auditable
    {
        public string CreatorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdaterId { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ApplicationUser Creator { get; set; }
        public virtual ApplicationUser Updater { get; set; }
    }
}