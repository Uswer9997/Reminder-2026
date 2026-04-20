''' <summary>
''' Содержит вспомогательные методы для настройки форм.
''' </summary>
Public MustInherit Class FormHelper

    ''' <summary>
    ''' Вызвращает точку всегда находящуюся на экране.
    ''' </summary>
    ''' <param name="originalPoint">Исходные координаты точки.</param>
    ''' <param name="Offset">Желаемое смещение точки.</param>
    ''' <returns></returns>
    Public Shared Function GetLocationPoint(ByVal targetForm As Form, ByVal originalPoint As Point, ByVal Offset As Point) As Point
        Dim newPoint As Point = originalPoint
        newPoint.X = newPoint.X + Offset.X
        Dim xx = Screen.FromControl(targetForm).WorkingArea
        If newPoint.X > Screen.FromControl(targetForm).WorkingArea.Width Then
            newPoint.X = originalPoint.X
        End If

        newPoint.Y = newPoint.Y + Offset.Y
        If newPoint.Y > Screen.FromControl(targetForm).WorkingArea.Height Then
            newPoint.Y = originalPoint.Y
        End If

        Return newPoint
    End Function
End Class
