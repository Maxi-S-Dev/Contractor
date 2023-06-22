using Contractor.Enums;
using System.Diagnostics;
using System.Drawing;
using Color = Microsoft.Maui.Graphics.Color;

namespace Contractor.Drawables
{
    public class ClockDrawable : IDrawable
    {
        const int width = 200;
        const int height = 200;

        const int radius = width / 2;

        const int strokeSize = 1;

        const int barWidth = 10;
        const int halfBarWidth = barWidth / 2;

        float circleX = 0;
        float circleY = 0;

        float degree = 0;

        Color Color;

        TimerType TimerType;
        public ClockDrawable(TimerType type)
        {
            TimerType = type;
            SetMainColor();
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            //Outside Border
            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = strokeSize;
            canvas.DrawCircle(dirtyRect.Center.X, dirtyRect.Center.Y, radius + halfBarWidth);

            //Inside Border
            canvas.StrokeColor = Colors.LightGray;
            canvas.StrokeSize = strokeSize;
            canvas.DrawCircle(dirtyRect.Center.X, dirtyRect.Center.Y, radius - halfBarWidth);

            //Inner Bar
            canvas.StrokeColor = Color;
            canvas.StrokeSize = barWidth;
            if(degree <= 0) canvas.DrawArc(dirtyRect.Center.X - radius, dirtyRect.Center.Y - radius, width, height, 90f, 90f + degree, true, false);
            else canvas.DrawArc(dirtyRect.Center.X - radius, dirtyRect.Center.Y - radius, width, height, 90f, 90f + degree, false, false);

            //Circel at the end of the bar
            circleX = dirtyRect.Center.X + radius * -(float)Math.Sin(2 * Math.PI / 360 * degree);
            circleY = dirtyRect.Center.Y + radius * -(float)Math.Cos(2 * Math.PI / 360 * degree);

            canvas.FillColor = Color;
            canvas.FillCircle(circleX, circleY, barWidth/2);
        }

        //Rotates the inner bar acording to a given percantage
        public void SetDegreesUsingPercent(float percent)
        {
            degree = -3.6f * percent;
            if (degree > 0) Color = Color.FromArgb("#FFff483b");
            else SetMainColor();
        }

        //Sets the color of the inner bar
        private void SetMainColor()
        {
            if(TimerType == TimerType.Productive) 
            {
                Color = Color.FromArgb("#FF6200EE");
                return;
            }

            Color = Color.FromArgb("#FF7F39FB");
        }
    }
}
