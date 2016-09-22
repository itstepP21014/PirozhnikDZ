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

namespace kursovoi_proekt_net_framework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<MyFile> fileCollection = new ObservableCollection<MyFile>();

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
        }

        string pathToFolder;

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            //lstw.ItemsSource = fileCollection;

            pathToFolder = @"C:\Users\admin\Desktop\PirozhnikDZ\WCF";

            if (!string.IsNullOrEmpty(pathToFolder))
            {
                pb.IsIndeterminate = true;
                var filesColl = fun(pathToFolder);
                foreach(var file in filesColl)
                {
                    fileCollection.Add(new MyFile(){FilePath = file, MD5sum = ComputeMD5Checksum(file), Clone = false});
                }

                //сортировка
                IList<MyFile> sortedFileColl = fileCollection.OrderBy(x => x.MD5sum).ToList();
                lstw.ItemsSource = sortedFileColl;
                for (var i = 0; i < sortedFileColl.Count - 1; ++i)
                {
                    if(sortedFileColl[i].MD5sum == sortedFileColl[i+1].MD5sum)
                    {
                        sortedFileColl[i + 1].Clone = true;
                    }
                }

                //for (var i = 0; i < fileCollection.Count; ++i)
                //{
                //    for (var j = i + 1; j < fileCollection.Count - 1; j++)
                //    {
                //        if (fileCollection[i].MD5sum == fileCollection[j].MD5sum)
                //        {
                //            if (compareFilesByByte(fileCollection[i].FilePath, fileCollection[j].FilePath))
                //            {
                //                //lb_info.Items.Add("Одинаковые файлы:______________________________________________");
                //                //lb_info.Items.Add(fileCollection[i].Path);
                //                //lb_info.Items.Add(fileCollection[j].Path);
                //            }
                //        }
                //    }
                //}
                pb.IsIndeterminate = false;
                //lb_info.Items.Add("Поиск окончен.");

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
            catch (IOException ex)
            {
                //lb_info.Items.Add(String.Format("Failed to compare {0} and {1}: {2}", file_1, file_2, ex.Message));
                return false;
            }
            finally
            {
                fs1.Close();
                fs2.Close();
            }
            return ((file1byte - file2byte) == 0);
 
        }


    }
}




