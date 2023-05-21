<?php
// example of update actor table, all first_name ADAM will be updated to CHRIS
$servername = "localhost";
$username = "sakila2";
$password = "pass";
$database = "sakila";
$conn = new mysqli($servername, $username, $password,
$database);
if ($conn->connect_error) {
 die("Database connection failed: " . $conn->connect_error);
}
 echo "Databse connected successfully, username " .$username . "<br><br>";

 $sql = "CREATE TABLE test (id int, name varchar(20))";
$conn->query($sql);
$sql = "DROP TABLE test";
$conn->close();

?>