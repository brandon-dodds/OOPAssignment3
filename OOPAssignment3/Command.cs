using System;

namespace OOPAssignment3
{
    abstract class Command
    {
        protected string[] Args { get; set; }
        // The run function and the help function. Declared abstract as these should be overridden.
        public abstract void Run();
        protected abstract string Help();
    }
}
