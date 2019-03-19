using Xamarin.Forms;
using System;
using System.Windows.Input;

namespace PracticeControls.Controls
{
	public partial class ImageButton : ContentView
	{
        //Text
        public static readonly BindableProperty ButtonTextProperty = BindableProperty.Create("Text", typeof(string), typeof(ImageButton), default(string));
        public string Text
        {
            get => (string)GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        public event EventHandler CLicked;

        //Command
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ImageButton), null);
        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ImageButton), default(string));
        public object CommandParameter
        {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        //Source image
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create("Source", typeof(ImageSource), typeof(ImageButton), default(ImageSource));
        public ImageSource Source
        {
            get => (string)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }


        public ImageButton ()
		{
			InitializeComponent();
            innerImage.SetBinding(Image.SourceProperty, new Binding("Soucre", source: this));
            innerLabel.SetBinding(Label.TextProperty, new Binding("Text", source: this));
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    CLicked?.Invoke(this, EventArgs.Empty);
                    if(Command != null && Command.CanExecute(CommandParameter))
                    {
                        Command.Execute(CommandParameter);
                    }
                })
            });
        }


    }
}