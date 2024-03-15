using System.Collections;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab4Chernyshenko44
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Note<int>[] Notes { get; set; }
        private bool isBirthSort = true;
        private bool isPhoneSort = true;

        public MainWindow()
        {
            InitializeComponent();
            mmCopy.IsEnabled = false;
            mmCreate.IsEnabled = false;
            tbCreate.IsEnabled = false;
            tbCopy.IsEnabled = false;
            Notes = new Note<int>[0];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbCount.Text))
            {
                Notes = new Note<int>[int.Parse(tbCount.Text)];
                MessageBox.Show("Массив размером " + Notes.Length + " элемента создан");
                Note<int>.Count = 0;
                mmCopy.IsEnabled = true;
                mmCreate.IsEnabled = true;
                tbCreate.IsEnabled = true;
                tbCopy.IsEnabled = true;
                NoteList.ItemsSource = null;
                stCount.Content = "Создано " + Note<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Введите размер массива");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void mmCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            if (headerClicked.Content.ToString() == "Номер")
            {
                if (isPhoneSort)
                {
                    Array.Sort(Notes);
                }
                else
                {
                    Notes = Notes.OrderByDescending(p => p.Phone).ToArray();
                }
                isPhoneSort = !isPhoneSort;
            }
            else if (headerClicked.Content.ToString() == "Дата рождения")
            {
                if (isBirthSort)
                {
                    Array.Sort(Notes!, new BirthComparator());
                }
                else
                {
                    Notes = Notes!.OrderByDescending(p => p.Birth).ToArray();
                }
                isBirthSort = !isBirthSort;
            }
            NoteList.ItemsSource = null;
            NoteList.ItemsSource = Notes;
        }

        private void tbCopy_Click(object sender, RoutedEventArgs e)
        {
            Copy();
        }

        private void tbCreate_Click(object sender, RoutedEventArgs e)
        {
            Add();
        }

        private void Copy()
        {
            if (NoteList.SelectedItems.Count != 0)
            {
                Note<int> note = NoteList.SelectedItem as Note<int>;
                Notes[Note<int>.Count] = (Note<int>)note.Clone();
                NoteList.ItemsSource = null;
                NoteList.ItemsSource = Notes;
                Note<int>.Count++;
                stCount.Content = "Создано " + Note<int>.Count + " из " + tbCount.Text;
            }
        }

        private void Add()
        {
            if (Notes.Length > Note<int>.Count)
            {
                NoteAdd add = new NoteAdd();
                if (add.ShowDialog() == true)
                {
                    Notes[Note<int>.Count] = new Note<int>();
                    Notes[Note<int>.Count].FName = add.FName;
                    Notes[Note<int>.Count].LName = add.LName;
                    Notes[Note<int>.Count].Phone = add.tbPhone;
                    Notes[Note<int>.Count].Birth = add.Birth;
                    Note<int>.Count++;
                }
                NoteList.ItemsSource = null;
                NoteList.ItemsSource = Notes;
                stCount.Content = "Создано " + Note<int>.Count + " из " + tbCount.Text;
            }
            else
            {
                MessageBox.Show("Массив полностью заполнен");
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }

    internal class BirthComparator : IComparer
    {
        public int Compare(object? x, object? y)
        {
            throw new NotImplementedException();
        }
    }
}
