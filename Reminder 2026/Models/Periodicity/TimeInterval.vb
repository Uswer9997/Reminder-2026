''' <summary>
''' Описывает интервал повторяющегося напоминания.
''' </summary>
<Serializable>
Public Class TimeInterval
    Inherits Periodicity
    Implements ICloneable

    Private _FrequencyOfRepeate As Repetitions

    Public Overrides ReadOnly Property IsPeriodic As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Property FrequencyOfRepeate As Repetitions
        Get
            Return _FrequencyOfRepeate
        End Get
        Set(value As Repetitions)
            If value = Repetitions.Once Then
                Throw New InvalidOperationException("Нельзя установить значение Once для данного типа.")
            End If
            SetValue(Of Repetitions)(_FrequencyOfRepeate, value)
        End Set
    End Property

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim MeClone As TimeInterval = Me.MemberwiseClone

        Return MeClone
    End Function
End Class
