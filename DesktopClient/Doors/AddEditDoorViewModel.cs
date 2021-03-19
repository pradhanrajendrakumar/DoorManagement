using System;
using System.ComponentModel;

using DesktopClient.Models;
using DesktopClient.Services;

using Microsoft.AspNetCore.SignalR.Client;

namespace DesktopClient.Doors
{
    public class AddEditDoorViewModel : ViewModelBase
    {
        private readonly HubConnection _connection;
        private bool _editMode;
        private DoorModel _doorModel = null;
        private EditableDoorModel _editableDoorModel;

        public event Action Cancel = delegate { };

        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand OpenCloseCommand { get; set; }

        public DelegateCommand DoorLockUnLockCommand { get; set; }
        public AddEditDoorViewModel(HubConnection connection)
        {
            _connection = connection;
            CancelCommand = new DelegateCommand(OnCancel);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            OpenCloseCommand = new DelegateCommand(OnOpenCloseDoor);
            DoorLockUnLockCommand = new DelegateCommand(OnDoorLockUnLock);
        }

        private void OnDoorLockUnLock()
        {
            _editableDoorModel.IsLocked = !_editableDoorModel.IsLocked;
        }

        private void OnOpenCloseDoor()
        {
            _editableDoorModel.IsOpen = !_editableDoorModel.IsOpen;
            if (_editableDoorModel.IsOpen)
            {
                _editableDoorModel.IsLocked = false;
            }
        }

        public bool EditMode
        {
            get => _editMode;
            set => SetProperty(ref _editMode, value);
        }

        public EditableDoorModel EditableDoorModel
        {
            get => _editableDoorModel;
            set => SetProperty(ref _editableDoorModel, value);
        }
        private async void OnSave()
        {
            IDoorService doorService = new DoorService();

            _doorModel.Label = _editableDoorModel.Label;
            _doorModel.IsLocked = _editableDoorModel.IsLocked;
            _doorModel.IsOpen = _editableDoorModel.IsOpen;

            if (EditMode)
            {
                await doorService.EditDoor(_doorModel);
                await _connection.SendAsync("SendEditDoor", _doorModel);
            }
            else
            {
                await doorService.AddDoor(_doorModel);
                await _connection.SendAsync("SendAddDoor", _doorModel);
            }
            Cancel();
        }
        private bool CanSave()
        {
            return !EditableDoorModel.HasErrors;
        }
        private void OnCancel()
        {
            Cancel();
        }

        public void SetDoor(DoorModel door)
        {
            _doorModel = door;
            if (EditableDoorModel != null)
            {
                EditableDoorModel.ErrorsChanged -= RaiseCanExecuteChanged;
            }

            EditableDoorModel = new EditableDoorModel();
            EditableDoorModel.ErrorsChanged += RaiseCanExecuteChanged;

            _editableDoorModel.Id = door.Id;
            _editableDoorModel.IsOpen = door.IsOpen;
            _editableDoorModel.IsLocked = door.IsLocked;
            _editableDoorModel.Label = door.Label;
        }

        private void RaiseCanExecuteChanged(object? sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }


    }
}
