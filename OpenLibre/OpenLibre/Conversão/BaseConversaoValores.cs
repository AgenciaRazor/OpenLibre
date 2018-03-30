using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace OpenLibre
{
    /// <summary>
    /// classe abstrata que serve de herança para todas conversão 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseConversaoValores<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        /// <summary>
        /// o que vai ser convertido
        /// </summary>
        private static T Conversor = null;

        /// <summary>
        /// ve se foi convertido
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // Case nao tenha sido passado nenhum objeto para nosso T, Atribuios um novo para ele
            return Conversor??(Conversor = new T());
        }
        /// <summary>
        ///Metodo para converter um valor em outro(um XAML para Enum) 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        /// <summary>
        /// Metodo que faz o inverso 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
