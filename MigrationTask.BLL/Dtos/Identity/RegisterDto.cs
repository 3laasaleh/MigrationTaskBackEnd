using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationTask.BLL.Dtos.Identity
{
    public class RegisterDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }

    public class LoginDto
    {
        [Required]
        public string? Email { get; set; }
        [Required]

        public string? Password { get; set; }
    }

}
