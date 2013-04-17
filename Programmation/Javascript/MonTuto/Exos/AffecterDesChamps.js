var EXERCISES = EXERCISES || [];

EXERCISES.push(
    {
        category: "Les champs",
        name: "Affecter un champ sur une variable de type 'dictionnaire'",

        content: function () {
            var variableX = {};
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
//========================================================================================//
    {
        category: "Les champs",
        name: "Affecter un champ sur une variable non déclarée",

        content: function () {
            var variableX;
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
//========================================================================================//
    {
        category: "Les champs",
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
        category: "Les champs",
        name: "Affecter un champ sur une variable de type 'nombre'",

        content: function () {
            var variableX = 5;
            variableX.Champ1 = "Hello";
            output(variableX.Champ1);
        }
    },
//========================================================================================//
    {
        category: "Les champs",
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