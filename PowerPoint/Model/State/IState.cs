namespace PowerPoint
{
    /// <summary>
    /// Interface representing the state of the application based on user interaction.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Handles the mouse press event.
        /// </summary>
        void PressMouse();

        /// <summary>
        /// Handles the mouse move event.
        /// </summary>
        /// <param name="x">X-coordinate of the mouse position.</param>
        /// <param name="y">Y-coordinate of the mouse position.</param>
        void MoveMouse(int x, int y);

        /// <summary>
        /// Handles the mouse release event.
        /// </summary>
        void ReleaseMouse(int x, int y);

        /// <summary>
        /// Draw
        /// </summary>
        void Draw(IGraphics graphics, Shapes shapes, int selectedIndex);
    }
}
