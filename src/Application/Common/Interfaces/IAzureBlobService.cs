﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IAzureBlobService
    {
        Task<string> Upload(string directory, string fileName, byte[] file);

        Task<string> DownloadURI(string directory, string fileName);
    }
}
