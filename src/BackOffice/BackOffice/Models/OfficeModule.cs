using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BackOffice.Models
{
    public class OfficeModule
    {
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public string IconFile { get; set; }
        public ICommand Command { get; set; }
    }
}