namespace Colors
{
    public class Paint
    {
        public double volume;
        public int red;
        public int green;
        public int blue;

        public Paint(double volume, int red, int green, int blue)
        {
            this.volume = volume;
            this.red = red;
            this.green = green;
            this.blue = blue;
        }

        public void Mix(Paint paint)
        {
            this.volume += paint.volume;
            this.red = (this.red + paint.red) / 2;
            this.green = (this.green + paint.green) / 2;
            this.blue = (this.blue + paint.blue) / 2;
        }
    }
}