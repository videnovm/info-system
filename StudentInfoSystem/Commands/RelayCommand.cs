﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace StudentInfoSystem
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;
        private Action<MainWindow> LoadStudentData;
        private Predicate<object> canExecute;
        private event EventHandler CanExecuteChangedInternal;

        public RelayCommand(Action execute)
            : this(_ => execute())
        {
        }

        public RelayCommand(Action<object> execute)
            : this(execute, DefaultCanExecute) { }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new ArgumentNullException(nameof(execute));

            if (canExecute == null)
                throw new ArgumentNullException(nameof(canExecute));

            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                this.CanExecuteChangedInternal += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
                this.CanExecuteChangedInternal -= value;
            }
        }

        public bool CanExecute(object parameter) => this.canExecute != null && this.canExecute(parameter);

        public void Execute(object parameter) => this.execute(parameter);

        public void OnCanExecuteChanged()
        {
            EventHandler handler = this.CanExecuteChangedInternal;

            handler?.Invoke(this, EventArgs.Empty);
        }
        public RelayCommand(Action<MainWindow> loadStudentData)
        {
            this.LoadStudentData = loadStudentData;
        }

        public void Destroy()
        {
            this.canExecute = _ => false;
            this.execute = _ => { };
        }

        private static bool DefaultCanExecute(object parameter) => true;
    }
}