using M2Link.Models;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace M2Link.WebServices
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IWSLogin" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IWSMessage
    {
        [OperationContract]
        List<MessageModel> Get_followed_users_messages(string nickname);

    }
}
