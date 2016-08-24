Imports Ada.Framework.Util.Date.Holiday.Business
Imports System.Globalization
Imports Ada.Framework.Util.Date.TO
Imports Ada.Framework.Util.Core.Validation.TO

Namespace Framework.Util.Date
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    ''' </remarks>
    Friend Class Fecha : Implements IFecha

        '
        'Método que convierte una cadena de texto en una fecha, según formato indicado.
        '
        '1.0 26/03/2012 Iván López B. (ADA Ltda.): Versión Inicial
        '
        'Parametros de Entrada:
        '----------------------
        'valor: cadena de texto a convertir.
        'formato: formato en que se debe interpretar el valor.
        '
        'Since 1.0
        '
        ''' <summary>
        ''' Método que convierte una cadena de texto en una fecha, según formato indicado.
        ''' </summary>
        ''' <param name="fecha">cadena de texto a convertir.</param>
        ''' <param name="formato">formato en que se debe interpretar el valor.</param>
        ''' <returns>retorna la fecha editada</returns>
        ''' <remarks></remarks>
        Public Function ConvertirStringADate(ByVal fecha As String, ByVal formato As String, Optional ByVal cultura As IFormatProvider = Nothing) As ResultadoValidacion(Of DateTime, EstadoFecha) Implements IFecha.ConvertirStringADate
            Dim retorno As ResultadoValidacion(Of DateTime, EstadoFecha) = New ResultadoValidacion(Of DateTime, EstadoFecha)()
            If (cultura Is Nothing) Then
                cultura = CultureInfo.InvariantCulture
            End If

            If (Not ValidarFormato(formato)) Then
                retorno.ValorAdicional = formato
                retorno.CodigoEstado = EstadoFecha.FORMINVALID
                Return retorno
            End If

            If Not (fecha Is Nothing) Then
                fecha = fecha.Trim()
            End If

            If (String.IsNullOrEmpty(fecha)) Then
                retorno.ValorAdicional = fecha
                retorno.CodigoEstado = EstadoFecha.FECINVALID
                Return retorno
            End If

            Dim fechaParseada As DateTime
            Try
                fechaParseada = DateTime.ParseExact(fecha, formato, cultura, DateTimeStyles.AllowWhiteSpaces)
            Catch ex As FormatException
                retorno.ValorAdicional = fecha
                retorno.CodigoEstado = EstadoFecha.FECINVALID
            End Try

            retorno.Valor = fechaParseada

            Return retorno
        End Function

        '
        'Método que convierte una fecha a cadena de texto, según formato indicado.
        '
        '1.0 26/03/2012 Iván López B. (ADA Ltda.): Versión Inicial
        '
        'Parametros de Entrada:
        '----------------------
        'valor: fecha a convertir.
        'formato: formato en que se debe interpretar el valor.
        '
        'Since 1.0
        '
        ''' <summary>
        ''' Método que convierte una fecha a cadena de texto, según formato indicado.
        ''' </summary>
        ''' <param name="fecha">fecha a convertir.</param>
        ''' <param name="formato">formato en que se debe interpretar el valor.</param>
        ''' <returns>retorna la fecha editada</returns>
        ''' <remarks></remarks>
        Public Function ConvertirDateAString(ByVal fecha As DateTime, ByVal formato As String, Optional ByVal cultura As IFormatProvider = Nothing) As ResultadoValidacion(Of String, EstadoFecha) Implements IFecha.ConvertirDateAString
            Dim retorno As ResultadoValidacion(Of String, EstadoFecha) = New ResultadoValidacion(Of String, EstadoFecha)
            If (cultura Is Nothing) Then
                cultura = CultureInfo.InvariantCulture
            End If
            Try
                retorno.Valor = fecha.ToString(formato, cultura)
            Catch ex As Exception
                retorno.CodigoEstado = EstadoFecha.FORMINVALID
                retorno.ValorAdicional = formato
            End Try

            Return retorno
        End Function

        '
        'Método que calcula la diferencia en días entre dos fechas entregadas.
        '
        '1.0 26/03/2012 Iván López B. (ADA Ltda.): Versión Inicial
        '
        'Parametros de Entrada:
        '----------------------
        'a: fecha inicial de la comparación.
        'b: fecha final de la comparación.
        '
        'Since 1.0
        '
        ''' <summary>
        ''' Método que calcula la diferencia en días entre dos fechas entregadas.
        ''' </summary>
        ''' <param name="fecha1">fecha inicial de la comparación.</param>
        ''' <param name="fecha2">fecha final de la comparación.</param>
        ''' <returns>retorna el numero de diferencia entre los dias</returns>
        ''' <remarks></remarks>
        Public Function DiferenciaEnDias(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer Implements IFecha.DiferenciaEnDias
            Dim diferencia As Double = ((fecha1 - fecha2).TotalDays)
            Return CInt(Math.Abs(diferencia))
        End Function

        '
        'Método que verifica la fecha
        '
        '1.0 22/11/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        '
        'Parametros de Entrada:
        '----------------------
        'fecha: fecha que sera verificada
        '
        '
        'Since 1.0
        '
        ''' <summary>
        ''' Método que verifica la fecha
        ''' </summary>
        ''' <param name="fecha">fecha que sera verificada</param>
        ''' <returns>retorna true o false dependiendo de la fecha</returns>
        ''' <remarks></remarks>
        Function ValidarFecha(ByVal fecha As String, ByVal formato As String) As ResultadoValidacion(Of Boolean, EstadoFecha) Implements IFecha.ValidarFecha
            Dim retorno As ResultadoValidacion(Of Boolean, EstadoFecha) = New ResultadoValidacion(Of Boolean, EstadoFecha)
            Dim resultadoConversion As ResultadoValidacion(Of DateTime, EstadoFecha) = ConvertirStringADate(fecha, formato)
            retorno.CodigoEstado = resultadoConversion.CodigoEstado
            retorno.ValorAdicional = resultadoConversion.ValorAdicional
            retorno.Valor = (retorno.CodigoEstado = EstadoFecha.Valido)
            If (retorno.CodigoEstado = EstadoFecha.Valido) Then
                retorno.ValorFormateado = fecha
            End If
            Return retorno
        End Function

        'Calcula la diferencia en meses entre dos fechas.
        Public Function DiferenciaEnMeses(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer Implements IFecha.DiferenciaEnMeses

            Dim meses As Integer = 0
            Dim fechaMenor As DateTime
            Dim fechaMayor As DateTime

            If fecha1 = Nothing Or fecha2 = Nothing Then
                Return meses
            End If

            If CompararFechas(fecha1, fecha2) > 0 Then
                fechaMayor = New DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0, 0)
                fechaMenor = New DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0, 0)
            Else
                fechaMayor = New DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0, 0)
                fechaMenor = New DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0, 0)
            End If

            meses = diferenciaEnAños(fechaMayor, fechaMenor) * 12
            meses = meses + fechaMayor.Month - fechaMenor.Month

            If fechaMayor.Day < fechaMenor.Day Then
                meses = meses - 1
            End If

            If fechaMayor.Month < fechaMenor.Month Then
                meses = meses + 12
            End If

            Return meses

        End Function

        'Calcula la diferencia en años entre dos fechas.
        Public Function DiferenciaEnAños(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer Implements IFecha.DiferenciaEnAños

            Dim anios As Integer = 0
            Dim fechaMenor As DateTime
            Dim fechaMayor As DateTime

            If fecha1 = Nothing Or fecha2 = Nothing Then
                Return anios
            End If

            If CompararFechas(fecha1, fecha2) > 0 Then
                fechaMayor = New DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0, 0)
                fechaMenor = New DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0, 0)
            Else
                fechaMayor = New DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0, 0)
                fechaMenor = New DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0, 0)
            End If

            anios = fechaMayor.Year - fechaMenor.Year

            If fechaMayor.Month < fechaMenor.Month Or (fechaMayor.Month = fechaMenor.Month And fechaMayor.Day < fechaMenor.Day) Then
                anios = anios - 1
            End If

            Return anios

        End Function

        Public ReadOnly Property Hoy() As Date Implements IFecha.Hoy
            Get
                Return Date.Today
            End Get
        End Property

        Public ReadOnly Property Ahora() As Date Implements IFecha.Ahora
            Get
                Return Date.Now
            End Get
        End Property

        'Retorna el último día del mes consultado.
        Public Function UltimoDiaDelMes(ByVal mes As Integer, ByVal año As Integer) As Integer Implements IFecha.UltimoDiaDelMes

            Dim c As New DateTime(año, mes, 1)

            c = c.AddMonths(1)
            c = c.AddDays(-(c.Day))

            Return c.Day

        End Function

        'Retorna el último día del mes consultado.
        Public Function UltimoDiaDelMes(ByVal fecha As Date) As Integer Implements IFecha.UltimoDiaDelMes

            Return UltimoDiaDelMes(fecha.Month, fecha.Year)

        End Function

        'Compara dos fechas.
        Public Function CompararFechas(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer Implements IFecha.CompararFechas

            If IsNothing(fecha1) OrElse IsNothing(fecha2) Then
                Return -1
            End If

            Dim fec1 As New DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0, 0)
            Dim fec2 As New DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0, 0)

            Return fec1.CompareTo(fec2)

        End Function

        'Suma los días indicados a la fecha entregada.
        Public Function SumarDias(ByVal fecha As Date, ByVal cantidad As Integer) As Date Implements IFecha.SumarDias

            fecha = fecha.AddHours(cantidad * 24)

            Return fecha

        End Function

        'Suma los meses indicados a la fecha entregada.
        Public Function SumarMeses(ByVal fecha As Date, ByVal cantidad As Integer, ByVal finDeMes As Boolean) As Date Implements IFecha.SumarMeses
            fecha = fecha.AddMonths(cantidad)
            If finDeMes Then
                fecha = New Date(fecha.Year, fecha.Month, fecha.Day, fecha.Hour, fecha.Minute, fecha.Second, fecha.Millisecond)
            End If

            Return fecha
        End Function

        'Suma los años indicados a la fecha entregada.
        Public Function SumarAños(ByVal fecha As Date, ByVal cantidad As Integer) As Date Implements IFecha.SumarAños

            fecha = fecha.AddYears(cantidad)

            Return fecha

        End Function

        'Resta los días indicados a la fecha entregada.
        Public Function RestarDias(ByVal fecha As Date, ByVal cantidad As Integer) As Date Implements IFecha.RestarDias

            fecha = fecha.AddHours(-cantidad * 24)

            Return fecha

        End Function

        'Resta los meses indicados a la fecha entregada.
        Public Function RestarMeses(ByVal fecha As Date, ByVal cantidad As Integer) As Date Implements IFecha.RestarMeses

            fecha = fecha.AddMonths(-cantidad)

            Return fecha

        End Function

        'Restar los años indicados a la fecha entregada.
        Public Function RestarAños(ByVal fecha As Date, ByVal cantidad As Integer) As Date Implements IFecha.RestarAños

            fecha = fecha.AddYears(-cantidad)

            Return fecha

        End Function

        'Determina si la fecha entragada corresponde a un fin de semana.
        Public Function EsFinDeSemana(ByVal fecha As Date) As Boolean Implements IFecha.EsFinDeSemana

            If fecha = Nothing Then
                Return False
            End If

            Return (Weekday(fecha) = FirstDayOfWeek.Saturday Or Weekday(fecha) = FirstDayOfWeek.Sunday)

        End Function

        Public Function ValidarFormato(ByVal formato As String) As Boolean Implements IFecha.ValidarFormato
            If Not (formato Is Nothing) Then
                formato = formato.Trim()
            End If
            If (String.IsNullOrEmpty(formato)) Then
                Return False
            End If

            Dim fecha As String = formato
            fecha = fecha _
                .Replace("dddd", "Monday") _
                .Replace("ddd", "Mon") _
                .Replace("dd", "01") _
                .Replace("d", "1") _
                .Replace("fffffff", "0000000") _
                .Replace("ffffff", "000000") _
                .Replace("fffff", "00000") _
                .Replace("ffff", "0000") _
                .Replace("fff", "000") _
                .Replace("ff", "00") _
                .Replace("f", "0") _
                .Replace("FFFFFFF", "0000000") _
                .Replace("FFFFFF", "000000") _
                .Replace("FFFFF", "00000") _
                .Replace("FFFF", "0000") _
                .Replace("FFF", "000") _
                .Replace("FF", "00") _
                .Replace("F", "0") _
                .Replace("g", "1") _
                .Replace("hh", "12") _
                .Replace("h", "12") _
                .Replace("HH", "00") _
                .Replace("H", "00") _
                .Replace("K", "Unspecified") _
                .Replace("mm", "00") _
                .Replace("m", "0") _
                .Replace("MMMM", "January") _
                .Replace("MMM", "Jan") _
                .Replace("MM", "12") _
                .Replace("M", "12") _
                .Replace("ss", "00") _
                .Replace("s", "0") _
                .Replace("tt", "AM") _
                .Replace("t", "A") _
                .Replace("yyyyy", "00001") _
                .Replace("yyyy", "0001") _
                .Replace("yyy", "001") _
                .Replace("yy", "01") _
                .Replace("y", "1") _
                .Replace("zzz", "0") _
                .Replace("zz", "0") _
                .Replace("z", "0")

            Dim fechaParseada As DateTime
            Try
                fechaParseada = DateTime.ParseExact(fecha, formato, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces)
            Catch ex As FormatException
                Return False
            End Try

            Return True
        End Function
    End Class
End Namespace

