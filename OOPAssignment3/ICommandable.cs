namespace OOPAssignment3
{
    interface ICommandable
    {
        // The run function and the help function are required in every function.
        void Run();
        string Help();
    }
}
