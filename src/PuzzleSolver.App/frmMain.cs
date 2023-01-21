using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Diagnostics;

namespace PuzzleSolver.App
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            //0. Setup
            List<Rgb24> palette = ColorPalettes.Get16ColorPalette();
            int subImageWidth = 250;
            int subImageHeight = 250;

            //1. Read in input image
            string sourceImageLocation = Environment.CurrentDirectory + @"/Images/st-john-beach.jpg";
            ImageProcessing imageProcessing = new(palette);
            ImageStats? sourceImageStats = imageProcessing.ProcessStatsForImage(sourceImageLocation, null, false);
            lblSourceImageStats.Text = sourceImageStats?.NamesToString;

            //2. Split apart images

            //Do bitmaps first
            List<Bitmap> bitmaps = SplitBitmapIntoPieces(picSourceImage.Image, subImageWidth, subImageHeight);
            lblSourceImageStats.Text = sourceImageStats?.NamesToString;

            //Crop the individual images next
            Image<Rgb24> sourceImg = SixLabors.ImageSharp.Image.Load<Rgb24>(sourceImageLocation);
            List<Image<Rgb24>> images = ImageProcessing.SplitImageIntoMultiplePieces(sourceImg, subImageWidth, subImageHeight);

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
            int containerHeight = 470;
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
                        Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Left
                    };
                    //Create a panel to sit in the group - this will allow us to add a horizontal scrollbar
                    Panel panel = new()
                    {
                        Location = new System.Drawing.Point(3, 34),
                        Size = new System.Drawing.Size(794, 430),
                        Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                        AutoScroll = true,
                        Parent = groupBox
                    };
                    //Create a image with the color that lives in the title of the groupbox
                    _ = new PictureBox()
                    {
                        Location = new System.Drawing.Point(6, 8),
                        Height = 20,
                        Width = 20,
                        BackColor = System.Drawing.Color.FromName(ColorPalettes.ToName(item.Key)),
                        Parent = groupBox
                    };

                    //Find all child images matching the top grouping spot
                    int xLocation = 0;
                    for (int j = 0; j < subImages.Count; j++)
                    {
                        Debug.WriteLine(subImages[j].TopColorGroupColor);
                        if (item.Key == subImages[j].TopColorGroupColor)
                        {
                            //Now we have to show the items that map to this parent
                            _ = new Label()
                            {
                                Location = new System.Drawing.Point(5 + (250 * xLocation + (20 * xLocation)), 10),
                                Size = new System.Drawing.Size(100, 30),
                                Text = "#" + (j + 1).ToString(),
                                Parent = panel
                            };
                            _ = new PictureBox()
                            {
                                Location = new System.Drawing.Point(5 + (250 * xLocation + (20 * xLocation)), 43), //5 + 250 for each column, with a 20 buffer for each column too.
                                Width = subImageWidth,
                                Height = subImageHeight,
                                Image = bitmaps[j],
                                BorderStyle = BorderStyle.FixedSingle,
                                Parent = panel
                            };
                            string text = subImages[j].NamesToString;
                            _ = new Label()
                            {
                                AutoSize = false,
                                Location = new System.Drawing.Point(6 + (250 * xLocation + (20 * xLocation)), 296),
                                Height = 100,
                                Width = 250,
                                Text = text,
                                Parent = panel
                            };
                            xLocation++;
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

    }
}