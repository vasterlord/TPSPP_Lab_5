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

namespace TPSPP_Lab_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<NoteBook> noteBook;
        NoteBook tempNoteBook;
        public MainWindow()
        {
            noteBook = new List<NoteBook>();
            tempNoteBook = new NoteBook(0);
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            noteBook.Add(new NoteBook(noteBook.Count + 1));
            InitializeComponent();
            SetSorce(noteBook);
            comboBox.Items.Add("First name");
            comboBox.Items.Add("Last name");
            comboBox.Items.Add("Date born");
            comboBox.Items.Add("Number phone");
            comboBox.SelectedIndex = 0;
        }

        private void SetSorce(List<NoteBook> someNoteBook)
        {
            dataGrid.ItemsSource = someNoteBook;
            dataGrid.Items.Refresh();
            dataGrid.SelectedIndex = 0;
        }

        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                tempNoteBook = (NoteBook)dataGrid.SelectedItem;
                textBoxFirstName.Text = tempNoteBook.FirstName;
                textBoxLastName.Text = tempNoteBook.LastName;
                pickerDate.Text = tempNoteBook.DateBorn.ToString();
                textBoxNumber.Text = tempNoteBook.NumberPhone;
                textBoxEmail.Text = tempNoteBook.Email;
            }
            catch (Exception) { }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pickerDate.DisplayDate > DateTime.Now)
                {
                    throw new Exception("Incorrect enterd date born");
                }
                noteBook.Add(new NoteBook(textBoxFirstName.Text, textBoxLastName.Text, pickerDate.DisplayDate, textBoxNumber.Text, textBoxEmail.Text));
                SetSorce(noteBook);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonAdd_Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (pickerDate.DisplayDate > DateTime.Now)
                {
                    throw new Exception("Incorrect enterd date born");
                }
                int noteIndex = noteBook.IndexOf(tempNoteBook);
                noteBook[noteIndex].FirstName = textBoxFirstName.Text;
                noteBook[noteIndex].LastName = textBoxLastName.Text;
                noteBook[noteIndex].DateBorn = pickerDate.DisplayDate;
                noteBook[noteIndex].NumberPhone = textBoxNumber.Text;
                noteBook[noteIndex].Email = textBoxEmail.Text;
                SetSorce(noteBook);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", ex.Message, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            noteBook.Remove(tempNoteBook);
            SetSorce(noteBook);
        }

        private void buttonShowAll_Click(object sender, RoutedEventArgs e)
        {
            SetSorce(noteBook);
        }

        private void buttonSort_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<NoteBook> sortedNotes;
                switch (comboBox.Text)
                {
                    case "First name":
                        sortedNotes = noteBook.OrderBy(note=>note.FirstName).ToList();
                        SetSorce(sortedNotes);
                        break;
                    case "Last name":
                        sortedNotes = noteBook.OrderBy(note => note.LastName).ToList();
                        SetSorce(sortedNotes);
                        break;
                    case "Date born":
                        sortedNotes = noteBook.OrderBy(note => note.DateBorn).ToList();
                        SetSorce(sortedNotes);
                        break;
                    case "Number phone":
                        sortedNotes = noteBook.OrderBy(note => note.NumberPhone).ToList();
                        SetSorce(sortedNotes);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }

        private void textBoxFinding_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            { 
                List<NoteBook> findedNotes = new List<NoteBook>(); ;
                SetSorce(findedNotes);
                switch (comboBox.Text)
                {
                    case "First name":
                        findedNotes = noteBook.Where(note => note.FirstName.Contains(textBoxFinding.Text)).ToList();
                        SetSorce(findedNotes);
                        break;
                    case "Last name":
                        findedNotes = noteBook.Where(note => note.LastName.Contains(textBoxFinding.Text)).ToList();
                        SetSorce(findedNotes);
                        break;
                    case "Date born":
                        findedNotes = noteBook.Where(note => note.DateBorn == Convert.ToDateTime(textBoxFinding.Text)).ToList();
                        SetSorce(findedNotes);
                        break;
                    case "Number phone":
                        findedNotes = noteBook.Where(note => note.NumberPhone.Contains(textBoxFinding.Text)).ToList();
                        SetSorce(findedNotes);
                        break;
                    default:
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
