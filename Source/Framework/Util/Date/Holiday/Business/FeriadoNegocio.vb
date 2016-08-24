Imports Ada.Framework.Util.Date.Holiday.TO
Imports Ada.Framework.Util.Date.Holiday.DAO
Imports Ada.Framework.Data.Notifications

Namespace Framework.Util.Date.Holiday.Business
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
    ''' </remarks>
    Friend Class FeriadoNegocio : Implements IFeriadoNegocio

        Private TablaMensaje As String = "Feriados"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private Shared feriados As IList(Of FeriadoTO)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private dao As FeriadoDAO = New FeriadoDAO()

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
        Public Function EsFeriado(ByVal fecha As Date) As Boolean Implements IFeriadoNegocio.EsFeriado
            Dim feriado As Boolean

            If (New Algorithms.AlgoritmosFeriado().ObtenerViernesSantoComputus(fecha.Year) = fecha) Then
                Return True
            End If

            Dim feriadoEncontrado As IEnumerable(Of FeriadoTO) = feriados.Where((Function(d As FeriadoTO) d.Dia = fecha.Day AndAlso d.Mes = fecha.Month AndAlso d.Año = fecha.Year _
                                     AndAlso d.Algoritmo = TipoAlgoritmo.Fijo))

            If (feriadoEncontrado.Count > 0) Then
                If (feriadoEncontrado.Single().Estado = EstadoFeriado.ACT) Then
                    feriado = True
                Else
                    Return False
                End If
            Else
                feriadoEncontrado = feriados.Where((Function(d As FeriadoTO) d.Dia = fecha.Day AndAlso d.Mes = fecha.Month AndAlso d.Año = -1 _
                                         AndAlso d.Algoritmo = TipoAlgoritmo.Fijo))
                If (feriadoEncontrado.Count > 0) Then
                    If (feriadoEncontrado.Single().Estado = EstadoFeriado.ACT) Then
                        feriado = True
                    Else
                        Return False
                    End If
                Else
                    feriado = EsFeriadoPorAlgoritmo(fecha)
                End If
            End If

            Return feriado
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Public Sub Recargar() Implements IFeriadoNegocio.Recargar
            feriados = New FeriadoDAO().ListarFeriadosSegunFiltro(New FeriadoTO())
        End Sub

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
        Public Function EsFeriadoPorAlgoritmo(ByVal fecha As Date) As Boolean Implements IFeriadoNegocio.EsFeriadoPorAlgoritmo
            Dim esFeriado As Boolean

            For index = 1 To 2
                Dim feriadosCercanos As IList(Of FeriadoTO) = Nothing

                If (feriadosCercanos Is Nothing) Then
                    feriadosCercanos = feriados.Where((Function(d As FeriadoTO) d.Algoritmo <> TipoAlgoritmo.Fijo AndAlso d.Estado = EstadoFeriado.ACT _
                                                                            AndAlso d.Año > 0 AndAlso New DateTime(fecha.Year, d.Mes, d.Dia) >= (fecha.AddDays(-5)) AndAlso _
                                                                            New DateTime(fecha.Year, d.Mes, d.Dia) <= (fecha.AddDays(5)) _
                                                                            )).ToList()
                End If

                For Each feriado As FeriadoTO In feriadosCercanos
                    Dim fechaFeriado As Date = New Algorithms.AlgoritmosFeriado().Algoritmos(feriado.Algoritmo)(feriado, fecha)
                    With feriado
                        .Año = fechaFeriado.Year
                        .Mes = fechaFeriado.Month
                        .Dia = fechaFeriado.Day
                    End With
                Next

                esFeriado = feriadosCercanos.Where((Function(d As FeriadoTO) d.Dia = fecha.Day AndAlso (d.Año = fecha.Year OrElse d.Año = -1) AndAlso d.Mes = fecha.Month)).Count() > 0
                If (esFeriado) Then
                    Exit For
                End If

                feriadosCercanos = feriados.Where((Function(d As FeriadoTO) d.Algoritmo <> TipoAlgoritmo.Fijo AndAlso d.Estado = EstadoFeriado.ACT _
                                                                            AndAlso d.Año = -1 AndAlso New DateTime(fecha.Year, d.Mes, d.Dia) >= (fecha.AddDays(-5)) AndAlso _
                                                                            New DateTime(fecha.Year, d.Mes, d.Dia) <= (fecha.AddDays(5)) _
                                                                            )).ToList()
            Next

            Return esFeriado
        End Function

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
        Public Function EsDiaHabil(ByVal fecha As Date) As Boolean Implements IFeriadoNegocio.EsDiaHabil

            If fecha = Nothing Then
                Return False
            End If

            Dim habil As Boolean = FechaFactory.ObtenerFecha().EsFinDeSemana(fecha) OrElse EsFeriado(fecha)

            Return Not habil

        End Function

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
        Public Function ObtenerDiaHabilSiguiente(ByVal fecha As Date) As Date Implements IFeriadoNegocio.ObtenerDiaHabilSiguiente

            While Not EsDiaHabil(fecha)
                fecha = FechaFactory.ObtenerFecha().SumarDias(fecha, 1)
            End While

            Return fecha

        End Function

        Function Agregar(ByVal feriado As FeriadoTO) As Notificacion Implements IFeriadoNegocio.Agregar
            Dim retorno As Notificacion = New Notificacion()
            Try
                Dim respuesta As Notificacion(Of Boolean) = Existe(feriado)
                retorno.Unir(respuesta)

                If Not (retorno.HayError) Then
                    If Not (respuesta.Respuesta) Then
                        dao.Agregar(feriado)
                        retorno.AgregarMensaje(TablaMensaje, "AGREGAR_OK")
                    Else
                        retorno.AgregarMensaje(TablaMensaje, "YA_EXISTE")
                    End If
                End If

            Catch ex As Exception
                retorno.AgregarMensaje(TablaMensaje, "AGREGAR_ERROR")
            End Try
            Return retorno
        End Function

        Function AgregarMasivo(ByVal feriados As IList(Of FeriadoTO), ByVal saltarAlError As Boolean) As Notificacion Implements IFeriadoNegocio.AgregarMasivo
            Dim retorno As Notificacion = New Notificacion()
            Try
                dao.AgregarMasivo(feriados, saltarAlError)
                retorno.AgregarMensaje(TablaMensaje, "AGREGAR_MASIVO_OK")
            Catch ex As Exception
                retorno.AgregarMensaje(TablaMensaje, "AGREGAR_MASIVO_ERROR")
            End Try
            Return retorno
        End Function

        Function Modificar(ByVal feriado As FeriadoTO) As Notificacion Implements IFeriadoNegocio.Modificar
            Dim retorno As Notificacion = New Notificacion()
            Try
                Dim respuesta As Notificacion(Of Boolean) = Existe(feriado)
                retorno.Unir(respuesta)

                If Not (retorno.HayError) Then
                    If (respuesta.Respuesta) Then
                        dao.Modificar(feriado)
                        retorno.AgregarMensaje(TablaMensaje, "MODIFICAR_OK")
                    Else
                        retorno.AgregarMensaje(TablaMensaje, "NO_EXISTE")
                    End If
                End If

            Catch ex As Exception
                retorno.AgregarMensaje(TablaMensaje, "MODIFICAR_ERROR")
            End Try
            Return retorno
        End Function

        Function Eliminar(ByVal feriado As FeriadoTO) As Notificacion Implements IFeriadoNegocio.Eliminar
            Dim retorno As Notificacion = New Notificacion()
            Try
                Dim respuesta As Notificacion(Of Boolean) = Existe(feriado)
                retorno.Unir(respuesta)

                If Not (retorno.HayError) Then
                    If (respuesta.Respuesta) Then
                        dao.Eliminar(feriado)
                        retorno.AgregarMensaje(TablaMensaje, "ELIMINAR_OK")
                    Else
                        retorno.AgregarMensaje(TablaMensaje, "NO_EXISTE")
                    End If
                End If

            Catch ex As Exception
                retorno.AgregarMensaje(TablaMensaje, "ELIMINAR_ERROR")
            End Try
            Return retorno
        End Function

        Function Existe(ByVal feriado As FeriadoTO) As Notificacion(Of Boolean) Implements IFeriadoNegocio.Existe
            Dim retorno As Notificacion(Of Boolean) = New Notificacion(Of Boolean)()
            Try
                retorno.Respuesta = dao.Existe(feriado)
            Catch ex As Exception
                retorno.AgregarMensaje(TablaMensaje, "EXISTE_ERROR")
            End Try
            Return retorno
        End Function
    End Class
End Namespace
