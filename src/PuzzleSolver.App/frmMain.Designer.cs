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
            this.grpTest = new System.Windows.Forms.GroupBox();
            this.picTestColor = new System.Windows.Forms.PictureBox();
            this.panTest = new System.Windows.Forms.Panel();
            this.lblTest3 = new System.Windows.Forms.Label();
            this.lblTest2 = new System.Windows.Forms.Label();
            this.lblTestStats3 = new System.Windows.Forms.Label();
            this.lblTestStats2 = new System.Windows.Forms.Label();
            this.lblTest1 = new System.Windows.Forms.Label();
            this.picTest3 = new System.Windows.Forms.PictureBox();
            this.picTest2 = new System.Windows.Forms.PictureBox();
            this.lblTestStats1 = new System.Windows.Forms.Label();
            this.picTest = new System.Windows.Forms.PictureBox();
            this.lblSourceTitle = new System.Windows.Forms.Label();
            this.lblGroupsTitle = new System.Windows.Forms.Label();
            this.lblSourceImageStats = new System.Windows.Forms.Label();
            this.panSource = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.panColors.SuspendLayout();
            this.grpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTestColor)).BeginInit();
            this.panTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTest3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).BeginInit();
            this.panSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // picSourceImage
            // 
            this.picSourceImage.Image = global::PuzzleSolver.App.Properties.Resources.st_john_beach;
            this.picSourceImage.Location = new System.Drawing.Point(3, 3);
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
            this.panColors.Controls.Add(this.grpTest);
            this.panColors.Location = new System.Drawing.Point(1052, 43);
            this.panColors.Name = "panColors";
            this.panColors.Size = new System.Drawing.Size(900, 896);
            this.panColors.TabIndex = 3;
            // 
            // grpTest
            // 
            this.grpTest.Controls.Add(this.picTestColor);
            this.grpTest.Controls.Add(this.panTest);
            this.grpTest.Location = new System.Drawing.Point(20, 20);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(800, 470);
            this.grpTest.TabIndex = 0;
            this.grpTest.TabStop = false;
            this.grpTest.Text = "   Test";
            this.grpTest.Visible = false;
            // 
            // picTestColor
            // 
            this.picTestColor.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picTestColor.Location = new System.Drawing.Point(6, 8);
            this.picTestColor.Name = "picTestColor";
            this.picTestColor.Size = new System.Drawing.Size(20, 20);
            this.picTestColor.TabIndex = 0;
            this.picTestColor.TabStop = false;
            // 
            // panTest
            // 
            this.panTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panTest.AutoScroll = true;
            this.panTest.Controls.Add(this.lblTest3);
            this.panTest.Controls.Add(this.lblTest2);
            this.panTest.Controls.Add(this.lblTestStats3);
            this.panTest.Controls.Add(this.lblTestStats2);
            this.panTest.Controls.Add(this.lblTest1);
            this.panTest.Controls.Add(this.picTest3);
            this.panTest.Controls.Add(this.picTest2);
            this.panTest.Controls.Add(this.lblTestStats1);
            this.panTest.Controls.Add(this.picTest);
            this.panTest.Location = new System.Drawing.Point(3, 34);
            this.panTest.Name = "panTest";
            this.panTest.Size = new System.Drawing.Size(794, 430);
            this.panTest.TabIndex = 7;
            // 
            // lblTest3
            // 
            this.lblTest3.Location = new System.Drawing.Point(643, 10);
            this.lblTest3.Name = "lblTest3";
            this.lblTest3.Size = new System.Drawing.Size(100, 30);
            this.lblTest3.TabIndex = 13;
            this.lblTest3.Text = "#3";
            // 
            // lblTest2
            // 
            this.lblTest2.Location = new System.Drawing.Point(325, 10);
            this.lblTest2.Name = "lblTest2";
            this.lblTest2.Size = new System.Drawing.Size(100, 30);
            this.lblTest2.TabIndex = 12;
            this.lblTest2.Text = "#2";
            // 
            // lblTestStats3
            // 
            this.lblTestStats3.Location = new System.Drawing.Point(643, 296);
            this.lblTestStats3.Name = "lblTestStats3";
            this.lblTestStats3.Size = new System.Drawing.Size(250, 100);
            this.lblTestStats3.TabIndex = 11;
            this.lblTestStats3.Text = "80% Blue\r\n15% White\r\n5% Other";
            // 
            // lblTestStats2
            // 
            this.lblTestStats2.Location = new System.Drawing.Point(325, 296);
            this.lblTestStats2.Name = "lblTestStats2";
            this.lblTestStats2.Size = new System.Drawing.Size(250, 100);
            this.lblTestStats2.TabIndex = 10;
            this.lblTestStats2.Text = "80% Blue\r\n15% White\r\n5% Other";
            // 
            // lblTest1
            // 
            this.lblTest1.Location = new System.Drawing.Point(5, 10);
            this.lblTest1.Name = "lblTest1";
            this.lblTest1.Size = new System.Drawing.Size(100, 30);
            this.lblTest1.TabIndex = 9;
            this.lblTest1.Text = "#1";
            // 
            // picTest3
            // 
            this.picTest3.BackgroundImage = global::PuzzleSolver.App.Properties.Resources.micro_st_john_beach;
            this.picTest3.Location = new System.Drawing.Point(643, 43);
            this.picTest3.Name = "picTest3";
            this.picTest3.Size = new System.Drawing.Size(250, 250);
            this.picTest3.TabIndex = 8;
            this.picTest3.TabStop = false;
            // 
            // picTest2
            // 
            this.picTest2.BackgroundImage = global::PuzzleSolver.App.Properties.Resources.micro_st_john_beach;
            this.picTest2.Location = new System.Drawing.Point(325, 43);
            this.picTest2.Name = "picTest2";
            this.picTest2.Size = new System.Drawing.Size(250, 250);
            this.picTest2.TabIndex = 7;
            this.picTest2.TabStop = false;
            // 
            // lblTestStats1
            // 
            this.lblTestStats1.Location = new System.Drawing.Point(3, 296);
            this.lblTestStats1.Name = "lblTestStats1";
            this.lblTestStats1.Size = new System.Drawing.Size(250, 100);
            this.lblTestStats1.TabIndex = 6;
            this.lblTestStats1.Text = "80% Blue\r\n15% White\r\n5% Other";
            // 
            // picTest
            // 
            this.picTest.BackgroundImage = global::PuzzleSolver.App.Properties.Resources.micro_st_john_beach;
            this.picTest.Location = new System.Drawing.Point(3, 43);
            this.picTest.Name = "picTest";
            this.picTest.Size = new System.Drawing.Size(250, 250);
            this.picTest.TabIndex = 1;
            this.picTest.TabStop = false;
            // 
            // lblSourceTitle
            // 
            this.lblSourceTitle.AutoSize = true;
            this.lblSourceTitle.Location = new System.Drawing.Point(22, 9);
            this.lblSourceTitle.Name = "lblSourceTitle";
            this.lblSourceTitle.Size = new System.Drawing.Size(168, 32);
            this.lblSourceTitle.TabIndex = 4;
            this.lblSourceTitle.Text = "Source picture";
            // 
            // lblGroupsTitle
            // 
            this.lblGroupsTitle.AutoSize = true;
            this.lblGroupsTitle.Location = new System.Drawing.Point(1052, 9);
            this.lblGroupsTitle.Name = "lblGroupsTitle";
            this.lblGroupsTitle.Size = new System.Drawing.Size(190, 32);
            this.lblGroupsTitle.TabIndex = 5;
            this.lblGroupsTitle.Text = "Grouped images";
            // 
            // lblSourceImageStats
            // 
            this.lblSourceImageStats.AutoSize = true;
            this.lblSourceImageStats.Location = new System.Drawing.Point(3, 756);
            this.lblSourceImageStats.Name = "lblSourceImageStats";
            this.lblSourceImageStats.Size = new System.Drawing.Size(134, 128);
            this.lblSourceImageStats.TabIndex = 7;
            this.lblSourceImageStats.Text = "56% Red\r\n34% Yellow\r\n12% Blue\r\n3% other";
            // 
            // panSource
            // 
            this.panSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSource.Controls.Add(this.lblSourceImageStats);
            this.panSource.Controls.Add(this.picSourceImage);
            this.panSource.Location = new System.Drawing.Point(22, 44);
            this.panSource.Name = "panSource";
            this.panSource.Size = new System.Drawing.Size(1024, 895);
            this.panSource.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 958);
            this.Controls.Add(this.lblGroupsTitle);
            this.Controls.Add(this.lblSourceTitle);
            this.Controls.Add(this.panColors);
            this.Controls.Add(this.panSource);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Solver tester";
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.panColors.ResumeLayout(false);
            this.grpTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTestColor)).EndInit();
            this.panTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTest3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).EndInit();
            this.panSource.ResumeLayout(false);
            this.panSource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox picSourceImage;
        private ImageList imglistTargetImages;
        private Panel panColors;
        private GroupBox grpTest;
        private PictureBox picTest;
        private PictureBox picTestColor;
        private Label lblTestStats1;
        private Label lblSourceTitle;
        private Label lblGroupsTitle;
        private Label lblSourceImageStats;
        private Panel panSource;
        private Panel panTest;
        private PictureBox picTest3;
        private PictureBox picTest2;
        private Label lblTest3;
        private Label lblTest2;
        private Label lblTestStats3;
        private Label lblTestStats2;
        private Label lblTest1;
    }
}