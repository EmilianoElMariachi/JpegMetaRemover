var EXERCISES = EXERCISES || [];

this.category = "Les fonctions";
EXERCISES.push(
    {
        category: this.category,
        name: "Comment déclarer et appeler des fonctions ?",
        content: function () {

            function function1() {          //Déclaration n°1
                output(arguments.callee.toString().match(/function\s+([^\s\(]+)/)[1] + " was called");
            }

            var function2 = function () {   //Déclaration n°2
                output("function2 was called");
            }

            function1();//Appel
            function2();//Appel
        },
        answer: function () {
            outputAnswer("Pour l'instant je ne vous apprends pas grand chose, si ce n'est qu'il est possible de connaitre le nom de la fonction courante...");
            outputAnswer("ATTENTION, ce hack ne marche pas pour la 2ème déclaration...");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Les pseudos \"pointeurs\" de fonctions",
        content: function () {
            function function1(callback) {
                callback();
            }

            var myCallback = function () {
                output("Callback was called!");
            };

            function1(myCallback);
        },
        answer: function () {
//            outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Les fonctions à nombre d'arguments variable (optionnels)",
        content: function () {
            function function1(arg1, arg2, arg3) {

                for(var i = 0; i < arguments.length ; i++){
                    output(arguments[i]);
                }

                output(arg1);
                output(arg2);
                output(arg3);

                output(arguments[arguments.length + 124]);
            }

            function1("un", "deux");
        },
        answer: function () {
            outputAnswer("La variable 'arguments' est une variable clé.");
            outputAnswer("Cette variable est un tableau contenant les arguments dans l'ordre d'appel.");
            outputAnswer("");
            outputAnswer("On notera qu'accéder à un élément non existant du tableau ne jette pas d'exception...");
        }
    }
);