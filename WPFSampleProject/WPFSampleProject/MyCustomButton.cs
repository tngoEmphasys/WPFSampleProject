using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFSampleProject
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFSampleProject"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WPFSampleProject;assembly=WPFSampleProject"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:MyCustomButton/>
    ///
    /// </summary>
    /// 
    [TemplatePart(Name = "MainButton", Type = typeof(Button))]
    public class MyCustomButton : Control
    {
        Button Button;

        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color",
            typeof(Color),
            typeof(MyCustomButton),
            new PropertyMetadata(Colors.Green));

        public Color Color
        {
            get
            {
                return (Color)this.GetValue(ColorProperty);
            }
            set
            {
                this.SetValue(ColorProperty, value);
            }
        }
        static void OnCustomCommand(object sender, ExecutedRoutedEventArgs e)
        {
            //Need to first retrieve the control
            MyCustomButton invoker = sender as MyCustomButton;

            //Do whatever you need
            
        }

        public static readonly ICommand CustomCommand = new RoutedUICommand("CustomCommand", "CustomCommand",
                                                        typeof(MyCustomButton),
                                                        new InputGestureCollection(
                                                            new InputGesture[] {
                                                                new KeyGesture(Key.Enter),
                                                                new MouseGesture(MouseAction.LeftClick) }
                                                                ));
        public static readonly RoutedEvent InvertCallEvent = EventManager.RegisterRoutedEvent("InvertCall",
                            RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyCustomButton));

        public event RoutedEventHandler InvertCall
        {
            add { AddHandler(InvertCallEvent, value); }
            remove { RemoveHandler(InvertCallEvent, value); }
        }

        private void OnInvertCall()
        {
            RoutedEventArgs args = new RoutedEventArgs(InvertCallEvent);
            RaiseEvent(args);
        }
        static MyCustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCustomButton), 
                new FrameworkPropertyMetadata(typeof(MyCustomButton)));
            CommandManager.RegisterClassCommandBinding(typeof(MyCustomButton),
                new CommandBinding(MyCustomButton.CustomCommand, OnCustomCommand));
            EventManager.RegisterClassHandler(typeof(MyCustomButton), Mouse.MouseDownEvent,
                new MouseButtonEventHandler(OnMouseDown));

        }
        static void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            MyCustomButton invoker = sender as MyCustomButton;
            //Do handle event

            //Raise your event
            invoker.OnInvertCall();

            //Do Rest
        }
   
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.Template != null)
            {
                Button myButton = this.Template.FindName("MainButton", this) as Button;
                
                if (myButton != Button)
                {
                    //First unhook existing handler
                    if (myButton != null)
                    {
                        myButton.MouseEnter -= new MouseEventHandler(MainBorder_MouseEnter);
                        myButton.MouseLeave -= new MouseEventHandler(MainBorder_MouseLeave);
                    }
                    Button = myButton;
                    if (Button != null)
                    {
                        Button.MouseEnter += new MouseEventHandler(MainBorder_MouseEnter);
                        Button.MouseLeave += new MouseEventHandler(MainBorder_MouseLeave);
                    }
                }
                Button.Background = new SolidColorBrush(Color);
            }
        }

        void MainBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            Button myButton = sender as Button;
            if (myButton != null)
            {
                myButton.Background = new SolidColorBrush(Color);
                Run r = new Run("Click Me");
                myButton.Content = r;

            }
        }

        void MainBorder_MouseEnter(object sender, MouseEventArgs e)
        {
            Button myButton = sender as Button;
            if (myButton != null)
            {
                myButton.Background = new SolidColorBrush(Colors.LightBlue);
                Run r = new Run("Save!");
                myButton.Content = r;
            }
        }
    }
}
