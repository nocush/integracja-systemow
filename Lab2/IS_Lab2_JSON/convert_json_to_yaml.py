# -*- coding: utf-8 -*-
"""
json to yaml converter
"""

import yaml
import json
import xml

class ConvertJsonToYaml:
    @staticmethod
    def run(deserializeddata, destinationfilelocation):
        print("let's convert something")
        if isinstance(deserializeddata, str):
            with open(deserializeddata, 'r', encoding='utf-8') as f:
                data = json.load(f)
        else:
            data = deserializeddata

        with open(destinationfilelocation, 'w', encoding='utf-8') as f:
            yaml.dump(deserializeddata, f, allow_unicode=True)
        print("it is done")
