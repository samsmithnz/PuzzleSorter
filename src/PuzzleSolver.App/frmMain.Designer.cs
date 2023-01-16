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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(21, 778);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 200);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "   Red";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Red;
            this.pictureBox1.Location = new System.Drawing.Point(6, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 1629);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.picSourceImage);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Solver tester";
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox picSourceImage;
        private ImageList imglistTargetImages;
        private GroupBox groupBox1;
        private PictureBox pictureBox1;
    }
}