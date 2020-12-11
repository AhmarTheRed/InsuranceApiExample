﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceApi.Domain.Interfaces
{
    public interface IClientRepository
    {
        public Task<IEnumerable<Client>> GetClients();
    }
}
