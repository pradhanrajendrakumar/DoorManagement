using DesktopClient.Doors;
using DesktopClient.Services;

using Microsoft.AspNetCore.SignalR.Client;

namespace DesktopClient
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly HubConnection _connection;
        private ViewModelBase _viewModelBase;
        private readonly DoorListViewModel _doorListViewModel;
        private readonly AddEditDoorViewModel _addEditDoorViewModel;
        public MainWindowViewModel(IDoorService doorService, HubConnection connection)
        {
            _connection = connection;
            _doorListViewModel = new DoorListViewModel(doorService, connection);
            _addEditDoorViewModel = new AddEditDoorViewModel(connection);

            ViewModelBase = _doorListViewModel;
            _doorListViewModel.DoorAdded += _doorListViewModel_DoorAdded;
            _doorListViewModel.DoorEdited += _doorListViewModel_DoorEdited;
            _addEditDoorViewModel.Cancel += _addEditDoorViewModel_Cancel;
        }

        private void _doorListViewModel_DoorEdited(Models.DoorModel obj)
        {
            _addEditDoorViewModel.EditMode = true;
            _addEditDoorViewModel.SetDoor(obj);
            ViewModelBase = _addEditDoorViewModel;


        }

        private void _doorListViewModel_DoorAdded(Models.DoorModel obj)
        {
            _addEditDoorViewModel.EditMode = false;
            _addEditDoorViewModel.SetDoor(obj);
            ViewModelBase = _addEditDoorViewModel;


        }

        private void _addEditDoorViewModel_Cancel()
        {
            ViewModelBase = _doorListViewModel;
        }

        public ViewModelBase ViewModelBase
        {
            get => _viewModelBase;
            set => SetProperty(ref _viewModelBase, value);
        }
    }
}
