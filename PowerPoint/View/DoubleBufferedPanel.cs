using System.Windows.Forms;

namespace PowerPoint
{
    /// <summary>
    /// Custom panel class with double buffering enabled for smooth drawing.
    /// </summary>
    public class DoubleBufferedPanel : Panel
    {
        /// <summary>
        /// Initializes a new instance of the DoubleBufferedPanel class with double buffering enabled.
        /// </summary>
        public DoubleBufferedPanel()
        {
            DoubleBuffered = true;
        }
    }
}
