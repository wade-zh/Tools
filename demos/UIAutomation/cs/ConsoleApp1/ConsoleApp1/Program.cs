using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Automation;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now + " -> 正在解析UI组件");
            var window = AutomationElement.FromHandle(new IntPtr(397890));
            var areas = window.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            if(areas.Count < 2)
            {
                Console.WriteLine(DateTime.Now + " -> 解析失败");
                return;
            }
            AutomationElement element = null;
            StringBuilder build = new StringBuilder();
            if (element != null)
            {
                build.AppendLine("Name:" + element.Current.Name);
                build.AppendLine("CalssName:" + element.Current.ClassName);
                build.AppendLine("Handle:" + element.Current.NativeWindowHandle);
                build.AppendLine("Rect:" + element.Current.BoundingRectangle);
                build.AppendLine("Value:" + ((ValuePattern)element.GetCurrentPattern(ValuePattern.Pattern)).Current.Value);
            }
            Console.WriteLine(DateTime.Now + " -> 解析结果: \r\n" + build.ToString());
            Console.ReadKey();
        }
    }
}
