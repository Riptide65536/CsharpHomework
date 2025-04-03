namespace OrdersWinform
{
    partial class DetailsMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            dataGridView1 = new DataGridView();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            idInput = new TextBox();
            CustomerIdInput = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            CustomerNameInput = new TextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            BackButton = new Button();
            addDetailButton = new Button();
            deleteDetailButton = new Button();
            orderDetailsBindingSource = new BindingSource(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(935, 581);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 163);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dataGridView1.Size = new Size(929, 415);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 8;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(label1, 1, 0);
            tableLayoutPanel2.Controls.Add(label2, 1, 1);
            tableLayoutPanel2.Controls.Add(label3, 3, 1);
            tableLayoutPanel2.Controls.Add(label4, 5, 1);
            tableLayoutPanel2.Controls.Add(idInput, 2, 0);
            tableLayoutPanel2.Controls.Add(CustomerIdInput, 2, 1);
            tableLayoutPanel2.Controls.Add(dateTimePicker1, 6, 1);
            tableLayoutPanel2.Controls.Add(CustomerNameInput, 4, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 2;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 40.9090919F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 59.0909081F));
            tableLayoutPanel2.Size = new Size(929, 94);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(35, 7);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 4;
            label1.Text = "订单编号";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(35, 54);
            label2.Name = "label2";
            label2.Size = new Size(82, 24);
            label2.TabIndex = 5;
            label2.Text = "用户编号";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(337, 54);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 6;
            label3.Text = "用户名";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(603, 54);
            label4.Name = "label4";
            label4.Size = new Size(82, 24);
            label4.TabIndex = 7;
            label4.Text = "创建日期";
            // 
            // idInput
            // 
            idInput.Anchor = AnchorStyles.Left;
            idInput.Location = new Point(123, 4);
            idInput.Name = "idInput";
            idInput.Size = new Size(150, 30);
            idInput.TabIndex = 8;
            idInput.TextChanged += idInput_TextChanged;
            // 
            // CustomerIdInput
            // 
            CustomerIdInput.Anchor = AnchorStyles.Left;
            CustomerIdInput.Location = new Point(123, 51);
            CustomerIdInput.Name = "CustomerIdInput";
            CustomerIdInput.Size = new Size(150, 30);
            CustomerIdInput.TabIndex = 9;
            CustomerIdInput.TextChanged += CustomerIdInput_TextChanged;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Left;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dateTimePicker1.Location = new Point(691, 51);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(211, 30);
            dateTimePicker1.TabIndex = 10;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // CustomerNameInput
            // 
            CustomerNameInput.Anchor = AnchorStyles.Left;
            CustomerNameInput.Location = new Point(407, 51);
            CustomerNameInput.Name = "CustomerNameInput";
            CustomerNameInput.Size = new Size(150, 30);
            CustomerNameInput.TabIndex = 11;
            CustomerNameInput.TextChanged += CustomerNameInput_TextChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 8;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Controls.Add(BackButton, 6, 0);
            tableLayoutPanel3.Controls.Add(addDetailButton, 1, 0);
            tableLayoutPanel3.Controls.Add(deleteDetailButton, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 103);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(929, 54);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // BackButton
            // 
            BackButton.Dock = DockStyle.Fill;
            BackButton.Location = new Point(763, 3);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(142, 48);
            BackButton.TabIndex = 0;
            BackButton.Text = "保存并返回";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // addDetailButton
            // 
            addDetailButton.Dock = DockStyle.Fill;
            addDetailButton.Location = new Point(23, 3);
            addDetailButton.Name = "addDetailButton";
            addDetailButton.Size = new Size(142, 48);
            addDetailButton.TabIndex = 1;
            addDetailButton.Text = "添加项目";
            addDetailButton.UseVisualStyleBackColor = true;
            addDetailButton.Click += addDetailButton_Click;
            // 
            // deleteDetailButton
            // 
            deleteDetailButton.Dock = DockStyle.Fill;
            deleteDetailButton.Location = new Point(171, 3);
            deleteDetailButton.Name = "deleteDetailButton";
            deleteDetailButton.Size = new Size(142, 48);
            deleteDetailButton.TabIndex = 2;
            deleteDetailButton.Text = "删除项目";
            deleteDetailButton.UseVisualStyleBackColor = true;
            deleteDetailButton.Click += deleteDetailButton_Click;
            // 
            // DetailsMenu
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(935, 581);
            Controls.Add(tableLayoutPanel1);
            Name = "DetailsMenu";
            Text = "DetailsMenu";
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)orderDetailsBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DataGridView dataGridView1;
        private TableLayoutPanel tableLayoutPanel2;
        private Button BackButton;
        private Button addDetailButton;
        private Button deleteDetailButton;
        private BindingSource orderDetailsBindingSource;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox idInput;
        private TextBox CustomerIdInput;
        private DateTimePicker dateTimePicker1;
        private TextBox CustomerNameInput;
        private TableLayoutPanel tableLayoutPanel3;
    }
}