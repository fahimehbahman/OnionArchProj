using PostModule.Domain.Base;
using PostModule.Domain.CityEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Domain.ProvinceEntity
{
   public class Province :BaseEntity<int>
    {

        public string Title { get; set; }

        public string CloseProvince { get; set; }
        public List<City> CityList { get; set; }
        public Province(string title)
        {
            Title = title;
            CreatedDate = DateTime.Now;
            CloseProvince = "";
        }

        public void Edit(string title)
        {
            Title = title;
        }


        public void ChangeCloseProvince(List<int> closeProvinceId)
        {
            CloseProvince = string.Join("-", closeProvinceId);
        }
      
    }
}
