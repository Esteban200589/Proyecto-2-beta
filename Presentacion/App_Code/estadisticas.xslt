<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="xml" indent="yes"/>
  <xsl:template match="@* | node()">

    <table >

      <tr style ="background-color: #C0C0C0">
        <td style=" border: thin double #800000"> Tipo </td>
        <td style=" border: thin double #800000"> Año </td>
        <td style=" border: thin double #800000"> Cantidad </td>
      </tr>

      <xsl:for-each select="Root/Noticia">
        <tr>
          <td>
            <xsl:value-of select="Tipo" />
          </td>
          <td>
            <xsl:value-of select="Anio" />
          </td>
          <td>
            <xsl:value-of select="Cantidad" />
          </td>
          <td style="background-color: #CCFFFF">
            <xsl:value-of select="MontoMov" />
          </td>
          <td style="background-color: #FFFF99">
            <xsl:value-of select="TipoMov" />
          </td>
        </tr>
      </xsl:for-each>
    </table>

  </xsl:template>
</xsl:stylesheet>