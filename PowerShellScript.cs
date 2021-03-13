using System;
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;

namespace Cison.PowerShell
{
    public class PowerShellScript
    {
        public static string RunScript(string scriptPowerShell){
            try{
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();

                Pipeline pipeline = runspace.CreatePipeline();
                pipeline.Commands.AddScript(scriptPowerShell);
                pipeline.Commands.Add("Out-String");

                Collection<PSObject> results = pipeline.Invoke();
                runspace.Close();

                StringBuilder stringBuild = new StringBuilder();
                
                foreach(PSObject pSObject in results)
                    stringBuild.AppendLine(pSObject.ToString());
                    
                return stringBuild.ToString();
            }
            catch(Exception e){
                return e.Message;
            }
        }
    }
}