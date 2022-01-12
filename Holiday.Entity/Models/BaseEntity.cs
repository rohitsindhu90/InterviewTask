using System;
using System.Collections.Generic;
using System.Text;

namespace Holiday.Entity.Models
{
    public class BaseIdentity<T>
    {
        public T Id { get; set; }
    }

    public class BaseEntity<T> : BaseIdentity<T>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
