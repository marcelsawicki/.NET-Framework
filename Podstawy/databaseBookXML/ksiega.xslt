<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="/">


      <head>
        <title>Księga gości:</title>
      </head>
      <html>
      <body>
        <table border = "0" cellpadding="2" cellspaceing="2">
          <tr>
            <td bgcolor="#cccccc">
              <b>Imie:</b></td>
            <td bgcolor="#cccccc">
              <b>Gracz:</b>
            </td>
            <td bgcolor="#cccccc">
              <b>Data:</b>
            </td>
              <td bgcolor="#cccccc">
              <b>Comment:</b>
            </td>
          </tr>
          

          
          <xsl:for-each select="guestbook/guest">
        <tr>
          <td>
            <em>
              <xsl:value-of select="name"/>
            </em>
          </td>
          
        <td>
            <em>
              <xsl:value-of select="e-mail"/>
            
            </em>
          </td>
          
                    <td>
            <em>
              <xsl:value-of select="data"/>
            
            </em>
          </td>
        <td>
            <em>
              <xsl:value-of select="comment"/>
            
            </em>
          </td>        
        </tr>
            <xsl:for-each select="obrazek">
              <tr>
                <td colspan='2'>
                  <img>
                    <xsl:attribute name="src">
                      <xsl:value-of select="@path"/>
                    </xsl:attribute>
                  </img>
                </td>
              </tr>
            </xsl:for-each>
        </xsl:for-each>
         <tr>
        </tr>
        </table>
      
      </body>
      </html>
</xsl:template>
</xsl:stylesheet>



