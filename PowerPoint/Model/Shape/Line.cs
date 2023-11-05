namespace PowerPoint
{
    public class Line : Shape
    {
        public override string Name
        {
            get
            {
                return "線";
            }
        }

        public Line(int x1, int y1, int x2, int y2) : base(x1, y1, x2, y2)
        {

        }

        public override void Draw(IGraphics graphics, ShapeColor shapeColor)
        {
            graphics.DrawLine(shapeColor, _x1, _y1, _x2, _y2);
        }
    }
}
