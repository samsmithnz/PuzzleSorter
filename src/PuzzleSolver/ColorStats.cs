namespace PuzzleSolver
{
    public class ColorStats
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public double Percent { get; set; }

        public ColorStats(string name, double percent, int order = 100)
        {
            Name = name;
            Percent = percent;
            Order = order;
        }
    }
}
