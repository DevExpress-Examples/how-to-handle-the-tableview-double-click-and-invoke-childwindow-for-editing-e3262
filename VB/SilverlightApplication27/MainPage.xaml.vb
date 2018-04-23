Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports System.Windows.Controls
Imports DevExpress.Xpf.Grid

Namespace SilverlightApplication27
	Partial Public Class MainPage
		Inherits UserControl
		Private list As New ObservableCollection(Of TestData)()

		Public Sub New()
			InitializeComponent()
			list.Add(New TestData() With {.Name = "name1", .Salary = 1})
			list.Add(New TestData() With {.Name = "name2", .Salary = 2})
			list.Add(New TestData() With {.Name = "name3", .Salary = 3})
			gridControl1.ItemsSource = list
		End Sub

		Private Sub view_RowDoubleClick(ByVal sender As Object, ByVal e As RowDoubleClickEventArgs)
			Dim ch As New ChildWindow1(TryCast(gridControl1.GetRow(e.HitInfo.RowHandle), TestData))
			ch.Show()
		End Sub
	End Class

	Public Class TestData
		Implements INotifyPropertyChanged
		Private _Name As String

		Public Property Name() As String
			Get
				Return _Name
			End Get
			Set(ByVal value As String)
				_Name = value
				OnPropertyChanged(New PropertyChangedEventArgs("Name"))
			End Set
		End Property

		Private _Salary As Integer

		Public Property Salary() As Integer
			Get
				Return _Salary
			End Get
			Set(ByVal value As Integer)
				_Salary = value
				OnPropertyChanged(New PropertyChangedEventArgs("Salary"))
			End Set
		End Property

		Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

		Public Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
			RaiseEvent PropertyChanged(Me, e)
		End Sub
	End Class
End Namespace
