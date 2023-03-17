# -*- coding: utf-8 -*-

"""
  deserialize json
"""

import json



class DeserializeJson:
    def __init__(self, filename):
        print("let's deserialize something")
        tempdata = open(filename, encoding="utf8")
        self.data = json.load(tempdata)

    # przykładowe statystyki
    def somestats(self):
        example_stat = 0
        for dep in self.data:
            if dep['typ_JST'] == 'GM' and dep['Województwo'] == 'dolnośląskie':
                example_stat += 1
        print('liczba urzędów miejskich w województwie dolnośląskim: ' + ' ' + str(example_stat))




        typy = set()
        for dep in self.data:
            typy.add(dep['typ_JST'])
        print(typy)
        wojewodztwa_nazwy = set()

        for dep in self.data:
            wojewodztwa_nazwy.add(dep['Województwo'].strip())
        print(wojewodztwa_nazwy)

        for wojewodztwo in wojewodztwa_nazwy:
            print('\n'+wojewodztwo)
            for typ in typy:
                count = 0
                for dep in self.data:
                    if dep['typ_JST'] == typ and dep['Województwo'] == wojewodztwo:
                        count += 1
                print(typ+': '+ str(count))


