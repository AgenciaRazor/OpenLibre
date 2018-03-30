
using System;
using System.Windows.Input;

namespace OpenLibre
{
    /// <summary>
    /// Classe para iniciar os comandos
    /// </summary>
    public class RelayCommand : ICommand
    {
        
        #region Membros Privados 
        /// <summary>
        /// Delegate que ira conter o comando a ser executado
        /// </summary>
        private readonly Action _execute;
        /// <summary>
        /// delegate que ira conter se o metodo contindo em _execute pode ser executado
        /// </summary>
        private readonly Func<bool> _canExecute;


        #endregion

        #region Construtor
        /// <summary>
        /// inicia uma instancia da classe RelayCommand que sempre poderar ser Executada
        /// </summary>
        /// <param name="Execute"></param>
        public RelayCommand(Action Execute) : this(Execute,null)
        {}  
        /// <summary>
        /// atribui as istancia privadas os valores 
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canexecute"></param>
        public RelayCommand(Action execute, Func<bool> canexecute)
        {
            if (execute == null)
                throw new ArgumentNullException("Execute");
            this._execute = execute;
            this._canExecute = canexecute;
        }
        #endregion

        #region Membros da Interface Iccomand
        /// <summary>
        /// implementação do CanExecute que ira definir se o comando vai ser executado
        /// </summary>
        /// <param name="Parametros"></param>
        /// <returns></returns>
        public bool CanExecute(object Parametros)
        {
            return _canExecute == null ? true : _canExecute();
        }
        /// <summary>
        /// Comando a ser executado
        /// </summary>
        /// <param name="Parametros"></param>
        public void Execute (object Parametros)
        {
            // executa o comando 
            _execute();
        }
        /// <summary>
        /// Evento Handler para mudanças 
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion


    }
}