<form method="post" action="personal.php">
<table width="986" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#e9e9e9">
		<td width="33.3%" valign="bottom">
			<div class="ui-shadow ui-alt-icon ui-nodisc-icon" style="margin-right: 5px; margin-bottom: 5px; margin-left: 5px;">
				<select id="report" name="report">
				<?php
					foreach ($reports as $rep) {
					echo '<option value="'.$rep.'" '.((isset($_POST['report']) && $_POST['report'] == $rep) ? 'selected="selected"': '').'>'.$rep.'</option>';						
					}
				?>
				</select>
			</div>
		</td>
		<td width="33.3%" valign="bottom">
			<div class="ui-shadow ui-alt-icon ui-nodisc-icon" style="margin-right: 5px; margin-bottom: 5px;">
				<select id="format" name="format">
				<?php
					foreach ($formats as $key => $for) {
					echo '<option value="'.$key.'" '.((isset($_POST['format']) && $_POST['format'] == $key) ? 'selected="selected"': '').'>'.$for.'</option>';
					}
				?>
				</select>
			</div>
		</td>
		<td width="33.3%" valign="bottom">
			<div id="button-submit" style="margin-right: 5px; margin-bottom: 5px;">
				<input type="submit" data-role="button" value="Print Report" name="submit" id="submit"/>
			</div>
		</td>
	
	</tr>
</table>
</form>