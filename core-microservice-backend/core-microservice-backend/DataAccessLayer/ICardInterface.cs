using core_microservice_backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace core_microservice_backend.DataAccessLayer
{
    public interface ICardInterface
    {
        Card GetCardByName(string CardName);
        void CreateCard(Card card);
        bool UpdateCard(string CardName, Card card);
        bool RemoveCard(string CardName);
        void AddLabel(int CardId, Label label);
        void UpdateLabel(int CardId, Label label);
        Label GetLabelByNoteIdAndLabelId(int CardId, int labelId);
        void DeleteLabelByNoteIdAndLabelID(int CardID, int LabelId);
        ICollection<Label> GetLabels(int CardId);
        ICollection<Attachment> GetAttachments(int CardID);
        ICollection<Member> GetMembers(int CardID);
        ICollection<Comment> GetComments(int CardID);

    }
}
