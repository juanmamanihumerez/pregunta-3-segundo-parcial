<?php
session_start();
$nombre=$_SESSION["usuario"];
$sql_c="update academico.alumno set nombre='".$nombre."' where id=1";
$resultado_c=mysqli_query($conn, $sql_c);
?>
