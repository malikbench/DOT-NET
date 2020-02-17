using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using M2Link.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace M2Link.WebServices
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "WSLogin" à la fois dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez WSLogin.svc ou WSLogin.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class WSLogin : IWSLogin
    {
        public UserModel Validate(string pseudo, string password)
        {
            using (M2LinkContext context = new M2LinkContext())
            {
                UserRepository repo = new UserRepository(context);
                if (!repo.checkUser(pseudo, password))
                {
                    return null;
                }
                else
                {
                    User user = repo.getUser(pseudo);
                    UserModel userModel = new UserModel()
                    {
                        Pseudo = user.Pseudo,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    return userModel;
                }
            }
        }
    }
}
