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
            var window = AutomationElement.FromHandle(new IntPtr(397890));
            var area = window.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            if (area != null)
            {
                StringBuilder build = new StringBuilder();
                build.AppendLine("Name:" + area.Current.Name);
                build.AppendLine("CalssName:" + area.Current.ClassName);
                build.AppendLine("Handle:" + area.Current.NativeWindowHandle);
                build.AppendLine("Rect:" + area.Current.BoundingRectangle);
                build.AppendLine("Value:" + ((ValuePattern)area.GetCurrentPattern(ValuePattern.Pattern)).Current.Value);
            }
        }
    }
}
