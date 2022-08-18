using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows;

namespace WpfMvvmDiEfSample.ViewModels
{
    /// <summary>
    /// Not fully bad idea, could inject services to VM, but:
    /// Has no suggestions in XAML binding... Not the best option to use
    /// 
    /// Binding to a View (put in XAML):
    ///         xmlns:vml="clr-namespace:WpfMvvmDiEfSample.ViewModels"
    ///         vml:ViewModelLocator.AutoHookedUpViewModel ="True"
    /// </summary>
    public static class ViewModelLocator
    {
        public static bool GetAutoHookedUpViewModel(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoHookedUpViewModelProperty);
        }

        public static void SetAutoHookedUpViewModel(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoHookedUpViewModelProperty, value);
        }

        // Using a DependencyProperty as the backing store for AutoHookedUpViewModel. 

        //This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoHookedUpViewModelProperty =
           DependencyProperty.RegisterAttached("AutoHookedUpViewModel",
           typeof(bool), typeof(ViewModelLocator), new
           PropertyMetadata(false, AutoHookedUpViewModelChanged));

        private static void AutoHookedUpViewModelChanged(DependencyObject dp, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(dp)) return;

            string str = dp.GetType().FullName;

            str = str.Replace(".Views.", ".ViewModels.");

            var viewTypeName = str;
            var viewModelTypeName = viewTypeName + "ViewModel";
            var viewModelType = Type.GetType(viewModelTypeName);
            var viewModel = ActivatorUtilities.CreateInstance(App.Current.AppHost.Services, viewModelType);

            ((FrameworkElement)dp).DataContext = viewModel;
        }
    }
}
