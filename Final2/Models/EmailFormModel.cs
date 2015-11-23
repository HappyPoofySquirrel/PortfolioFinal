using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final2.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "What Does Your Mother Call You?")]
        public string FromName { get; set; }
        [Required, Display(Name = "Where can we email you back?"), EmailAddress]
        public string FromEmail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
    }
}