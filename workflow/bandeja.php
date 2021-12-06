<!DOCTYPE html>
<html lang="es">
<head>
	<meta charset="utf-8">
	<title>ELECCIONES CEI</title>

        <link rel="stylesheet" href="css/style.css">
		<link rel="stylesheet" href="css/styletabla.css">
</head>

<body>
<?php include 'cabecera.php'; ?>
<section id="main-content">
<?php
session_start();
include "conexion.inc.php";
$sql="select * from seguimiento where usuario='".$_SESSION["usuario"]."' ";
$sql.="and fechafin is null";
$resultado=mysqli_query($conn, $sql);
?>
<div class="content">
<table border="1" style="width: 100%">
<thead>
<tr>
	<th>Tramite</th>
	<th>Flujo</th>
	<th>Proceso</th>
	<th>Fecha Inicio</th>
	<th>Accion</th>
</tr>
</thead>
<?php
while($fila=mysqli_fetch_array($resultado))
{
	echo "<tbody><tr>";
	echo "<td>".$fila["notramite"]."</td>";
	echo "<td>".$fila["flujo"]."</td>";
	echo "<td>".$fila["proceso"]."</td>";
	echo "<td>".$fila["fechainicio"]."</td>";
	echo "<td><a ";
	echo "href='desflujo.php?flujo=$fila[flujo]&proceso=$fila[proceso]'";
	echo ">Ver<a/></td>";
	echo "</tr></tbody>";
}
?>
</table>
</div>
</section>
</body>