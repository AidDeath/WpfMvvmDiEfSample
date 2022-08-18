﻿using System;
using System.Threading.Tasks;

namespace WpfMvvmDiEfSample.Helpers.Commands
{
    /// <summary>
    /// Универсальная команда для вызова
    /// </summary>
    public class AsyncRelayCommand : AsyncCommand
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly Func<object, Task> _execute;

        /// <summary>
        /// 
        /// </summary>
        private readonly Func<object, bool> _canExecute;

        /// <summary>
        /// Конструктор команды
        /// </summary>
        /// <param name="execute">Вызов команды</param>
        /// <param name="canExecute">Проверка доступности команды</param>
        public AsyncRelayCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(ExecuteAsync));
            _canExecute = canExecute;

        }

        /// <summary>
        /// Вызов команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        /// <summary>
        /// Проверка доступности команды
        /// </summary>
        /// <param name="parameter"></param>
        public override async Task ExecuteAsync(object parameter) => await _execute(parameter);
    }
}
