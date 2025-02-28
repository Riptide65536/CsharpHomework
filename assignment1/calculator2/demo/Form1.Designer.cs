
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
            resultText = new Label();
            SuspendLayout();
            // 
            // CalButton
            // 
            CalButton.Location = new Point(223, 251);
            CalButton.Name = "CalButton";
            CalButton.Size = new Size(112, 51);
            CalButton.TabIndex = 0;
            CalButton.Text = "计算";
            CalButton.UseVisualStyleBackColor = true;
            CalButton.Click += Button1_Click;
            // 
            // input1
            // 
            input1.Location = new Point(185, 180);
            input1.Name = "input1";
            input1.Size = new Size(150, 30);
            input1.TabIndex = 1;
            // 
            // inputOp
            // 
            inputOp.FormattingEnabled = true;
            inputOp.Items.AddRange(new object[] { "+", "-", "*", "/" });
            inputOp.Location = new Point(338, 178);
            inputOp.Name = "inputOp";
            inputOp.Size = new Size(122, 32);
            inputOp.TabIndex = 2;
            // 
            // input2
            // 
            input2.Location = new Point(466, 180);
            input2.Name = "input2";
            input2.Size = new Size(150, 30);
            input2.TabIndex = 3;
            // 
            // resultText
            // 
            resultText.AutoSize = true;
            resultText.Location = new Point(382, 264);
            resultText.Name = "resultText";
            resultText.Size = new Size(0, 24);
            resultText.TabIndex = 5;
            resultText.Visible = false;
            // 
            // Calculator
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultText);
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
        private Label resultText;
    }
}
