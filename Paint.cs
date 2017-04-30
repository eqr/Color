namespace Colors
{
    public class Paint
    {
        public double Volume {get; private set;}
        public PigmentColor Color {get; private set;}

        public Paint(double volume, PigmentColor color)
        {
            this.Volume = volume;
            this.Color = color;
        }

        public void Mix(Paint paint)
        {
            this.Volume += paint.Volume;
            this.Color.MixedWith(paint.Color);
        }
    }
}