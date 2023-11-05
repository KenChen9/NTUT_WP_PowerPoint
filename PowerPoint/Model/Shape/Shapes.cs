using System.ComponentModel;

namespace PowerPoint
{
    public class Shapes
    {
        public BindingList<Shape> ShapeList { get; private set; } = new BindingList<Shape>();

        public void Add(string shapeType)
        {
            Shape shape = Factory.CreateShape(shapeType);
            if (shape != null)
            {
                ShapeList.Add(shape);
            }
        }

        public void Add(Shape shape)
        {
            ShapeList.Add(shape);
        }

        public void RemoveAt(int index)
        {
            ShapeList.RemoveAt(index);
        }

        public void Draw(IGraphics graphics, int selectedIndex)
        {
            for (int i = 0; i < ShapeList.Count; i++)
            {
                ShapeList[i].Draw(graphics, i == selectedIndex ? ShapeColor.Red : ShapeColor.Black);
            }
        }
    }
}
