using System;
using System.ComponentModel.DataAnnotations;

namespace CoreTraining.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}