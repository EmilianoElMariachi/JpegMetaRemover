var EXERCISES = EXERCISES || [];

this.category = "Introduction";
EXERCISES.push(
    {
        category: this.category,
        name: "De quoi s'agit-il?",

        content: function () {
            //  Ce tutoriel a pour but de vous présenter quelques notions élémentaires
            //sur le langage Javascript.
            //
            //  Ce tutoriel est composé d un ensemble d'exercices ludiques au cours desquels
            //vous devrez trouver la sortie produite par le code.
            //
            //  Pour cela, analysez le code, et repérer la/les lignes comportant l'appel à la
            //fonction [output(x)]
            //
            //  Vous êtes prêts???
            //  alors allons-y... Commençons par un exemple simple...
            //
            //  Quelle sera la sortie pour le code suivant:
            output(new Date(1980, 03, 09).toLocaleDateString());
        },

        answer: function () {
            outputAnswer("Non non, ce n'est pas une erreur... le mois est en base zéro, il s'agit bien du mois d'Avril et non du mois de Mars...");
            outputAnswer("Pour plus d'information, consultez la documentation sur l'objet Date <a href='http://www.w3schools.com/jsref/jsref_obj_date.asp' target='_blank'>ici</a>");
            outputAnswer("");
            outputAnswer("Ah, et puis vous pouvez toujours retenir cette date, c'est mon anniv ;-)");

        }
    },
    //========================================================================================//
    {
        category: this.category,
        name: "La console",

        content: function () {

            console.log("Voilà un jour comme un autre.");
            console.info("Jusque là, tout va bien!");
            console.warn("Humm, ça commence à sentir mauvais...");
            console.error("Et voilà! Tout à planté !!!");

            console.log(["Un", "Deux", "Trois"]);
        },

        answer: function () {
            outputAnswer("Bizarre: c'est quoi cette Console??? Appuie sur F12 pour le savoir...");
        }
    }
);
