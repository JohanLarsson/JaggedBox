﻿namespace JaggedBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private bool knowsWPF;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (value == firstName) return;
                firstName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (value == lastName) return;
                lastName = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get { return string.Format("{0} {1}", firstName, lastName); }
        }

        public bool KnowsWPF
        {
            get { return knowsWPF; }
            set
            {
                if (value == knowsWPF) return;
                knowsWPF = value;
                OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
