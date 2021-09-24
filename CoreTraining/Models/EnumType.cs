using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("EnumType")]
    public partial class EnumType : BaseModel
    {
        public EnumType()
        {
            EnumTypeItems = new HashSet<EnumTypeItem>();
        }

        [Required]
        [StringLength(100)]
        public string Code { get; set; }

        [InverseProperty(nameof(EnumTypeItem.EnumType))]
        public virtual ICollection<EnumTypeItem> EnumTypeItems { get; set; }
    }
}
