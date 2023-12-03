namespace PowerPoint
{
    public interface IState
    {
        // Comment
        void PressMouse(MyPoint cursorPoint);

        // Comment
        void MoveMouse(ShapeType currentTool, MyPoint cursorPoint);

        // Comment
        void ReleaseMouse();

        // Comment
        void Draw(IGraphics graphics);
    }
}
