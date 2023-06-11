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

public class GetInternalMessageParams
{
    [Required]
    public Guid HousingCommunityId { get; set; }

    public PageDto? Page { get; set; }
}

public class InternalMessageDto
{
    public Guid Id { get; set; }
    
    public string Message { get; set; } = null!;

    public Guid FromUserId { get; set; }
    public DateTime RecievedAt { get; set; }

}