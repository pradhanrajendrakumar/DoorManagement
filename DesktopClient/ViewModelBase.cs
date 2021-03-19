using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DesktopClient
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        protected virtual void SetProperty<T>(ref T member, T value,
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) return;
            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
