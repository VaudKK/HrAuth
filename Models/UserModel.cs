using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrAuth.Models{

    [Table("users")]
    public record User: BaseModel {

        [Column("user_id")]
        public Guid UserId {get; init;}

        [Column("first_name")]
        public string FirstName {get;init;}

        [Column("last_name")]
        public string LastName {get;init;}

        [Column("password")]
        public string Password {get;init;}

        [Column("email")]
        public string Email {get;init;}

        [Column("primary_contact")]
        public string PrimaryContact {get;init;}

    }

}