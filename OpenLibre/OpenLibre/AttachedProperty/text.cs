using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace OpenLibre

{
     public class text
     {


        #if false
        /// <summary>
        /// dependency property para conter o texto
        /// </summary>
        public readonly DependencyProperty textproperty = 
            DependencyProperty.RegisterAttached("text", typeof(bool), typeof(text), new PropertyMetadata(null));

        public static void Settext()


        public static bool Gettext(UIElement e)
        {
           e.GetValue(textproperty,value)
        }

        #endif


    }
}
