Imports Reminder_2026
''' <summary>
''' Описывает интервал однократного напоминания.
''' </summary>
<Serializable>
Public Class OneTime
    Inherits Periodicity
    Implements ICloneable

    Private _Text As String = "Один раз"

    Public Overrides ReadOnly Property IsPeriodic As Boolean
        Get
            Return False
        End Get
    End Property

    Public Overrides Property FrequencyOfRepeate As Repetitions
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
