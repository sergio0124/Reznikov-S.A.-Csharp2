using LawFirmBusinessLogic.BindingModels;
using LawFirmBusinessLogic.BusinessLogic;
using LawFirmBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LawFirmRestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly OrderLogic _order;

        private readonly DocumentLogic _document;

        private readonly MailLogic _mail;

        public MainController(OrderLogic order, DocumentLogic document, MailLogic mail)
        {
            _order = order;
            _document = document;
            _mail = mail;
        }

        [HttpGet]
        public List<DocumentViewModel> GetDocumentList() => _document.Read(null)?.ToList();

        [HttpGet]
        public DocumentViewModel GetDocument(int documentId) => _document.Read(new DocumentBindingModel { Id = documentId })?[0];

        [HttpGet]
        public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel { ClientId = clientId });

        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _mail.Read(new MessageInfoBindingModel { ClientId = clientId });

        [HttpPost]
        public void CreateOrder(CreateOrderBindingModel model) => _order.CreateOrder(model);
    }
}