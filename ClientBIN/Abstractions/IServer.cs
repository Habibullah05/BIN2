using ClientBIN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientBIN.Abstractions
{
    public interface IServer
    {
        Task<IEnumerable<BIN>> GetBINs();
        Task<IEnumerable<BIN>> GetBINs(long pan);
        Task TimerStart();
        
    }
}
