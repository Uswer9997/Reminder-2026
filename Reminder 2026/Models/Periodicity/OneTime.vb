Imports Reminder_2026
''' <summary>
''' Описывает интервал однократного напоминания.
''' </summary>
Public Class OneTime
    Implements IPeriodicity, ICloneable

    Private _Text As String = "Один раз"

    Public ReadOnly Property IsPeriodic As Boolean Implements IPeriodicity.IsPeriodic
        Get
            Return False
        End Get
    End Property

    Public Property Text As String Implements IPeriodicity.Text
        Get
            Return _Text
        End Get
        Set
            _Text = Value
        End Set
    End Property

    Public Property Interval As TimeSpan Implements IPeriodicity.Interval

    Public Property FrequencyOfRepeate As Repetitions Implements IPeriodicity.FrequencyOfRepeate
        Get
            Return Repetitions.Once
        End Get
        Set(value As Repetitions)
            If value <> Repetitions.Once Then
                Throw New InvalidOperationException("Нельзя установить значение отличное от Once для данного типа.")
            End If
        End Set
    End Property

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim MeClone As OneTime = Me.MemberwiseClone

        Return MeClone
    End Function
End Class
