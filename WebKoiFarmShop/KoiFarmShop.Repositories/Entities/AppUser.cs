using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.Entities
{
    public class AppUser : IdentityUser<int>
    {
        [Column(TypeName="nvarchar")]
        [StringLength(256)]
        public string? HomeAddress { get; set; }
    }
}
