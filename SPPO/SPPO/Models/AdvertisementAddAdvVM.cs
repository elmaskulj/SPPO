using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SPPO.Models
{
    public class AdvertisementAddAdvVM: IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int JobId { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public List<SelectListItem> jobs { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate < StartDate)
            {
                yield return new ValidationResult(
                    errorMessage: "EndDate must be greater than StartDate",
                    memberNames: new[] { "EndDate" }
               );
            }
        }
    }
}
