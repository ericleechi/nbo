using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NBOTask.Models;
using Newtonsoft.Json.Linq;

namespace NBOTask.Services.NBO
{

    public class ProductSuggestion
    {
        public ProductSuggestion(List<Product> products)
        {
            this.products = products;
        }
        public List<Product> products { set; get; }
    }
    public class SuggestionRequest : IRequest<SuggestionResponse>
    {

        public string CustomerId { set; get; }
        public string Q { set; get; } 
        public int Limit { set; get; } = 3;
    }

    
    public class SuggestionResponse : INBOResponse<IProduct[]>
    {
        protected readonly JArray _rawResponse;

        public SuggestionResponse(JArray array)
        {
            this._rawResponse = array;
        }

        public IProduct[] GetResponse()
        {
            return this._rawResponse.ToObject<Product[]>();
        }

    }
    public class SuggestionHandler : IRequestHandler<SuggestionRequest, SuggestionResponse>
    {
        private readonly INBOService _service;

        public SuggestionHandler(INBOService service)
        {
            this._service = service;
        }

        public async Task<SuggestionResponse> Handle(SuggestionRequest request, CancellationToken cancellationToken)
        {
            var result = await this._service.FetchProductSuggestion(request);

            return new SuggestionResponse(result);

        }
    }
}
