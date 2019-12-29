using System;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Reflection;
using JHUICOLORPICKER;

static class Program
{
    [STAThread]
    static void Main()
    {
        if (!SingleInstance.Start())
        {
            MessageBox.Show("This program is already started, check your task bar.");
            return;
        }

        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        try
        {
            Form1 mainForm = new Form1();
            Application.Run(mainForm);
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }

        SingleInstance.Stop();
    }
}

static public class SingleInstance
{
    static Mutex mutex;
    static public bool Start()
    {
        bool onlyInstance = false;
        string mutexName = String.Format("Local\\{0}", ProgramInfo.AssemblyGuid);

        // if you want your app to be limited to a single instance
        // across ALL SESSIONS (multiple users & terminal services), then use the following line instead:
        // string mutexName = String.Format("Global\\{0}", ProgramInfo.AssemblyGuid);

        mutex = new Mutex(true, mutexName, out onlyInstance);
        return onlyInstance;
    }

    static public void Stop()
    {
        mutex.ReleaseMutex();
    }
}

static public class ProgramInfo
{
    static public string AssemblyGuid
    {
        get
        {
            object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false);
            if (attributes.Length == 0)
            {
                return "bc59ee70-7768-4e47-b793-6c841eb7175d";
            }
            return ((System.Runtime.InteropServices.GuidAttribute)attributes[0]).Value;
        }
    }
    static public string AssemblyTitle
    {
        get
        {
            object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if (attributes.Length > 0)
            {
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                if (titleAttribute.Title != "")
                {
                    return titleAttribute.Title;
                }
            }
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
        }
    }
}
