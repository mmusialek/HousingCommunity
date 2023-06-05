using Hocomm.Contracts.Common;
using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Users;
public class CreateUserProfileDto
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string FirstName { get; set; } = null!;
    [Required]
    public string LastName { get; set; } = null!;

    [Required]
    public AddressDto Address { get; set; } = null!;
}
