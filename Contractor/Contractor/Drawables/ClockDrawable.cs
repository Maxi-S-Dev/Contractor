using System.Diagnostics;
using System.Drawing;
using Color = Microsoft.Maui.Graphics.Color;

namespace Contractor.Drawables
{
    public class ClockDrawable : IDrawable
    {

        const int width = 200;
        const int height = 200;

        const int radius = width/2;

        const int strokeSize = 1;

        const int barWidth= 10;
        const int halfBarWidth = barWidth/2;

        float circleX = 0;
        float circleY = 0;

        float degree = 0;

        Color Color = Colors.Red;

        public ClockDrawable(int i)
        {
            if (i == 1) Color = Color.FromArgb("#ff6200ee");
            else Color = Colors.Blue;
        }
        
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {

            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = strokeSize;
            canvas.DrawCircle(dirtyRect.Center.X, dirtyRect.Center.Y, radius + halfBarWidth);

            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = strokeSize;
            canvas.DrawCircle(dirtyRect.Center.X, dirtyRect.Center.Y, radius - halfBarWidth);


            canvas.StrokeColor = Color;
            canvas.StrokeSize = barWidth;
            canvas.DrawArc(dirtyRect.Center.X - radius, dirtyRect.Center.Y - radius, width, height, 90f, 90f + degree, true, false);

            Trace.WriteLine(degree);

            circleX = dirtyRect.Center.X + radius * -(float)Math.Sin(2 * Math.PI / 360 * degree);
            circleY = dirtyRect.Center.Y + radius * -(float)Math.Cos(2 * Math.PI / 360 * degree);

            canvas.FillColor = Color;
            canvas.FillCircle(circleX, circleY, barWidth/2);
        }
        
        public void AddDegrees (float inputDegree)
        {
            degree -= inputDegree;
            degree = degree % 360;
        }
    }
}
