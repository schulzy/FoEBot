using System;

namespace Schulzy.FoEBot.BL.Server
{
    internal class MethodNameAttribute : Attribute
    {
        public MethodNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
