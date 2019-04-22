using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBOTask.Services.NBO
{
    public interface  INBOResponse<T>
    {
        T GetResponse();
    }
}
