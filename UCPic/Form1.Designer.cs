namespace UCPic
{
    partial class Form1
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
            pictureBox1 = new PictureBox();
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            label2 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(17, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(461, 216);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.DoubleClick += pictureBox1_DoubleClick;
            // 
            // listView1
            // 
            listView1.Location = new Point(507, 14);
            listView1.Name = "listView1";
            listView1.Size = new Size(180, 216);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.AfterLabelEdit += listView1_AfterLabelEdit;
            listView1.ItemSelectionChanged += listView1_ItemSelectionChanged;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.Location = new Point(431, 260);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 2;
            button1.Text = "貼上";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(631, 260);
            button2.Name = "button2";
            button2.Size = new Size(62, 29);
            button2.TabIndex = 3;
            button2.Text = "刪除";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(545, 260);
            button3.Name = "button3";
            button3.Size = new Size(67, 29);
            button3.TabIndex = 4;
            button3.Text = "上傳";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(83, 265);
            label1.Name = "label1";
            label1.Size = new Size(39, 19);
            label1.TabIndex = 5;
            label1.Text = "網址";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(128, 265);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(107, 19);
            linkLabel1.TabIndex = 6;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "______________";
            // 
            // button4
            // 
            button4.Location = new Point(23, 260);
            button4.Name = "button4";
            button4.Size = new Size(54, 29);
            button4.TabIndex = 7;
            button4.Text = "copy";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(631, 304);
            button5.Name = "button5";
            button5.Size = new Size(62, 29);
            button5.TabIndex = 8;
            button5.Text = "存檔";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(545, 304);
            button6.Name = "button6";
            button6.Size = new Size(67, 29);
            button6.TabIndex = 9;
            button6.Text = "載入";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(456, 309);
            label2.Name = "label2";
            label2.Size = new Size(69, 19);
            label2.TabIndex = 10;
            label2.Text = "本地存檔";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(5, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(702, 242);
            panel1.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 345);
            Controls.Add(panel1);
            Controls.Add(label2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            KeyPreview = true;
            Name = "Form1";
            Text = "UCPImg";
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private ListView listView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Label label1;
        private LinkLabel linkLabel1;
        private Button button4;
        private Button button5;
        private Button button6;
        private Label label2;
        private Panel panel1;
    }
}