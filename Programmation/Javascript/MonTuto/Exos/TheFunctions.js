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
    }
);