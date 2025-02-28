namespace demo
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (!GetNum(out double num1, out double num2)) return;
            if (!GetOp(out char oper)) return;

            Calculate(num1, oper, num2);
            
        }

        private bool GetNum(out double num1, out double num2)
        {
            num1 = double.NaN;
            num2 = double.NaN;
            if (!double.TryParse(input1.Text, out _))
            {
                SendError("输入1不合法！");
                return false;
            }
            if (!double.TryParse(input2.Text, out _))
            {
                SendError("输入2不合法！");
                return false;
            }
            num1 = double.Parse(input1.Text);
            num2 = double.Parse(input2.Text);
            return true;
        }

        private bool GetOp(out char oper)
        {
            string? input = inputOp.Text;
            if (input.Length != 1 || !"+-*/".Contains(input[0]))
            {
                SendError("符号不合法！");
                oper = '\0';
                return false;
            }
            oper = input[0];
            return true;
        }

        private void Calculate(double num1, char oper, double num2)
        {
            double result;
            switch (oper)
            {
                case '+': result = num1 + num2; break;
                case '-': result = num1 - num2; break;
                case '*': result = num1 * num2; break;
                case '/':
                    if (num2 == 0)
                    {
                        SendError("不能除以0！");
                        return;
                    }
                    else
                    {
                        result = num1 / num2;
                    }
                    break;
                default:
                    SendError("符号不合法！");
                    return;
            }

            resultText.ForeColor = Color.Black;
            resultText.Text = $"计算结果为：{result}";
        }

        private void SendError(string message)
        {
            resultText.ForeColor = Color.Red;
            resultText.Text = $"错误：{message}";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            resultText.Visible = true;
        }
    }
}
