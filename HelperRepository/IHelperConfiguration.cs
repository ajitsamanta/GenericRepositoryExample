using System;
using System.Collections.Generic;
using System.Text;

namespace HelperRepository
{
    public interface IHelperConfiguration
    {
        string ConnectionString { get; }

        string Database { get; }
    }
}
