var EXERCISES = EXERCISES || [];

EXERCISES.push(
    {

        category: "Les classes",
        name: "Qu'est-ce qu'une classe en Javascript",

        content: function () {
            var ClassPhone = function (owner, operator) {   //Constructeur

                //Membres publiques
                this.owner = owner || "UNKNOWN";
                this.operator = operator || "NONE";

                //Membres privés
                var _imei = "156a4d884fr13";
                var _brand = "HTC";

                //Méthode publique
                this.callPerson = function (phoneNumber) {
                    var connexion = _getConnexionString(phoneNumber);
                    output(connexion);
                }

                //Méthode privée
                var _getConnexionString = function _getConnexionString(phoneNumber) {
                    return "http://" + this.owner + "@" + this.operator + ":" + phoneNumber;
                }
            }

            var myPhone = new ClassPhone("ElMariachi", "B&You");

            myPhone.callPerson("01 02 03 04 05");

        }
    });
