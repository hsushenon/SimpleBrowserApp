﻿// Copyright (c) Microsoft. All rights reserved.

using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SimpleBrowserApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Go_Web_Click(object sender, RoutedEventArgs e)
        {
            DoWebNavigate();
        }


        private void Web_Address_KeyUp(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                DoWebNavigate();
            }
        }

        private void DoWebNavigate()
        {
            DismissMessage();

            try
            {
                if (Web_Address.Text.Length > 0)
                {
                    webView.Navigate(new Uri(Web_Address.Text));
                }
                else
                {
                    DisplayMessage("You need to enter a web address.");
                }
            }
            catch (Exception e)
            {
                DisplayMessage("Error: " + e.Message);
            }
        }


        private void DisplayMessage(String message)
        {
            webView.Visibility = Visibility.Collapsed;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Frame.Navigate(typeof(HomePage));
            }
            catch (Exception)
            { }
        }

        private void OnMessageDismiss_Click(object sender, RoutedEventArgs e)
        {
            DismissMessage();
        }

        private void DismissMessage()
        {
            webView.Visibility = Visibility.Visible;
           // MessageStackPanel.Visibility = Visibility.Collapsed;
        }
    }
}
