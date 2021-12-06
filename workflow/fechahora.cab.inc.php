<?php
session_start();
$nombre1=$_SESSION["usuario"];
$sql_c="select * from academico.alumno where nombre='$nombre'";
$resultado_c=mysqli_query($conn, $sql_c);
$fila_c=mysqli_fetch_array($resultado_c);
$nombre=$fila_c["nombre"];
?>
