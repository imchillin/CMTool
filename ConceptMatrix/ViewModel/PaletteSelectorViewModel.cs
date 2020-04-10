using System;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using ConceptMatrix.Properties;
using ConceptMatrix.Utility;

namespace ConceptMatrix.ViewModel
{
    public class PaletteSelectorViewModel
    {
        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
        }
        public ICommand ToggleBackground { get; } = new AnotherCommandImplementation(o => ApplyBG((bool)o));

        public ICommand ToggleBaseCommand { get; } = new AnotherCommandImplementation(o => ApplyBase((bool)o));

        public IEnumerable<Swatch> Swatches { get; }

        public ICommand ApplyPrimaryCommand { get; } = new AnotherCommandImplementation(o => ApplyPrimary((Swatch)o));

        public ICommand ApplyAccentCommand { get; } = new AnotherCommandImplementation(o => ApplyAccent((Swatch)o));

        private static void ApplyBG(bool isBG)
        {
            if (!isBG)
            {
                MainViewModel.ViewTime.ActorBG.Opacity = 0;
                MainViewModel.ViewTime2.EquipBG.Opacity = 0;
                MainViewModel.ViewTime3.WorldBG.Opacity = 0;
                MainViewModel.ViewTime4.PropBG.Opacity = 0;
           //     MainViewModel.ViewTime5.PoseBG.Opacity = 0;
                MainViewModel.AboutTime.AboutBG.Opacity = 0;
            }
            else
            {
                MainViewModel.ViewTime.ActorBG.Opacity = 100;
                MainViewModel.ViewTime2.EquipBG.Opacity = 100;
                MainViewModel.ViewTime3.WorldBG.Opacity = 100;
                MainViewModel.ViewTime4.PropBG.Opacity = 100;
             //   MainViewModel.ViewTime5.PoseBG.Opacity = 100;
                MainViewModel.AboutTime.AboutBG.Opacity = 100;
            }
            SaveSettings.Default.HasBackground = isBG;
        }

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
            SaveSettings.Default.Theme = !isDark ? "Light" : "Dark";
        }

        private static void ApplyPrimary(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
            SaveSettings.Default.Primary = swatch.Name;
        }

        private static void ApplyAccent(Swatch swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
            SaveSettings.Default.Accent = swatch.Name;
        }

    }
    public class AnotherCommandImplementation : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public AnotherCommandImplementation(Action<object> execute) : this(execute, null)
        {
        }

        public AnotherCommandImplementation(Action<object> execute, Func<object, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute ?? (x => true);
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Refresh()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
