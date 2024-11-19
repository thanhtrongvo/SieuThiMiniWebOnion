using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMiniShop.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string MatKhau { get; set; }
    }
}
