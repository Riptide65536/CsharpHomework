namespace demo
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            int num1, num2, result; char oper;
            num1 = Int32.Parse(input1.Text);
            oper = Char.Parse(inputOp.Text);
            num2 = Int32.Parse(input2.Text);

            switch (oper)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    if (num2 == 0)
                    {
                        label1.Text = "除数不能为0！";
                        label1.Visible = true;
                        return;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    label1.Text = "请选择正确的计算符号！";
                    label1.Visible = true;
                    return;
            }

            label1.Visible = true;
            resultOut.Text = Convert.ToString(result);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void input1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
