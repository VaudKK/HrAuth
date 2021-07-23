using System.ComponentModel.DataAnnotations;

namespace HrAuth.Dto{

    public record UserAuthDto{
        [Required]
        public string Password {get;init;}
        [Required]
        public string Email {get;init;}
    }

}