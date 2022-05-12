using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NullLib.GoCqHttpSdk
{
    public interface ICqPostSession
    {
        CqPostPipeline PostPipeline { get; }
    }
}
