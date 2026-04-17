Public Interface IPeriodicity
    ''' <summary>
    ''' Признак повторяющегося задания.
    ''' </summary>
    ''' <returns>True если задание должно периодически повторяться и False в ином случае.</returns>
    Property IsPeriodic As Boolean

    ''' <summary>
    ''' Интервал между началом и следующим выполнением задания.
    ''' </summary>
    ''' <returns></returns>
    Property Interval As TimeSpan

    ''' <summary>
    ''' Описание задания.
    ''' </summary>
    ''' <returns></returns>
    Property Text As String
End Interface
