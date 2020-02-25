using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPMVC.Models
{
    public class UserListViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
    }
}