using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("PropertyType")]
    public partial class PropertyType : BaseModel
    {
        public PropertyType()
        {
            Properties = new HashSet<Property>();
        }

        [Required]
        [StringLength(50)]
        public string Code { get; set; }

        [InverseProperty(nameof(Property.PropertyType))]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
