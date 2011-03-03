//-----------------------------------------------------------------------
// <copyright file="Profile.cs" company="RIA Library Foundation">
//     Copyright © 2011 RIA Library Foundation. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace RiaLib.Data.Tests.Models.Membership
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required, MaxLength(50)]
        public string UserName { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual Profile Profile { get; set; }
    }
}
