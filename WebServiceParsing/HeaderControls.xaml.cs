using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace WebServiceParsing
{
    public partial class HeaderControls : ContentView
    {
        public HeaderControls()
        {
            InitializeComponent();
        }

        public static BindableProperty ImageProperty = BindableProperty.Create(
                                                         propertyName: "Image",
                                                         returnType: typeof(string),
                                                          declaringType: typeof(HeaderControls),
                                                         defaultValue: "",
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: ImageSourcePropertyChanged);

        public string Image
        {
            get { return base.GetValue(ImageProperty).ToString(); }
            set { base.SetValue(ImageProperty, value); }
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (HeaderControls)bindable;
            control.btnBackground.Source = ImageSource.FromFile(newValue.ToString());
        }

        public static BindableProperty ButtonTextProperty = BindableProperty.Create(
                                                         propertyName: "ButtonText",
                                                         returnType: typeof(string),
                                                          declaringType: typeof(HeaderControls),
                                                         defaultValue: String.Empty,
                                                         defaultBindingMode: BindingMode.OneWay,
                                                         propertyChanged: ButtonTextPropertyChanged);

        private static void ButtonTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var popup = (HeaderControls)bindable;
            popup.lblConfirm.Text = newValue as string;
        }

        public string ButtonText
        {
            get { return (string)base.GetValue(ButtonTextProperty); }
            set { base.SetValue(ButtonTextProperty, value); }
        }
    }
}
