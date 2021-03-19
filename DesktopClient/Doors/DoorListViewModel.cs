using System;
using System.Collections.ObjectModel;
using System.Linq;

using DesktopClient.Models;
using DesktopClient.Services;

using Microsoft.AspNetCore.SignalR.Client;

namespace DesktopClient.Doors
{
    public class DoorListViewModel : ViewModelBase
    {
        private readonly IDoorService _doorService;


        private ObservableCollection<DoorModel> _doors;
        private DoorModel _selectedDoor;
        readonly HubConnection _connection;
        public DoorListViewModel(IDoorService doorService, HubConnection connection)
        {
            _doorService = doorService;

            AddDoorCommand = new DelegateCommand<DoorModel>(OnAddDoor);
            RemoveDoorCommand = new DelegateCommand<DoorModel>(OnDeleteDoor);
            EditDoorCommand = new DelegateCommand<DoorModel>(OnEditDoor);

            _connection = connection;

            connection.On<DoorModel>("DeleteMessageReceived", obj =>
            {
                var doorItem = Doors.FirstOrDefault(x => x.Id == obj.Id);
                Doors.Remove(doorItem);
            });

            connection.On<DoorModel>("AddMessageReceived", obj =>
            {
                var doorItem = Doors.FirstOrDefault(x => x.Id == obj.Id);
                if (doorItem == null)
                {
                    Doors.Add(obj);
                }
            });

            connection.On<DoorModel>("EditMessageReceived", obj =>
            {
                var doorItem = Doors.FirstOrDefault(x => x.Id == obj.Id);
                if (doorItem != null)
                {
                    doorItem.IsLocked = obj.IsLocked;
                    doorItem.IsOpen = obj.IsOpen;
                    doorItem.Label = obj.Label;
                }
            });
        }

        public ObservableCollection<DoorModel> Doors
        {
            get => _doors;
            set => SetProperty(ref _doors, value);
        }

        public DelegateCommand<DoorModel> AddDoorCommand { get; private set; }
        public DelegateCommand<DoorModel> RemoveDoorCommand { get; private set; }
        public DelegateCommand<DoorModel> EditDoorCommand { get; private set; }
        public DoorModel SelectedDoor
        {
            get => _selectedDoor;
            set => SetProperty(ref _selectedDoor, value);
        }

        public event Action<DoorModel> DoorAdded = delegate { };
        public event Action<DoorModel> DoorEdited = delegate { };

        private async void OnEditDoor(DoorModel obj)
        {
            DoorEdited(obj);
        }

        private async void OnDeleteDoor(DoorModel obj)
        {
            await _doorService.RemoveDoor(obj);
            await _connection.SendAsync("SendDeleteDoor", obj);
        }

        private async void OnAddDoor(DoorModel obj)
        {
            DoorAdded(new DoorModel() { Label = "" });

        }

        public async void LoadDoors()
        {
            Doors = new ObservableCollection<DoorModel>(await _doorService.GetDoors());
        }
    }
}
