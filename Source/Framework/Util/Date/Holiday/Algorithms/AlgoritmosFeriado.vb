Imports Ada.Framework.Util.Date.Holiday.TO

Namespace Framework.Util.Date.Holiday.Algorithms

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
    ''' </remarks>
    Friend Class AlgoritmosFeriado

#Region "Declaraciones e Instanciaciones"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="feriado"></param>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        Public Delegate Function AlgoritmoDesplazamiento(ByVal feriado As FeriadoTO, ByVal fecha As Date) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Algoritmos As IDictionary(Of TipoAlgoritmo, AlgoritmoDesplazamiento)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <value></value>
        ''' <returns></returns>
        Public Property Algoritmos() As IDictionary(Of TipoAlgoritmo, AlgoritmoDesplazamiento)
            Get
                Return _Algoritmos
            End Get
            Set(ByVal value As IDictionary(Of TipoAlgoritmo, AlgoritmoDesplazamiento))
                _Algoritmos = value
            End Set
        End Property

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Public Sub New()
            _Algoritmos = New Dictionary(Of TipoAlgoritmo, AlgoritmoDesplazamiento)()
            _Algoritmos.Add(TipoAlgoritmo.Variable, AddressOf ObtenerFeriadoVariable)
            _Algoritmos.Add(TipoAlgoritmo.Continuo, AddressOf ObtenerFeriadoContinuo)
        End Sub

#End Region

#Region "Algoritmos"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="feriado"></param>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        Public Function ObtenerFeriadoVariable(ByVal feriado As FeriadoTO, ByVal fecha As Date) As Date
            If fecha = Nothing Then
                Return Nothing
            End If

            Dim FeriadoVariable As Date = feriado.ObtenerFecha(fecha)

            'El martes, miércoles y el jueves, se traslada al lunes anterior.
            'El viernes, se traslada al lunes siguente.
            Select Case Weekday(FeriadoVariable)
                Case FirstDayOfWeek.Tuesday
                    FeriadoVariable = FeriadoVariable.AddDays(-1)
                Case FirstDayOfWeek.Wednesday
                    FeriadoVariable = FeriadoVariable.AddDays(-2)
                Case FirstDayOfWeek.Thursday
                    FeriadoVariable = FeriadoVariable.AddDays(-3)
                Case FirstDayOfWeek.Friday
                    FeriadoVariable = FeriadoVariable.AddDays(3)
            End Select

            Return FeriadoVariable
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="feriado"></param>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        Public Function ObtenerFeriadoContinuo(ByVal feriado As FeriadoTO, ByVal fecha As Date) As Date
            If fecha = Nothing Then
                Return Nothing
            End If

            Dim FeriadoContinuo As Date = feriado.ObtenerFecha(fecha)

            'El martes,  se traslada al viernes anterior.
            'El miercoles, se traslada al viernes siguente.
            Select Case Weekday(FeriadoContinuo)
                Case FirstDayOfWeek.Tuesday
                    FeriadoContinuo = FeriadoContinuo.AddDays(-4)
                Case FirstDayOfWeek.Wednesday
                    FeriadoContinuo = FeriadoContinuo.AddDays(2)
            End Select

            Return FeriadoContinuo
        End Function


#End Region



        ''' <summary>
        ''' Cálculo según Dionisio el Exiguo 525
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 15/06/2015 Pablo Olivarez O. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="año"></param>
        ''' <returns></returns>
        Public Function ObtenerViernesSantoComputus(ByVal año As Integer) As Date
            Dim viernesSanto = Nothing

            Dim a
            Dim b
            Dim c
            Dim d
            Dim e
            Dim M
            Dim N
            If año < 2100 Then
                M = 24
                N = 5
            ElseIf (año > 2100) Then
                M = 24
                N = 6
            Else
                M = 0
                N = 0
            End If

            a = año Mod 19
            b = año Mod 4
            c = año Mod 7
            d = ((19 * a) + M) Mod 30
            e = ((2 * b) + (4 * c) + (6 * d) + N) Mod 7
            If (d + e) < 10 Then
                viernesSanto = New DateTime(año, 3, Integer.Parse(d + e + 22), 0, 0, 0, 0)
            End If

            If (d + e) > 9 Then
                viernesSanto = New DateTime(año, 4, Integer.Parse(d + e - 9), 0, 0, 0, 0)
            End If

            If viernesSanto = New DateTime(año, 4, 26, 0, 0, 0, 0) Then
                viernesSanto = New DateTime(año, 4, 19, 0, 0, 0, 0)
            End If

            If viernesSanto = New DateTime(año, 4, 25, 0, 0, 0, 0) AndAlso d = 28 AndAlso e = 6 AndAlso a > 10 Then
                viernesSanto = New DateTime(año, 4, 19, 0, 0, 0, 0)
            End If

            Return Convert.ToDateTime(viernesSanto).AddDays(-2)

        End Function


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="año"></param>
        ''' <returns></returns>
        Public Function ObtenerViernesSanto(ByVal año As Integer) As Date

            Dim DA As Integer = 0
            Dim Mo As Integer = 4

            Dim G As Integer = CInt((año - año / 19 * 19) + 1)
            Dim siglo As Integer = CInt(año / 100 + 1)

            Dim X As Integer = CInt(3 * siglo / 4 - 12)
            Dim Z As Integer = CInt((8 * siglo + 5) / 25 - 5)
            Dim D As Integer = CInt((5 * año / 4 - X) - 10)
            Dim N As Integer = (11 * G + 20 + Z) - X
            Dim E As Integer = CInt(N / 30)
            E = N - E * 30

            If E = 24 Or (E = 25 And G > 11) Then
                E = E + 1
            End If

            N = 44 - E
            If N < 21 Then
                N = N + 30
            End If

            D = D + N
            G = CInt(D / 7)
            N = (N + 7) - (D - G * 7)

            If N > 31 Then
                DA = N - 31
            Else
                DA = N
                Mo = 3
            End If

            Dim c As New DateTime(año, Mo - 1, DA - 2, 0, 0, 0, 0)

            Return c
        End Function

    End Class
End Namespace

