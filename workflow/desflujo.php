<html>
	<head>
		<title>Tabla BD</title>
	</head>
<body>
	<?php
	include "conexion.inc.php";
	$flujo=$_GET["flujo"];
	$proceso=$_GET["proceso"];
	$sql="select * from flujoproceso where flujo='".$flujo."' and proceso='".$proceso."'";
	$resultado=mysqli_query($conn, $sql);
	$fila=mysqli_fetch_array($resultado);
	include $fila['formulario'].'.cab.inc.php';
	
	?>
	<form action="motflujo.php" method="GET">
		
		<?php include $fila['formulario'].'.inc.php';?>
		<br>
		<input type="hidden" value="<?php echo $fila['formulario'];?>" name="formulario"/>
		<input type="hidden" value="<?php echo $flujo?>" name="flujo"/>
		<input type="hidden" value="<?php echo $proceso?>" name="proceso"/>
		<input type="submit" value="Anterior" name="Anterior"/>
		<input type="submit" value="Siguiente" name="Siguiente"/>
	</form>
</body>
</html>