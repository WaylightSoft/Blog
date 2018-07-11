namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSubsToTag")]
    public partial class UserSubsToTag
    {
        public int Id { get; set; }

        public int UserSubscriberId { get; set; }

        public int TagId { get; set; }

        public virtual Tag Tag { get; set; }

        public virtual User User { get; set; }
    }
}
