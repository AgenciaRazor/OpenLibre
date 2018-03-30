using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenLibre.Paginas
{
    /// <summary>
    /// Interação lógica para CdUser.xam
    /// </summary>
    public partial class CdUser : Page
    {
        public CdUser()
        {
            InitializeComponent();
            this.DataContext = new ViewModelRg_Usuario();
        }
    }
}
