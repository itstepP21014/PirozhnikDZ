<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">


<xsl:param name="category" />
<xsl:template match="/">
  <html>
  <body>
  <p><xsl:value-of select="$category" /></p>
  <table border="1" style="margin:auto">
    <tr bgcolor="#9acd32">
      <th style="text-align:center">Название</th>
      <th style="text-align:center">Состав</th>
	    <th style="text-align:center">Грамм в порции</th>
	    <th style="text-align:center">Стоимость</th>
      <th style="text-align:center">Каллорий на порцию</th>
    </tr>
    <xsl:for-each select="catalog/dish[category = $category]">
    <tr>
      <td><xsl:value-of select="name" /></td>
      <td><xsl:value-of select="composition" /></td>
	    <td><xsl:value-of select="portion" /></td>
      <td><xsl:value-of select="price" /></td>
	    <td><xsl:value-of select="kkal" /></td>
    </tr>
    </xsl:for-each>
  </table>
  
  <div id="divForPicture">
   <img src="" alt=""></img>
  </div>  

  </body>
  </html>
</xsl:template>

</xsl:stylesheet> 