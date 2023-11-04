namespace PowerPoint
{
    public interface IState
    {
        void PressMouse();
        void MoveMouse();
        void ReleaseMouse();
        void EnterPanel();
        void LeavePanel();
    }
}
