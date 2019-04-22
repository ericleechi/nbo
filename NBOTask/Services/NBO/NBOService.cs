using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NBOTask.Mocks;
using NBOTask.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NBOTask.Services.NBO
{
  
    public interface INBOService
    {
        Task<JArray> FetchProductSuggestion(SuggestionRequest request);
        Task<JArray> GiveProductFeedback(FeedbackRequest feedback);
    }

    public class NBOService : INBOService
    {
        public Task<JArray> FetchProductSuggestion(SuggestionRequest request)
        {
            return Task.FromResult(JArray.FromObject(
               ServiceMocks.GetProducts(request.Limit)
            ));
        }

        public Task<JArray> GiveProductFeedback(FeedbackRequest feedback)
        {
            return Task.FromResult(JArray.FromObject(
                ServiceMocks.GetProducts() 
             ));
        }
    }
}