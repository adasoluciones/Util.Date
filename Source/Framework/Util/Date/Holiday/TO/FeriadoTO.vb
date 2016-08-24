Namespace Framework.Util.Date.Holiday.TO
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
    ''' </remarks>
    Public Class FeriadoTO

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Dia As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Mes As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Año As Integer
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _TipoUbicacion As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _CodigoUbicacion As String
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Estado As EstadoFeriado
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private _Algoritmo As TipoAlgoritmo

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        Public Function ObtenerFecha(ByVal fecha As Date) As Date
            Dim fechaRetorno As Date

            If (Año = -1) Then
                fechaRetorno = New Date(fecha.Year, Mes, Dia)
            Else
                fechaRetorno = New Date(Año, Mes, Dia)
            End If

            Return fechaRetorno
        End Function







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
        Public Property Dia() As Integer
            Get
                Return _Dia
            End Get
            Set(ByVal value As Integer)
                _Dia = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property Mes() As Integer
            Get
                Return _Mes
            End Get
            Set(ByVal value As Integer)
                _Mes = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property Año() As Integer
            Get
                Return _Año
            End Get
            Set(ByVal value As Integer)
                _Año = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property TipoUbicacion() As String
            Get
                Return _TipoUbicacion
            End Get
            Set(ByVal value As String)
                _TipoUbicacion = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property CodigoUbicacion() As String
            Get
                Return _CodigoUbicacion
            End Get
            Set(ByVal value As String)
                _CodigoUbicacion = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property Estado() As EstadoFeriado
            Get
                Return _Estado
            End Get
            Set(ByVal value As EstadoFeriado)
                _Estado = value
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
        Private _Operativo As Nullable(Of Boolean)

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
        Public Property Operativo() As Nullable(Of Boolean)
            Get
                Return _Operativo
            End Get
            Set(ByVal value As Nullable(Of Boolean))
                _Operativo = value
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
        Private _Tipo As String

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
        Public Property Tipo() As String
            Get
                Return _Tipo
            End Get
            Set(ByVal value As String)
                _Tipo = value
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
        ''' <value></value>
        ''' <returns></returns>
        Public Property Algoritmo() As TipoAlgoritmo
            Get
                Return _Algoritmo
            End Get
            Set(ByVal value As TipoAlgoritmo)
                _Algoritmo = value
            End Set
        End Property

  

    End Class
End Namespace
