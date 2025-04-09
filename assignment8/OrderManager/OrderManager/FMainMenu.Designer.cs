
namespace OrderManager
{
    partial class MainWindow
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
            Title = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            button1 = new Button();
            button2 = new Button();
            tableLayoutBig = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutBig.SuspendLayout();
            SuspendLayout();
            // 
            // Title
            // 
            Title.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            Title.AutoSize = true;
            Title.Font = new Font("Microsoft YaHei UI", 18F);
            Title.Location = new Point(3, 0);
            Title.Name = "Title";
            Title.Size = new Size(794, 225);
            Title.TabIndex = 0;
            Title.Text = "欢迎使用订单管理程序";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(button1, 1, 1);
            tableLayoutPanel1.Controls.Add(button2, 3, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 228);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(794, 219);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Fill;
            button1.Location = new Point(161, 75);
            button1.Name = "button1";
            button1.Size = new Size(152, 66);
            button1.TabIndex = 0;
            button1.Text = "订单管理";
            button1.UseVisualStyleBackColor = true;
            button1.Click += this.Button1_Click;
            // 
            // button2
            // 
            button2.Dock = DockStyle.Fill;
            button2.Location = new Point(477, 75);
            button2.Name = "button2";
            button2.Size = new Size(152, 66);
            button2.TabIndex = 1;
            button2.Text = "存货管理";
            button2.UseVisualStyleBackColor = true;
            button2.Click += this.Button2_Click;
            // 
            // tableLayoutBig
            // 
            tableLayoutBig.ColumnCount = 1;
            tableLayoutBig.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutBig.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutBig.Controls.Add(Title, 0, 0);
            tableLayoutBig.Dock = DockStyle.Fill;
            tableLayoutBig.Location = new Point(0, 0);
            tableLayoutBig.Name = "tableLayoutBig";
            tableLayoutBig.RowCount = 2;
            tableLayoutBig.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutBig.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutBig.Size = new Size(800, 450);
            tableLayoutBig.TabIndex = 2;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutBig);
            Name = "MainWindow";
            Text = "MainWindow";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutBig.ResumeLayout(false);
            tableLayoutBig.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label Title;
        private Button button1;
        private Button button2;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutBig;
    }
}
