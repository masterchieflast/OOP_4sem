using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Lab04_05
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> items;
        private readonly List<ObservableCollection<Product>> _mementos = new();
        private int cursor = 0;
        public MainWindow()
        {
            var projectDir = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.Parent?.FullName;
            items = new ObservableCollection<Product>();
            var cursorPath = Path.Combine(projectDir, "Resources/Cursor/Cursor.cur");

            var iconPath = Path.Combine(projectDir, "Resources/Icon/app.ico");

            Icon = new BitmapImage(new Uri(iconPath));
            Cursor = new Cursor(cursorPath);
            InitializeComponent();
        }

        private void CostSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ShopCostTextBlock.Text = (string)FindResource("Cost") + " " + (int)ShopCostSlider.Value;
        }

        private void RedactorCostSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RedactorCostTextBlock.Text = (string)FindResource("Cost") + " " + (int)RedactorCostSlider.Value;
        }

        private void LanguageButton_Click(object sender, RoutedEventArgs e)
        {
            var buttonName = (sender as Button).Name;
            var sourceUri = buttonName switch
            {
                "EnglishButton" => new Uri("Resources/Languages/English.xaml", UriKind.Relative),
                "RussianButton" => new Uri("Resources/Languages/Russian.xaml", UriKind.Relative),
                _ => new Uri("Resources/Languages/English.xaml", UriKind.Relative),
            };

            if (Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Source == sourceUri) != null)
            {
                return;
            }

            var newLanguageResource = new ResourceDictionary() { Source = sourceUri };
            var englishLanguageResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Source == new Uri("Resources/Languages/English.xaml", UriKind.Relative));
            var russianLanguageResource = Application.Current.Resources.MergedDictionaries.FirstOrDefault(x => x.Source == new Uri("Resources/Languages/Russian.xaml", UriKind.Relative));

            if (englishLanguageResource != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(englishLanguageResource);
            }
            else if (russianLanguageResource != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(russianLanguageResource);
            }

            Application.Current.Resources.MergedDictionaries.Add(newLanguageResource);
        }

        private void OpenExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                //set img url to img
                ProductImage.Source = new BitmapImage(new System.Uri(openFileDialog.FileName));
            }
        }

        private void UndoButton_Click(object? sender, ExecutedRoutedEventArgs e)
        {
            if (cursor == 0) return;

            cursor--;
            items = new ObservableCollection<Product>(_mementos[cursor]);
            ProductsDataGrid.ItemsSource = items;
        }

        private void RedoButton_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (cursor == _mementos.Count - 1) return;

            cursor++;
            items = new ObservableCollection<Product>(_mementos[cursor]);
            ProductsDataGrid.ItemsSource = items;
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            using var reader = new StreamReader(@"../../../Files/Products.json");
            var json = reader.ReadToEnd();

            var serializedItems = JsonConvert.DeserializeObject<List<Product>>(json);
            foreach (var serializedItem in serializedItems!)
            {
                items.Add(serializedItem);
            }

            _mementos.Add(new ObservableCollection<Product>(items));
            cursor++;
            UndoButton_Click(null, null!);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var items = ProductsDataGrid.ItemsSource;
            using (var sw = new StreamWriter(@"../../../Files/Products.json"))
            {
                var jsonString = JsonConvert.SerializeObject(items);
                sw.Write(jsonString);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ProductsDataGrid.SelectedItem;
            if (selectedItem != null)
            {
                items.Remove(selectedItem as Product);
            }
            _mementos.Add(new ObservableCollection<Product>(items));
            cursor++;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ProductsDataGrid.SelectedItem;
            if (selectedItem == null) return;
            var itemNumberInCollection = items.IndexOf(selectedItem as Product);
            if (itemNumberInCollection == -1) return;

            var type = TypeComboBox.SelectedIndex switch
            {
                0 => ProductType.Ready,
                1 => ProductType.OnRequest,
                _ => ProductType.OnRequest
            };

            var fotoUrl = ProductImage.Source != null ? ProductImage.Source.ToString() : "";

            var ChangedProduct = new Product(NameTextBox.Text, type, fotoUrl, RedactorDescriptionTextBox.Text, (int)RedactorCostSlider.Value);

            items.RemoveAt(itemNumberInCollection);
            items.Insert(itemNumberInCollection, ChangedProduct);

            _mementos.Add(new ObservableCollection<Product>(items));
            cursor++;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var type = TypeComboBox.SelectedIndex switch
            {
                0 => ProductType.Ready,
                1 => ProductType.OnRequest,
                _ => ProductType.Ready
            };

            var photoUrl = ProductImage.Source != null ? ProductImage.Source.ToString() : "";

            var newProduct = new Product(NameTextBox.Text, type, photoUrl, RedactorDescriptionTextBox.Text, (int)RedactorCostSlider.Value);

            items.Add(newProduct);

            _mementos.Add(new ObservableCollection<Product>(items));
            cursor++;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var searchingCost = (int)ShopCostSlider.Value;

            ProductType productType;
            if (ReadyRadioButton.IsChecked == true) productType = ProductType.Ready;
            else productType = ProductType.OnRequest;

            var description = ShopDescriptionTextBox.Text;

            var filteredItems = items.Where(x => (x.Cost <= searchingCost && x.ProductType == productType) && x.Name.Contains(ShopDescriptionTextBox.Text));

            ShopDataGrid.ItemsSource = filteredItems;

        }
    }
}
