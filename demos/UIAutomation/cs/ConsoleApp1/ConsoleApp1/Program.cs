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
            var area = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            StringBuilder build = new StringBuilder();
            if (area != null)
            {
                build.AppendLine("Name:" + area.Current.Name);
                build.AppendLine("CalssName:" + area.Current.ClassName);
                build.AppendLine("Handle:" + area.Current.NativeWindowHandle);
                build.AppendLine("Rect:" + area.Current.BoundingRectangle);
                build.AppendLine("Value:" + ((ValuePattern)area.GetCurrentPattern(ValuePattern.Pattern)).Current.Value);
            }
            Console.WriteLine(DateTime.Now + " -> 解析结果: \r\n" + build.ToString());
            Console.ReadKey();
        }
    }
}
