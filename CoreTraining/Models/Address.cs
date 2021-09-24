using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CoreTraining.Models
{
    [Table("Address")]
    public partial class Address : BaseModel
    {
        public Address()
        {
            Properties = new HashSet<Property>();
        }

        [StringLength(128)]
        public string PropertyName { get; set; }
        [StringLength(140)]
        public string PropertyNumber { get; set; }
        [StringLength(128)]
        public string Line1 { get; set; }
        [StringLength(32)]
        public string Postcode { get; set; }
        [StringLength(128)]
        public string City { get; set; }

        [InverseProperty(nameof(Property.Address))]
        public virtual ICollection<Property> Properties { get; set; }
    }
}
