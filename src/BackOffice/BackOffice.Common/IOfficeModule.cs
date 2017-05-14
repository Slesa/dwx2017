using System;
using System.Collections.Generic;

namespace BackOffice.Common
{
    public interface IOfficeModule
    {
        string Title { get;  }
        string Tooltip { get; }
        string IconFile { get; }
        //int Priority { get; }
        //Uri TargetUri { get; }
        //Type ParentType { get; }
        //IEnumerable<string> Keywords { get; }
    }
}