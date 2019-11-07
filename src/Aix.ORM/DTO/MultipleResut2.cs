using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.ORM.DTO
{
   public class MultipleResut2<Result1,Result2>
    {
        public List<Result1> R1 { get; set; }


        public List<Result2> R2 { get; set; }
    }
}
