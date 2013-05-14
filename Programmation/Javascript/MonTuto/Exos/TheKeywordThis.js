var EXERCISES = EXERCISES || [];

this.category = "Le mot clé 'this'";

EXERCISES.push(
    {
        category: this.category,
        name: "Qui est 'this' par défaut?",
        content: function () {

            output(this);

            function f1() {
                output(this);
            }

            f1();
        },
        answer: function () {
            outputAnswer("Par défaut le mot clé 'this' représente l'objet 'window'");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Qu'est-ce que 'this' dans une fonction de dictionnaire (partie 1)",
        content: function () {

            var message = 'Coucou';

            var dict = {
                message: 'Hello'
            };

            var outputMessage = function () {
                output(this.message);
            };

            dict.outputMessage = outputMessage;

            //Appel 1:
            dict.outputMessage();

            //Appel 2:
            outputMessage();

        },
        answer: function () {
            outputAnswer("Normalement, vous devriez être en mesure de dire pourquoi le 2ème appel affiche 'undefined'");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Qu'est-ce que 'this' dans une fonction de dictionnaire (partie 2)",
        content: function () {

            window.name = "1";

            var name = "2";

            this.name = "3";

            var dict = {

                fieldFunction: function () {

                    var name = "4";

                    return this;
                },

                name: "5"
            }

            output(dict.fieldFunction().name);

            var f = dict.fieldFunction;

            output(f().name);
        },
        answer: function () {
            //outputAnswer("");
        }

    },
    //========================================================================================//
    {
        category: this.category,
        name: "Imbriquons les fonctions",
        content: function () {

            this.Msg = "0";
            func1();
            output(this.Msg);

            function func1() {
                this.Msg = "1";
                func2();
                output(this.Msg);

                function func2() {
                    this.Msg = "2";
                    func3();
                    output(this.Msg);

                    function func3() {
                        this.Msg = "3";
                        func4();
                        output(this.Msg);

                        function func4() {
                            this.Msg = "4";

                        }//func4
                    }//func3
                }//func2
            }//func1

            output(window.Msg);
        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Imbriquons les instances",
        content: function () {

            this.Msg = "0";
            new func1();
            output(this.Msg);

            function func1() {
                this.Msg = "1";
                new func2();
                output(this.Msg);

                function func2() {
                    this.Msg = "2";
                    new func3();
                    output(this.Msg);

                    function func3() {
                        this.Msg = "3";
                        new func4();
                        output(this.Msg);

                        function func4() {
                            this.Msg = "4";

                        }//func4
                    }//func3
                }//func2
            }//func1

            output(window.Msg);
        },
        answer: function () {
            outputAnswer("Par défaut, il existe un contexte par instance créée.");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Changeons le contexte d'appel (méthode call)",
        content: function () {

            this.type = "Window";

            function ClassA() {

                this.type = "ClassA";

                this.displayType = function (begin, end) {
                    output(begin + this.type + end);
                }
            }

            var classA = new ClassA();
            classA.displayType("I am a ", " object");
            classA.displayType.call(this, "I am a ", " object");
            classA.displayType.call({type: "CustomContext"}, "I am a ", " object");
        },
        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Changeons le contexte d'appel (méthode apply)",
        content: function () {

            this.type = "Window";

            function ClassA() {

                this.type = "ClassA";

                this.displayType = function (begin, end) {
                    output(begin + this.type + end);
                }
            }

            var classA = new ClassA();
            classA.displayType("I am a ", " object");
            classA.displayType.apply(this, ["I am a ", " object"]);
            classA.displayType.apply({type: "CustomContext"}, ["I am a ", " object"]);
        },
        answer: function () {
            //outputAnswer("");
        }
    }
);
