using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace PuzzleSolver.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //0. Setup
            List<Rgb24> palette = ColorPalettes.Get8ColorPalette();

            //1. Read in input image
            string sourceImageLocation = Environment.CurrentDirectory + @"/Images/st-john-beach.jpg";
            ImageProcessing imageProcessing = new(palette);
            Dictionary<Rgb24, List<Rgb24>> sourceGroupedStats = imageProcessing.ProcessImageIntoColorGroups(sourceImageLocation);
            string sourceGroupedStatsString = ImageProcessing.BuildNamedColorsAndPercentsString(sourceGroupedStats);
            lblSourceImageStats.Text = sourceGroupedStatsString;

            //2. Split apart images

            //Do bitmaps first
            List<Bitmap> bitmaps = SplitBitmapIntoPieces(picSourceImage.Image, 250, 250);
            lblSourceImageStats.Text = bitmaps.Count.ToString();

            //Do images second
            Image<Rgb24> sourceImg = SixLabors.ImageSharp.Image.Load<Rgb24>(sourceImageLocation);
            List<Image<Rgb24>> images = ImageProcessing.SplitImageIntoPieces(sourceImg, 250, 250);

            //Do image stats third
            //List<List<KeyValuePair<string, double>>> imageStats = new();
            List<KeyValuePair<Image<Rgb24>, List<KeyValuePair<string, double>>>> imageAndStats = new();
            foreach (Image<Rgb24> image in images)
            {
                Dictionary<Rgb24, List<Rgb24>> groupedStats = imageProcessing.ProcessImageIntoColorGroups(null, image);
                List<KeyValuePair<string, double>> stats = ImageProcessing.BuildNamedColorsAndPercentList(groupedStats, true);
                //imageStats.Add(stats);
                imageAndStats.Add(new(image, stats));
            }
            //Double check that all is well before continuing
            if (bitmaps.Count != images.Count)
            {
                MessageBox.Show($"Something is wrong. There are {bitmaps.Count} bitmaps and {images.Count} images - these should be equal");
            }

            int containerStartingX = 20;
            int containerStartingY = 20;
            int containerHeight = 420;
            int containerWidth = 800;
            int i = 0;
            foreach (KeyValuePair<Rgb24, List<Rgb24>> item in sourceGroupedStats)
            {
                //Rgb24 item = palette[i];
                int x = containerStartingX;
                int y = (i * containerHeight) + (i * containerStartingY) + containerStartingY;
                //Create the groupbox container for the parent color
                GroupBox groupBox = new()
                {
                    Height = containerHeight,
                    Width = containerWidth,
                    Text = "   " + ColorPalettes.ToName(item.Key),
                    Location = new System.Drawing.Point(x, y),
                    Parent = panColors,
                    Anchor = AnchorStyles.Top
                };

                //Create a image with the color 
                _ = new PictureBox()
                {
                    Location = new System.Drawing.Point(6, 8),
                    Height = 20,
                    Width = 20,
                    BackColor = System.Drawing.Color.FromName(ColorPalettes.ToName(item.Key)),
                    Parent = groupBox
                };

                //Add all of the cropped images and their stats
                for (int j = 0; j < bitmaps.Count; j++)
                {
                    //Now we have to show the items that map to this parent
                    _ = new PictureBox()
                    {
                        Location = new System.Drawing.Point(5 + (250 * j + (20 * j)), 35), //5 + 250 for each column, with a 20 buffer for each column too.
                        Height = 250,
                        Width = 250,
                        Image = bitmaps[j],
                        Parent = groupBox
                    };
                    Dictionary<Rgb24, List<Rgb24>> microSourceGroupedStats = imageProcessing.ProcessImageIntoColorGroups(null, images[j]);
                    string text = ImageProcessing.BuildNamedColorsAndPercentsString(microSourceGroupedStats,true);
                    _ = new Label()
                    {
                        AutoSize = false,
                        Location = new System.Drawing.Point(6 + (250 * j + (20 * j)), 288),
                        Height = 128,
                        Width = 250,
                        Text = text,
                        Parent = groupBox
                    };
                }
                i++;
            }

            //3. Group images by biggest % 
            //4. Display grouped images
            //int startingX = 20;
            //int startingY = 20; //778;
            //int containerHeight = 420;
            //int containerWidth = 800;
            //for (int i = 0; i < palette.Count; i++)
            //{
            //    Rgb24 item = palette[i];
            //    int x = startingX;
            //    int y = (i * containerHeight) + (i * startingY);
            //    //Debug.WriteLine("X:" + x + ",Y:" + y);
            //    GroupBox groupBox = new()
            //    {
            //        Height = containerHeight,
            //        Width = containerWidth,
            //        Text = "   " + ColorPalettes.ToName(item),
            //        Location = new System.Drawing.Point(x, y),
            //        Parent = panColors,
            //        Anchor = AnchorStyles.Top
            //    };

            //    //Bitmap bitmap = new()
            //    //SixLabors.ImageSharp.Image img = microImage.CloneAs<SixLabors.ImageSharp.Formats.Bmp>();
            //    _ = new PictureBox()
            //    {
            //        Location = new System.Drawing.Point(6, 8),
            //        Height = 20,
            //        Width = 20,
            //        //BackColor = System.Drawing.Color.FromName(ColorPalettes.ToName(item)),
            //        Image = new Bitmap(ToNetImage(ImageProcessing.ToArray(microImage))),
            //        Parent = groupBox
            //    };

            //    for (int j = 0; j < 3; j++)
            //    {
            //        //Now we have to show the items that map to this parent
            //        _ = new PictureBox()
            //        {
            //            Location = new System.Drawing.Point(5 + (250 * j + (20 * j)), 35),
            //            Height = 250,
            //            Width = 250,
            //            //BackColor = System.Drawing.Color.FromName(ColorPalettes.ToName(item)),
            //            Parent = groupBox
            //        };
            //        _ = new Label()
            //        {
            //            Location = new System.Drawing.Point(6 + (250 * j + (20 * j)), 288),
            //            Height = 128,
            //            Width = 134,
            //            Text = "56% Red\r\n34% Yellow\r\n12% Blue\r\n3% other",
            //            Parent = groupBox
            //        };
            //    }

            //}


        }

        private List<Bitmap> SplitBitmapIntoPieces(System.Drawing.Image sourceImage, int width, int height)
        {
            BitmapSplitter splitter = new();
            List<Bitmap> bitmaps = new();
            for (int y = 0; y < (sourceImage.Height / height); y++)
            {
                for (int x = 0; x < (sourceImage.Width / width); x++)
                {
                    System.Drawing.Rectangle rectangle = new(x * width, y * height, width, height);
                    bitmaps.Add(splitter.CropImage(picSourceImage.Image, rectangle));
                }
            }
            return bitmaps;
        }

        private System.Drawing.Image ToNetImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new(byteArrayIn))
            {
                System.Drawing.Image returnImage = System.Drawing.Image.FromStream(ms);
                return returnImage;
            }
        }

        //public static Image ImageToJPG(this SixLabors.ImageSharp.Image imageIn)
        //{
        //    byte[] bytes = ToArray(imageIn);
        //    return ToImage(bytes);
        //}

    }
}