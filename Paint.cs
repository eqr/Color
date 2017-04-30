namespace Colors
{
    using System.Collections.Generic;

    public class Paint
    {
        public double Volume { get; private set; }
        public PigmentColor Color { get; private set; }

        public Paint(double volume, PigmentColor color)
        {
            this.Volume = volume;
            this.Color = color;
        }
    }

    public class MixedPaint
    {
        public MixedPaint()
        {
            this.Color = new PigmentColor(0, 0, 0);
            this.Constituents = new List<Paint>();
        }

        public PigmentColor Color { get; private set; }
        public IEnumerable<Paint> Constituents { get; private set; }
        public double Volume { get; private set; }

        public void MixIn(Paint paint)
        {
            if (this.Volume == 0.0)
            {
                this.Color = paint.Color;
            }
            else
            {
                this.Color.MixWith(paint.Color);
            }
            
            this.Volume += paint.Volume;
            this.Constituents.Add(paint);
        }
    }
}