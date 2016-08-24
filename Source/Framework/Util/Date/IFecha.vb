Imports Ada.Framework.Util.Core.Validation.TO
Imports Ada.Framework.Util.Date.TO

Namespace Framework.Util.Date
    ''' <summary>
    ''' Contrato del utilitario de fechas.
    ''' </summary>
    ''' <remarks>
    '''     Registro de versiones:
    '''
    '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    ''' </remarks>
    Public Interface IFecha
        ''' <summary>
        ''' Obtiene la fecha actual (sin la hora).
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Hoy() As Date

        ''' <summary>
        ''' Obtiene la fecha y hora actual (en que se realiza la llamada).
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ReadOnly Property Ahora() As Date

        ''' <summary>
        ''' Convierte una cadena de texto en una fecha, según formato indicado y un formateador(cultura).
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha">Fecha como cadena de texto.</param>
        ''' <param name="formato">Formato de la fecha.</param>
        ''' <param name="cultura">Formateador cultural.</param>
        ''' <returns></returns>
        Function ConvertirStringADate(ByVal fecha As String, ByVal formato As String, Optional ByVal cultura As IFormatProvider = Nothing) As ResultadoValidacion(Of DateTime, EstadoFecha)

        ''' <summary>
        ''' Convierte una fecha (DateTime) a cadena de texto, según formato indicado y un formateador(cultura).
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha">Fecha a formatear.</param>
        ''' <param name="formato">Formato de salida.</param>
        ''' <param name="cultura">Formateador cultural.</param>
        ''' <returns></returns>
        Function ConvertirDateAString(ByVal fecha As DateTime, ByVal formato As String, Optional ByVal cultura As IFormatProvider = Nothing) As ResultadoValidacion(Of String, EstadoFecha)

        ''' <summary>
        ''' Verifica que la fecha es válida para el formato indicado.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha">Fecha a validar.</param>
        ''' <param name="formato">Formato válido.</param>
        ''' <returns></returns>
        Function ValidarFecha(ByVal fecha As String, ByVal formato As String) As ResultadoValidacion(Of Boolean, EstadoFecha)

        ''' <summary>
        ''' Obtiene la cantidad de días de diferencia donde:
        '''          fecha1 - fecha2.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha1">Fecha minuendo.</param>
        ''' <param name="fecha2">Fecha sustraendo.</param>
        ''' <returns></returns>
        Function DiferenciaEnDias(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer

        ''' <summary>
        ''' Obtiene la cantidad de meses de diferencia donde:
        '''          fecha1 - fecha2.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha1">Fecha minuendo.</param>
        ''' <param name="fecha2">Fecha sustraendo.</param>
        ''' <returns></returns>
        Function DiferenciaEnMeses(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer

        ''' <summary>
        ''' Obtiene la cantidad de años de diferencia donde:
        '''          fecha1 - fecha2.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha1">Fecha minuendo.</param>
        ''' <param name="fecha2">Fecha sustraendo.</param>
        ''' <returns></returns>
        Function DiferenciaEnAños(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer

        ''' <summary>
        ''' Obtiene el último día del mes para un mes y año determinado.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="mes">Mes de referencia.</param>
        ''' <param name="año">Año de referencia.</param>
        ''' <returns></returns>
        Function UltimoDiaDelMes(ByVal mes As Integer, ByVal año As Integer) As Integer

        ''' <summary>
        ''' Obtiene el último día del mes para una fecha determinada.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha">Fecha de referencia.</param>
        ''' <returns></returns>
        Function UltimoDiaDelMes(ByVal fecha As Date) As Integer

        ''' <summary>
        ''' Compara 2 fechas e indica con un valor numérico el resultado de la comparación:
        '''           * -1 La fecha mayor es la fecha2.
        '''           * 0 Ambas son iguales
        '''           * 1 La fecha mayor es la fecha1.
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha1">Fecha1</param>
        ''' <param name="fecha2">Fecha2</param>
        ''' <returns></returns>
        Function CompararFechas(ByVal fecha1 As Date, ByVal fecha2 As Date) As Integer

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SumarDias(ByVal fecha As Date, ByVal cantidad As Integer) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <param name="finDeMes"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SumarMeses(ByVal fecha As Date, ByVal cantidad As Integer, ByVal finDeMes As Boolean) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function SumarAños(ByVal fecha As Date, ByVal cantidad As Integer) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function RestarDias(ByVal fecha As Date, ByVal cantidad As Integer) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function RestarMeses(ByVal fecha As Date, ByVal cantidad As Integer) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <param name="cantidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function RestarAños(ByVal fecha As Date, ByVal cantidad As Integer) As Date

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="fecha"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function EsFinDeSemana(ByVal fecha As Date) As Boolean

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <remarks>
        '''     Registro de versiones:
        '''
        '''        1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        ''' </remarks>
        ''' <param name="formato"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Function ValidarFormato(ByVal formato As String) As Boolean

    End Interface
End Namespace