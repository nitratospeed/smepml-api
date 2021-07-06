﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repositories
{
    public interface IDiagnosticoRepository
    {
        Task<int> Add(Diagnostico diagnostico);
    }
}
