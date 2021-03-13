# PowerShellScript

##Install


##Example
```
using System;
using Cison.PowerShell;

namespace TestPowerShell
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PowerShellScript.RunScript("Get-Process"));
        }
    }
}
```
