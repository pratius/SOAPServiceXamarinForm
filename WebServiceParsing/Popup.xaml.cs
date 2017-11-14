using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebServiceParsing
{
    public partial class Popup : ContentView
    {
        public Popup()
        {
            InitializeComponent();
        }

        public static BindableProperty MessageTextProperty = BindableProperty.Create(
                                                          propertyName: "MessageText",
                                                          returnType: typeof(string),
            declaringType: typeof(Popup),
                                                          defaultValue: String.Empty,
                                                          defaultBindingMode: BindingMode.OneWay,
                                                          propertyChanged: HandleButtonPropertyChanged);

        private static void HandleButtonPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var popup = (Popup)bindable;
            popup.lblConecting.Text = newValue as string;
        }

        public string MessageText
        {
            get { return (string)base.GetValue(MessageTextProperty); }
            set { base.SetValue(MessageTextProperty, value); }
        }

    }
}
