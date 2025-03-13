using Shape;
using System.Collections.Specialized;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace Shape
{
    public abstract class Shape
    {
        public abstract double Area {get; }
        public abstract void PrintInfo();
    }

    public class Rectangle : Shape
    {
        private double height; 
        private double width;  
        public double Height
        {
            get => height;
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                height = value;
            }
        }
        public double Width
        {
            get => width;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                width = value;
            }
        }
        public Rectangle()
        {
            this.Height = 0;
            this.Width = 0;
        }
        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public override double Area
        {
            get
            {
                return Height * Width;
            }
                
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"形状：长方形，参数：{width}, {height}");
        }
    }

    public class Square: Rectangle
    {
        public double Side
        {
            get => Height; // 或者 Width，因为正方形的宽和高相等
            set
            {
                // 设置side时，同时更新Width和Height
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                Height = value;
                Width = value;
            }
        }
        public Square() : base() { }
        public Square(double side) : base(side, side) { }

        public new double Width
        {
            get => base.Width;
            private set => base.Width = value;
        }

        public new double Height
        {
            get => base.Height;
            private set => base.Height = value;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"形状：正方形，参数：{Side}");
        }
    }

    public class Triangle: Shape
    {
        private double a, b, c;
        public double A
        {
            get => a;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                a = value;
            }
        }
        public double B
        {
            get => b;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                b = value;
            }
        }
        public double C
        {
            get => c;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                c = value;
            }
        }

        public Triangle()
        {
            this.A = 0; this.B = 0; this.C = 0;
        }
        public Triangle(double a, double b, double c)
        {
            this.A = a; this.B = b; this.C = c;
        }

        public bool IsValid()
        {
            return (a + b > c) && (b + c > a) && (a + c > b);
        }
        public override double Area
        {
            get
            {
                double p = a + b + c;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"形状：三角形，参数：{a}，{b}，{c}");
        }
    }

    public class Circle : Shape
    {
        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Side cannot be negative.");
                }
                radius = value;
            }
        }
        public Circle()
        {
            this.Radius = 0;
        }
        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double Area
        {
            get
            {
                return Math.PI * radius * radius;
            }

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"形状：圆形，半径：{radius}");
        }
    }

    class SimpleFactory
    { 
        public enum ShapeType{Rectangle, Square, Triangle, Circle}

        public static Shape GetShape(ShapeType name, double[] sides)
        {
            return name switch
            {
                ShapeType.Rectangle => new Rectangle(sides[0], sides[1]),
                ShapeType.Square => new Square(sides[0]),
                ShapeType.Triangle => new Triangle(sides[0], sides[1], sides[2]),
                ShapeType.Circle => new Circle(sides[0]),
                _ => throw new Exception("The shape name does not exist in the factory!"),
            };
        }
    };

    public static class Generator
    {
        private static double NextDouble(this Random ran, double minValue, double maxValue)
        {
            return ran.NextDouble() * (maxValue - minValue) + minValue;
        }
        public static Shape[] Generate(int size)
        {
            // 随机生成以size为大小的形状数组
            string[] nameList = ["Rectangle", "Square", "Triangle", "Circle"];
            Shape[] list = new Shape[size];
            Random ran = new();
            for(int i=0; i<size; i++)
            {
                int type = ran.Next(0, 4);
                string name = nameList[type];
                double[] sides = new double[3];
                for(int j=0; j<3; j++)
                {
                    sides[j] = NextDouble(ran, 0.0, 50.0);
                }
                list[i] = SimpleFactory.GetShape((SimpleFactory.ShapeType)type, sides);
            }
            return list;
        }
    }

    public class ShapeListProcessing
    {
        public static void InterpretShapes(Shape[] shapes)
        {
            foreach (Shape s in shapes)
            {
                s.PrintInfo();
            }
        }
        public static double SumOfArea(Shape[] shapes)
        {
            double sum = 0;
            foreach (Shape s in shapes)
            {
                sum += s.Area;
            }
            return sum;
        }
    }
}


namespace Program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Shape.Shape[] list = Shape.Generator.Generate(10);
            Console.WriteLine("形状信息如下：");
            Shape.ShapeListProcessing.InterpretShapes(list);
            double sumOfArea = Shape.ShapeListProcessing.SumOfArea(list);
            Console.WriteLine($"这些形状的面积和为：{sumOfArea}");
        }
    }
}
