using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Hackernator.Models;
using System.Text;
using System.Xml.Linq;
using Hackernator.HNAPI;
using Hackernator.Util;

namespace Hackernator
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            HackerNewsDownloader downloader = new HackerNewsDownloader();
            downloader.DownloadRawFrontPage(new Action<string>(n =>
                {
                    HackerNewsParser parser = new HackerNewsParser();
                    BindingCentral.Instance.NewLinks = parser.GetLinksFromRaw(n).ToObservableCollection();
                }));
        }

        private void FillSamples(int numberOfSamples)
        {
            for (int i = 0; i < numberOfSamples; i++)
            {
                Link link = new Link();
                link.Author = GetRandomString(5);
                link.Title = GetRandomString(20);
                link.Points = 20;
                link.Comments = 345;
                link.Domain = "dennisdel.com";
                BindingCentral.Instance.NewLinks.Add(link);
            }
        }

        private string GetRandomString(int p)
        {
            byte[] data = new byte[p];
            Random r = new Random();
            r.NextBytes(data);

            return Encoding.Unicode.GetString(data, 0, p);
        }
    }
}