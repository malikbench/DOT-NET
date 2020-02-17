using M2Link.Context;
using M2Link.Entities;
using M2Link.Models;
using M2Link.Repositories;
using M2Link.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace M2Link.WebServices
{
    /// <summary>
    /// Description résumée de WSMessage
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WSMessage : System.Web.Services.WebService
    {
        [WebMethod]
        public List<MessageModel> get_followed_users_messages(string nickname)
        {
            List<MessageModel> messages = new List<MessageModel>();

            using (M2LinkContext context = new M2LinkContext())
            {
                MessageRepository msgRepo = new MessageRepository(context);

                UserRepository userRepo = new UserRepository(context);
                List<string> list_follow = userRepo.getFollowedUsersPseudo(nickname);

                foreach (Message msg in msgRepo.getMessages(list_follow))
                {
                    MessageModel msgModel = new MessageModel()
                    {
                        guid = msg.guid,
                        auteur = msg.auteur.Pseudo,
                        date = msg.date,
                        message = msg.message
                    };
                    messages.Add(msgModel);
                }
            }
            return messages;
        }
    }
}
