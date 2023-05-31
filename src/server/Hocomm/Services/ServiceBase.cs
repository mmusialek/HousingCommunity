using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm.Services;
public abstract class ServiceBase
{
    protected ServiceMetadata _metadata = null!;
    public void SetMetaData(ServiceMetadata metadata)
    {
        _metadata = metadata;
    }
}
