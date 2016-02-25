using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace AnimaTools.UI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Implementation of interactive tabs from http://www.codeproject.com/Articles/493538/Add-Remove-Tabs-Dynamically-in-WPF
    /// </summary>
    public partial class MainWindow : Window {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        private object _addTabHeader;

        public MainWindow() {
            InitializeComponent();
            try {
                // initialize tabItem array
                _tabItems = new List<TabItem>();

                // add a tabItem with + in header 
                TabItem tabAdd = new TabItem();
                tabAdd.Header = "+";
                _tabAdd = tabAdd;
                _tabItems.Add(tabAdd);

                // add first tab
                this.AddTabItem();

                // bind tab control
                tabControl.DataContext = _tabItems;

                tabControl.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private TabItem AddTabItem() {
            int count = _tabItems.Count;

            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = string.Format("Tab {0}", count);
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = tabControl.FindResource("TabHeader") as DataTemplate;

            // add controls to tab item, this case I added just a textbox
            TextBox txt = new TextBox();
            txt.Name = "txt";
            tab.Content = txt;

            // insert tab item right before the last (+) tab item
            _tabItems.Insert(count - 1, tab);
            return tab;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            TabItem tab = tabControl.SelectedItem as TabItem;

            if (tab != null && tab.Header != null) {
                if (tab.Header.Equals(_tabAdd.Header)) {
                    // clear tab control binding
                    tabControl.DataContext = null;

                    // add new tab
                    TabItem newTab = this.AddTabItem();

                    // bind tab control
                    tabControl.DataContext = _tabItems;

                    // select newly added tab item
                    tabControl.SelectedItem = newTab;
                }
                else {
                    // your code here...
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabControl.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;
            if (tab != null) {
                if (_tabItems.Count < 3) {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes) {
                    // get selected tab
                    TabItem selectedTab = tabControl.SelectedItem as TabItem;

                    // clear tab control binding
                    tabControl.DataContext = null;

                    _tabItems.Remove(tab);

                    // bind tab control
                    tabControl.DataContext = _tabItems;

                    // select previously selected tab. if that is removed then select first tab
                    if (selectedTab == null || selectedTab.Equals(tab)) {
                        selectedTab = _tabItems[0];
                    }
                    tabControl.SelectedItem = selectedTab;
                }
            }
        }
    }
}
