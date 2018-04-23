using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using DevExpress.Xpf.Grid;

namespace SilverlightApplication27 {
    public partial class MainPage : UserControl {
        ObservableCollection<TestData> list = new ObservableCollection<TestData>();

        public MainPage() {
            InitializeComponent();
            list.Add(new TestData() { Name = "name1", Salary = 1 });
            list.Add(new TestData() { Name = "name2", Salary = 2 });
            list.Add(new TestData() { Name = "name3", Salary = 3 });
            gridControl1.ItemsSource = list;
        }

        void view_RowDoubleClick(object sender, RowDoubleClickEventArgs e) {
            ChildWindow1 ch = new ChildWindow1(gridControl1.GetRow(e.HitInfo.RowHandle) as TestData);
            ch.Show();
        }
    }

    public class TestData : INotifyPropertyChanged{
        private string _Name;

        public string Name {
            get {
                return _Name;
            }
            set {
                _Name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));
            }
        }

        private int _Salary;

        public int Salary {
            get {
                return _Salary;
            }
            set {
                _Salary = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Salary"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e) {
            if (PropertyChanged != null) {
                PropertyChanged(this, e);
            }
        }
    }
}
