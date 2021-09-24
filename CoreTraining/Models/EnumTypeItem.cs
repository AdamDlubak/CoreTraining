using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("EnumTypeItem")]
    public partial class EnumTypeItem : BaseModel
    {
        public EnumTypeItem()
        {
            Activities = new HashSet<Activity>();
        }

        [Required]
        [StringLength(40)]
        public string Code { get; set; }
        public Guid EnumTypeId { get; set; }

        [ForeignKey(nameof(EnumTypeId))]
        [InverseProperty("EnumTypeItems")]
        public virtual EnumType EnumType { get; set; }
        [InverseProperty(nameof(Activity.ActivityStatus))]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
