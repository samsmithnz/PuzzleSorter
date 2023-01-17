using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //1. Read in input image
            //2. Split apart image
            //3. Group images by biggest % 
            //4. Display grouped images


            List<Rgb24> palette = ColorPalettes.GetPrimaryAndSecondaryColorsPalette();

            int startingX = 20;
            int startingY = 20; //778;
            int containerHeight = 420;
            int containerWidth = 800;
            for (int i = 0; i < palette.Count; i++)
            {
                Rgb24 item = palette[i];
                int x = startingX;
                int y = (i * containerHeight) + (i * startingY);
                //Debug.WriteLine("X:" + x + ",Y:" + y);
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

                for (int j = 0; j < 3; j++)
                {
                    //Now we have to show the items that map to this parent
                    _ = new PictureBox()
                    {
                        Location = new Point(5 + (250 * j + (20 * j)), 35),
                        Height = 250,
                        Width = 250,
                        //BackColor = Color.FromName(ColorPalettes.ToName(item)),
                        Parent = groupBox
                    };
                    _ = new Label()
                    {
                        Location = new Point(6 + (250 * j + (20 * j)), 288),
                        Height = 128,
                        Width = 134,
                        Text = "56% Red\r\n34% Yellow\r\n12% Blue\r\n3% other",
                        Parent = groupBox
                    };
                }

            }

        }
    }
}