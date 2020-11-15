using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPPO.EntityModels
{
    public class AccountGrade
    {
        public bool? Graded { get; set; }
        public float? Grade { get; set; }
        public int? GiversID { get; set; }
        public Account Givers { get; set; }
        public int? RecieverID { get; set; }
        public Account Reciever { get; set; }
    }
}
