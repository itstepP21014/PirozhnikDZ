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

namespace ExampleCommand
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Создание привязки  к команде Open в XAML
          
            CommandBinding binding = new CommandBinding(ApplicationCommands.New);
            // указываем обработки события по команде - New_Executed
            binding.Executed += CommandNewbinding_Executed;
            // Привязка в коллекцию команд окна
            this.CommandBindings.Add(binding);
        }

        void CommandNewbinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда 'New' была вызвана.");
        }

        private void CommandOpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда 'Open' была вызвана.");
        }

        private void Copy_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Cut_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Paste_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

       
    }
}
