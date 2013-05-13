var EXERCISES = EXERCISES || [];

EXERCISES.push(
    {
        category: "Le mot clé 'this'",
        name: "Qu'est-ce que 'this' dans une fonction de dictionnaire (partie 1)",
        content: function () {

            //Soit la variable message dans le contexte de l&apos;objet window
            var message = 'Coucou';

            //Soit un message dans un dictionnaire
            var dict = {
                message: 'Hello'
            };

            //Soit une fonction affichant la propriété message du contexte courant
            var outputMessage = function () {
                output(this.message);
            };

            //Donnons au dictionnaire la possibilité d&apos;afficher le message
            dict.outputMessage = outputMessage;

            //Appel 1:
            dict.outputMessage();

            //Appel 2:
            outputMessage();

        },

        answer: function () {
            outputAnswer("Quoi??? Mais pourquoi j'ai 'undefined' sur le deuxième appel???");
        }
    },
    //========================================================================================//
    {
        category: "Le mot clé 'this'",
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

        }
    },
    //========================================================================================//
    {
        category: "Le mot clé 'this'",
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
        }
    },
    //========================================================================================//
    {
        category: "Le mot clé 'this'",
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
        }
    }
);
