using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLoginUI.Models
{
    public class UserBasicInfo
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int? RoleID { get; set; }
        public string Email { get; set; }
        public string FullName
        {
            get => $"{FirstName} {LastName}";
        }
    }

    public enum RoleDetails
    {
        Student = 1,
        Teacher,
        Admin,
    }
}
