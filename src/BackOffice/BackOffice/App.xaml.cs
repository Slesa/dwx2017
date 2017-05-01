using System.Windows;

namespace BackOffice
{
	public partial class App : Application
	{
	    private void OnApplicationStartup(object sender, StartupEventArgs e)
	    {
	        var bootstrapper = new Bootstrapper();
            bootstrapper.Run();
	    }
	}
}
