using System.Drawing;

namespace PowerPoint
{
    public interface IState
    {
        /// <summary>
        /// Handles the mouse press event.
        /// </summary>
        void PressMouse(Point cursorPoint);

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        void MoveMouse(Point cursorPoint);

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        void ReleaseMouse(Point cursorPoint);

        /// <summary>
        /// Draw
        /// </summary>
        void Draw(IGraphics graphics);
    }
}
