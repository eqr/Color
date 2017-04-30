namespace Colors
{
    public class Paint
    {
        public double v;
        public int r;
        public int g;
        public int b;

        public void Mix(Paint paint)
        {
            this.v += paint.v;
            this.r = (this.r + paint.r) / 2;
            this.g = (this.g + paint.g) / 2;
            this.b = (this.r + paint.b) / 2;
        }
    }
}