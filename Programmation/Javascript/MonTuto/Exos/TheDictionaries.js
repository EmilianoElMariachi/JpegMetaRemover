var EXERCISES = EXERCISES || [];

this.category = "Les dictionnaires";
EXERCISES.push(
    {
        category: this.category,
        name: "Qu'est-ce qu'un dictionnaire en Javascript",

        content: function () {
            var myDict = {
                field1: 1,

                "I'am field 2": "hello",

                field3: {
                    subField1: "coucou",

                    subField2: new String("bye!")
                }
            };

            output(myDict.field1);
            output(myDict["I'am field 2"]);
            output(myDict.field3.subField1);
            output(myDict.field3.subField2);

        },
        answer: function () {
            outputAnswer("Un dictionnaire est un objet où chaque champs peut être de n'importe quel type.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Comment itérer dynamiquement sur les champs et récupérer leur valeur?",

        content: function () {
            var myDict = {
                "field 1": "Is my dictionary alive?",

                field2: "the answer is",

                field3: "yes!"
            };

            for (var fieldTmp in myDict) {
                output(fieldTmp + "=" + myDict[fieldTmp]);
            }

        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Comment tester si un champs existe",

        content: function () {
            var myDict = {
                field1: "coucou",
                "field 2": undefined
            };


            output("Solution 1");
            output("field1" in myDict);
            output("field 2" in myDict);
            output("field3" in myDict);

            output("Solution 2");
            output(myDict.hasOwnProperty("field1"));
            output(myDict.hasOwnProperty("field 2"));
            output(myDict.hasOwnProperty("field3"));
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Comment ajouter dynamiquement des champs?",

        content: function () {
            var myDict = {};
            myDict.Champ1 = "Hello";
            myDict["What a long long field name"] = "!";

            output(myDict.Champ1);
            output(myDict["What a long long field name"]);
        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Comment supprimer dynamiquement des champs?",

        content: function () {
            var myDict = {};
            myDict.Field1 = "Hello";
            myDict.Field2 = undefined;

            output("Field1" in myDict);
            output("Field2" in myDict);

            delete myDict.Field1;
            delete myDict.Field2;

            output("Field1" in myDict);
            output("Field2" in myDict);
        },
        answer: function () {
            //outputAnswer("");
        }
    }
);
