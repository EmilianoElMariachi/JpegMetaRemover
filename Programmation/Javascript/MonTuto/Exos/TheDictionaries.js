var EXERCISES = EXERCISES || [];

this.category = "Les dictionnaires";
EXERCISES.push(
    {
        category: this.category,
        name: "Qu'est-ce qu'un dictionnaire en Javascript",

        content: function () {
            var myDict = {
                field1: 1,

                "I'am field 2" : "hello",

                field3: {
                    subField1:"coucou",

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
    } ,
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
    }   ,
    //========================================================================================//
    {
        category: this.category,
        name: "Comment supprimer dynamiquement des champs?",

        content: function () {
            var myDict = {};
            myDict.Champ1 = "Hello";
            myDict["What a long long field name"] = "!";

            delete myDict.Champ1;

            output(myDict.Champ1);
            output(myDict["What a long long field name"]);
        },
        answer: function () {
            //outputAnswer("");
        }
    }
);
