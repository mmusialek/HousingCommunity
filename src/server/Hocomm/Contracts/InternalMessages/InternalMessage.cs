using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.InternalMessages;

public class CreateInternalMessageDto
{
    [Required]
    [MinLength(10)]
    public string Message { get; set; } = null!;

    [Required]
    public Guid ToUserId { get; set; }

    [Required]
    public Guid HousingCommunityId { get; set; }
}
