using System.Collections.Generic;
using CoderCampsMentor.Models;
using CoderCampsMentor.ViewModels;

namespace CoderCampsMentor.Interfaces
{
    public interface ICommService
    {
        void DeleteComm(int id);
        IEnumerable<CommViewModel> GetAdminFirstFive();
        IList<CommViewModel> GetAllComms();
        Comm GetCommById(int id);
        IList<CommViewModel> GetCommsByUserName(string uid);
        int GetCountCurrentUserNewMessages(string uid);
        void SaveComm(Comm comm, string uid);
    }
}