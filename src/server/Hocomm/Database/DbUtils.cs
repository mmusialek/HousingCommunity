using Hocomm.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Database;
internal static class DbUtils
{
    public static (int Size, int Skip) GetPage(this PageDto pageDto)
    {
        var page = pageDto ?? new PageDto { Page = 1, Size = 10 };
        var skip = page.Page * page.Size;
        var take = page.Size;

        return (Size: take, Skip: skip);
    }
}
