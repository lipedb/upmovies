using System;
using System;
using System.Threading.Tasks;

namespace UpMovies.Common
{
    //Real simple class to help us with Commands, one if for when we need return, the other is for when we do not need it
    public class AsyncCommand : BaseAsyncCommand
    {
        private readonly Func<Task> command;
        private readonly Func<bool> canExecute;

        public AsyncCommand(Func<Task> command, Func<bool> canExecute = null)
        {
            this.command = command;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return this.command != null && !IsExecuting && (this.canExecute?.Invoke() ?? true);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await command?.Invoke();
        }
    }

    public class AsyncCommand<T> : BaseAsyncCommand
    {
        private readonly Func<T, Task> command;
        private readonly Func<T, bool> canExecute;

        public AsyncCommand(Func<T, Task> command, Func<T, bool> canExecute = null)
        {
            this.command = command;
            this.canExecute = canExecute;
        }
        public override bool CanExecute(object parameter)
        {
            return this.command != null && !IsExecuting && (this.canExecute?.Invoke((T)parameter) ?? true);
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await command?.Invoke((T)parameter);
        }
    }
}