Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Grid
Imports System.ComponentModel

Namespace SilverlightApplication27
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			list = New ObservableCollection(Of TestData)()
			list.Add(New TestData() With {.Name = "name1", .Salary = 1})
			list.Add(New TestData() With {.Name = "name2", .Salary = 2})
			list.Add(New TestData() With {.Name = "name3", .Salary = 3})
			gridControl1.DataSource = list
		End Sub


		Private list As ObservableCollection(Of TestData)

		Private Sub gridControl1_DoubleClick(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim gridControl As GridControl = TryCast(sender, GridControl)
			Dim rowHandle As Integer = gridControl1.View.GetRowHandleByMouseEventArgs(e)
			Dim ch As New ChildWindow1(TryCast(gridControl1.GetRow(rowHandle), TestData))
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

	Public Delegate Sub DoubleClickHandler(ByVal sender As Object, ByVal e As MouseButtonEventArgs)

	Public Class MyGridControl
		Inherits GridControl
		Public Event DoubleClick As DoubleClickHandler
		Private _clickPosition As Point
		Public _lastClick As DateTime = DateTime.Now
		Private _firstClickDone As Boolean = False

		Protected Overrides Sub OnPreviewMouseLeftButtonDown(ByVal e As MouseButtonEventArgs)
			Dim element As UIElement = TryCast(Me, UIElement)
			Dim clickTime As DateTime = DateTime.Now

			Dim span As TimeSpan = clickTime.Subtract(_lastClick)


			If span.TotalMilliseconds > 300 OrElse _firstClickDone = False Then
				_clickPosition = e.GetPosition(element)
				_firstClickDone = True
				_lastClick = DateTime.Now
			Else
				Dim position As Point = e.GetPosition(element)
				If Math.Abs(_clickPosition.X - position.X) < 4 AndAlso Math.Abs(_clickPosition.Y - position.Y) < 4 Then 'mouse didn't move => Valid double click
					RaiseEvent DoubleClick(Me, e)
				End If
				'else
				'    DoubleClickTB.Text = "Double Click failed due to mouse move!";
				_firstClickDone = False
			End If
			MyBase.OnPreviewMouseLeftButtonDown(e)
		End Sub
	End Class


End Namespace
