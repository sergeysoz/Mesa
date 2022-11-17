namespace Mesa.Interfaces
{
    internal interface ISession
    {
        // We execute command that has been received
        // as a console argument
        void SelectProcessByCommand();
        void Exit();

    }
}
