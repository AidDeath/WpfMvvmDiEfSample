using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Windows;

namespace WpfMvvmDiEfSample.ViewModels
{
    /// <summary>
    /// Not fully bad idea, but dont know how to pass Services into ViewModel Constructor
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
            var viewModel = ActivatorUtilities.CreateInstance(App.Current.Services, viewModelType);

            ((FrameworkElement)dp).DataContext = viewModel;
        }
    }
}
