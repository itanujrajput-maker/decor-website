using System.ComponentModel.DataAnnotations;

namespace ND.Models
{
    public class EnquiryModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }

        public string WorkType { get; set; }

        public string Message { get; set; }
        public string ServiceType { get; set; }
    }
}
