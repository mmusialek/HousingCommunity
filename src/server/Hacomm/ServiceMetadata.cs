﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hocomm;
public class ServiceMetadata
{
    public Guid UserId { get; set; }

    public ServiceMetadata(Guid userId)
    {
        UserId = userId;
    }
}