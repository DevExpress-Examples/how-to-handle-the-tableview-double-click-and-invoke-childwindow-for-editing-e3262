# How to handle the TableView double click and invoke ChildWindow for editing


<p>To show a window for editing, handle the TableView.RowDoubleClick event and pass the current clicked row to the ChildWindow constructor. You can get an object by using the RowDoubleClickEventArgs.HitInfo.RowHandle property and the GridControl.GetRow method.</p><br />


<br/>


