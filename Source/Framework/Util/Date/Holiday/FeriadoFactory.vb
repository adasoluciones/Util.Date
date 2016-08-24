Imports Ada.Framework.Util.Date.Holiday.Business

Namespace Framework.Util.Date.Holiday
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
    ''' </remarks>
    Public Class FeriadoFactory
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 05/12/2012 Nicolas Fuentes M. (ADA Ltda.): Versión Inicial
        ''' </remarks>
        ''' <returns></returns>
        Public Shared Function ObtenerFeriadoNegocio() As IFeriadoNegocio
            Return New FeriadoNegocio()
        End Function
    End Class
End Namespace
