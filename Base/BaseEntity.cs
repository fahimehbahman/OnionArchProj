using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.Base
{
   public class BaseEntity<TKEY>
    {

        public TKEY Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public BaseEntity()
        {
            CreatedDate = DateTime.Now;
        }

    }
}
