
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using PropertyChanged;


namespace OpenLibre
{
    [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};
        /// <summary>
        /// metodo para mudança 
        /// </summary>
        /// <param name="e"></param>
        public virtual void onpropertyChange(string e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(e));
        }
    }
}