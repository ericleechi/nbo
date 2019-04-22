using MediatR;
using System.Threading;
using System.Threading.Tasks;
using NBOTask.Models;
using Newtonsoft.Json.Linq;

namespace NBOTask.Services.NBO
{
    /*
     * Not sure what feedback information is needed from customer when making a presentation
     */
    public class FeedbackRequest :  IRequest<FeedbackResponse>
    {
        public string FeedBack { set; get; }
        public string CustomerId { set; get; }
        public int? Rating { set; get; }
        public string ProductId { set; get; }
        public bool Accepted { set; get; }
    }
    
    public class FeedbackResponse : SuggestionResponse
    {
        public FeedbackResponse(JArray array) : base(array)
        {
        }
    }

   
    public class FeedbackHandler : IRequestHandler<FeedbackRequest, FeedbackResponse>
    {
        private readonly INBOService _service;

        public FeedbackHandler(INBOService service)
        {
            this._service = service;
        }

        public async Task<FeedbackResponse> Handle(FeedbackRequest request, CancellationToken cancellationToken)
        {
            var result = await _service.GiveProductFeedback(request);
            return new FeedbackResponse(result);
        
        }
    }
    
    
}
