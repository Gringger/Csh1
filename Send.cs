using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Lab01.Annotations;

namespace Lab01
{
    class Send : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        private Command _sendDate;
        private Action<bool> _showLoaderAction;
        private readonly Action _closeAction;

        public Send(Action close, Action<bool> showLoader)
        {
            _closeAction = close;
            _showLoaderAction = showLoader;
        }

        public User User
        {
            get { return CurrentUser.CurrUser; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {

                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public Command SendDate
        {
            get
            {
                return _sendDate ?? (_sendDate = new Command(SendDateImpl));
            }
        }

        private async void SendDateImpl(object o)
        {
            User newUser = null;

            _showLoaderAction.Invoke(true);
            await Task.Run((() =>
            {
                newUser = new User(_dateOfBirth);
                Thread.Sleep(2000);
            }));

            if (newUser.Age < 0 || newUser.Age > 135)
                MessageBox.Show("Age must be from 0 to 135");

            else
            {
                CurrentUser.CurrUser = newUser;
                OnPropertyChanged("User");
                if (IsBirthday(CurrentUser.CurrUser.DateOfBirth))
                    MessageBox.Show("Happy birhday!!");
            }
            _showLoaderAction.Invoke(false);
        }

        private bool IsBirthday(DateTime birthday_date)
        {
            if (DateTime.Today.Month.Equals(birthday_date.Month) && DateTime.Today.Day.Equals(birthday_date.Day))
                return true;
            return false;
        }

        #region Implementation
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
