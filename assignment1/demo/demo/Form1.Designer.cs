
namespace demo
{
    partial class Calculator
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
            components = new System.ComponentModel.Container();
            CalButton = new Button();
            input1 = new TextBox();
            toolTip1 = new ToolTip(components);
            inputOp = new ComboBox();
            input2 = new TextBox();
            resultOut = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // CalButton
            // 
            CalButton.Location = new Point(200, 278);
            CalButton.Name = "CalButton";
            CalButton.Size = new Size(112, 34);
            CalButton.TabIndex = 0;
            CalButton.Text = "计算";
            CalButton.UseVisualStyleBackColor = true;
            CalButton.Click += button1_Click;
            // 
            // input1
            // 
            input1.Location = new Point(159, 190);
            input1.Name = "input1";
            input1.Size = new Size(150, 30);
            input1.TabIndex = 1;
            input1.TextChanged += input1_TextChanged;
            // 
            // inputOp
            // 
            inputOp.FormattingEnabled = true;
            inputOp.Items.AddRange(new object[] { "+", "-", "*", "/" });
            inputOp.Location = new Point(315, 188);
            inputOp.Name = "inputOp";
            inputOp.Size = new Size(122, 32);
            inputOp.TabIndex = 2;
            inputOp.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // input2
            // 
            input2.Location = new Point(443, 190);
            input2.Name = "input2";
            input2.Size = new Size(150, 30);
            input2.TabIndex = 3;
            // 
            // resultOut
            // 
            resultOut.Location = new Point(477, 280);
            resultOut.Name = "resultOut";
            resultOut.ReadOnly = true;
            resultOut.Size = new Size(208, 30);
            resultOut.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(353, 283);
            label1.Name = "label1";
            label1.Size = new Size(118, 24);
            label1.TabIndex = 5;
            label1.Text = "计算结果为：";
            label1.Visible = false;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(resultOut);
            Controls.Add(input2);
            Controls.Add(inputOp);
            Controls.Add(input1);
            Controls.Add(CalButton);
            Name = "Calculator";
            Text = "Calculator";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button CalButton;
        private TextBox input1;
        private ToolTip toolTip1;
        private ComboBox inputOp;
        private TextBox input2;
        private TextBox resultOut;
        private Label label1;
    }
}
