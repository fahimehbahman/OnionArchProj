using PostModule.Domain.Base;
using PostModule.Domain.ProvinceEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.CityEntity
{
   public class City : BaseEntity<int>
    {

        public string Title { get;  private set; }

        public int ProvinceId { get; private set; }
        public Province Province { get; private set; }
        public bool IsCapital { get; private set; }

        public bool IsCenterCity { get; private set; }
        public City(int provinceId,string title)
        {
            ProvinceId = provinceId;
            Title = title;
            IsCenterCity = false;
            IsCenterCity = false;

        }


        public void Edit(string title)
        {
            Title = title;
        }

        public void IsCaptal()
        {
            IsCapital = true;
            IsCenterCity = true;

        }


        public void IsCenter()
        {
            IsCapital = false;
            IsCenterCity = true;

        }

        public void NotCenterOrTehran()
        {
            IsCapital = false;
            IsCenterCity = false;

        }



    }
}
