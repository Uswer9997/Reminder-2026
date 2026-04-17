Imports System.ComponentModel

Public MustInherit Class Notifier
    Implements System.ComponentModel.INotifyPropertyChanged

#Region "INotifyPropertyChanged"

    Public Event PropertyChanged As PropertyChangedEventHandler Implements INotifyPropertyChanged.PropertyChanged

    Protected Overridable Sub OnPropertyChanged(ByVal Optional PropertyName As String = Nothing)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(PropertyName))
    End Sub

    Protected Overridable Function SetValue(Of T)(ByRef field As T, ByVal value As T,
                                               <System.Runtime.CompilerServices.CallerMemberName> ByVal Optional PropertyName As String = Nothing) As Boolean
        If Equals(field, value) Then Return False

        field = value
        OnPropertyChanged(PropertyName)
        Return True
    End Function

#End Region
End Class
