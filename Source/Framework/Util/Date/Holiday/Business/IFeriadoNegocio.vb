Imports Ada.Framework.Util.Date.Holiday.TO
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
    Public Interface IFeriadoNegocio
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function EsFeriado(ByVal fecha As Date) As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function EsFeriadoPorAlgoritmo(ByVal fecha As Date) As Boolean
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks></remarks>
        Sub Recargar()
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function ObtenerDiaHabilSiguiente(ByVal fecha As Date) As Date
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function EsDiaHabil(ByVal fecha As Date) As Boolean

        Function Agregar(ByVal feriado As FeriadoTO) As Notificacion

        Function AgregarMasivo(ByVal feriado As IList(Of FeriadoTO), ByVal saltarAlError As Boolean) As Notificacion

        Function Modificar(ByVal feriado As FeriadoTO) As Notificacion

        Function Eliminar(ByVal feriado As FeriadoTO) As Notificacion

        Function Existe(ByVal feriado As FeriadoTO) As Notificacion(Of Boolean)
    End Interface
End Namespace
