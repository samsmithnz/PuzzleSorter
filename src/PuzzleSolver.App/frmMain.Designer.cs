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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTest = new System.Windows.Forms.Label();
            this.picTest = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSourceImageStats = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).BeginInit();
            this.panColors.SuspendLayout();
            this.grpTest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTestColor)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.grpTest.Controls.Add(this.panel2);
            this.grpTest.Location = new System.Drawing.Point(20, 20);
            this.grpTest.Name = "grpTest";
            this.grpTest.Size = new System.Drawing.Size(800, 470);
            this.grpTest.TabIndex = 0;
            this.grpTest.TabStop = false;
            this.grpTest.Text = "   Test";
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
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.lblTest);
            this.panel2.Controls.Add(this.picTest);
            this.panel2.Location = new System.Drawing.Point(3, 34);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 430);
            this.panel2.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(643, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 30);
            this.label7.TabIndex = 13;
            this.label7.Text = "#3";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(325, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 30);
            this.label6.TabIndex = 12;
            this.label6.Text = "#2";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(643, 296);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(250, 100);
            this.label5.TabIndex = 11;
            this.label5.Text = "80% Blue\r\n15% White\r\n5% Other";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(325, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 100);
            this.label4.TabIndex = 10;
            this.label4.Text = "80% Blue\r\n15% White\r\n5% Other";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 9;
            this.label3.Text = "#1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::PuzzleSolver.App.Properties.Resources.micro_st_john_beach;
            this.pictureBox2.Location = new System.Drawing.Point(643, 43);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 250);
            this.pictureBox2.TabIndex = 8;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::PuzzleSolver.App.Properties.Resources.micro_st_john_beach;
            this.pictureBox1.Location = new System.Drawing.Point(325, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 250);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // lblTest
            // 
            this.lblTest.Location = new System.Drawing.Point(3, 296);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(250, 100);
            this.lblTest.TabIndex = 6;
            this.lblTest.Text = "80% Blue\r\n15% White\r\n5% Other";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Source picture";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1052, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 32);
            this.label2.TabIndex = 5;
            this.label2.Text = "Grouped images";
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblSourceImageStats);
            this.panel1.Controls.Add(this.picSourceImage);
            this.panel1.Location = new System.Drawing.Point(22, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1024, 895);
            this.panel1.TabIndex = 8;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1984, 958);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panColors);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puzzle Solver tester";
            ((System.ComponentModel.ISupportInitialize)(this.picSourceImage)).EndInit();
            this.panColors.ResumeLayout(false);
            this.grpTest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTestColor)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTest)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private Label lblTest;
        private Label label1;
        private Label label2;
        private Label lblSourceImageStats;
        private Panel panel1;
        private Panel panel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
    }
}