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
using System.Collections.ObjectModel;
using Hackernator.Models;
using System.Collections.Generic;

namespace Hackernator.Util
{
    public static class CollectionHelper
    {
        public static ObservableCollection<Link> ToObservableCollection(this IEnumerable<Link> source)
        {
            var result = new ObservableCollection<Link>();
            foreach (var x in source)
                result.Add(x);

            return result;
        }
    }
}
