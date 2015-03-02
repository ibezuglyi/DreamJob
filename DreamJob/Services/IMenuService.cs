namespace DreamJob.Services
{
    using System;
    using System.Linq;

    using DreamJob.Infrastructure;
    using DreamJob.Models;
    using DreamJob.ViewModels;

    public interface IMenuService
    {
        MenuNewMessagesViewModel GetNewMessages();
    }

    class MenuService : IMenuService
    {
        private readonly IAccountService authentication;

        private readonly ApplicationDatabase applicationDatabase;

        public MenuService(IAccountService authentication, ApplicationDatabase applicationDatabase)
        {
            this.authentication = authentication;
            this.applicationDatabase = applicationDatabase;
        }

        public MenuNewMessagesViewModel GetNewMessages()
        {
            var currentLoggedUserId = this.authentication.GetCurrentLoggedUserId();
            var now = DateTime.Now;
            var newMessageToReads = this.applicationDatabase
                .NewMessagesToRead
                .Where(message => message.CreateDateTime < now)
                .Where(message => message.UserAccountId == currentLoggedUserId)
                .ToList();
            var messageTypes = newMessageToReads.GroupBy(message => message.MessageType);

            var dictionary = messageTypes.ToDictionary(m => m.Key, m => m.Count());
            var viewmodel = new MenuNewMessagesViewModel(dictionary);
            return viewmodel;
        }
    }
}