using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrAuth.Models{

    [Table("users")]
    public record User: BaseModel {

        [Column("user_id")]
        public Guid UserId {get; init;}

        [Column("company_id")]
        public string CompanyId { get; set; }

        [Column("first_name")]
        public string FirstName {get;init;}

        [Column("last_name")]
        public string LastName {get;init;}

        [Column("password")]
        public string Password {get;init;}

        [Column("email")]
        public string Email {get;init;}

    }

}