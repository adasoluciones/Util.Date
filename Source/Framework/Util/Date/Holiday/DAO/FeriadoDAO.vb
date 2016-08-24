Imports Ada.Framework.Data.DBConnector
Imports Ada.Framework.Data.DBConnector.Connections
Imports Ada.Framework.Data.DBConnector.Entities.DataBase
Imports Ada.Framework.Data.DBConnector.Entities.Query
Imports Ada.Framework.Util.Date.Holiday.TO
Imports Ada.Framework.Data.DBConnector.Queries.SP
Imports Ada.Framework.Data.DBConnector.Entities.Parameter

Namespace Framework.Util.Date.Holiday.DAO
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
    ''' </remarks>
    Friend Class FeriadoDAO

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        Private Function ObtenerConexion() As ConexionBaseDatos
            Dim config As IConfiguracionBaseDatos = ConfiguracionBaseDatosFactory.ObtenerConfiguracionDeBaseDatos()
            Dim db As ConexionTO = config.ObtenerConexion("Feriados")
            Dim conexion As ConexionBaseDatos = ConexionBaseDatosFactory.ObtenerConexionBaseDatos(db)
            conexion.AutoConectarse = True
            Return conexion
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <param name="feriadoTO"></param>
        ''' <returns></returns>
        Public Function ListarFeriadosSegunFiltro(ByVal feriadoTO As FeriadoTO) As IList(Of FeriadoTO)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado

            sp.Nombre = "SP_ListarFeriadosSegunFiltro"

            If Not (feriadoTO.Dia <= 0) Then
                sp.Parametros.Add("Dia", feriadoTO.Dia)
            Else
                sp.Parametros.Add("Dia", Nothing)
            End If

            If Not (feriadoTO.Mes <= 0) Then
                sp.Parametros.Add("Mes", feriadoTO.Mes)
            Else
                sp.Parametros.Add("Mes", Nothing)
            End If

            If Not (feriadoTO.Año <= 0) Then
                sp.Parametros.Add("Año", feriadoTO.Año)
            Else
                sp.Parametros.Add("Año", Nothing)
            End If

            sp.Parametros.Add("TipoUbicacion", feriadoTO.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriadoTO.CodigoUbicacion)

            If (feriadoTO.Estado = EstadoFeriado.Ninguno) Then
                sp.Parametros.Add("Estado", Nothing)
            Else
                sp.Parametros.Add("Estado", feriadoTO.Estado.ToString())
            End If

            sp.Parametros.Add("Operativo", feriadoTO.Operativo)
            sp.Parametros.Add("Tipo", feriadoTO.Tipo)
            sp.Parametros.Add("Algoritmo", feriadoTO.Algoritmo.ToString())
            sp.Ejecutar()

            Dim respuesta As IList(Of RespuestaEjecucion(Of FeriadoTO)) = sp.Consultar(Of FeriadoTO)()

            Return respuesta.Select((Function(r As RespuestaEjecucion(Of FeriadoTO)) r.Respuesta)).ToList()
        End Function



        Public Function ListarFeriadosSegunFiltro2(ByVal feriadoTO As FeriadoTO) As IList(Of FeriadoTO)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado

            sp.Nombre = "SP_ListarFeriadosSegunFiltro"

            If Not (feriadoTO.Dia <= 0) Then
                sp.Parametros.Add("Dia", feriadoTO.Dia)
            Else
                sp.Parametros.Add("Dia", Nothing)
            End If

            If Not (feriadoTO.Mes <= 0) Then
                sp.Parametros.Add("Mes", feriadoTO.Mes)
            Else
                sp.Parametros.Add("Mes", Nothing)
            End If

            If Not (feriadoTO.Año <= 0) Then
                sp.Parametros.Add("Año", feriadoTO.Año)
            Else
                sp.Parametros.Add("Año", Nothing)
            End If

            sp.Parametros.Add("TipoUbicacion", feriadoTO.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriadoTO.CodigoUbicacion)

            If (feriadoTO.Estado = EstadoFeriado.Ninguno) Then
                sp.Parametros.Add("Estado", Nothing)
            Else
                sp.Parametros.Add("Estado", feriadoTO.Estado.ToString())
            End If

            sp.Parametros.Add("Operativo", feriadoTO.Operativo)
            sp.Parametros.Add("Tipo", feriadoTO.Tipo)
            sp.Parametros.Add("Algoritmo", feriadoTO.Algoritmo.ToString())
            sp.Ejecutar()

            Dim respuesta As IList(Of RespuestaEjecucion(Of FeriadoTO)) = sp.Consultar(Of FeriadoTO)()

            Return respuesta.Select((Function(r As RespuestaEjecucion(Of FeriadoTO)) r.Respuesta)).ToList()
        End Function

        Public Sub Agregar(ByVal feriado As FeriadoTO)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado
            sp.Nombre = "SP_AgregarFeriado"

            sp.Parametros.Add("Dia", feriado.Dia)
            sp.Parametros.Add("Mes", feriado.Mes)
            sp.Parametros.Add("Año", feriado.Año)
            sp.Parametros.Add("TipoUbicacion", feriado.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriado.CodigoUbicacion)
            sp.Parametros.Add("Estado", feriado.Estado.ToString())

            If (feriado.Operativo.HasValue) Then
                sp.Parametros.Add("Operativo", feriado.Operativo.Value)
            Else
                sp.Parametros.Add("Operativo", Nothing)
            End If

            sp.Parametros.Add("Tipo", feriado.Tipo)
            sp.Parametros.Add("Algoritmo", feriado.Algoritmo.ToString())

            sp.Ejecutar()
        End Sub

        Public Sub AgregarMasivo(ByVal feriados As IList(Of FeriadoTO), ByVal saltarAlError As Boolean)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado
            sp.Nombre = "SP_AgregarFeriados"

            Dim tabla As Tabla = New Tabla()
            tabla.AgregarColumna("Dia")
            tabla.AgregarColumna("Mes")
            tabla.AgregarColumna("Año")
            tabla.AgregarColumna("TipoUbicacion")
            tabla.AgregarColumna("CodigoUbicacion")
            tabla.AgregarColumna("Estado")
            tabla.AgregarColumna("Operativo")
            tabla.AgregarColumna("Tipo")
            tabla.AgregarColumna("Algoritmo")

            For Each feriado As FeriadoTO In feriados
                tabla.AgregarValor("Dia", feriado.Dia)
                tabla.AgregarValor("Mes", feriado.Mes)
                tabla.AgregarValor("Año", feriado.Año)
                tabla.AgregarValor("TipoUbicacion", feriado.TipoUbicacion)
                tabla.AgregarValor("CodigoUbicacion", feriado.CodigoUbicacion)
                tabla.AgregarValor("Estado", feriado.Estado.ToString())

                If (feriado.Operativo.HasValue) Then
                    tabla.AgregarValor("Operativo", feriado.Operativo.Value)
                Else
                    tabla.AgregarValor("Operativo", Nothing)
                End If

                tabla.AgregarValor("Tipo", feriado.Tipo)
                tabla.AgregarValor("Algoritmo", feriado.Algoritmo.ToString())
            Next

            sp.Parametros.Add("saltarAlError", saltarAlError)
            sp.Parametros.Add("registros", tabla)

            sp.Ejecutar()
        End Sub

        Public Sub Modificar(ByVal feriado As FeriadoTO)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado
            sp.Nombre = "SP_ModificarFeriado"

            sp.Parametros.Add("Dia", feriado.Dia)
            sp.Parametros.Add("Mes", feriado.Mes)
            sp.Parametros.Add("Año", feriado.Año)
            sp.Parametros.Add("TipoUbicacion", feriado.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriado.CodigoUbicacion)
            sp.Parametros.Add("Estado", feriado.Estado.ToString())

            If (feriado.Operativo.HasValue) Then
                sp.Parametros.Add("Operativo", feriado.Operativo.Value)
            Else
                sp.Parametros.Add("Operativo", Nothing)
            End If

            sp.Parametros.Add("Tipo", feriado.Tipo)
            sp.Parametros.Add("Algoritmo", feriado.Algoritmo.ToString())

            sp.Ejecutar()
        End Sub

        Public Sub Eliminar(ByVal feriado As FeriadoTO)
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado
            sp.Nombre = "SP_EliminarFeriado"

            sp.Parametros.Add("Dia", feriado.Dia)
            sp.Parametros.Add("Mes", feriado.Mes)
            sp.Parametros.Add("Año", feriado.Año)
            sp.Parametros.Add("TipoUbicacion", feriado.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriado.CodigoUbicacion)

            sp.Ejecutar()
        End Sub

        Function Existe(ByVal feriado As FeriadoTO) As Boolean
            Dim db As ConexionBaseDatos = ObtenerConexion()

            Dim sp As ProcedimientoAlmacenado = db.CrearProcedimientoAlmacenado
            sp.Nombre = "SP_ExisteFeriado"

            sp.Parametros.Add("Dia", feriado.Dia)
            sp.Parametros.Add("Mes", feriado.Mes)
            sp.Parametros.Add("Año", feriado.Año)
            sp.Parametros.Add("TipoUbicacion", feriado.TipoUbicacion)
            sp.Parametros.Add("CodigoUbicacion", feriado.CodigoUbicacion)

            Return sp.Obtener(Of Boolean)().Respuesta
        End Function

    End Class
End Namespace

