var EXERCISES = EXERCISES || [];

this.category = "Les variables et leur portée";
EXERCISES.push(
    {
        category: this.category,
        name: "Comment déclarer une variable?",
        content: function () {
            var aVariable = "Hello world!";

            output(aVariable);
        },
        answer: function () {
            outputAnswer("Bon, on le savait déjà, on préfixe les variables avec le mot clé 'var'");
        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "var ou pas var, ça change quoi?",
        content: function () {
            var var1 = "Hello world 1";
            var2 = "Hello world 2";

            output(var1);
            output(var2);

            output(this.var1);
            output(this.var2);
        },
        answer: function () {
            outputAnswer("Oups! Mais c'est grave ça!");
            outputAnswer("");
            outputAnswer("Si on oublie le mot clé 'var', la variable se retrouve immédiatement dans le contexte de l'objet 'window' ET NON DE L'OBJET COURANT.");
            outputAnswer("");
            outputAnswer("Aussi, il est important de noter que 'var1' se trouve dans le scope de l'objet window.");
        }
    },
    //========================================================================================//
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
            outputAnswer("Quoi??? Mais pourquoi j'ai 'undefined' bordel??? Difficile à dire...");
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
    },
    //========================================================================================//
    {
        category: this.category,
        name: "Comment effacer une variable",
        content: function () {

            var a = "I'm var a!";
            var b = "I'm var b!";

            a = undefined;
            delete b;

            output(a);

            output(b);
        },

        answer: function () {
            outputAnswer("Undefined est donc bien une valeur!");
        }
    }
);

