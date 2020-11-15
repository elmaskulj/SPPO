using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace SPPO.EntityModels
{
    public class Notification
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int? FormId { get; set; }
        public Form Form { get; set; }
        public int? ReviewId { get; set; }
        public Review Review { get; set; }


    }
}
