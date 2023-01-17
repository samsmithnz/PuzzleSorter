namespace PuzzleSolver.App
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.picSourceImage = new System.Windows.Forms.PictureBox();
            this.imglistTargetImages = new System.Windows.Forms.ImageList(this.components);
            this.panColors = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picSourceImage
            // 
            this.picSourceImage.Image = global::PuzzleSolver.App.Properties.Resources.st_john_beach;
            this.picSourceImage.Location = new System.Drawing.Point(21, 22);
            this.picSourceImage.Name = "picSourceImage";
            this.picSourceImage.Size = new System.Drawing.Size(1000, 750);
            this.picSourceImage.TabIndex = 0;
            this.picSourceImage.TabStop = false;
            // 
            // imglistTargetImages
            // 
            this.imglistTargetImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglistTargetImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglistTargetImages.ImageStream")));
            this.imglistTargetImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imglistTargetImages.Images.SetKeyName(0, "BaseImage.png");
            this.imglistTargetImages.Images.SetKeyName(1, "ColorfulPhoto.jpg");
            this.imglistTargetImages.Images.SetKeyName(2, "NamedColors.jpg");
            this.imglistTargetImages.Images.SetKeyName(3, "PrimaryAndSecondaryColors.png");
            this.imglistTargetImages.Images.SetKeyName(4, "PuzzlePieces.jpg");
            this.imglistTargetImages.Images.SetKeyName(5, "RedToBlueBlend.jpg");
            // 
            // panColors
            // 
            this.panColors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panColors.AutoScroll = true;
            this.panColors.AutoScrollMinSize = new System.Drawing.Size(0, 815);
            this.panColors.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panColors.Location = new System.Drawing.Point(1052, 22);
            this.panColors.Name = "panColors";
            this.panColors.Size = new System.Drawing.Size(900, 750);
            this.panColors.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 821);
            this.Controls.Add(this.panColors);
            this.Controls.Add(this.picSourceImage);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Solver tester";
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picSourceImage;
        private ImageList imglistTargetImages;
        private Panel panColors;
    }
}