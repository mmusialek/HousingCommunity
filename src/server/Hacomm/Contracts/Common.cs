using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Contracts;
public class PageDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Size { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int Page { get; set; }
}
