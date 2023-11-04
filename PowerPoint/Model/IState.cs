namespace PowerPoint
{
    public interface IState
    {
        void PressMouse();
        void MoveMouse(int x, int y);
        void ReleaseMouse();
    }
}
