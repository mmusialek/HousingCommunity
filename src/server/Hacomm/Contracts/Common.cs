using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hacomm.Contracts;
public class PageDto
{
    [Required]
    [Range(1, int.MaxValue)]
    public int Size { get; set; }

    [Required]
    [Range(1, int.MaxValue)]
    public int PAge { get; set; }
}
