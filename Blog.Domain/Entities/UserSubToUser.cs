namespace Blog.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserSubToUser")]
    public partial class UserSubToUser
    {
        public int Id { get; set; }

        public int UserSubscriberId { get; set; }

        public int UserCreatorId { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
