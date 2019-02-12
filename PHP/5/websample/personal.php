<?php
  include('data.php');
?>

<!--
<HTML>
<HEAD><title>List & Label WebReporting Sample</title><LINK href="format.css" type="text/css" rel="stylesheet"></HEAD>
<body>


<!-- *******   Beginn linke Navigationsleiste ******* -->
<link rel="stylesheet" href="format/format.css">

<?php
	include('top.php');
?>


<!-- *******   Start Rahmen Inhaltsbereich ******* -->
		</td>
		<td valign="top">
			<table border="0" cellpadding="0" cellspacing="0" align="center" bgcolor="#FFFFFF" width="986">
				<tr>
					<td><img src="grafix/shop_inhalt_ecke_oben_links.gif" width="6" height="6" /></td>
					<td><img src="grafix/spacer.gif" width="960" height="1" /></td>
					<td><img src="grafix/inhalt_ecke_oben_rechts.gif" width="6" height="6" /></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
						    <tr>
								<td>
									  <?php
									  if (!isset($_POST['submit'])) {
										echo 'Please choose an action.';
									  } elseif (!isset($_POST['report']) || empty($_POST['report'])) {
										echo 'You have to choose a report file.';
									  } elseif (!isset($_POST['format']) || empty($_POST['format'])) {
										echo 'You have to choose an export format.';
									  } elseif (!in_array($_POST['report'], $reports)) {
										echo 'Invalid report file.';
									  } elseif (!isset($formats[$_POST['format']])) {
										echo 'Invalid export format.';
									  } else {
										echo '<br /><iframe width="974px" height="650px" style="border:0;" src="frame.php?format='.$_POST['format'].'&report='.$_POST['report'].'"></iframe>';
									  }
									 ?>
								</td>
								</tr>
								<tr>
								<td>
									<?php
									if (!isset($_POST['submit'])) {
										echo '<img src="grafix/spacer.gif" width="5" height="500" alt="">';
									}
									else
									{
										//echo '<img src="grafix/spacer.gif" width="5" height="5" alt="">';
									}
									?>
								</td>
						    </tr>
						</table>
					</td>
					
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td><img src="grafix/inhalt_ecke_unten_links.gif" width="6" height="6" /></td>
					<td><img src="grafix/spacer.gif" width="1" height="1" /></td>
					<td><img src="grafix/inhalt_ecke_unten_rechts.gif" width="6" height="6" /></td>
				</tr>
			</table>

		</td>
		
	</tr>
	<tr>
		<td colspan="3"><img src="grafix/spacer.gif" width="1" height="1" /></td>
	</tr>
</table>
<!-- *******   Start Fussbereich ******* -->
<!--
<table width="986" height="6" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#a1cbf3">
	<tr>
		<td valign="bottom"><img src="grafix/shop_ecke_unten_links.gif" width="2" height="3" /></td>
		<td>&nbsp;</td>
		<td align="right" valign="bottom"><img src="grafix/shop_ecke_unten_rechts.gif" width="2" height="3" /></td>
	</tr>
</table>
-->
<!-- </body>
</HTML> -->
