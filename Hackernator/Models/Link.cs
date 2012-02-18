using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Hackernator.Models
{
    public class Link
    {
        public string Title { get; set; }
        public string ID { get; set; }
        public string Domain { get; set; }
        public string Url { get; set; }
        public int Points { get; set; }
        public string Author { get; set; }
        public int Comments { get; set; }
    }
}
