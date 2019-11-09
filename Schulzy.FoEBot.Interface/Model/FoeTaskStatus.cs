using System;

namespace Schulzy.FoEBot.Interface.Model
{
    [Flags]
    public enum FoeTaskStatus
    {
        None = 0,
        NotStarted = 1 << 0,
        Running = NotStarted << 1,
        Error = Running << 2,
        Success = Error << 3,
        LoginIssue = Success << 4
    }
}