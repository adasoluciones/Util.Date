Namespace Framework.Util.Date

    ''' <summary>
    ''' Factoría de implementación del utilitario de fechas.
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 15/09/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): Versión Inicial
    ''' </remarks>
    Public Class FechaFactory
        ''' <summary>
        ''' Obtiene una instancia de implementacion de <see cref="Ada.Framework.Util.Date.IFecha"></see>.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 15/09/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): Versión Inicial
        ''' </remarks>
        ''' <returns></returns>
        Shared Function ObtenerFecha() As IFecha
            Return New Fecha()
        End Function
    End Class
End Namespace
