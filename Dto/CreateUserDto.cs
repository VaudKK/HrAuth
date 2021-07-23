using System.ComponentModel.DataAnnotations;

namespace HrAuth.Dto{

    public record CreateUserDto{

        [Required]
        public string FirstName {get;init;}
        public string LastName {get;init;}
        [Required]
        public string Password {get;init;}
        [Required]
        public string Email {get;init;}
        public string PrimaryContact {get;init;}

    }

}