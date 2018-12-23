using FFXIVTool.Utility;
using FFXIVTool.ViewModel;
using System;
using System.Windows.Input;

namespace FFXIVTool.Commands
{
    public class RefreshEntitiesCommand : ICommand
    {
        private CharacterDetailsViewModel entityListViewModel;
        public event EventHandler CanExecuteChanged;

        public RefreshEntitiesCommand(CharacterDetailsViewModel vm)
        {
            entityListViewModel = vm;
        }

        public bool CanExecute(object parameter)
        {
            return MemoryManager.Instance.IsReady();
        }

        public void Execute(object parameter)
        {
            entityListViewModel.Refresh();
        }
    }
}

