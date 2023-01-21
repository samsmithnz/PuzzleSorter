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
            List<Rgb24> palette = ColorPalettes.Get3ColorPalette();

            //1. Read in input image
            string sourceImageLocation = Environment.CurrentDirectory + @"/Images/st-john-beach.jpg";
            ImageProcessing imageProcessing = new(palette);
            ImageStats? sourceImageStats = imageProcessing.ProcessStatsForImage(sourceImageLocation, null, false);
            lblSourceImageStats.Text = sourceImageStats?.NamesToString;

            //2. Split apart images

            //Do bitmaps first
            List<Bitmap> bitmaps = SplitBitmapIntoPieces(picSourceImage.Image, 250, 250);
            lblSourceImageStats.Text = sourceImageStats?.NamesToString;

            //Crop the individual images next
            Image<Rgb24> sourceImg = SixLabors.ImageSharp.Image.Load<Rgb24>(sourceImageLocation);
            List<Image<Rgb24>> images = ImageProcessing.SplitImageIntoMultiplePieces(sourceImg, 250, 250);

            //Get image stats for each individual image and combine in one list
            List<ImageStats> subImages = new();
            foreach (Image<Rgb24> image in images)
            {
                ImageStats? subitemImageStats = imageProcessing.ProcessStatsForImage(null, image, true);
                if (subitemImageStats != null)
                {
                    subImages.Add(subitemImageStats);
                }
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
            if (sourceImageStats?.ColorGroups != null)
            {
                foreach (KeyValuePair<Rgb24, List<Rgb24>> item in sourceImageStats.ColorGroups)
                {
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

                    //Find all child images matching the top grouping spot
                    for (int j = 0; j < subImages.Count; j++)
                    {
                        if (item.Key == subImages[j].TopColorGroupColor)
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
                            string text = subImages[j].NamesToString;
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
                    }
                    i++;
                }
            }


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