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

namespace kursovoi_proekt_net_framework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MyFile> fileCollection = new List<MyFile>();

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
        }

        private void btn_start_Click(object sender, RoutedEventArgs e)
        {
            if (tb_path.Text != "")
            {
                lb_info.Items.Clear();
                var filesCollection = fun(tb_path.Text);
                foreach(var file in filesCollection)
                {
                    //lb_info.Items.Add(file);
                    fileCollection.Add(new MyFile(){Path = file, MD5sum = ComputeMD5Checksum(file)});
                }

                for(var i = 0; i < fileCollection.Count; ++i)
                {
                    for (var j = i + 1; j < fileCollection.Count - 1; j++)
                    {
                        if (fileCollection[i].MD5sum == fileCollection[j].MD5sum)
                        {
                            if (compareFilesByByte(fileCollection[i].Path, fileCollection[j].Path))
                            {
                                lb_info.Items.Add("Одинаковые файлы:");
                                lb_info.Items.Add(fileCollection[i].Path);
                                lb_info.Items.Add(fileCollection[j].Path);
                            }
                        }
                    }                             
                }
            } 
        }


        static List<string> fun(string _path)
        {
            // получаю все файлы
            var collection = new List<string>();
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
            byte[] byte1 = new byte[1024];
            byte[] byte2 = new byte[1024];

            var fs1 = new FileStream(file_1, FileMode.Open);
            var fs2 = new FileStream(file_2, FileMode.Open);

            if (fs1.Length != fs2.Length)
            {
                fs1.Close();
                fs2.Close();
                return false;
            }
            else
            {
                int res1, res2;
                do
                {
                    res1 = fs1.Read(byte1, 0, byte1.Length);
                    res2 = fs2.Read(byte2, 0, byte2.Length);

                    //for (int i = 0; i < byte1.Length; i++)
                    //{
                    //    if (byte1[i] != byte2[i])
                    //    {
                    //        return false;
                    //    }
                    //}

                } while (res1 != 0 && res2 != 0);

                return true;
            }
 
        }


    }
}




