using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Notifications;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.ViewManagement;
using Windows.ApplicationModel.Core;
using Windows.UI;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace UWP_Clicker
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            /*
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ForegroundColor = Windows.UI.Colors.Black;
            titleBar.BackgroundColor = Windows.UI.Colors.WhiteSmoke;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.WhiteSmoke;
            */

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            ApplicationViewTitleBar titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.ButtonBackgroundColor = Colors.Transparent;
            titleBar.ButtonInactiveBackgroundColor = Colors.Transparent;

            titleBar.ButtonForegroundColor = Windows.UI.Colors.Black;
        }
            
        int clicks = 0;
        int cn = 1;

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ItemsControl_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            clicks = clicks + cn;
            txtBlock.Text = clicks.ToString();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (clicks>50)
            {
                clicks = clicks - 50;
                cn = cn + 1;
                txtBlock.Text = clicks.ToString();

                /*
                ToastContent content = new ToastContent()
                {

                    Visual = new ToastVisual()
                    {
                        BindingGeneric = new ToastBindingGeneric()
                        {
                            Children =
                            {
                                new AdaptiveText()
                                {
                                    Text = "You bought booster!",
                                    HintMaxLines = 1
                                },
                            }
                        }
                    },
                };
                

                var toast = new ToastNotification(content.GetXml());
                ToastNotificationManager.CreateToastNotifier().Show(toast);
                */
            }

            else
            {
                
                ContentDialog SClicks = new ContentDialog
                {
                Title = "Collect more  clicks!",
                Content = "Collect 50 clicks and try again.",
                CloseButtonText = "OK"
                };

                ContentDialogResult result = await SClicks.ShowAsync();
                
            }
        }

        private void ClickB(object sender, RoutedEventArgs e)
        {
            clicks = clicks + cn;
            txtBlock.Text = clicks.ToString();
        }
    }
}
