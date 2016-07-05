using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Reflection;
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
using SpellChecker.Dal;
using SpellChecker.Wpf.Helpers;
using SpellChecker.Wpf.Helpers.UI;
//using System.Linq.Dynamic;
using SpellChecker.Lib;
using SpellChecker.Lib.Extensions;
using SpellChecker.Lib.Helpers;
using SpellChecker.Lib.Models;
using SpellChecker.Wpf.Models;
using DataFileHelper = SpellChecker.Wpf.Helpers.DataFileHelper;

namespace SpellChecker.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Version _assemblyVer = null;
        private DbContext _context;
        private IRepository _repository;
        private string _fileName = ""; // e.g. "a.bin", "h.bin", etc
        private string _checkedWord = "";

        #region property
        /// <summary>
        /// Get the path of the assembly the code is in
        /// http://stackoverflow.com/questions/52797/how-do-i-get-the-path-of-the-assembly-the-code-is-in
        /// </summary>
        public static string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;
                var uri = new UriBuilder(codeBase);
                var path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }

        public IQueryable<word> WordQuery
        {
            get
            {
               var query = _repository.GetQuery<word>();
               return query;
            }
        }

        public ObjectSet<word> WordObjectSet
        {
            get
            {
                ObjectContext objectContext = ((IObjectContextAdapter)_context).ObjectContext;
                ObjectSet<word> set = objectContext.CreateObjectSet<word>();
                return set;
            }
        }

        #endregion

        public MainWindow()
        {
            InitializeComponent();
            _context = new EnglishWordEntities();
            _repository = new GenericRepository(_context);
            _assemblyVer = Utilities.GetVersion();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // center window
            this.KevinCenterWindowOnScreen();
            // disable Upload and Browse button
            
            textBlockVersion.Text = $"{Utilities.GetUserName()} | {_assemblyVer.ToString(3)}";

            fillDataGridResults();
            fillComboBoxLevenshteinPrecisions();

            progressBarStatus.Visibility = Visibility.Hidden;
        }

       

        #region reload

        private void buttonReload_Click(object sender, RoutedEventArgs e)
        {
            progressBarStatus.Visibility = Visibility.Visible;
            var fileName = ((Button) sender).Tag.ToString();
            var letter = System.IO.Path.GetFileName(fileName).Replace(Constants.DataFileExtension, "")[0];
            var fullPathFile = System.IO.Path.Combine(AssemblyDirectory, $"{letter}{Constants.DataFileExtension}");
            var set = WordObjectSet;
            var query = WordQuery;
            writeFile(fullPathFile, letter, query, set);
            fillDataGridResults();
            progressBarStatus.Visibility = Visibility.Hidden;
        }

        #endregion

        #region reload all
        private void buttonReloadAll_click(object sender, RoutedEventArgs e)
        {
            progressBarStatus.Visibility = Visibility.Visible;

            BackgroundWorker bgwReloadAll = new BackgroundWorker();
            bgwReloadAll.DoWork += BgwReloadAll_DoWork;
            bgwReloadAll.RunWorkerCompleted += BgwReloadAll_RunWorkerCompleted;
            bgwReloadAll.RunWorkerAsync(); 
        }

        private void BgwReloadAll_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"BgwReloadAll_RunWorkerCompleted() error -->{e.Error}");
            }
            else
            {
                // OK when reaching here
                fillDataGridResults();
                progressBarStatus.Visibility = Visibility.Hidden;
                textBlockStatusText.Text = "Ready";
            }
        }

        private void BgwReloadAll_DoWork(object sender, DoWorkEventArgs e)
        {
            var set = WordObjectSet;
            var query = WordQuery;

            foreach (var letter in Constants.Alphabet)
            {
                var file = System.IO.Path.Combine(AssemblyDirectory, $"{letter}{Constants.DataFileExtension}");
                writeFile(file, letter, query, set);
            }
        }

        private void writeFile(string fullFileName, char letter, IQueryable<word> query, ObjectSet<word> set)
        {
            if (File.Exists(fullFileName))
            {
                File.Delete(fullFileName);
            }
            using (var fs = File.OpenWrite(fullFileName))
            {
                // https://msdn.microsoft.com/en-us/library/8bh11f1k.aspx
                using (var writer = new StreamWriter(fs))
                {
                    // http://stackoverflow.com/questions/23572277/dynamic-linq-to-add-like-to-where-clause
                    // main task for searching
                    query = set.Where($"it.word_id LIKE '{letter}%'");
                    try
                    {
                        query.Select(x => x.word_id).ToList().ForEach(w => writer.Write(w + Constants.WordEndDelimiter));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        #endregion

        #region fillDataGridResults
        private void fillDataGridResults()
        {
            var list = getListOfDataFileViewModel();

            dataGridResults.ItemsSource = list;
            dataGridResults.DataContext = list;

            fillDataGridDirectoryFiles(list);
        }

        #endregion

        #region fillComboBoxLevenshteinPrecisions

        private void fillComboBoxLevenshteinPrecisions()
        {
            var list = LevenshteinPrecisionDistancesExtensions.ToList();
            comboBoxLevenshteinPrecisions.ItemsSource = list;
            comboBoxLevenshteinPrecisions.DataContext = list;
            comboBoxLevenshteinPrecisions.DisplayMemberPath = "text"; // http://stackoverflow.com/questions/22166302/filling-combobox-with-observable-list-which-consumed-from-wcf-service

            comboBoxLevenshteinPrecisions.SelectedIndex = 1; // EightyPercent precision
        }

        #endregion

        private void fillDataGridDirectoryFiles(List<DataFileViewModel> inList=null)
        {
            if (inList != null)
            {
                dataGridDirectoryFiles.ItemsSource = inList;
                dataGridDirectoryFiles.DataContext = inList;
            }
            else
            {
                var list = getListOfDataFileViewModel();
                dataGridDirectoryFiles.ItemsSource = list;
                dataGridDirectoryFiles.DataContext = list;
            }
        }

        private List<DataFileViewModel> getListOfDataFileViewModel()
        {
            var assDir = AssemblyDirectory;
            return DataFileHelper.GetListOfBinaryFileViewModel(assDir);
        }

        #region search

        private void buttonBrowse_click(object sender, RoutedEventArgs e)
        {
           
            progressBarStatus.Visibility = Visibility.Visible;
            _checkedWord = textBoxSearchedWord.Text;
            _fileName = System.IO.Path.Combine(AssemblyDirectory, $"{_checkedWord.First()}{Constants.DataFileExtension}");


            BackgroundWorker bgwSearch = new BackgroundWorker();
            bgwSearch.DoWork += BgwSearch_DoWork;
            bgwSearch.RunWorkerCompleted += BgwSearch_RunWorkerCompleted;
            bgwSearch.RunWorkerAsync();
            
        }

        private void BgwSearch_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show($"BgwSearch_RunWorkerCompleted() error -->{e.Error}");
            }
            else
            {
                // OK when reaching here
                var found = (bool) e.Result;
                textBlockSearchResult.Text = found ? "Found" : "Not Found";
                if (!found)
                {
                    getSuggestedWords(_fileName);
                }
                else
                {
                    comboBoxSuggestedWords.ItemsSource = null;
                    progressBarStatus.Visibility = Visibility.Hidden;
                }  
            }
        }

        private void BgwSearch_DoWork(object sender, DoWorkEventArgs e)
        {
            var found = SpellCheckerMgr.SearchWord(_checkedWord);
            e.Result = found;
        }

        private void getSuggestedWords(string inputFilename)
        {
            getNearestWords();
        }


        #endregion

        private void comboBoxLevenshteinPrecisions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            getNearestWords();
        }

        private void getNearestWords()
        {
            if (string.IsNullOrWhiteSpace(_checkedWord))
            {
                return;
            }

            int acceptedDistance = Convert.ToInt16(((TextValue)comboBoxLevenshteinPrecisions.SelectedValue).value);

            //comboBoxSuggestedWords.Items.Clear(); // http://stackoverflow.com/questions/805876/wpf-combobox-clear
            comboBoxSuggestedWords.ItemsSource = null;
            var list = SpellCheckerMgr.GetSuggestedWords(_checkedWord, acceptedDistance);
            comboBoxSuggestedWords.ItemsSource = list;
            comboBoxSuggestedWords.DataContext = list;

            comboBoxSuggestedWords.SelectedIndex = 0;

            progressBarStatus.Visibility = Visibility.Hidden;
        }
    }
}

