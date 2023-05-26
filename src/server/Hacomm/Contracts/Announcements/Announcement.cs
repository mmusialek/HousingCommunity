using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.Announcements;
public class AddAnnouncementRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    [MinLength(10)]
    public string Message { get; set; } = null!;

    //[Required]
    //public Guid AuthorId { get; set; }


    public DateTime? ValidTo { get; set; }
}

public class UpdateAnnouncementRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    [MinLength(10)]
    public string Message { get; set; } = null!;

    //[Required]
    //public Guid AuthorId { get; set; }


    public DateTime? ValidTo { get; set; }
}

public class GetAnnouncementParams
{
    public PageDto? PageDto { get; set; }
}

public class AnnouncementDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Message { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public DateTime? ValidTo { get; set; }


    public Guid AuthorId { get; set; }
}
