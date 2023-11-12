using System.ComponentModel;

namespace PowerPoint
{
    /// <summary>
    /// Represents a collection of shapes in a PowerPoint presentation.
    /// </summary>
    public class Shapes
    {
        /// <summary>
        /// Gets the list of shapes using a BindingList for data binding and dynamic updates.
        /// </summary>
        private BindingList<Shape> _shapeList = new BindingList<Shape>();

        public BindingList<Shape> ShapeList
        {
            get
            {
                return _shapeList;
            }
        }

        /// <summary>
        /// Adds a shape to the Shapes collection based on the provided shape type.
        /// </summary>
        /// <param name="shapeType">String representation of the shape type (線, 矩形, or 圓).</param>
        public void Add(string shapeType)
        {
            Shape shape = Factory.CreateShape(shapeType);
            if (shape != null)
            {
                ShapeList.Add(shape);
            }
        }

        /// <summary>
        /// Adds a specified shape to the Shapes collection.
        /// </summary>
        /// <param name="shape">The Shape object to be added.</param>
        public void Add(Shape shape)
        {
            ShapeList.Add(shape);
        }

        /// <summary>
        /// Removes the shape at the specified index from the Shapes collection.
        /// </summary>
        /// <param name="index">Index of the shape to be removed.</param>
        public void RemoveAt(int index)
        {
            ShapeList.RemoveAt(index);
        }

        /// <summary>
        /// Draws all shapes using the specified graphics object, highlighting the shape at the specified index in red.
        /// </summary>
        /// <param name="graphics">The IGraphics object used for drawing.</param>
        /// <param name="selectedIndex">Index of the shape to be highlighted in red.</param>
        public void Draw(IGraphics graphics, int selectedIndex)
        {
            for (int i = 0; i < ShapeList.Count; i++)
            {
                ShapeList[i].Draw(graphics, i == selectedIndex);
            }
        }
    }
}
