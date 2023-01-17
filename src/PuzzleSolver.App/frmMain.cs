using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;

namespace PuzzleSolver.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            List<Rgb24> palette = ColorPalettes.GetPrimaryAndSecondaryColorsPalette();

            int startingX = 20;
            int startingY = 20; //778;
            int containerHeight = 250;
            int containerWidth = 800;
            for (int i = 0; i < palette.Count; i++)
            {
                Rgb24 item = palette[i];
                int x = startingX;
                int y = (i * containerHeight) + (i * startingY);
                Debug.WriteLine("X:" + x + ",Y:" + y);
                GroupBox groupBox = new()
                {
                    Height = containerHeight,
                    Width = containerWidth,
                    Text = "   " + ColorPalettes.ToName(item),
                    Location = new Point(x, y),
                    Parent = panColors,
                    Anchor = AnchorStyles.Top
                };

                _ = new PictureBox()
                {
                    Location = new Point(6, 8),
                    Height = 20,
                    Width = 20,
                    BackColor = Color.FromName(ColorPalettes.ToName(item)),
                    Parent = groupBox
                };

            }
        }
    }
}