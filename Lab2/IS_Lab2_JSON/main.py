import yaml


tempconffile = open("Assets/basic_config.yaml",encoding="utf-8")
confdata = yaml.load(tempconffile, Loader = yaml.FullLoader)


print("hey, it's me - Python!")
from deserialize_json import DeserializeJson
newDeserializator = DeserializeJson(confdata['paths']['source_folder'] + confdata['paths']['json_source_file'])


from serialize_json import SerializeJson


def serialize():
    if confdata['serialization_source'] == 'file':
        ConvertJsonToYaml.run(confdata['paths']['source_folder'] + confdata['paths']['json_source_file'],
                              confdata['paths']['source_file'] + confdata['paths']['json_destination_file'])
    elif confdata['serialization_source'] == 'object':
        SerializeJson.run(newDeserializator, confdata['paths']['source_folder'] + confdata['paths'][
            'json_destination_file'])  # 'Assets/data_mod.json')



from convert_json_to_yaml import ConvertJsonToYaml


def json_to_yaml():
    if confdata['serialization_source'] == 'file':
        ConvertJsonToYaml.run(confdata['paths']['source_folder'] + confdata['paths']['json_source_file'],
                              confdata['paths']['source_file'] + confdata['paths']['yaml_destination_file'])
    elif confdata['serialization_source'] == 'object':
        ConvertJsonToYaml.run(newDeserializator, confdata['paths']['source_folder'] + confdata['paths']['yaml_destination_file'])#'Assets/data_ymod.yaml')


akcje = {
    'somestats': newDeserializator.somestats,
    'serialize': serialize,
    'convert_json_to_yaml': json_to_yaml
}

for akcja in confdata['actions']:
    akcje[akcja]()




