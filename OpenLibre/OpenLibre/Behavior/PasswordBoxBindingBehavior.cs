using System.Security;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Interactivity;
using System.Reflection;
using System;

namespace OpenLibre
{
    /// <summary>
    /// Behavior que cria um comportamento para fazer auxilia on Bind
    /// </summary>
   public class PasswordBoxBindingBehavior : Behavior<PasswordBox>
   {
        /// <summary>
        /// metodo que sobrescreve 
        /// </summary>
        protected override void OnAttached()
        {
            // quando o evento PasswordChange e Disparado ativo o metodo senhaemMudaca
            AssociatedObject.PasswordChanged += SenhaEmMudanca;
        }
        /// <summary>
        /// Toda vez que a senha muda essse metodo é ativado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SenhaEmMudanca(object sender, RoutedEventArgs e)
        {
            // vai fazer o blinding com uma property que nos criamos 
            var binding = BindingOperations.GetBindingExpression(this, senhaProperty);
            if (binding != null)
            {
                PropertyInfo property = binding.DataItem.GetType().GetProperty(binding.ParentBinding.Path.Path);
                if (property != null)
                    property.SetValue(binding.DataItem, AssociatedObject.SecurePassword, null);
            }
              
       }
        /// <summary>
        /// Get e set Da DependencyProperty
        /// </summary>
        public SecureString senha
        {
            get { return (SecureString)GetValue(senhaProperty); }
            set { SetValue(senhaProperty, value); }
        }
        /// <summary>
        /// Declaração da Property 
        /// </summary>
        public static readonly DependencyProperty senhaProperty =
            DependencyProperty.Register("senha", typeof(SecureString), typeof(PasswordBoxBindingBehavior), new PropertyMetadata(null));


    }
}
