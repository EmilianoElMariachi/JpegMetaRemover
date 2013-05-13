var EXERCISES = EXERCISES || [];

this.category = "Les champs";
EXERCISES.push(
    //========================================================================================//
    {
        category: this.category,
        name: "Tester si un champs existe",

        content: function () {
            var myDict = {
                field1:"coucou",
                field2:undefined
            };

            output("field1" in myDict);
            output("field2" in myDict);
            output("field3" in myDict);
        }
    },
    //========================================================================================//
    {
        category: this.category,//TODO : redondant avec un exo de "TheDictionaries"
        name: "Effacer un champs",

        content: function () {
            var myDict = {
                field1:"coucou",
                field2:undefined
            };

            output("field1 exists ? " + ("field1" in myDict));
            delete myDict.field1;
            output("field1 exists ? " + ("field1" in myDict));

        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Affecter un champ sur une variable non déclarée",

        content: function () {
            var variableX;
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Affecter un champ sur une variable de type 'fonction'",

        content: function () {
            var variableX = function () {
            };

            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Affecter un champ sur une variable de type 'nombre'",

        content: function () {
            var variableX = 5;
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Affecter un champ sur une variable de type 'class'",

        content: function () {
            var ClassA = function () {
            }

            var variableX = new ClassA();
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    }
);