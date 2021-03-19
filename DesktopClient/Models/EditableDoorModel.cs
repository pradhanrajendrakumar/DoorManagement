using System;
using System.ComponentModel.DataAnnotations;

namespace DesktopClient.Models
{
    public class EditableDoorModel : NotifiableDataErrorViewModelBase
    {
        private string _label;
        private bool _isOpen;
        private bool _isLocked;
        private Guid _id;

        public Guid Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        [Required]
        public string Label
        {
            get => _label;
            set => SetProperty(ref _label, value);
        }

        public bool IsOpen
        {
            get => _isOpen;
            set => SetProperty(ref _isOpen, value);
        }

        public bool IsLocked
        {
            get => _isLocked;
            set => SetProperty(ref _isLocked, value);
        }
    }
}