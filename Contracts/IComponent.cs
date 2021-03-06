﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contracts
{
    public interface IComponent
    {
        string Description { get; }
        string ManipulateOperation(params double[] args);
    }

    public interface IMetadata
    {
        char Symbol { get; }
    }
}
