using System;

namespace CoreTraining.Models
{
    public class BaseCreationModel : BaseModel
    {
        public DateTimeOffset CreationTime { get; set; }
    }
}