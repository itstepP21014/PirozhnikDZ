using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExampleCommandCustom.Custom
{
   // 
   public class CustomCommands
    {
        // Объявляем команды! Все команды типа RoutedUICommand
        private static RoutedUICommand createReport;
        private static RoutedUICommand updateData;

        public static RoutedUICommand CreateReport
        {
            get { return createReport; }
        }

        public static RoutedUICommand UpdateData
        {
            get { return updateData; }
        }

        static CustomCommands()
        {
            createReport = new RoutedUICommand("Создать отчет", "CreateReport", typeof(CustomCommands));
            // 1 параметр: Текст, который будет отображаться, если команда будет присвоена пункту меню.
            // 2 параметр: Имя команды.
            // 3 параметр: Класс объявляющий команду.

            // Создание горячих клавиш
            InputGestureCollection inUpdateData = new InputGestureCollection();
            inUpdateData.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl+R"));
            updateData = new RoutedUICommand("Обновить данные", "UpdateData", typeof(CustomCommands), inUpdateData);
            // 4 параметр: Горячие клавиши.
        }
        
    }

}
