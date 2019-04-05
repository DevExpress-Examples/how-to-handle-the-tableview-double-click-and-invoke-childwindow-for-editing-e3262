<!-- default file list -->
*Files to look at*:

* [ChildWindow1.xaml](./CS/SilverlightApplication27/ChildWindow1.xaml) (VB: [ChildWindow1.xaml](./VB/SilverlightApplication27/ChildWindow1.xaml))
* [ChildWindow1.xaml.cs](./CS/SilverlightApplication27/ChildWindow1.xaml.cs) (VB: [ChildWindow1.xaml.vb](./VB/SilverlightApplication27/ChildWindow1.xaml.vb))
* [MainPage.xaml](./CS/SilverlightApplication27/MainPage.xaml) (VB: [MainPage.xaml](./VB/SilverlightApplication27/MainPage.xaml))
* [MainPage.xaml.cs](./CS/SilverlightApplication27/MainPage.xaml.cs) (VB: [MainPage.xaml.vb](./VB/SilverlightApplication27/MainPage.xaml.vb))
<!-- default file list end -->
# How to handle the TableView double click and invoke ChildWindow for editing


<p>To show a window for editing, handle the TableView.RowDoubleClick event and pass the current clicked row to the ChildWindow constructor. You can get an object by using the RowDoubleClickEventArgs.HitInfo.RowHandle property and the GridControl.GetRow method.</p><br />


<br/>


