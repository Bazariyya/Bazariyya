﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Product.Domain.SeedWork
{
    public abstract class BaseCommand<TResponse> : 
        IRequest<TResponse>
    {
    }
}
