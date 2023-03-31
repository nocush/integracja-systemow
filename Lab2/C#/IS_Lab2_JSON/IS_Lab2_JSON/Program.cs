using YamlDotNet.Serialization;

var tempconffile = new StreamReader("Assets/basic_config.yaml");
var deserializer = new DeserializerBuilder().Build();
var confdata = deserializer.Deserialize<dynamic>(tempconffile);

var jsonDeserializer = new DeserializeJson(confdata["paths"]["source_folder"] + confdata["paths"]["json_source_file"]);
jsonDeserializer.somestats();

SerializeJson.run(confdata["paths"]["source_folder"] + confdata["paths"]["json_source_file"], confdata["paths"]["source_folder"] + confdata["paths"]["json_destination_file"]);