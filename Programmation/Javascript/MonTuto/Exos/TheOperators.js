var EXERCISES = EXERCISES || [];

this.category = "Les opérateurs",
    EXERCISES.push(
        {
            category: this.category,
            name: "L'opérateur d'égalité == ou === avec des types 'élémentaires'",
            content: function () {
                output("Cas 1:");
                output(1.5 == 1.5);
                output(1.5 === 1.5);

                output("Cas 2:");
                output(-2.798 == "-2.798");
                output(-2.798 === "-2.798");

            },
            answer: function () {
                //outputAnswer("");
            }
        },
        //========================================================================================//
        {
            category: this.category,
            name: "L'opérateur d'égalité == ou === avec des types 'objet' (partie 1)",
            content: function () {

                function AClass() {
                    this.toString = function () {
                        return "10.1234";
                    }
                }

                var c1 = new AClass();
                var c2 = new AClass();

                output("Cas 1:");
                output(10.1234 == c1);
                output("10.1234" === c1);

                output("Cas 2:");
                output(c1 == c2);
                output(c1 === c2);

                output("Cas 3:");
                output(c1 == c1);
                output(c1 === c1);

            },
            answer: function () {
                //outputAnswer("");
            }
        },
        //========================================================================================//
        {
            category: this.category,
            name: "L'opérateur d'égalité == ou === avec des types 'objet' (partie 2)",
            content: function () {
                var dict1 = {
                    toString: function () {
                        return "10.1234";
                    }
                }

                var dict2 = {
                    toString: function () {
                        return "10.1234";
                    }
                }

                output("Cas 1:");
                output(10.1234 == dict1);
                output("10.1234" === dict1);

                output("Cas 2:");
                output(dict1 == dict2);
                output(dict1 === dict2);
            },
            answer: function () {
                //outputAnswer("");
            }
        }
    );