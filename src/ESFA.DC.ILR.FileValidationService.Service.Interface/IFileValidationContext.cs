﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ESFA.DC.ILR.FileValidationService.Service.Interface
{
    public interface IFileValidationContext
    {
        string FileReference { get; }

        string Container { get; }

        string OutputFileReference { get; }

        string OutputContainer { get; }
    }
}
