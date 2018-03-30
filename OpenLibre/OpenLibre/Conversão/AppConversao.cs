using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLibre 
{
    /// <summary>
    /// Classe para Conversão de Valores 
    /// </summary>
    public class AppConversao : BaseConversaoValores<AppConversao>
    {

        #region Metodos
        /// <summary>
        /// metodo que sobrescreve o nosso metodo abstrato da classe baseConversaoValores
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // converte o nosso pagina
            switch((PaginaDaApplicacao)value)
            {
                // caso nosso enumerador seja PaginaDaApplicação então convertermos para a View Especifica
                case PaginaDaApplicacao.Logim:
                    return  new Paginas.Logim();
                // retorna uma nova instacia da pagina 
                case PaginaDaApplicacao.Registro:
                    return new Paginas.Registro();
                //Retorna A parte de Dados
                case PaginaDaApplicacao.Pagina:
                    return new Paginas.PaginaPrincipal();
                //Retorna Os livros 
                case PaginaDaApplicacao.Livros:
                    return new Paginas.Livro();
                //
                case PaginaDaApplicacao.registroUser:
                    return new Paginas.CdUser();
                //
                case PaginaDaApplicacao.Aluguel:
                    return new Paginas.Aluguel();
                // caso nao aja nenhum entao saimos do brek e retornamos Null
                default:
                    Debugger.Break();
                    return null;

            }
        }
        /// <summary>
        /// Metodo para Converter de Volta
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
#endregion

    }
}
