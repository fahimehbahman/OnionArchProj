using PostModule.Domain.CityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.Reposity
{
   public interface ICityRepository :IRepository<int,City>
    {

    }
}
