namespace MyLib4Reflection
{
    public class ReflectionClass
    {
        // поля
        private int _privateField;
        protected string _protectedField;
        public double PublicField;

        // Свойства 
        public int PublicProperty { get; set; }
        protected string ProtectedProperty { get; set; }
        private bool PrivateProperty { get; set; }

        // Методы 
        public void PublicMethod()
        {
            Console.WriteLine("PublicMethod вызван");
        }

        protected void ProtectedMethod()
        {
            Console.WriteLine("ProtectedMethod вызван");
        }

        private string PrivateMethod(string input)
        {
            Console.WriteLine($"PrivateMethod вызван. Вы ввели {input}");
            return input;
        }

        public ReflectionClass()
        {
            Console.WriteLine("Базовый конструктор");
        }

        // Конструктор с полями
        public ReflectionClass(int privateField, string protectedField, double publicField)
        {
            _privateField = privateField;
            _protectedField = protectedField;
            PublicField = publicField;
            ProtectedProperty = protectedField;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"private field - {_privateField}, protected prop - {ProtectedProperty}");
        }
    }
}
