using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleAppXamarin.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationControl : Grid
    {
        public NavigationControl()
        {
            InitializeComponent();
        }
        #region CommandParameter BindableProperty
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(string),
            typeof(NavigationControl),
            string.Empty,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationControl)bindable;
                ctrl.CommandParameter = (string)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);
        private string commandParameter;
        public string CommandParameter
        {
            get { return commandParameter; }
            set
            {
                commandParameter = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Icon BindableProperty
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
         nameof(Icon),
         typeof(string),
         typeof(NavigationControl),
         string.Empty,
         propertyChanging: (bindable, oldValue, newValue) =>
         {
             var ctrl = (NavigationControl)bindable;
             ctrl.Icon = (string)newValue;
         },
         defaultBindingMode: BindingMode.OneWay);

        private string icon;

        public string Icon
        {
            get { return icon; }
            set
            {
                icon = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Text BindableProperty
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
             nameof(Text),
             typeof(string),
             typeof(NavigationControl),
             string.Empty,
             propertyChanging: (bindable, oldValue, newValue) =>
             {
                 var ctrl = (NavigationControl)bindable;
                 ctrl.Text = (string)newValue;
             },
             defaultBindingMode: BindingMode.OneWay);

        private string text;
        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command BindableProperty
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            "Command",
            typeof(ICommand),
            typeof(NavigationControl),
            null,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (NavigationControl)bindable;
                ctrl.Command = (ICommand)newValue;
            },
            defaultBindingMode: BindingMode.OneWay);

        private ICommand command;

        public ICommand Command
        {
            get { return command; }
            set
            {
                command = value;
                OnPropertyChanged();
            }
        }
        #endregion  
    }
}