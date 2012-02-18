using System;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Hackernator.Models;

namespace Hackernator
{
    public class BindingCentral : INotifyPropertyChanged
    {

        static BindingCentral instance = null;
        static readonly object padlock = new object();

        public BindingCentral()
        {
            if (NewLinks == null)
                NewLinks = new ObservableCollection<Link>();
        }

        public static BindingCentral Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BindingCentral();
                    }
                    return instance;
                }
            }
        }

        private ObservableCollection<Link> _newLinks;
        public ObservableCollection<Link> NewLinks
        {
            get
            {
                return _newLinks;
            }
            set
            {
                if (_newLinks != value)
                {
                    _newLinks = value;
                    NotifyPropertyChanged("NewLinks");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
               System.Windows.Deployment.Current.Dispatcher.BeginInvoke(
                   () => 
                   { 
                       PropertyChanged(this, new PropertyChangedEventArgs(info)); 
                   });
            }
        }
    }
}
