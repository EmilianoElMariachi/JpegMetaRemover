var EXERCISES = EXERCISES || [];

this.category = "Les classes";

EXERCISES.push(
    {
        category: this.category,
        name: "Qu'est-ce qu'une classe en Javascript",
        content: function () {
            function Function1() {
                output("Hello!");
            }

            var result = Function1();
            output(result);

            var result2 = new Function1();
            output(result2);
        },
        answer: function () {
            outputAnswer("Une classe n'est autre qu'une fonction, tout dépend de la façon dont on l'utilise.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Le constructeur",
        content: function () {
            function ClassA(arg1, arg2) {//Un constructeur avec 2 arguments

                this.display = function () {
                    output(arg1 + arg2);
                }
            }

            var classA = new ClassA(3, 2);
            classA.display();
        },
        answer: function () {
            outputAnswer("Tiens, comment se fait-il que la fonction 'display' connaisse arg1 et arg2 ? Et bien voilà une belle closure.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Créer des méthodes et des membres publiques",

        content: function () {

            //Nous devrions d'abord jeter un oeil à la section sur le mot clé this!
            var ClassPhone = function () {

                this.lastCalledNumber = null;   //Un membre publique

                this.call = function (number) { //Un méthode publique
                    output("I'm calling " + number);
                    this.lastCalledNumber = number;
                }

            }

            var myPhone = new ClassPhone();
            output("Last called number:" + myPhone.lastCalledNumber);
            myPhone.call("01 02 03 04 05");
            output("Last called number:" + myPhone.lastCalledNumber);
        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Créer des méthodes et des membres privés",

        content: function () {
            var AClass = function () {

                var _coeff = 3; //Membre privé

                var _multiplyWithCoeff = function (number) {//Fonction privée
                    return number * _coeff;
                }

                this.multiplyWithCoeff = function (number) {//Fonction publique
                    return _multiplyWithCoeff(number);
                }
            }

            var aClass = new AClass();

            output("Can I access private method? Answer is " + (aClass._multiplyWithCoeff !== undefined));
            output("Can I access public method? Answer is " + (aClass.multiplyWithCoeff !== undefined));
            output("So, let's call it : " + aClass.multiplyWithCoeff(5));
        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Oublier le mot clé 'var' pour un membre privé, ça fait quoi?",

        content: function () {
            var ClassA = function () {

                var ClassB = function () {
                    _member = 3; //Membre qui devait être privé
                }

                this.classB = new ClassB();//Membre publique de la classe A
            }

            var classA = new ClassA();

            output(classA.classB._member);
            output(classA._member);
            output(this._member);
            output(_member);
        },
        answer: function () {
            outputAnswer("Vous vous êtes trompé sur le résultat ? Peut-être devriez-vous retourner voir le thème sur les variables!");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "A vous de jouer! (partie 1)",

        content: function () {

            var ClassPhone = function (phoneOwner) {   //Constructeur

                //Membres publiques
                this.caller = phoneOwner || "UNDEFINED OWNER";

                //Méthode publique
                this.call = function (called) {
                    output(_tellMeWhoIsCallingWho(called));
                }

                //Méthode privée
                var _tellMeWhoIsCallingWho = function (called) {

                    return this.caller + " is calling " + called;
                }
            }

            var myPhone = new ClassPhone("Boubou");

            myPhone.call("Hailan");

        },
        answer: function () {
            outputAnswer("QUOI !!! Pourquoi 'undefined' et non 'Boubou'??? Passons à la partie 2.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "A vous de jouer! (partie 2)",

        content: function () {

            var ClassPhone = function (phoneOwner) {   //Constructeur

                //Membres publiques
                this.caller = phoneOwner || "UNDEFINED OWNER";

                //Méthode publique
                this.call = function (called) {
                    output(_tellMeWhoIsCallingWho(called));
                }

                //Méthode privée
                var _tellMeWhoIsCallingWho = function (called) {
                    output(this); //VOILA QUI DEVRAIT NOUS AIDER A MIEUX COMPRENDRE
                    return this.caller + " is calling " + called;
                }
            }

            var myPhone = new ClassPhone("Boubou");

            myPhone.call("Hailan");

        },
        answer: function () {
            outputAnswer("Ah d'accord! 'this' est l'objet 'window', normal que this.caller soit 'undefined'...");
            outputAnswer("Mais pourquoi je me retrouve dans le contexte de l'objet window ??? Passons à la partie 3.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "A vous de jouer! (partie 3)",

        content: function () {

            var ClassPhone = function (phoneOwner) {   //Constructeur

                //Membres publiques
                this.caller = phoneOwner || "UNDEFINED OWNER";

                //Méthode publique
                this.call = function (called) {
                    output(_tellMeWhoIsCallingWho.call(this, called));
                }

                //Méthode privée
                var _tellMeWhoIsCallingWho = function (called) {
                    //output(this); //PLUS BESOIN DE CETTE LIGNE
                    return this.caller + " is calling " + called;
                }
            }

            var myPhone = new ClassPhone("Boubou");

            myPhone.call("Hailan");

        },
        answer: function () {
            outputAnswer("Cool, ça marche!!!");
            outputAnswer("");
            outputAnswer("JE VOUS CONSEIL DONC DE RETENIR CECI:");
            outputAnswer("Lorsqu'on appelle une fonction sans partir d'un objet comme par exemple");
            outputAnswer("\"function1( );\" par opposition l'expression \"object.function1( );\"");
            outputAnswer("alors le contexte sera toujours celui de l'objet 'window'");
            outputAnswer("");
            outputAnswer("Aussi, ne confondez pas contexte et scope!");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Une petite dernière pour la route?",
        content: function () {
            var ClassA = function () {   //Constructeur

                this.callTheGivenCallback = function (callback) {
                    callback();
                }
            }

            var classA = new ClassA();

            classA.callTheGivenCallback(function(){
               output(this);
            });
        },
        answer: function () {
        }
    }

);
