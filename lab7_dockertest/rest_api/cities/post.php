<?php
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
include_once '../config/Database.php';
include_once '../class/Cities.php';

$database = new Database();
$db = $database->getConnection();
$cities = new Cities($db);

$data = json_decode(file_get_contents("php://input"));


if ($_SERVER['REQUEST_METHOD'] != 'POST') {
    http_response_code(405);
    echo json_encode(array("message" => "Method not allowed."));
    exit();
}


if (
    !empty($data->name) &&
    !empty($data->countryCode) &&
    !empty($data->district) &&
    !empty($data->population)
) {
    $cities->name = $data->name;
    $cities->countryCode = $data->countryCode;
    $cities->district = $data->district;
    $cities->population = $data->population;

    if ($cities->post()) {
        http_response_code(201);
        echo json_encode(array("message" => "City was created."));
    } else {
        http_response_code(503);
        echo json_encode(array("message" => "Unable to create city."));
    }
} else {
    http_response_code(400);
    echo json_encode(array("message" => "Unable to create city. Data is incomplete."));
}
?>
