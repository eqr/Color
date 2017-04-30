namespace Colors
{
    public class Paint
    {
        public double Volume {get; private set;}
        public int Red {get; private set;}
        public int Green {get; private set;}
        public int Blue {get; private set;}

        public Paint(double volume, int red, int green, int blue)
        {
            this.Volume = volume;
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public void Mix(Paint paint)
        {
            this.Volume += paint.Volume;
            this.Red = (this.Red + paint.Red) / 2;
            this.Green = (this.Green + paint.Green) / 2;
            this.Blue = (this.Blue + paint.Blue) / 2;
        }
    }
}