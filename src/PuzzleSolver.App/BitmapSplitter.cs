namespace PuzzleSolver.App
{
    public class BitmapSplitter
    {
        public Bitmap CropImage(Image img, Rectangle cropArea)
        {
            Bitmap bmpImage = new(img);
            Bitmap bmpCrop = bmpImage.Clone(cropArea, bmpImage.PixelFormat);
            return bmpCrop;
        }

        public BitmapItem[] BitmapToArray(Bitmap inp, Point BlockSize)
        {
            if (BlockSize.X > inp.Width || BlockSize.Y > inp.Height)
            {
                BlockSize.X = BlockSize.Y = 100;
            }

            int NW;
            int NH;
            int tx = 1;
            int ty = 1;
            if (((inp.Width % BlockSize.X) == 0) && ((inp.Height % BlockSize.Y) == 0))
            {
                NW = inp.Width;
                NH = inp.Height;
            }
            else
            {
                tx = inp.Width / BlockSize.X;
                NW = (BlockSize.X * tx) + BlockSize.X;
                ty = inp.Height / BlockSize.Y;
                NH = (BlockSize.Y * ty) + BlockSize.Y;
            }

            //Operations for making an exact bitmap size
            Bitmap Temp = new(NW, NH);
            Graphics g = Graphics.FromImage(Temp);
            g.DrawImage(inp, 0, 0, new Rectangle(0, 0, Temp.Width, Temp.Height), GraphicsUnit.Pixel);
            g.Dispose(); //Cleaning up; Temp now has the exact bitmap size of what input BMP should has for devision.

            BitmapItem[] T = new BitmapItem[(tx * ty) + 1]; //Array for Bitmap MatriX

            int Xpos = 0, Ypos;
            int counter = 0;
            //Move left to right, top to bottom, like reading a book.
            for (int i = 0; i < tx; i++)
            {
                Ypos = 0;
                for (int j = 0; j < ty; j++)
                {
                    BitmapItem t = new();
                    t.start_location = new Point(Xpos, Ypos);
                    t.Bitmap = new Bitmap(BlockSize.X, BlockSize.Y);
                    Graphics gt = Graphics.FromImage(t.Bitmap);
                    gt.DrawImage(Temp, Xpos, Ypos, new Rectangle(0, 0, t.Bitmap.Width, t.Bitmap.Height), GraphicsUnit.Pixel);
                    gt.Dispose();
                    T[counter] = t;

                    Ypos += BlockSize.Y;
                    counter += 1;
                }
                Xpos += BlockSize.X;
            }
            return T;
        }

        public class BitmapItem
        {
            public Point start_location;

            public Bitmap Bitmap;
        }
    }
}
