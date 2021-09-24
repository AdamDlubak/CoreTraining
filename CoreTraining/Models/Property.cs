using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("Property")]
    public partial class Property : BaseCreationModel
    {
        public Property()
        {
            Activities = new HashSet<Activity>();
        }

        [Required]
        [StringLength(20)]
        public string UniqueReferenceCode { get; set; }
        public Guid? AddressId { get; set; }
        public Guid PropertyTypeId { get; set; }

        [ForeignKey(nameof(AddressId))]
        [InverseProperty("Properties")]
        public virtual Address Address { get; set; }
        [ForeignKey(nameof(PropertyTypeId))]
        [InverseProperty("Properties")]
        public virtual PropertyType PropertyType { get; set; }
        [InverseProperty(nameof(Activity.Property))]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
