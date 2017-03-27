using System.Threading.Tasks;
using static System.Console;

namespace Ch24Ex11
{
    internal static class Program
    {
        private static int[] _data;

        private static void MyTransform(int i)
        {
            _data[i] = _data[i] / 10;

            if (_data[i] < 10000)
            {
                _data[i] = 0;
            }
            if (_data[i] > 10000 & _data[i] < 20000)
            {
                _data[i] = 100;
            }
            if (_data[i] > 20000 & _data[i] < 30000)
            {
                _data[i] = 200;
            }
            if (_data[i] > 30000)
            {
                _data[i] = 300;
            }
        }

        private static void Main()
        {
            WriteLine("Основной поток выполнения запущен.");

            _data = new int[100000000];

            for (var i = 0; i < _data.Length; i++)
            {
                _data[i] = i;
            }

            Parallel.For(0, _data.Length, MyTransform);
            
            WriteLine("Основной поток выполнения завершён.");
        }
    }
    
}
