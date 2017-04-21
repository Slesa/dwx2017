using System.Windows.Input;

namespace BackOffice.Models
{
    public class OfficeModule
    {
        public string Title { get; set; }
        public string Tooltip { get; set; }
        public string IconFileName { get; set; }
        public ICommand Command { get; set; }
    }
}