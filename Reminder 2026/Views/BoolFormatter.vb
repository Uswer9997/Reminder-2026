''' <summary>
''' Форматтер булевых значений в значения вида ДаНет.
''' </summary>
Public Class BoolFormatter
    Implements ICustomFormatter, IFormatProvider

    Public Function Format(parformat As String, arg As Object, formatProvider As IFormatProvider) As String Implements ICustomFormatter.Format
        If arg.GetType() Is GetType(Boolean) Then
            Dim val As Boolean = CType(arg, Boolean)
            If val = True Then
                Return "Да"
            Else
                Return "Нет"
            End If
        Else
            Return String.Empty
        End If
    End Function

    Public Function GetFormat(formatType As Type) As Object Implements IFormatProvider.GetFormat
        If formatType Is GetType(ICustomFormatter) Then
            Return Me
        Else
            Return Nothing
        End If
    End Function
End Class
