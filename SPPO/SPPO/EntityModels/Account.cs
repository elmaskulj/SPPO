using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace SPPO.EntityModels
{
    public class Account
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
       
        public string UserName { get; set; }
        public DateTime CreateDate { get; set; }
        public bool? Online { get; set; }
        public string PasswordHash { get; set; }
        public float? AvgGrade { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }
        public int? CompanyID { get; set; }
        public Company Company { get; set; }
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
        public int? ThemeId { get; set; }
        public Theme Theme { get; set; }

    }
}
