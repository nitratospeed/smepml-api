using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string UserName { get; }
        public DateTime? NotValidBefore { get; }
        public DateTime? Expiration { get; }
    }
}
