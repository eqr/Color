namespace Colors
{
    public class PigmentColor
    {
        public int Red { get; private set; }
        public int Green { get; private set; }
        public int Blue { get; private set; }

        public PigmentColor(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public void MixWith(PigmentColor color)
        {
            this.Red = (this.Red + color.Red) / 2;
            this.Green = (this.Green + color.Green) / 2;
            this.Blue = (this.Blue + color.Blue) / 2;            
        }
    }
}