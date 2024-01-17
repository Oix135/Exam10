using Exzm10.Interfaces;
using System.Globalization;

namespace Exzm10
{
    internal class Calculator:ICalculator
    {
        ILogger Logger { get; }
        public Calculator(ILogger logger) 
        {
            Logger = logger;
            Logger.Event("Сложение чисел!\n");
            Work(null,null);
        }

        private void Work(double? x, double? y)
        {
            
            if(x is null)
            {
                Logger.Event("Введите первое число");
                GetArgument(out x,  y, false);
                return;
            }
            if(y is null)
            {
                Logger.Event("Введите второе число");
                GetArgument(out y, x, true);
                return;
            }
            var result = Calculate((double)x, (double)y);
            Logger.Event($"\nРезультат: {x} + {y} = {result}");
        }

        private void GetArgument(out double? x, double? y, bool inverseArgs)
        {
            x = null;
            try
            {
               x = double.Parse(Console.ReadLine(), CultureInfo.CurrentCulture);
            }
            catch(FormatException ex)
            {
                Logger.Error(ex.Message);
                x = null;
            }
            finally
            {
                if(!inverseArgs)
                {
                    Work(x, y);
                }
                else
                {
                    Work(y, x);
                }
                
            }
        }

        public double Calculate(double x, double y)
        {
            return Math.Round(x + y, 2);
        }
    }
}
