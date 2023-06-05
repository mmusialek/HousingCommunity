using Hocomm.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts.FailureReports;
public class CreateFailureReportDto
{
    [Required]
    [MaxLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    public string Message { get; set; } = null!;

    [Required]
    public Guid HousingCommunityId { get; set; }
}

public class AddFailureReportCommentDto
{
    [Required]
    public string Message { get; set; } = null!;
    
    [Required]
    public Guid FailureReportId { get; set; }
}

public class ChangeFailureReportStatusDto
{
    [Required]
    public Guid FailureReportId { get; set; }

    [Required]
    public FailureReportStatus Status { get; set; }
}