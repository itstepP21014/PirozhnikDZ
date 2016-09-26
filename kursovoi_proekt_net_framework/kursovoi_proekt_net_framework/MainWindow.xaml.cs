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
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Threading;

namespace kursovoi_proekt_net_framework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyFile> fileCollection = new ObservableCollection<MyFile>();
        string pathToFolder = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_choose_folder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            DialogResult result = dlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                tb_path.Text = dlg.SelectedPath;
            }
            pathToFolder = tb_path.Text;
            if (!string.IsNullOrEmpty(pathToFolder))
            {
                btn_start.IsEnabled = true;
            }
        }

        private void clearAll()
        {
            lstw.Items.Clear();
            fileCollection.Clear();
            lb_delete.Content = null;
            lb_fin.Content = null;
        }
        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            clearAll();

            if (!string.IsNullOrEmpty(pathToFolder))
            {
                //pb.IsIndeterminate = true;
                btn_start.IsEnabled = false;

                List<string> filesColl = new List<string>();
                try
                {
                    // сбор всех файлов в заданном месте
                    filesColl = fun(pathToFolder);
                    foreach (var file in filesColl)
                    {
                        fileCollection.Add(new MyFile()
                        {
                            FilePath = file,
                            Name = System.IO.Path.GetFileName(file),
                            MD5sum = ComputeMD5Checksum(file),
                            Clone = false
                        });
                    }

                    //сортировка
                    IList<MyFile> sortedFileColl = fileCollection.OrderBy(x => x.MD5sum).ToList();

                    // поиск повторов
                    for (var i = 0; i < sortedFileColl.Count - 1; ++i)
                    {
                        if (sortedFileColl[i].MD5sum == sortedFileColl[i + 1].MD5sum &&
                            compareFilesByByte(sortedFileColl[i].FilePath, sortedFileColl[i + 1].FilePath) &&
                            sortedFileColl[i].Name == sortedFileColl[i + 1].Name)
                        {
                            sortedFileColl[i + 1].Clone = true;
                        }

                        lstw.Items.Add(sortedFileColl[i]);
                    }
                    //pb.IsIndeterminate = false;
                    btn_start.IsEnabled = false;
                    lb_total.Content = "Просмотренно файлов: " + lstw.Items.Count;

                    List<MyFile> filesToDelete = new List<MyFile>();
                    foreach (var item in lstw.Items)
                    {
                        var i = item as MyFile;
                        if (i.Clone == true)
                        {
                            filesToDelete.Add(i);
                        }
                    }
                    if (filesToDelete.Count == 0)
                    {
                        System.Windows.Forms.MessageBox.Show(
                        "Одинаковых файлов не обнаружено.",
                        "Инфо",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(
                        String.Format("Обнаружено дубликатов: {0}.", filesToDelete.Count,
                        "Инфо",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk));
                    }
                }
                catch (System.IO.DirectoryNotFoundException ex)
                {
                    System.Windows.Forms.MessageBox.Show(
                    String.Format("Указан не верный путь {0}.", pathToFolder,
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error));
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(
                    String.Format("Ошибка {0}", ex,
                    "Ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error));
                }
            } 
        }


        static List<string> fun(string _path)
        {
            // получаю все файлы
            var collection = new List<string>();
            try
            {
                foreach (var item in Directory.GetFileSystemEntries(_path))
                {
                    if (System.IO.File.Exists(item))
                    {
                        collection.Add(item);
                    }
                    else if (System.IO.Directory.Exists(item))
                    {
                        foreach (var el in fun(item))
                        {
                            collection.Add(el);
                        }
                    }
                }
            }
            catch(UnauthorizedAccessException)
            {
                //ignore
            }

            return collection;
        }

        private string ComputeMD5Checksum(string path)
        {
            using (FileStream fs = System.IO.File.OpenRead(path))
            {
                var md5 = new MD5CryptoServiceProvider();
                var fileData = new byte[fs.Length];
                fs.Read(fileData, 0, (int)fs.Length);
                var checkSum = md5.ComputeHash(fileData);
                string result = BitConverter.ToString(checkSum).Replace("-", String.Empty);
                return result;
            }
        }

        private bool compareFilesByByte(string file_1, string file_2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1 = null, fs2 = null;
            try
            {
                fs1 = new FileStream(file_1, FileMode.Open);
                fs2 = new FileStream(file_2, FileMode.Open);

                do
                {
                    file1byte = fs1.ReadByte();
                    file2byte = fs2.ReadByte();
                }
                while ((file1byte == file2byte) && (file1byte != -1));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(
                    String.Format(ex.Message), 
                    "Инфо", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Asterisk);
                return false;
            }
            finally
            {
                if(fs1 != null)
                    fs1.Close();
                if (fs2 != null)
                    fs2.Close();
            }
            return ((file1byte - file2byte) == 0);
 
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            List<MyFile> filesToDelete = new List<MyFile>();
            
            MyFile i = null;
            int count = 0;
            List<int> h = new List<int>();
            int g = 0;
            foreach (var item in lstw.Items)
            {
                i = item as MyFile;
                if (i.Clone == true)
                {
                    filesToDelete.Add(i);

                    DialogResult result = System.Windows.Forms.MessageBox.Show(
                        "Вы уверены, что хотите удалить файл " + i.Name +
                        " из " + i.FilePath + "?",
                        "ВНИМАНИЕ!!!",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == System.Windows.Forms.DialogResult.Yes) //Если нажал Да
                    {
                        File.Delete(i.FilePath);
                        System.Windows.Forms.MessageBox.Show(
                            "Файл " + i.Name + " успешно удален.",
                            "Готово",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);

                        h.Add(g);
                        ++count;
                    }
                }
                ++g;
            }
            foreach(var z in h)
            {
                //lstw.Items.Remove(z);
                fileCollection.RemoveAt(z);
            }
            lstw.Items.Clear();
            lstw.ItemsSource = fileCollection;
            lstw.Items.Refresh();
            
            if (filesToDelete.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show(
                    "Нет файлов для удаления.",
                    "Инфо",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Asterisk);
            }
            else
            {
                lb_delete.Content = "Из них удалено файлов: " + count;
                lb_fin.Content = "Осталось файлов: " + lstw.Items.Count;
            }
        }

        private void tb_path_TextChanged(object sender, TextChangedEventArgs e)
        {
            pathToFolder = tb_path.Text;
            btn_start.IsEnabled = true;
        }
    }
}




