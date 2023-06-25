<?php
header ( "Access-Control-Allow-Origin: *" );
header ( "Content-Type: application/json; charset=UTF-8" );
include_once '../config/Database.php';
include_once '../class/Cities.php';

$database = new Database ();
$db = $database->getConnection ();
$cities = new Cities ( $db );

if ($_SERVER [ 'REQUEST_METHOD' ] != 'PUT') {
    http_response_code ( 405 );
    echo json_encode ( array (
            "message" => "Method not allowed." 
    ) );
    exit ();
}


$data = json_decode ( file_get_contents ( "php://input" ) );
$cities -> id = $data -> id;
$cities -> name = $data -> name;
$cities -> countryCode = $data -> countryCode;
$cities -> district = $data -> district;
$cities -> population = $data -> population;
if ($cities -> update ()) {
    http_response_code ( 200 );
    echo json_encode ( array (
            "message" => "Miasto zostalo zaktualizowane." 
    ) );
} else {
    http_response_code ( 503 );
    echo json_encode ( array (
            "message" => "Nie udalo sie zaktualizowac miasta" 
    ) );
}
?>