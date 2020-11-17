using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DelClub.Models.ViewModels
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
