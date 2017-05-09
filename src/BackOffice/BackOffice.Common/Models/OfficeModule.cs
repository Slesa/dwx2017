using System.Windows.Input;

namespace BackOffice.Common.Models
{
    public class OfficeModule
    {
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public string IconFile { get; set; }
        public ICommand Command { get; set; }
    }
}