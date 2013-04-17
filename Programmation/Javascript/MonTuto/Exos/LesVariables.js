var EXERCISES = EXERCISES || [];


this.category = "Les variables et leur portée";
EXERCISES.push(
    {
        category: this.category,
        name: "Affichons une variable initialisée à l'exterieur d'une fonction",
        content: function () {

            var msg = "Hello";

            function func1() {
                output(msg);
                //var msg = "Coucou";
            }

            func1();
        },

        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Une variable définie à l'exterieur d'une fonction (mais décommentons la ligne)",
        content: function () {

            var msg = "Hello";

            function func1() {
                output(msg);
                var msg = "Coucou";
            }

            func1();
        },

        answer: function () {
            outputAnswer("Quoi??? Mais pourquoi j'ai 'undefined' bordel???");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Imbriquons les fonctions",
        content: function () {

            var msg = "Hello";

            function func1() {

                func2();
                function func2() {
                    func3();
                    function func3() {
                        output(msg);
                        msg = "Coucou";
                    }
                }
            }

            func1();

            output(msg);
        },

        answer: function () {
            //outputAnswer("");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Imbriquons les fonctions (avec un petit changement)",
        content: function () {

            var msg = "Hello";

            function func1() {
                var msg = "Coucou";
                func2();
                function func2() {
                    func3();
                    function func3() {
                        output(msg);

                    }
                }
            }

            func1();

            output(msg);
        },

        answer: function () {
            //outputAnswer("");
        }
    }
);

