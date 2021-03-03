using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace AuthorizationApp.Models
{
    public partial class Etudiants:IdentityUser
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenome { get; set; }
        public string Cin { get; set; }
        public string Adress { get; set; }
    }
}
