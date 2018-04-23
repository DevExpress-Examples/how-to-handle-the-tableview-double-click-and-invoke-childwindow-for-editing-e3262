using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;
using System.ComponentModel;

namespace SilverlightApplication27 {
    public partial class MainPage : UserControl {
        public MainPage() {
            InitializeComponent();
            list = new ObservableCollection<TestData>();
            list.Add(new TestData() { Name = "name1", Salary = 1 });
            list.Add(new TestData() { Name = "name2", Salary = 2 });
            list.Add(new TestData() { Name = "name3", Salary = 3 });
            gridControl1.DataSource = list;
        }

 
        ObservableCollection<TestData> list;

        private void gridControl1_DoubleClick(object sender, MouseButtonEventArgs e) {
            GridControl gridControl = sender as GridControl;
            int rowHandle = gridControl1.View.GetRowHandleByMouseEventArgs(e);
            ChildWindow1 ch = new ChildWindow1(gridControl1.GetRow(rowHandle) as TestData);
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

    public delegate void DoubleClickHandler(object sender, MouseButtonEventArgs e);
    
    public class MyGridControl : GridControl {
        public event DoubleClickHandler DoubleClick;
        Point _clickPosition;
        public DateTime _lastClick = DateTime.Now;
        private bool _firstClickDone = false;

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e) {
            UIElement element = this as UIElement;
            DateTime clickTime = DateTime.Now;

            TimeSpan span = clickTime - _lastClick;


            if (span.TotalMilliseconds > 300 || _firstClickDone == false) {
                _clickPosition = e.GetPosition(element);
                _firstClickDone = true;
                _lastClick = DateTime.Now;
            } else {
                Point position = e.GetPosition(element);
                if (Math.Abs(_clickPosition.X - position.X) < 4 && Math.Abs(_clickPosition.Y - position.Y) < 4) //mouse didn't move => Valid double click
                    this.DoubleClick(this, e);
                //else
                //    DoubleClickTB.Text = "Double Click failed due to mouse move!";
                _firstClickDone = false;
            } 
            base.OnPreviewMouseLeftButtonDown(e);
        }
    }

    
}
